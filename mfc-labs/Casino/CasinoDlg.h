
// CasinoDlg.h : header file
//

#pragma once
#include "CCasinoObject.h"

// CCasinoDlg dialog
class CCasinoDlg : public CDialogEx
{
// Construction
public:
	CCasinoDlg(CWnd* pParent = nullptr);	// standard constructor
	CStatic* m_picture;    // pointer to a picture control
	CArray<HBITMAP> spinHB;
	INT spinner;
	CCasinoObject* m_casino;


// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_CASINO_DIALOG };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	void reColorButton(int id, unsigned long colorFace, unsigned long colorText = 16777215)
	{
		((CMFCButton*)GetDlgItem(id))->EnableWindowsTheming(FALSE);
		((CMFCButton*)GetDlgItem(id))->SetFaceColor(colorFace, true);
		((CMFCButton*)GetDlgItem(id))->SetTextColor(colorText);
	}

	void baseColoringButton()
	{
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
	}

	void UpdateUserData()
	{
		CString a;
		a.Format(_T("%d"), m_casino->userBank);
		CWnd* pStaticTest = (CWnd*)GetDlgItem(IDC_STATIC_BALANCE);
		pStaticTest->SetWindowTextW(a);
	}
	void OnBtClickedAction(CMFCButton* bt)
	{
		if (bt) 
		{
			CString val;
			bt->GetWindowTextW(val);
			int betID = m_casino->FindBet(val);
			CString betval;
			CWnd* pbet = (CWnd*)GetDlgItem(IDC_BET);
			pbet->GetWindowTextW(betval);
			if (betval.GetLength()>0)
			{
				if (betID == -1)
				{
					if (m_casino->userBank >= StrToInt(betval))
					{
						m_casino->bets.insert(m_casino->bets.end(),val);
						m_casino->betsBank.insert(m_casino->betsBank.end(),StrToInt(betval));
						bt->SetTextColor(RGB(255, 255, 0));
						m_casino->userBank -= StrToInt(betval);
					}
				}
				else
				{
					m_casino->userBank += m_casino->betsBank[betID];
					m_casino->bets.erase(m_casino->bets.begin()+betID);
					bt->SetTextColor(RGB(255, 255, 255));	
				}
				UpdateUserData();
			}
		}
	}

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButtonSpin();
	afx_msg void OnBnClickedButton0();
	afx_msg void OnBnClickedButton2();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton4();
	afx_msg void OnBnClickedButton5();
	afx_msg void OnBnClickedButton6();
	afx_msg void OnBnClickedButton7();
	afx_msg void OnBnClickedButton8();
	afx_msg void OnBnClickedButton9();
	afx_msg void OnBnClickedButton10();
	afx_msg void OnBnClickedButton11();
	afx_msg void OnBnClickedButton12();
	afx_msg void OnBnClickedButton13();
	afx_msg void OnBnClickedButton14();
	afx_msg void OnBnClickedButton15();
	afx_msg void OnBnClickedButton16();
	afx_msg void OnBnClickedButton17();
	afx_msg void OnBnClickedButton18();
	afx_msg void OnBnClickedButton19();
	afx_msg void OnBnClickedButton20();
	afx_msg void OnBnClickedButton21();
	afx_msg void OnBnClickedButton22();
	afx_msg void OnBnClickedButton23();
	afx_msg void OnBnClickedButton24();
	afx_msg void OnBnClickedButton25();
	afx_msg void OnBnClickedButton26();
	afx_msg void OnBnClickedButton27();
	afx_msg void OnBnClickedButton28();
	afx_msg void OnBnClickedButton29();
	afx_msg void OnBnClickedButton30();
	afx_msg void OnBnClickedButton31();
	afx_msg void OnBnClickedButton32();
	afx_msg void OnBnClickedButton33();
	afx_msg void OnBnClickedButton34();
	afx_msg void OnBnClickedButton35();
	afx_msg void OnBnClickedButton36();
	afx_msg void OnBnClickedButtonH1();
	afx_msg void OnBnClickedButtonH2();
	afx_msg void OnBnClickedButtonH3();
	afx_msg void OnBnClickedButtonW1();
	afx_msg void OnBnClickedButtonW2();
	afx_msg void OnBnClickedButtonW3();
	afx_msg void OnBnClickedButtonD1();
	afx_msg void OnBnClickedButtonD2();
	afx_msg void OnBnClickedButtonRED();
	afx_msg void OnBnClickedButtonBLACK();
	afx_msg void OnBnClickedButtonEVEN();
	afx_msg void OnBnClickedButtonODD();
};
