
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
	afx_msg void OnBnClickedCancel();
	afx_msg void OnBnClickedButtonSpin();
	afx_msg void OnBnClickedButton3();
};
