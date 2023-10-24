using System.Text;
using System.Data.SqlClient;


namespace _5._Change_Town_Names_Casing

{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();
            //SqlTransaction transaction = connection.BeginTransaction();

            using SqlCommand updateTownNamesCmd = new SqlCommand(SQLQuerries.UpdateTownNames, connection);
            updateTownNamesCmd.Parameters.AddWithValue("@countryName", country);

            object? numberOfTowns = updateTownNamesCmd.ExecuteNonQuery();

            if (numberOfTowns == null || (int)numberOfTowns == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{(int)numberOfTowns} town names were affected.");
                using SqlCommand selectChangedTowns = new SqlCommand(SQLQuerries.SelectTownNames, connection);
                selectChangedTowns.Parameters.AddWithValue("@countryName", country);

                using SqlDataReader towns = selectChangedTowns.ExecuteReader();

                List<string> townNames = new List<string>();
                while (towns.Read())
                {
                    string townName = towns[0].ToString();
                    townNames.Add(townName);
                }
                Console.Write("[");
                Console.Write(string.Join(", ", townNames));
                Console.Write("]");

               
            }

        }
    }
}