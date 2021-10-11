using System.Runtime.CompilerServices;
using Bank_Kata.Interfaces;
using Castle.DynamicProxy.Generators;
using NSubstitute;
using NUnit.Framework;

namespace Bank_Kata.Test {
    public class AccountShould
    {
        private AccountService account;
        private PrinterService printer;
        private TimeService timeProvider;

        [Test]
        public void print_statement_with_all_transactions() {

            printer = Substitute.For<PrinterService>();
            timeProvider = Substitute.For<TimeService>();
            TransactionStore transactionStore = new TransactionStore(timeProvider);
            account = new Account(printer, transactionStore);
            timeProvider.GetTodayAsString().Returns("14 / 01 / 2012", "13 / 01 / 2012", "10 / 01 / 2012");

            account.Deposit(1000);
            account.Deposit(2000);
            account.Withdraw(500); 
            account.PrintStatement();

            printer.Received(1).Print("Date || Amount || Balance");
            printer.Received(1).Print("14 / 01 / 2012 || -500 || 2500");
            printer.Received(1).Print("13 / 01 / 2012 || 2000 || 3000");
            printer.Received(1).Print("10 / 01 / 2012 || 1000 || 1000");
        }

    }
}