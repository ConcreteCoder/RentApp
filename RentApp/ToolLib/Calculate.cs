
using System;

namespace ToolLib
{
    public interface ICalculate
    {
        decimal CalcPrices(int type, int days);

        int CalcPoints(int type);
    }
    public class Calculate : ICalculate
    {
        public decimal CalcPrices(int type, int days)
        {
            const int One_time_rental_fee = 100;
            const int Premium_daily_fee = 60;
            const int Regular_daily_fee = 40;

            switch (type)
            {
                case 1:
                    return One_time_rental_fee + Premium_daily_fee * days;

                case 2:
                    return One_time_rental_fee + Premium_daily_fee * 2 + Regular_daily_fee * (days > 2 ? days - 2 : 0);

                case 3:
                    return Premium_daily_fee * 3 + Regular_daily_fee * (days > 3 ? days - 3 : 0);

                default:
                    throw new ApplicationException("Unknown Equipment.Type=" + type);
            }
        }

        public int CalcPoints(int type)
        {
            int loyaltyPoints = 0;

            if (type == 1)
            {
                loyaltyPoints += 2;
            }
            else if (type == 2 || type == 3)
            {
                loyaltyPoints += 1;
            }
            else
            {
                throw new ApplicationException("Unknown Equipment.Type=" + type);
            }
            return loyaltyPoints;
        }

    }
}
