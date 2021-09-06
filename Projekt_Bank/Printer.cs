using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Bank
{
    class Printer : IPrinter
    {
        public void Print(Account account)//tutaj mamy parametr, a nie argument z waaktualną wartością
        {
            Console.WriteLine("Dane konta: {0}", account.AccountNumber);
            Console.WriteLine("Rodzaj konta {0}", account.TypeName());
            Console.WriteLine("Saldo: {0}", account.GetBallance());
            Console.WriteLine("Imię i nazwisko właściciela: {0}", account.GetFullName());
            Console.WriteLine("PESEL właściciela: {0}\n", account.PESEL);
        }
    }
}
