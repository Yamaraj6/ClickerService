using ClickerRepository;
using ClickerRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClickerModels
{
    public class PlayerShopItemsRepository : IPlayerShopItemsRepository
    {
        private DatabaseProvider databaseProvider;

        public PlayerShopItemsRepository(DatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public Dictionary<int, int> GetPlayerShopItems(string idPlayer)
        {
            using (var connection = databaseProvider.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.GetPlayerShopItems", connection);
                sqlCommand.Parameters.Add(new SqlParameter("@idPlayer", idPlayer));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    Dictionary<int, int> shopItemsWithLevels = new Dictionary<int, int>();
                    while(sqlReader.Read())
                    {
                        shopItemsWithLevels.Add(Convert.ToInt32(sqlReader["ShopItemId"]),
                            Convert.ToInt32(sqlReader["ItemLevel"]));
                    }
                    return shopItemsWithLevels;
                }
            }
        }

        public void UpdatePlayerShopItems(string idPlayer, Dictionary<int, int> shopItemsWithLvls)
        {
            using (var connection = databaseProvider.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.UpdatePlayerShopItems", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (var key in shopItemsWithLvls.Keys)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@idPlayer", idPlayer));
                    sqlCommand.Parameters.Add(new SqlParameter("@idShopItem", key));
                    sqlCommand.Parameters.Add(new SqlParameter("@itemLvl", shopItemsWithLvls[key]));
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        Console.WriteLine($"Player {idPlayer} doesn't exist in the base or\n" +
                            $"ShopItem {key} doesn't exist in the base!");
                    }
                    sqlCommand.Parameters.Clear();
                }
            }
        }
    }
}