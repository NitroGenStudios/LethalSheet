using System;
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

        public static int overallShip = 0;
        public static int overallTotal = 0;
        public static int overallAverage = 0;
        public static int overallSold = 0;

        public static void Init()
        { 
            quotas = new Quota[numOfQuotas];

            quotas[0].quotaReq = 130;
        }

        public static void Recalculate()
        {
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
            quotas[currentQuota].SetDay(currentDay, amount);
            currentDay++;
            daysPassed++;

            Recalculate();
        }

        public static void AddScrapSold(int amount)
        {
            quotas[currentQuota].SetSold(amount);
            Recalculate();
        }

        public static void SetNewQuota(int amount)
        {
            currentQuota++;
            currentDay = 0;

            quotas[currentQuota].quotaReq = amount;
        }
    }

    public class Quota
    {
        public int[] days;
        public int sold;

        public int quotaReq;
        public int total;
        public float average;

        Quota()
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

        public void SetSold(int amount)
        {
            this.sold = amount;
            Recalculate();
        }

        public void Recalculate()
        {
            this.total = days[0] + days[1] + days[2];
            this.average = total / 3f;
        }
    }
}
