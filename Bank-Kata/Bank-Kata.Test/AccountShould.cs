using Bank_Kata.Interfaces;
using Castle.DynamicProxy.Generators;
using NSubstitute;
using NUnit.Framework;

namespace Bank_Kata.Test {
    public class AccountShould {

        [Test]
        public void print_statement_with_all_transactions() {
            
            var account = Substitute.For<AccountService>();
            var printer = Substitute.For<PrinterService>();

            account.deposit(1000);
            account.deposit(2000);
            account.withdraw(500); 
            account.printStatement();

            printer.Received(1).Print("Date || Amount || Balance");
            printer.Received(1).Print("14 / 01 / 2012 || -500 || 2500");
            printer.Received(1).Print("13 / 01 / 2012 || 2000 || 3000");
            printer.Received(1).Print("10 / 01 / 2012 || 1000 || 1000");
        }
    }
}