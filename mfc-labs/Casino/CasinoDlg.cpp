
// CasinoDlg.cpp : implementation file
//

#include "pch.h"
#include "framework.h"
#include "Casino.h"
#include "CasinoDlg.h"
#include "afxdialogex.h"
#include <WinUser.h>
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
	m_casino = new CCasinoObject(1000);
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
	
	UpdateUserData();

	auto green = RGB(0, 100, 0);
	auto red = RGB(255, 0, 0);
	auto silver = RGB(192, 192, 192);
	auto white = RGB(255, 255, 255);
	auto black = RGB(0, 0, 0);

	reColorButton(IDC_BUTTON_0, green);
	reColorButton(IDC_BUTTON_1, red);
	reColorButton(IDC_BUTTON_2, black);
	reColorButton(IDC_BUTTON_3, red);
	reColorButton(IDC_BUTTON_4, black);
	reColorButton(IDC_BUTTON_5, red);
	reColorButton(IDC_BUTTON_6, black);
	reColorButton(IDC_BUTTON_7, red);
	reColorButton(IDC_BUTTON_8, black);
	reColorButton(IDC_BUTTON_9, red);
	reColorButton(IDC_BUTTON_10, black);
	reColorButton(IDC_BUTTON_11, black);
	reColorButton(IDC_BUTTON_12, red);
	reColorButton(IDC_BUTTON_13, black);
	reColorButton(IDC_BUTTON_14, red);
	reColorButton(IDC_BUTTON_15, black);
	reColorButton(IDC_BUTTON_16, red);
	reColorButton(IDC_BUTTON_17, black);
	reColorButton(IDC_BUTTON_18, red);
	reColorButton(IDC_BUTTON_19, red);
	reColorButton(IDC_BUTTON_20, black);
	reColorButton(IDC_BUTTON_21, red);
	reColorButton(IDC_BUTTON_22, black);
	reColorButton(IDC_BUTTON_23, red);
	reColorButton(IDC_BUTTON_24, black);
	reColorButton(IDC_BUTTON_25, red);
	reColorButton(IDC_BUTTON_26, black);
	reColorButton(IDC_BUTTON_27, red);
	reColorButton(IDC_BUTTON_28, black);
	reColorButton(IDC_BUTTON_29, black);
	reColorButton(IDC_BUTTON_30, red);
	reColorButton(IDC_BUTTON_31, black);
	reColorButton(IDC_BUTTON_32, red);
	reColorButton(IDC_BUTTON_33, black);
	reColorButton(IDC_BUTTON_34, red);
	reColorButton(IDC_BUTTON_35, black);
	reColorButton(IDC_BUTTON_36, red);
	reColorButton(IDC_BUTTON_W1, green);
	reColorButton(IDC_BUTTON_W2, green);
	reColorButton(IDC_BUTTON_W3, green);
	reColorButton(IDC_BUTTON_H1, green);
	reColorButton(IDC_BUTTON_H2, green);
	reColorButton(IDC_BUTTON_H3, green);
	reColorButton(IDC_BUTTON_D1, green);
	reColorButton(IDC_BUTTON_D2, green);
	reColorButton(IDC_BUTTON_EVEN, green);
	reColorButton(IDC_BUTTON_ODD, green);
	reColorButton(IDC_BUTTON_RED, red);
	reColorButton(IDC_BUTTON_BLACK, black);
	reColorButton(IDC_BUTTON_SPIN, green);

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
	CString val;
	auto bt = ((CMFCButton*)GetDlgItem(IDC_BUTTON_3));
	bt->GetWindowTextW(val);
	int betID = m_casino->FindBet(val);
	if (betID == -1)
	{
		m_casino->bets.Add(val);
		bt->SetTextColor(RGB(255, 255, 0));
	}
	else
	{
		m_casino->bets.RemoveAt(betID);
		bt->SetTextColor(RGB(255, 255, 255));
	}
}

