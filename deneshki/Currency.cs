using System;
using System.Collections.Generic;
using System.Text;
using static deneshki.Program;

namespace deneshki
{
    internal class Currency
    {
        public bool Convert(Account account, string newCurrency, decimal rate) //метод конвертации
        {
            if (account == null || account.IsBlocked || rate <= 0 || string.IsNullOrWhiteSpace(newCurrency)) return false; //проверяем данные

            account.Balance *= rate; //пересчитываем баланс
            account.CurrencyCode = newCurrency; //меняем валюту
            account.History.Add("конвертация в " + newCurrency); //записываем операцию

            return true; //возвращаем результат
        }
    }
}
