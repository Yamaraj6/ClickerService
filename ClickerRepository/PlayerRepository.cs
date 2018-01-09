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
        DatabaseProvider databaseProvider;

        public PlayerRepository(DatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public void CreatPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        //     sqlCommand.ExecuteNonQuery();   //INster update set

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
                            FirstLogin = GetDateTimeFromSqlDRString(sqlReader["FirstLogin"].ToString()),
                            LastLogOut = GetDateTimeFromSqlDRString(sqlReader["LastLogOut"].ToString()),
                            Money = Convert.ToInt32(sqlReader["Money"].ToString()),
                            Diamonds = Convert.ToInt32(sqlReader["Diamonds"].ToString()),

                            TotalEarnings = Convert.ToDouble(sqlReader["TotalEarnings"].ToString()),
                            TotalClicks = Convert.ToDouble(sqlReader["TotalClicks"].ToString()),
                            MaxCps = Convert.ToDouble(sqlReader["MaxCps"].ToString()),
                            MaxClickMultiplier = Convert.ToDouble(sqlReader["MaxClickMultiplier"].ToString())
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
                            FirstLogin = GetDateTimeFromSqlDRString(sqlReader["FirstLogin"].ToString()),
                            LastLogOut = GetDateTimeFromSqlDRString(sqlReader["LastLogOut"].ToString()),
                            Money = Convert.ToInt32(sqlReader["Money"].ToString()),
                            Diamonds = Convert.ToInt32(sqlReader["Diamonds"].ToString()),

                            TotalEarnings = Convert.ToDouble(sqlReader["TotalEarnings"].ToString()),
                            TotalClicks = Convert.ToDouble(sqlReader["TotalClicks"].ToString()),
                            MaxCps = Convert.ToDouble(sqlReader["MaxCps"].ToString()),
                            MaxClickMultiplier = Convert.ToDouble(sqlReader["MaxClickMultiplier"].ToString())
                        };
                    }
                    return null;
                }
            }
        }

        public void RemovePlayer(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        private DateTime? GetDateTimeFromSqlDRString(String sqlDataReader)
        {
            if (sqlDataReader != null)
            {
                return Convert.ToDateTime(sqlDataReader);
            }
            return null;
        }
    }
}
