using System;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class DateCalculations
    {
        public static int GetMonthsBetweenTwoDates(DateTime date1, DateTime date2)
        {
            if(date1 > date2)
                throw new InvalidDateSubtractionException();

            return ((date1.Year - date2.Year) * 12) + date1.Month - date2.Month;
        }
    }
}