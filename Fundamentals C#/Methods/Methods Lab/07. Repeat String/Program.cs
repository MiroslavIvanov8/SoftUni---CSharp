string massage = Console.ReadLine();
int num = int.Parse(Console.ReadLine());
string result = GetString(massage, num);
Console.WriteLine(result);
static string GetString(string massage, int num)
{
    string result = "";
    for (int i = 0; i < num; i++)
    {
        result += massage;
    }
    return result;
}