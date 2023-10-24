using System.Data.SqlClient;


namespace _2._Villain_Names
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            using SqlConnection conn = new SqlConnection(Config.connectionString);
            conn.Open();

            string query = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  \r\n    FROM Villains AS v \r\n    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId \r\nGROUP BY v.Id, v.Name \r\n  HAVING COUNT(mv.VillainId) > 3 \r\nORDER BY COUNT(mv.VillainId)";

            using SqlCommand cmd = new SqlCommand(query, conn);

            using SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine($"{dataReader[0]} - {dataReader[1]}");
            }
        }
    }
}