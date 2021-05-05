namespace Tasks.Lesson7_1
{
    public class User
    {
        public double Balance { get; set; } = 0;
        public int Id { get; private set; }

        public User(int id)
        {
            Id = id;
        }
    }
}
