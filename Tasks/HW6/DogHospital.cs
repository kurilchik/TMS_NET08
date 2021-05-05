using Newtonsoft.Json;
using System;

namespace Tasks.HW6
{
    public class DogHospital
    {
        public void PutIntoArchive(Dog dog)
        {
            Console.WriteLine(JsonConvert.SerializeObject(dog));
        }
    }
}
