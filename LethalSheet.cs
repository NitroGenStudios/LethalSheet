using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalSheet
{
    public class LethalSheet
    {
        public static int[] averageQuotas = new int[10]
        {
            130, 237, 363, 521, 724, 984, 1313, 1725, 2232, 2847
        };

        public static int[] averageQuotaIncrease = new int[10]
        {
            0, 107, 126, 158, 203, 260, 329, 412, 507, 615
        };

        public static int numOfQuotas = 10; //
        public static Quota[] quotas = new Quota[numOfQuotas];

        public static int currentDay = 0;
        public static int currentQuota = 0;
        public static int daysPassed = 0;   //
        public static int currentCredits = 0;

        public static int overallShip = 0;  //
        public static int overallTotal = 0; //  
        public static int overallAverage = 0;   //
        public static int overallSold = 0;  //

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
            currentDay = 0;
            currentQuota = 0;

            // recalc
            Recalculate();
        }

        public static void Recalculate()
        {
            overallTotal = 0;
            overallSold = 0;
            daysPassed = 0;

            foreach (Quota q in quotas)
            {
                daysPassed += q.days.Count(i => i > 0);

                overallTotal += q.total;
                overallSold += q.sold;
                q.isQuotaPredicted = false;
            }

            overallShip = overallTotal - overallSold;
            overallAverage = Math.Max((int)Math.Round((float)overallTotal / (float)daysPassed), 0);

            PredictQuotas();
        }

        private static void PredictQuotas()
        {
            int currentQ = GetCurrentQuota().quotaReq;
            int sum = currentQ;

            for (int i = currentQuota + 1; i < numOfQuotas; i++)
            {
                Quota q = GetQuota(i);

                q.isQuotaPredicted = true;

                sum += averageQuotaIncrease[i];
                q.quotaReq = sum;
            }
        }

        public static int CalculateAverageRequiredToCompleteRun()
        {
            int sumRequired = 0;

            for (int i = currentQuota; i < numOfQuotas; i++)
            {
                Quota q = GetQuota(i);
                sumRequired += q.quotaReq;
            }

            return (int)Math.Round((float)(sumRequired - overallShip) / GetRemainingDays());
        }

        public static int GetRemainingDays()
        {
            return (numOfQuotas * 3) - (currentDay + 1);
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
            // need to compensate for less selling value, otherwise ship scrap get's desynced
            if (currentDay == 2)
                GetCurrentQuota().AddSold((int)Math.Round(amount / (23f/30f)));    // 76.66%
            else if (currentDay == 1)
                GetCurrentQuota().AddSold((int)Math.Round(amount / (8f/15f)));  // 53.33%
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
            return quotas[Math.Clamp(q, 0, numOfQuotas - 1)];
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

        public static String ToString()
        {
            String result = "";

            result += $"{currentDay}/{currentQuota}/{currentCredits}";

            foreach (Quota q in quotas)
            {
                result += $"/{q.ToString()}";
            }

            return result;
        }

        public static void FromString(String str)
        {
            String[] split = str.Split("/");

            currentDay = int.Parse(split[0]);
            currentQuota = int.Parse(split[1]);
            currentCredits = int.Parse(split[2]);

            for (int i = 3; i < split.Length; i++)
            {
                quotas[i - 3] = new Quota(split[i]);
                quotas[i - 3].Recalculate();
            }

            Recalculate();
        }
    }

    public class Quota
    {
        public int[] days;
        public int sold;

        public int quotaReq;
        public int total;
        public float average;

        public bool isQuotaPredicted;

        public Quota()
        {
            this.quotaReq = 0;
            this.days = new int[3];
            this.sold = 0;
            this.total = 0;
            this.average = 0;
            this.isQuotaPredicted = false;
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

        public override String ToString()
        {
            return $"{days[0]};{days[1]};{days[2]}|{sold}|{quotaReq}|{isQuotaPredicted}";
        }

        public Quota(String str)
        {
            String[] split = str.Split("|");

            this.days = split[0].Split(";").Select(int.Parse).ToArray();
            this.sold = int.Parse(split[1]);
            this.quotaReq = int.Parse(split[2]);
            this.isQuotaPredicted = bool.Parse(split[3]);
        }
    }
}
