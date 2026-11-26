namespace deneshki
{
    internal class Program //создаём главный класс
    {
        static void Main(string[] args) //главный метод программы
        {
            Bank bank = new Bank(); //создаём банк
            Currency currency = new Currency(); //создаём объект конвертации

            Account account1 = new Account("макан", 5000, "RUB"); //создаём первый счёт
            Account account2 = new Account("газанчик", 20000, "RUB"); //создаём второй счёт

            Console.WriteLine("начальный баланс: " + account1.Balance + " " + account1.CurrencyCode); //выводим начальный баланс

            Console.WriteLine("\nпополнение: " + bank.Deposit(account1, 1000)); //пополняем счёт
            Console.WriteLine("снятие: " + bank.Withdraw(account1, 500)); //снимаем деньги
            Console.WriteLine("перевод: " + bank.Transfer(account1, account2, 1000)); //переводим деньги

            Console.WriteLine("\nбаланс до конвертации: " + account1.Balance + " " + account1.CurrencyCode); //выводим баланс до конвертации
            Console.WriteLine("конвертация: " + currency.Convert(account1, "USD", 0.01m)); //конвертируем валюту
            Console.WriteLine("баланс после конвертации: " + account1.Balance + " " + account1.CurrencyCode); //выводим баланс после конвертации

            bank.Block(account1); //блокируем первый счёт
            Console.WriteLine("\nсчёт заблокирован: " + account1.IsBlocked); //проверяем блокировку
            Console.WriteLine("пополнение заблокированного счёта: " + bank.Deposit(account1, 500)); //пробуем пополнить заблокированный счёт

            bank.Unblock(account1); //разблокируем первый счёт
            Console.WriteLine("счёт разблокирован: " + !account1.IsBlocked); //проверяем разблокировку
            Console.WriteLine("пополнение после разблокировки: " + bank.Deposit(account1, 500)); //проверяем пополнение после разблокировки

            Console.WriteLine("\nистория операций:"); //выводим заголовок истории
            foreach (string operation in account1.History) //перебираем историю операций
            {
                Console.WriteLine(operation); //выводим операцию
            }
            Console.WriteLine("\nитоговый баланс: " + account1.Balance + " " + account1.CurrencyCode); //выводим итоговый баланс
        }
    }
}