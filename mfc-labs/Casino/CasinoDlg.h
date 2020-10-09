
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
