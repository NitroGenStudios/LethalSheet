﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalSheet
{
    public class LethalSheet
    {
        public static int numOfQuotas = 10;
        public static Quota[] quotas = new Quota[numOfQuotas];

        public static int currentDay = 0;
        public static int currentQuota = 0;
        public static int daysPassed = 0;
        public static int currentCredits = 0;

        public static int overallShip = 0;
        public static int overallTotal = 0;
        public static int overallAverage = 0;
        public static int overallSold = 0;

        public static void Reset()
        { 
            quotas = new Quota[numOfQuotas];

            // why
            for (int i = 0; i < numOfQuotas; i++)
            {
                quotas[i] = new Quota();
            }

            // set first quota
            quotas[0].quotaReq = 130;
            currentCredits = 60;
        }

        public static void Recalculate()
        {
            overallTotal = 0;
            overallSold = 0;

            foreach (Quota q in quotas)
            {
                overallTotal += q.total;
                overallSold += q.sold;
            }

            overallShip = overallTotal - overallSold;
            overallAverage = (int)Math.Round((float)overallTotal / (float)daysPassed);
        }

        public static void AddScrapCollected(int amount)
        {
            if (currentDay > 2)
                return;

            GetCurrentQuota().SetDay(currentDay, amount);
            currentDay++;
            daysPassed++;

            Recalculate();
        }

        public static void AddScrapSold(int amount)
        {
            if (currentDay == 2)
                GetCurrentQuota().AddSold((int)Math.Round(amount / (23f/30f)));    // 76.66%
            else if (currentDay == 1)
                GetCurrentQuota().AddSold((int)Math.Round(amount / (8f/15f)));  // 53.66%
            else if (currentDay == 0)
                GetCurrentQuota().AddSold((int)Math.Round(amount / 0.3f));  // 30%
            else
                GetCurrentQuota().AddSold(amount);  // 100%

            Recalculate();
        }

        public static void SetNewQuota(int amount)
        {
            currentCredits += GetCurrentQuota().sold + CalculateOvertimeBonus();

            currentQuota++;
            currentDay = 0;

            GetCurrentQuota().quotaReq = amount;
        }

        public static Quota GetCurrentQuota()
        {
            return quotas[currentQuota];
        }

        public static Quota GetQuota(int q)
        {
            return quotas[q];
        }

        // https://lethal.miraheze.org/wiki/Quota
        public static int CalculateOvertimeBonus()
        {
            Quota currentQuota = GetCurrentQuota();
            int result = 0;

            if (currentDay >= 3)
                result = ((currentQuota.sold - currentQuota.quotaReq) / 5) - 15;
            else
                result = ((currentQuota.sold - currentQuota.quotaReq) / 5) + (15 * (3 - currentDay));

            return Math.Max(result, 0);
        }
    }

    public class Quota
    {
        public int[] days;
        public int sold;

        public int quotaReq;
        public int total;
        public float average;

        public Quota()
        {
            this.quotaReq = 0;
            this.days = new int[3];
            this.sold = 0;
            this.total = 0;
            this.average = 0;
        }

        public void SetDay(int day, int amount)
        {
            this.days[day] = amount;
            Recalculate();
        }

        public void AddSold(int amount)
        {
            this.sold += amount;
            Recalculate();
        }

        public void Recalculate()
        {
            this.total = days[0] + days[1] + days[2];
            this.average = total / 3f;
        }
    }
}
