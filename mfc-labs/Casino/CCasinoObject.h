#pragma once
#include "framework.h"
#include <vector>

class CCasinoObject
{
public:
    int redTable[18] = { 1, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
    int blackTable[18] = { 2, 4, 6, 8, 10, 11, 13 ,15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
    char* imp[37] = { "0", "32", "15","19","4","21","2","25","17","34","6","27","13","36","11","30","8","23","10","5","24","16","33","1","20","14","31","9","22","18","29","7","28","12","35","3","26" };

    int userBank;
    std::vector<CString> bets;
    std::vector<INT> betsBank;
    CCasinoObject(int bank = 0) : userBank(bank) {}
    void checkPrize(int num)
    {
        CString val = CString(imp[num]);
        INT valINT = StrToInt(val);
        for (int i = 0;i<bets.size();i++)
        {
            if(bets[i]==val)
            {
                userBank+=betsBank[i] * 36;
            }
            else if (bets[i] == "1-12")
            {
                if(valINT <=12 && valINT>=1)
                    userBank += betsBank[i] * 3;
            }
            else if (bets[i] == "13-24")
            {
                if (valINT <= 24 && valINT >= 13)
                    userBank += betsBank[i] * 3;
            }
            else if (bets[i] == "25-36")
            {
                if (valINT <= 36 && valINT >= 25)
                    userBank += betsBank[i] * 3;
            }
            else if (bets[i] == "RED")
            {
                for(int j=0;j<18;j++)
                    if(redTable[j]==valINT)
                        userBank += betsBank[i] * 2;
            }
            else if (bets[i] == "BLACK")
            {
                for (int j = 0; j < 18; j++)
                    if (blackTable[j] == valINT)
                        userBank += betsBank[i] * 2;
            }
            else if (bets[i] == "ODD")
            {
                if(valINT%2==0)
                     userBank += betsBank[i] * 2;
            }
            else if (bets[i] == "EVEN")
            {
                if (valINT % 2 == 1)
                    userBank += betsBank[i] * 2;
            }
            else if (bets[i] == "1-18")
            {
                if (valINT <= 18 && valINT >= 1)
                    userBank += betsBank[i] * 2;
            }
            else if (bets[i] == "19-36")
            {
                if (valINT <= 36 && valINT >= 19)
                    userBank += betsBank[i] * 2;
            }
        }
        bets.clear();
        betsBank.clear();
    }

    int FindBet(CString& val)
    {
        for (int i = 0; i < bets.size(); i++)
        {
            auto t = bets[i];
            if (bets[i] == val)
                return i;
        }
        return -1;
    }
};

