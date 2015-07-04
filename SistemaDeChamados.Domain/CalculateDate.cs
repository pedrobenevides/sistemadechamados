using System;
using SistemaDeChamados.Domain.Interfaces;

namespace SistemaDeChamados.Domain
{
    public class CalculateDate : ICalculateDate
    {
        public int CalculateBusinessDays(DateTime initialDate)
        {
            if (initialDate.Date == DateTime.Now.Date)
                return 0;
            
            var result = 0;
            while (initialDate.Date < DateTime.Now.Date)
            {
                initialDate = initialDate.AddDays(1);

                if (!IsBusinessDay(initialDate.Date)) continue;

                result++;
            }

            return result;
        }

        public int CalculateBusinessDays(DateTime initialDate, DateTime finalDate)
        {
            throw new NotImplementedException();
        }

        public bool IsBusinessDay(DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}