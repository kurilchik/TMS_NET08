namespace Tasks.Lesson6._1
{
    public class Bank
    {
        const decimal RATE = 0.30M;

        public decimal GiveLoan(User user, decimal amount)
        {
            return user.Balance - amount * (1 + RATE);
        }

    }
}
