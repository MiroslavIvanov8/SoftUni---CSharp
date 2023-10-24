using System.Threading.Channels;
using System.Data.SqlClient;
namespace _4._Add_Minion
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            
            using SqlConnection connection = new SqlConnection(Config.connectionString);
            connection.Open();
           
            string[] minionInfo = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] villianInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];

            string vilianName = villianInfo[1];

            // First we check if there is an existing Town

            SqlTransaction sqlTransaction = connection.BeginTransaction();

            SqlCommand getMinionTownIdCmd = new SqlCommand(SQLQueries.GetMinionTown,connection);
            getMinionTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

            object? minionTownId = getMinionTownIdCmd.ExecuteScalar();
            if (minionTownId == null)
            {
                SqlCommand insertTownCmd = new SqlCommand(SQLQueries.InsertTown, connection);
                insertTownCmd.Parameters.AddWithValue("@townName", minionTown);

                insertTownCmd.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }


            SqlCommand getVillianId = new SqlCommand(SQLQueries.GetVilianId, connection);
            getVillianId.Parameters.AddWithValue("@Name", vilianName);

            object? villianId = getVillianId.ExecuteScalar();
            if (villianId == null)
            {
                SqlCommand insertVillian = new SqlCommand(SQLQueries.InsertVillian,connection);
                insertVillian.Parameters.AddWithValue("@villainName", vilianName);
                insertVillian.ExecuteNonQuery();

                Console.WriteLine($"Villain {vilianName} was added to the database.");
            }


            // then we check if we have existing minion if not we insert in into the DB
            SqlCommand getMinionIdcmd = new SqlCommand(SQLQueries.GetMinionIdQuerry, connection);
            getMinionIdcmd.Parameters.AddWithValue("@Name", minionName);

            minionTownId = getMinionTownIdCmd.ExecuteScalar();
            object ? minionId = getMinionIdcmd.ExecuteScalar();

            if (minionId == null)
            {
                SqlCommand insertMinionCmd = new SqlCommand(SQLQueries.InsertMinion,connection);
                insertMinionCmd.Parameters.AddWithValue("@name", minionName);
                insertMinionCmd.Parameters.AddWithValue("@age", minionAge);
                insertMinionCmd.Parameters.AddWithValue("@townId", minionTownId);

                insertMinionCmd.ExecuteNonQuery();
               
            }

            villianId = getVillianId.ExecuteScalar();
            minionId = getMinionIdcmd.ExecuteScalar();

            SqlCommand insertMinionIdAndVillianId = new SqlCommand(SQLQueries.InsertVillianAndMinionId, connection);

            insertMinionIdAndVillianId.Parameters.AddWithValue("@minionId", minionId);
            insertMinionIdAndVillianId.Parameters.AddWithValue("@villainId", villianId);
            insertMinionIdAndVillianId.ExecuteNonQuery();

            Console.WriteLine($"Successfully added {minionName} to be minion of {vilianName}.");

            //sqlTransaction.Rollback();
            
            //sqlTransaction.Commit();
        }

    }
}