using Newtonsoft.Json;

namespace Tasks.Lesson6._1
{
    public class User
    {
        public decimal Balance { get; set; }

        public User(decimal balance)
        {
            Balance = balance;
        }

        public string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
