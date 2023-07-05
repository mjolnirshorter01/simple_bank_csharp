using System;
using System.Collections.Generic;

class Account
{
    public string AccountNumber { get; }
    public decimal Balance { get; private set; }

    public Account(string accountNumber, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Vklad ve výši {amount} Kč byl proveden.");
    }

    public void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Výběr ve výši {amount} Kč byl proveden.");
        }
        else
        {
            Console.WriteLine("Nedostatečný zůstatek na účtu.");
        }
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Aktuální zůstatek na účtu {AccountNumber} je {Balance} Kč.");
    }
}

class Bank
{
    private Dictionary<string, Account> accounts;

    public Bank()
    {
        accounts = new Dictionary<string, Account>();
    }

    public void CreateAccount(string accountNumber, decimal initialBalance = 0)
    {
        if (accounts.ContainsKey(accountNumber))
        {
            Console.WriteLine("Účet s tímto číslem již existuje.");
        }
        else
        {
            accounts[accountNumber] = new Account(accountNumber, initialBalance);
            Console.WriteLine($"Účet s číslem {accountNumber} byl vytvořen.");
        }
    }

    public Account GetAccount(string accountNumber)
    {
        if (accounts.ContainsKey(accountNumber))
        {
            return accounts[accountNumber];
        }
        else
        {
            Console.WriteLine("Účet s tímto číslem neexistuje.");
            return null;
        }
    }
}

class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("\n******** Bankovní aplikace ********");
            Console.WriteLine("1. Vytvořit nový účet");
            Console.WriteLine("2. Vklad na účet");
            Console.WriteLine("3. Výběr z účtu");
            Console.WriteLine("4. Zobrazit zůstatek na účtu");
            Console.WriteLine("5. Konec");

            Console.Write("Zadejte číslo volby: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Zadejte číslo účtu: ");
                    string accountNumber = Console.ReadLine();
                    Console.Write("Zadejte počáteční zůstatek na účtu: ");
                    decimal initialBalance = decimal.Parse(Console.ReadLine());
                    bank.CreateAccount(accountNumber, initialBalance);
                    break;

                case "2":
                    Console.Write("Zadejte číslo účtu: ");
                    string depositAccountNumber = Console.ReadLine();
                    Account depositAccount = bank.GetAccount(depositAccountNumber);
                    if (depositAccount != null)
                    {
                        Console.Write("Zadejte částku k vložení: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        depositAccount.Deposit(depositAmount);
                    }
                    break;

                case "3":
                    Console.Write("Zadejte číslo účtu: ");
                    string withdrawAccountNumber = Console.ReadLine();
                    Account withdrawAccount = bank.GetAccount(withdrawAccountNumber);
                    if (withdrawAccount != null)
                    {
                        Console.Write("Zadejte částku k výběru: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        withdrawAccount.Withdraw(withdrawAmount);
                    }
                    break;

                case "4":
                    Console.Write("Zadejte číslo účtu: ");
                    string balanceAccountNumber = Console.ReadLine();
                    Account balanceAccount = bank.GetAccount(balanceAccountNumber);
                    if (balanceAccount != null)
                    {
                        balanceAccount.DisplayBalance();
                    }
                    break;

                case "5":
                    Console.WriteLine("Děkujeme, že jste použili bankovní aplikaci. Ukončení programu.");
                    return;

                default:
                    Console.WriteLine("Neplatná volba. Zadejte číslo volby znovu.");
                    break;
            }
        }
    }
}
