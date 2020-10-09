
// CasinoDlg.cpp : implementation file
//

#include "pch.h"
#include "framework.h"
#include "Casino.h"
#include "CasinoDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CCasinoDlg dialog



CCasinoDlg::CCasinoDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_CASINO_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDC_ICON);
}

void CCasinoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CCasinoDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDCANCEL, &CCasinoDlg::OnBnClickedCancel)
	ON_BN_CLICKED(IDC_BUTTON_SPIN, &CCasinoDlg::OnBnClickedButtonSpin)
	ON_BN_CLICKED(IDC_BUTTON_3, &CCasinoDlg::OnBnClickedButton3)
END_MESSAGE_MAP()


// CCasinoDlg message handlers

BOOL CCasinoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();
	m_casino = new CCasinoObject();
	srand(time(0));
	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	m_picture = (CStatic*)GetDlgItem(IDC_ROULLET);
	CFileFind finder;       // for file loading
	BOOL bLastFile=FALSE;
	BOOL bWorking = finder.FindFile(L".\\res\\spin\\*.bmp");
	if (bWorking)
	{
		while (!bLastFile)
		{
			DWORD dwFind = finder.FindNextFile();
			spinHB.Add((HBITMAP)::LoadImage(AfxGetInstanceHandle(), finder.GetFilePath(), IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE));
			m_picture->ModifyStyle(0xF, SS_BITMAP, SWP_NOSIZE);
			bLastFile = dwFind ? FALSE : TRUE;
		}
	}
	m_picture->SetBitmap(spinHB[0]);
	spinner = 0;
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CCasinoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);

	
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CCasinoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CCasinoDlg::OnBnClickedCancel()
{
	// TODO: Add your control notification handler code here
	CDialogEx::OnCancel();
}


void CCasinoDlg::OnBnClickedButtonSpin()
{
	INT RandTime = rand() % 100;
	while (--RandTime > 0)
	{
		m_picture->ModifyStyle(0xF, SS_BITMAP, SWP_NOSIZE);
		Sleep(90);
		m_picture->SetBitmap(spinHB[spinner++]);
		if (spinner == spinHB.GetSize())
			spinner = 0;
	}
}


void CCasinoDlg::OnBnClickedButton3()
{
	m_casino.bets.Add(CString("3"));
}
