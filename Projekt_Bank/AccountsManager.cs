﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Bank
{
    class AccountsManager
    {
        private IList<Account> _accounts;
        public AccountsManager()
        {
            _accounts = new List<Account>();
        }
        
        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();

            SavingsAccount account = new SavingsAccount(id, firstName, lastName, pesel);

            _accounts.Add(account);

            return account;
        }
        public BillingAccount CreateBillingAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();

            BillingAccount account = new BillingAccount(id, firstName, lastName, pesel);

            _accounts.Add(account);

            return account;
        }
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }

       /* public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long pesel)
        { 
            List<Account> customerAccounts = new List<Account>();
            foreach (Account account in _accounts)
            {
                if (account.FirstName == firstName && account.LastName == lastName && account.PESEL == pesel)
                { 
                    customerAccounts.Add(account); 
                } 
            } 
            return customerAccounts; 
        }*/
        public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long pesel)
        {
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.PESEL == pesel);//użucie Linq
        }
        public Account GetAccount(string accountNo)
        {
            return _accounts.Single(x => x.AccountNumber == accountNo);
        }
        public IEnumerable<string> ListOfCustomers() 
        {
            return _accounts.Select(a => string.Format("Imię: {0} | Nazwisko: {1} | PESEL: {2}", a.FirstName, a.LastName, a.PESEL)).Distinct();
        }
        public void CloseMonth()
        {
            foreach (SavingsAccount account in _accounts.Where(x => x is SavingsAccount))
            {
                account.AddInterest(0.04M);
            }
            foreach (BillingAccount account in _accounts.Where(x => x is BillingAccount))
            {
                account.TakeCharge(5.0M);
            }
        }
        public void AddMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(value);
        }
        public void TakeMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(-value);
        }
        private int generateId()
        {
            int id = 1;

            if (_accounts.Any())//czy lista ma jakieś elementy
            {
                id = _accounts.Max(x => x.Id) + 1;//wyrażenie lambda zwraca Id dla obiektu x, Max() zwraca największą wartość z listy
            }

            return id;
        }

    }
}
