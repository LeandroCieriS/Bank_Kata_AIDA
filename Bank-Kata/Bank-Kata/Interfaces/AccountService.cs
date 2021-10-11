namespace Bank_Kata
{
    public interface AccountService
    {
        void deposit(int amount);
        void withdraw(int amount);
        void printStatement();
    }
}