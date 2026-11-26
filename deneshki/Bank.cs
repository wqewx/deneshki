using System;
using System.Collections.Generic;
using System.Text;
using static deneshki.Account;
using static deneshki.Program;

namespace deneshki
{
    internal class Bank
    {
        public bool Deposit(Account account, decimal amount) //метод пополнения
        {
            if (account == null || account.IsBlocked || amount <= 0) return false; //проверяем данные

            account.Balance += amount; //пополняем баланс
            account.History.Add("пополнение: " + amount); //записываем операцию
            return true; //возвращаем результат
        }

        public bool Withdraw(Account account, decimal amount) //метод снятия денег
        {
            if (account == null || account.IsBlocked || amount <= 0 || account.Balance < amount) return false; //проверяем данные

            account.Balance -= amount; //снимаем деньги
            account.History.Add("снятие: " + amount); //записываем операцию
            return true; //возвращаем результат
        }

        public bool Transfer(Account sender, Account recipient, decimal amount) //метод перевода денег
        {
            if (sender == null || recipient == null || sender == recipient) return false; //проверяем счета
            if (sender.IsBlocked || recipient.IsBlocked || amount <= 0) return false; //проверяем блокировку и сумму
            if (sender.Balance < amount || sender.CurrencyCode != recipient.CurrencyCode) return false; //проверяем баланс и валюту

            sender.Balance -= amount; //списываем деньги
            recipient.Balance += amount; //зачисляем деньги
            sender.History.Add("перевод: " + amount); //записываем операцию отправителю
            recipient.History.Add("получен перевод: " + amount); //записываем операцию получателю

            return true; //возвращаем результат
        }

        public void Block(Account account) //метод блокировки счёта
        {
            if (account == null) return; //проверяем счёт

            account.IsBlocked = true; //блокируем счёт
            account.History.Add("счёт заблокирован"); //записываем операцию
        }

        public void Unblock(Account account) //метод разблокировки счёта
        {
            if (account == null) return; //проверяем счёт

            account.IsBlocked = false; //разблокируем счёт
            account.History.Add("счёт разблокирован"); //записываем операцию
        }

    }
}
