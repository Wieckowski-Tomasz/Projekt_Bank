using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Bank
{
    class Printer : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("Account information: {0}", account.AccountNumber);
            Console.WriteLine("Account type {0}", account.TypeName());
            Console.WriteLine("Balance: {0}", account.GetBallance());
            Console.WriteLine("Owner's name and surname: {0}", account.GetFullName());
            Console.WriteLine("PESEL number of the owner: {0}\n", account.PESEL);
        }
    }
}
