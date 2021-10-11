using System;
using Bank_Kata.Interfaces;

namespace Bank_Kata {
    public class Account : AccountService {
        public Account(PrinterService printer, TransactionStore transactionStore)
        {
            throw new NotImplementedException();
        }

        public void Deposit(int amount)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(int amount)
        {
            throw new NotImplementedException();
        }

        public void PrintStatement()
        {
            throw new NotImplementedException();
        }
    }
}
