#pragma once
#include "framework.h"

class CCasinoObject
{
public:
    int redTable[18] = { 1, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
    int blackTable[18] = { 2, 4, 6, 8, 10, 11, 13 ,15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };


    int userBank;
    CArray<CString> bets;
    CArray<INT> betsBank;
    CCasinoObject(int bank=0) : userBank(bank) {}
    void checkPrize(CString num)
    {
        for (int i = 0;i<bets.GetSize();i++)
        {
            if(bets[i]==num)
            {

            }
        }
    }
    int FindBet(CString& val)
    {
        for (int i = 0; i < bets.GetSize(); i++)
            if (bets[i] == val)
                return i;
        return -1;
    }
};

