using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Bank
{
    class BankManager
    {
        private AccountsManager _accountsManager;
        private IPrinter _printer;

        public BankManager()
        {
            _accountsManager = new AccountsManager();
            _printer = new Printer();
        }

        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose action:");
            Console.WriteLine("1 - List of customer's accounts");
            Console.WriteLine("2 - Add a billing account");
            Console.WriteLine("3 - Add a savings account");
            Console.WriteLine("4 - Deposit money to account");
            Console.WriteLine("5 - Withdraw money from account");
            Console.WriteLine("6 - List of all clients");
            Console.WriteLine("7 - All accounts");
            Console.WriteLine("8 - Summarize the month");
            Console.WriteLine("0 - Finish");
        }


        public void Run()
        {
            int action;
            do
            {
                PrintMainMenu();
                action = SelectedAction();
                switch (action)
                {
                    case 1:
                        ListOfAccounts();
                        break;
                    case 2:
                        AddBillingAccount();
                        break;
                    case 3:
                        AddSavingsAccount();
                        break;
                    case 4:
                        AddMoney();
                        break;
                    case 5:
                        TakeMoney();
                        break;
                    case 6:
                        ListOfCustomers();
                        break;
                    case 7:
                        ListOfAllAccounts();
                        break;
                    case 8:
                        CloseMonth();
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Unknown command");
                        Console.ReadKey();
                        break;
                }
            }
            while (action != 0);
        }
        private int SelectedAction()
        {
            Console.Write("Action: ");
            string action = Console.ReadLine();
            if (string.IsNullOrEmpty(action))
            {
                return -1;
            }
            return int.Parse(action);
        }
        private CustomerData ReadCustomerData()
        {
            string firstName;
            string lastName;
            string pesel;
            Console.WriteLine("Provide customer details:");
            Console.Write("First name: ");
            firstName = Console.ReadLine();
            Console.Write("Lirst name: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            pesel = Console.ReadLine();

            return new CustomerData(firstName, lastName, pesel);
        }
        private void ListOfAccounts()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Console.WriteLine();
            Console.WriteLine("Customer's accounts {0} {1} {2}", data.FirstName, data.LastName, data.PESEL);

            foreach (Account account in _accountsManager.GetAllAccountsFor(data.FirstName, data.LastName, data.PESEL))
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }
        private void AddBillingAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account billingAccount = _accountsManager.CreateBillingAccount(data.FirstName, data.LastName, data.PESEL);

            Console.WriteLine("A billing account has been created:");
            _printer.Print(billingAccount);
            Console.ReadKey();
        }
        private void AddSavingsAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account savingsAccount = _accountsManager.CreateSavingsAccount(data.FirstName, data.LastName, data.PESEL);

            Console.WriteLine("A savings account has been created:");
            _printer.Print(savingsAccount);
            Console.ReadKey();
        }
        private void AddMoney()
        {
            string accountNo;
            decimal value;

            Console.WriteLine("Money deposit");
            Console.Write("Account number: ");
            accountNo = Console.ReadLine();
            Console.Write("Amount: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.AddMoney(accountNo, value);

            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);

            Console.ReadKey();
        }
        private void TakeMoney()
        {
            string accountNo;
            decimal value;

            Console.WriteLine("Withdrawing money");
            Console.Write("Account number: ");
            accountNo = Console.ReadLine();
            Console.Write("Amount: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.TakeMoney(accountNo, value);

            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);

            Console.ReadKey();
        }
        private void ListOfCustomers()
        {
            Console.Clear();
            Console.WriteLine("List of all clients:");
            foreach (string customer in _accountsManager.ListOfCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();
        }
        private void ListOfAllAccounts()
        {
            Console.Clear();
            Console.WriteLine("All accounts:");
            foreach (Account account in _accountsManager.GetAllAccounts())
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }
        private void CloseMonth()
        {
            Console.Clear();
            _accountsManager.CloseMonth();
            Console.WriteLine("The month is summarized");
            Console.ReadKey();
        }
    }
    class CustomerData
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long PESEL { get; }

        public CustomerData(string firstName, string lastName, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            PESEL = long.Parse(pesel);
        }
    }
}
