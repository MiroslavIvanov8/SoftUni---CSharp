












Console.Write("Length: ");
double dul = double.Parse(Console.ReadLine());
Console.Write("Width: ");
double sh = double.Parse(Console.ReadLine());
Console.Write("Height: ");
double H = double.Parse(Console.ReadLine());
double V = (dul * sh * H) / 3;
Console.WriteLine($"Pyramid Volume: {V:f2}");
