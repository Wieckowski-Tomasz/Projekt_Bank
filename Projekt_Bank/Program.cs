using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string name = "Projekt banku";
            string author = "Autor: Tomasz Więckowski";
            Console.WriteLine(name);
            Console.WriteLine(author);
            */
            BankManager bankManager = new BankManager();
            bankManager.Run();
            /*AccountsManager manager = new AccountsManager();

            manager.CreateBillingAccount("Tomasz", "Więckowski", 92010133333);
            manager.CreateSavingsAccount("Jan", "Nowak", 95040712345);
            manager.CreateBillingAccount("Jan", "Nowak", 95040712345);
            
            IEnumerable<Account> accountsList = manager.GetAllAccounts();*/
            //IList<Account> accountsList = (IList<Account>)manager.GetAllAccounts();//zmiana typu listy z IEnumerable na IList, IEnumerable nie posaida []

            /*List<Account> accountsList = new List<Account>();
            accountsList.Add(new SavingsAccount(1, "Tomasz", "Więckowski", 92010133333));
            accountsList.Add(new SavingsAccount(2, "Jan", "Nowak", 95040712345));
            accountsList.Add(new BillingAccount(3, "Jan", "Nowak", 95040712345));
            */

            /*nowe konta bez listy
            SavingsAccount savingsAccount = new SavingsAccount(1, "Tomasz", "Więckowski", 92010133333);

            //second account
            SavingsAccount savingsAccount2 = new SavingsAccount(2, "Jan", "Nowak", 95040712345);

            BillingAccount billingAccount = new BillingAccount(3, savingsAccount2.FirstName, savingsAccount2.LastName, savingsAccount2.PESEL);
            */
            /*IPrinter sPrinter = new SmallerPrinter();
            IPrinter printer = sPrinter;//new Printer();
            foreach (Account account in accountsList)
            {
                printer.Print(account);
            }*/
            /*
            printer.Print(accountsList[0]);// podajemy argument zawierający wartość
            printer.Print(accountsList[2]);
             */
            //printer.Print(billingAccount);

            /*
            string fullName = accountsList[0].GetFullName();
            Console.WriteLine("Pierwsze konto w systemie dostał(-a): {0}", fullName);
            string ballance = accountsList[2].GetBallance();
            Console.WriteLine("Saldo wynosi {0}", ballance);
            */
            /*IEnumerable<string> users = manager.ListOfCustomers();
            foreach (string user in users)
            { 
                Console.WriteLine(user);
            }*/
            //Console.ReadKey();
        }
    }
}
