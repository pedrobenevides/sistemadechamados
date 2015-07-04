using System;
using SistemaDeChamados.Domain.Interfaces;

namespace SistemaDeChamados.Domain
{
    public class CalculateDate : ICalculateDate
    {
        public int CalculateBusinessDays(DateTime initialDate, DateTime finalDate)
        {
            if (initialDate.Date == finalDate.Date)
                return 0;

            var result = 0;
            while (initialDate.Date < finalDate.Date)
            {
                initialDate = initialDate.AddDays(1);

                if (!IsBusinessDay(initialDate.Date)) continue;

                result++;
            }

            return result;
        }

        public bool IsBusinessDay(DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}