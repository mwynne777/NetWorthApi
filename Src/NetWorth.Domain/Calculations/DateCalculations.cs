using System;
using System.Collections.Generic;
using NetWorth.Domain.Exceptions;

namespace NetWorth.Domain.Calculations
{
    public class DateCalculations
    {
        public static int GetMonthsBetweenTwoDates(DateTime date1, DateTime date2)
        {
            if(date1 > date2)
                throw new InvalidDateSubtractionException();

            return ((date2.Year - date1.Year) * 12) + date2.Month - date1.Month;
        }

        public static List<DateTime> GetAllMonthsBetweenTwoDates(DateTime date1, DateTime date2)
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(date1);

            while(date1.Month != date2.Month || date1.Year != date2.Year)
            {
                date1 = date1.AddMonths(1);
                dates.Add(date1);
            }

            return dates;
        }
    }
}