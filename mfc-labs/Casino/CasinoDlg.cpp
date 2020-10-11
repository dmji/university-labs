
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
	ON_BN_CLICKED(IDC_BUTTON_SPIN, &CCasinoDlg::OnBnClickedButtonSpin)
	ON_BN_CLICKED(IDC_BUTTON_36, &CCasinoDlg::OnBnClickedButton36)
	ON_BN_CLICKED(IDC_BUTTON_35, &CCasinoDlg::OnBnClickedButton35)
	ON_BN_CLICKED(IDC_BUTTON_34, &CCasinoDlg::OnBnClickedButton34)
	ON_BN_CLICKED(IDC_BUTTON_33, &CCasinoDlg::OnBnClickedButton33)
	ON_BN_CLICKED(IDC_BUTTON_32, &CCasinoDlg::OnBnClickedButton32)
	ON_BN_CLICKED(IDC_BUTTON_31, &CCasinoDlg::OnBnClickedButton31)
	ON_BN_CLICKED(IDC_BUTTON_30, &CCasinoDlg::OnBnClickedButton30)
	ON_BN_CLICKED(IDC_BUTTON_29, &CCasinoDlg::OnBnClickedButton29)
	ON_BN_CLICKED(IDC_BUTTON_28, &CCasinoDlg::OnBnClickedButton28)
	ON_BN_CLICKED(IDC_BUTTON_27, &CCasinoDlg::OnBnClickedButton27)
	ON_BN_CLICKED(IDC_BUTTON_26, &CCasinoDlg::OnBnClickedButton26)
	ON_BN_CLICKED(IDC_BUTTON_25, &CCasinoDlg::OnBnClickedButton25)
	ON_BN_CLICKED(IDC_BUTTON_24, &CCasinoDlg::OnBnClickedButton24)
	ON_BN_CLICKED(IDC_BUTTON_23, &CCasinoDlg::OnBnClickedButton23)
	ON_BN_CLICKED(IDC_BUTTON_22, &CCasinoDlg::OnBnClickedButton22)
	ON_BN_CLICKED(IDC_BUTTON_21, &CCasinoDlg::OnBnClickedButton21)
	ON_BN_CLICKED(IDC_BUTTON_20, &CCasinoDlg::OnBnClickedButton20)
	ON_BN_CLICKED(IDC_BUTTON_19, &CCasinoDlg::OnBnClickedButton19)
	ON_BN_CLICKED(IDC_BUTTON_18, &CCasinoDlg::OnBnClickedButton18)
	ON_BN_CLICKED(IDC_BUTTON_17, &CCasinoDlg::OnBnClickedButton17)
	ON_BN_CLICKED(IDC_BUTTON_16, &CCasinoDlg::OnBnClickedButton16)
	ON_BN_CLICKED(IDC_BUTTON_15, &CCasinoDlg::OnBnClickedButton15)
	ON_BN_CLICKED(IDC_BUTTON_14, &CCasinoDlg::OnBnClickedButton14)
	ON_BN_CLICKED(IDC_BUTTON_13, &CCasinoDlg::OnBnClickedButton13)
	ON_BN_CLICKED(IDC_BUTTON_12, &CCasinoDlg::OnBnClickedButton12)
	ON_BN_CLICKED(IDC_BUTTON_11, &CCasinoDlg::OnBnClickedButton11)
	ON_BN_CLICKED(IDC_BUTTON_10, &CCasinoDlg::OnBnClickedButton10)
	ON_BN_CLICKED(IDC_BUTTON_9, &CCasinoDlg::OnBnClickedButton9)
	ON_BN_CLICKED(IDC_BUTTON_8, &CCasinoDlg::OnBnClickedButton8)
	ON_BN_CLICKED(IDC_BUTTON_7, &CCasinoDlg::OnBnClickedButton7)
	ON_BN_CLICKED(IDC_BUTTON_6, &CCasinoDlg::OnBnClickedButton6)
	ON_BN_CLICKED(IDC_BUTTON_5, &CCasinoDlg::OnBnClickedButton5)
	ON_BN_CLICKED(IDC_BUTTON_4, &CCasinoDlg::OnBnClickedButton4)
	ON_BN_CLICKED(IDC_BUTTON_3, &CCasinoDlg::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON_2, &CCasinoDlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON_1, &CCasinoDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON_0, &CCasinoDlg::OnBnClickedButton0)

	ON_BN_CLICKED(IDC_BUTTON_H1, &CCasinoDlg::OnBnClickedButtonH1)
	ON_BN_CLICKED(IDC_BUTTON_H2, &CCasinoDlg::OnBnClickedButtonH2)
	ON_BN_CLICKED(IDC_BUTTON_H3, &CCasinoDlg::OnBnClickedButtonH3)
	ON_BN_CLICKED(IDC_BUTTON_W1, &CCasinoDlg::OnBnClickedButtonW1)
	ON_BN_CLICKED(IDC_BUTTON_W2, &CCasinoDlg::OnBnClickedButtonW2)
	ON_BN_CLICKED(IDC_BUTTON_W3, &CCasinoDlg::OnBnClickedButtonW3)
	ON_BN_CLICKED(IDC_BUTTON_D1, &CCasinoDlg::OnBnClickedButtonD1)
	ON_BN_CLICKED(IDC_BUTTON_D2, &CCasinoDlg::OnBnClickedButtonD2)
	ON_BN_CLICKED(IDC_BUTTON_RED, &CCasinoDlg::OnBnClickedButtonRED)
	ON_BN_CLICKED(IDC_BUTTON_BLACK, &CCasinoDlg::OnBnClickedButtonBLACK)
	ON_BN_CLICKED(IDC_BUTTON_EVEN, &CCasinoDlg::OnBnClickedButtonEVEN)
	ON_BN_CLICKED(IDC_BUTTON_ODD, &CCasinoDlg::OnBnClickedButtonODD)

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
	baseColoringButton();

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

