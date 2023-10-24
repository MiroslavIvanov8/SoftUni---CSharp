using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Channels;

namespace _3._Minion_Names
{
      

    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(Config.connectionString);
            connection.Open();

            using SqlCommand getVillanName = new SqlCommand(SQLQuerries.getVillanName,connection);

            int villianId = int.Parse(Console.ReadLine());
            getVillanName.Parameters.AddWithValue("@Id",villianId);
            object? villian = getVillanName.ExecuteScalar();

            if (villian == null)
            {
                Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                
            }

            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Villain: {villian.ToString()}");

                using SqlCommand getMinioNames = new SqlCommand(SQLQuerries.getMinionNames, connection);
                getMinioNames.Parameters.AddWithValue("@Id", villianId);
                using SqlDataReader minionNames = getMinioNames.ExecuteReader();

                if (!minionNames.HasRows)
                {
                    sb.AppendLine("(no minions)");
                }
                else
                {
                    while(minionNames.Read())
                    sb.AppendLine($"{minionNames[0]}. {minionNames[1]} {minionNames[2]}");
                }

                Console.WriteLine(sb.ToString().TrimEnd());
                
            }
            
        }
    }
}   