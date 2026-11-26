using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic; //подключаем списки


namespace deneshki
{
    internal class Account
    {
        public string Owner { get; private set; } //владелец счёта
        public decimal Balance { get; internal set; } //баланс счёта
        public string CurrencyCode { get; internal set; } //валюта счёта
        public bool IsBlocked { get; internal set; } //статус блокировки
        public List<string> History { get; private set; } //история операций

        public Account(string owner, decimal balance, string currencyCode) //конструктор счёта
        {
            Owner = owner; //устанавливаем владельца
            Balance = balance; //устанавливаем баланс
            CurrencyCode = currencyCode; //устанавливаем валюту
            IsBlocked = false; //счёт изначально не заблокирован
            History = new List<string>(); //создаём историю операций
        }
    }
}