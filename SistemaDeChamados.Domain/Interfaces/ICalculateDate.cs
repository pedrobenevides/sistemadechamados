using System;

namespace SistemaDeChamados.Domain.Interfaces
{
    public interface ICalculateDate
    {
        int CalculateBusinessDays(DateTime initialDate);
        int CalculateBusinessDays(DateTime initialDate, DateTime finalDate);
        bool IsBusinessDay(DateTime date);
    }
}