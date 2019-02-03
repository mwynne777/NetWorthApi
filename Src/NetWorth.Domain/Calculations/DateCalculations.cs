using System;
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
    }
}