void CCasinoDlg::OnBnClickedButtonSpin()
{
	INT RandTime = rand() % 100;
	while (--RandTime > 0)
	{
		Sleep(90);
		m_picture->SetBitmap(spinHB[spinner++]);
		if (spinner == spinHB.GetSize())
			spinner = 0;
		
	}
	m_casino->checkPrize(spinner-1);
	baseColoringButton();
}

void CCasinoDlg::OnBnClickedButton1()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_1)));
}
void CCasinoDlg::OnBnClickedButton2()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_2)));
}
void CCasinoDlg::OnBnClickedButton3()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_3)));
}
void CCasinoDlg::OnBnClickedButton4()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_4)));
}
void CCasinoDlg::OnBnClickedButton5()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_5)));
}
void CCasinoDlg::OnBnClickedButton6()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_6)));
}
void CCasinoDlg::OnBnClickedButton7()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_7)));
}
void CCasinoDlg::OnBnClickedButton8()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_8)));
}
void CCasinoDlg::OnBnClickedButton9()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_9)));
}
void CCasinoDlg::OnBnClickedButton0()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_0)));
}
void CCasinoDlg::OnBnClickedButton10()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_10)));
}
void CCasinoDlg::OnBnClickedButton11()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_11)));
}
void CCasinoDlg::OnBnClickedButton12()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_12)));
}
void CCasinoDlg::OnBnClickedButton13()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_13)));
}
void CCasinoDlg::OnBnClickedButton14()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_14)));
}
void CCasinoDlg::OnBnClickedButton15()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_15)));
}
void CCasinoDlg::OnBnClickedButton16()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_16)));
}
void CCasinoDlg::OnBnClickedButton17()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_17)));
}
void CCasinoDlg::OnBnClickedButton18()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_18)));
}
void CCasinoDlg::OnBnClickedButton19()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_19)));
}
void CCasinoDlg::OnBnClickedButton20()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_20)));
}
void CCasinoDlg::OnBnClickedButton21()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_21)));
}
void CCasinoDlg::OnBnClickedButton22()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_22)));
}
void CCasinoDlg::OnBnClickedButton23()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_23)));
}
void CCasinoDlg::OnBnClickedButton24()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_24)));
}
void CCasinoDlg::OnBnClickedButton25()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_25)));
}
void CCasinoDlg::OnBnClickedButton26()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_26)));
}
void CCasinoDlg::OnBnClickedButton27()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_27)));
}
void CCasinoDlg::OnBnClickedButton28()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_28)));
}
void CCasinoDlg::OnBnClickedButton29()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_29)));
}
void CCasinoDlg::OnBnClickedButton30()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_30)));
}
void CCasinoDlg::OnBnClickedButton31()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_31)));
}
void CCasinoDlg::OnBnClickedButton32()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_32)));
}
void CCasinoDlg::OnBnClickedButton33()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_33)));
}
void CCasinoDlg::OnBnClickedButton34()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_34)));
}
void CCasinoDlg::OnBnClickedButton35()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_35)));
}
void CCasinoDlg::OnBnClickedButton36()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_36)));
}

void CCasinoDlg::OnBnClickedButtonH1()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_H1)));
}
void CCasinoDlg::OnBnClickedButtonH2()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_H2)));
}
void CCasinoDlg::OnBnClickedButtonH3()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_H3)));
}

void CCasinoDlg::OnBnClickedButtonW1()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_W1)));
}
void CCasinoDlg::OnBnClickedButtonW2()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_W2)));
}
void CCasinoDlg::OnBnClickedButtonW3()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_W3)));
}

void CCasinoDlg::OnBnClickedButtonRED()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_RED)));
}
void CCasinoDlg::OnBnClickedButtonBLACK()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_BLACK)));
}
void CCasinoDlg::OnBnClickedButtonODD()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_ODD)));
}
void CCasinoDlg::OnBnClickedButtonEVEN()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_EVEN)));
}
void CCasinoDlg::OnBnClickedButtonD1()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_D1)));
}
void CCasinoDlg::OnBnClickedButtonD2()
{
	OnBtClickedAction(((CMFCButton*)GetDlgItem(IDC_BUTTON_D2)));
}