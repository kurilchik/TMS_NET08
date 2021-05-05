namespace Tasks.HW6
{
    public class Run
    {
        public void Program()
        {
            DogHospital dogHospital = new DogHospital();

            Dog dog = new Dog(DogType.Pooch);

            IBitable siemens = new Siemens();
            IBitable generalElectric = new GeneralElectric();

            dog.Bite();
            dog.Bite(siemens);
            dog.Bite(generalElectric);

            dogHospital.PutIntoArchive(dog);
        }
    }
}
