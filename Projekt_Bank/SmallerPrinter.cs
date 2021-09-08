using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Bank
{
    class SmallerPrinter : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("Account information: {0}", account.AccountNumber);
            Console.WriteLine("PESEL number of the owner: {0}\n", account.GetFullName());
        }
    }
}
