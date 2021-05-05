namespace Tasks.Lesson7_1
{
    public class Run
    {
        public void Program()
        {
            Bank bank = new Bank();
            User user = new User(1);
            User user2 = new User(2);

            bank.GiveLoan(user, 1_000);
            bank.TopUpBalance(user, 1_000);

            bank.GiveLoan(user2, 10_000);
            bank.TopUpBalance(user2, 1_000);
            bank.TopUpBalance(user2, 1_000);

            bank.GetBalance(user);
            bank.GetBalance(user2);

            bank.GetBalanceSR(user);
        }
    }
}
