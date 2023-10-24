using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._Add_Minion
{
    internal class SQLQueries
    {
        public const string GetMinionIdQuerry =
            @"SELECT Id FROM Minions WHERE Name = @Name";

        public const string GetMinionTown =
            @"SELECT Id FROM Towns WHERE Name = @townName";

        public const string InsertTown =
            @"INSERT INTO Towns (Name) VALUES (@townName)";

        public const string InsertMinion =
            @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public const string GetVilianId =
            @"SELECT Id FROM Villains WHERE Name = @Name";

        public const string InsertVillian =
            @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public const string InsertVillianAndMinionId =
            @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
    }
}
