int people = int.Parse(Console.ReadLine());
int capacity = int.Parse(Console.ReadLine());
double courses = (people/capacity);
Console.WriteLine(Math.Ceiling(courses));