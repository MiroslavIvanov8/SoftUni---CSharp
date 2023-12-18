using System;

namespace _01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double studentsNum = int.Parse(Console.ReadLine());
            double lecturesNum = int.Parse(Console.ReadLine());
            double additionalBonus = int.Parse(Console.ReadLine());

            double currentStudentTotalBonusScore = 0;
            double totalBonusScore = 0;
            double currStudentAttendances = 0;
            double bestStudentAttendances = 0;
            for(int i = 0;i<studentsNum;i++)
            {
                //{total bonus} = {student attendances} / {course lectures} * (5 + {additional bonus})
                currStudentAttendances =int.Parse(Console.ReadLine());
                currentStudentTotalBonusScore = (currStudentAttendances / lecturesNum) * (5 + additionalBonus);
                if (currentStudentTotalBonusScore > totalBonusScore)
                {
                    totalBonusScore= currentStudentTotalBonusScore;
                    bestStudentAttendances = currStudentAttendances;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(totalBonusScore)}.");
            Console.WriteLine($"The student has attended {bestStudentAttendances} lectures.");
        }
    }
}
