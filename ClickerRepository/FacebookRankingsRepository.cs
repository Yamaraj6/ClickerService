using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClickerService.Models;

namespace ClickerRepository
{
    public class FacebookRankingsRepository : IFacebookRankingsRepository
    {
        private DatabaseProvider databaseProvider;

        public FacebookRankingsRepository(DatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public IEnumerable<Player> GetFacebookFriendRanking(List<string> friendsFbId)
        {
            string facebookIds = "";
            foreach (var facebookId in friendsFbId)
            {
                facebookIds += facebookId + ";";
            }
            using (var connection = databaseProvider.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.GetFacebookPlayers", connection);
                sqlCommand.Parameters.Add(new SqlParameter("@facebookIds", facebookIds));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    List<Player> facebookPlayers = new List<Player>();
                    while(sqlReader.Read())
                    {
                        facebookPlayers.Add(new Player
                        {
                            Id = sqlReader["Id"].ToString(),
                            IdFacebook = sqlReader["IdFacebook"].ToString(),
                            Name = sqlReader["Name"].ToString(),
                            ImageUrl = sqlReader["ImageUrl"].ToString(),
                            Country = sqlReader["Country"].ToString(),
                            FirstLogin = Convert.ToDateTime(sqlReader["FirstLogin"]),
                            LastLogout = Convert.ToDateTime(sqlReader["LastLogout"]),
                            Money = Convert.ToInt32(sqlReader["Money"]),
                            Diamonds = Convert.ToInt32(sqlReader["Diamonds"]),
                            
                            TotalEarnings = ConvertToDouble(sqlReader["TotalEarnings"]),
                            TotalClicks = ConvertToDouble(sqlReader["TotalClicks"]),
                            MaxCps = ConvertToDouble(sqlReader["MaxCps"]),
                            MaxClickMultiplier = ConvertToDouble(sqlReader["MaxClickMultiplier"])
                        });
                    }
                    return facebookPlayers;
                }
            }
        }

        private double ConvertToDouble(object sqlDataReader)
        {
            try
            { 
                return Convert.ToDouble(sqlDataReader.ToString());
            }
            catch
            {
                return 0;
            }
        }
    }
}