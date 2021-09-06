using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Bank
{
    abstract class Account
    {
        public int Id { get; }
        public string AccountNumber { get; }
        public decimal Balance { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public long PESEL { get; }

        public Account()
        {

        }
        public Account(int id, string firstName, string lastName, long pesel)
        {
            Id = id;
            AccountNumber = generateAccountNumber(id);
            Balance = 0.0M;
            FirstName = firstName;
            LastName = lastName;
            PESEL = pesel;
        }
        public string GetFullName()
        {
            string fullName = string.Format("{0} {1}", FirstName, LastName);//działa tak samo jak writeline tylko zapisune dane do zmiennej

            return fullName;
        }

        public string GetBallance()
        {
            string ballance = string.Format("{0}zł", Balance);
            return ballance;
        }

        abstract public string TypeName();//metoda abstrakcyjna ma różne definicje w klasach dziedziczących

        private string generateAccountNumber(int id)//gerowanie numeru konta na podstawie id
        {
            string accountNumber = string.Format("94{0:D10}", id);//94 dalej numer id uzupełniony zerami
            return accountNumber;
        }
        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }

    }
}
