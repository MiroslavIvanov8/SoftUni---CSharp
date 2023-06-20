namespace SoftUniKindergarten
{
    public class Child
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string ParentName;
        public string ContactNumber;
        public Child(string firstName,string lastName, int age,string parentName,string contactNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            ParentName = parentName;
            ContactNumber = contactNumber;
        }
        public override string ToString()
        {
            return $"Child: {FirstName} {LastName}, Age: {Age}, Contact info: {ParentName} - {ContactNumber}";

        }
    }
}
