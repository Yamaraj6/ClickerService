using ClickerRepository.Interfaces;
using ClickerService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClickerRepository
{
    public class PlayerRepository : IPlayerRepository
    {
        private DatabaseProvider databaseProvider;

        public PlayerRepository(DatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }
        
        public Player GetPlayer(string id)
        {
            using (var connection = databaseProvider.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.GetPlayer", connection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        return new Player
                        {
                            Id = sqlReader["Id"].ToString(),
                            IdFacebook = sqlReader["IdFacebook"].ToString(),
                            Name = sqlReader["Name"].ToString(),
                            ImageUrl = sqlReader["ImageUrl"].ToString(),
                            Country = sqlReader["Country"].ToString(),
                            FirstLogin = DateTime.Parse(sqlReader["FirstLogin"].ToString()),
                            LastLogout = DateTime.Parse(sqlReader["LastLogout"].ToString()),
                            Money = Convert.ToInt32(sqlReader["Money"].ToString()),
                            Diamonds = Convert.ToInt32(sqlReader["Diamonds"].ToString()),

                            TotalEarnings = ConvertToDouble(sqlReader["TotalEarnings"].ToString()),
                            TotalClicks = ConvertToDouble(sqlReader["TotalClicks"].ToString()),
                            MaxCps = ConvertToDouble(sqlReader["MaxCps"].ToString()),
                            MaxClickMultiplier = ConvertToDouble(sqlReader["MaxClickMultiplier"].ToString())
                        };
                    }
                    return null;
                }
            }
        }
        
        public Player GetPlayerByFacebookId(string idFacebook)
        {
            using (var connection = databaseProvider.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.GetPlayerByFacebookId", connection);
                sqlCommand.Parameters.Add(new SqlParameter("@idFacebook", idFacebook));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        return new Player
                        {
                            Id = sqlReader["Id"].ToString(),
                            IdFacebook = sqlReader["IdFacebook"].ToString(),
                            Name = sqlReader["Name"].ToString(),
                            ImageUrl = sqlReader["ImageUrl"].ToString(),
                            Country = sqlReader["Country"].ToString(),
                            FirstLogin = DateTime.Parse(sqlReader["FirstLogin"].ToString()),
                            LastLogout = DateTime.Parse(sqlReader["LastLogout"].ToString()),
                            Money = Convert.ToInt32(sqlReader["Money"].ToString()),
                            Diamonds = Convert.ToInt32(sqlReader["Diamonds"].ToString()),

                            TotalEarnings = ConvertToDouble(sqlReader["TotalEarnings"].ToString()),
                            TotalClicks = ConvertToDouble(sqlReader["TotalClicks"].ToString()),
                            MaxCps = ConvertToDouble(sqlReader["MaxCps"].ToString()),
                            MaxClickMultiplier = ConvertToDouble(sqlReader["MaxClickMultiplier"].ToString())
                        };
                    }
                    return null;
                }
            }
        }
        
        public void RemovePlayer(string id)
        {
            using (var connection = databaseProvider.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.RemovePlayer", connection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
        }
        
        public void UpdatePlayer(Player player)
        {
            using (var connection = databaseProvider.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.UpdatePlayer", connection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", player.Id));
                sqlCommand.Parameters.Add(new SqlParameter("@idFacebook", player.IdFacebook));
                sqlCommand.Parameters.Add(new SqlParameter("@name", player.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@imageUrl", player.ImageUrl));
                sqlCommand.Parameters.Add(new SqlParameter("@country", player.Country));
                sqlCommand.Parameters.Add(new SqlParameter("@firstLogin", player.FirstLogin));
                sqlCommand.Parameters.Add(new SqlParameter("@lastLogout", player.LastLogout));
                sqlCommand.Parameters.Add(new SqlParameter("@money", player.Money));
                sqlCommand.Parameters.Add(new SqlParameter("@diamonds", player.Diamonds));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();

                UpdateStats(player, connection);
            }
        }
        
        private void UpdateStats(Player player, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("dbo.UpdateStats", connection);
            sqlCommand.Parameters.Add(new SqlParameter("@id", player.Id));
            sqlCommand.Parameters.Add(new SqlParameter("@totalEarnings", player.TotalEarnings));
            sqlCommand.Parameters.Add(new SqlParameter("@totalClicks", player.TotalClicks));
            sqlCommand.Parameters.Add(new SqlParameter("@maxCps", player.MaxCps));
            sqlCommand.Parameters.Add(new SqlParameter("@maxClickMultiplier", player.MaxClickMultiplier));
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
        }

        public static double ConvertToDouble(object sqlDataReader)
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