using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClickerRepository;
using ClickerService.Models;

namespace ClickerModels
{
    public class ShopItemsRepository : IShopItemsRepository
    {
        DatabaseProvider databaseProvider;

        public ShopItemsRepository(DatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public IEnumerable<ShopItem> GetShopItems()
        {
            using (var connection = databaseProvider.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.GetShopItems", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var rdr = sqlCommand.ExecuteReader())
                {
                    List<ShopItem> shopItems = new List<ShopItem>();

                    while (rdr.Read())
                    {
                        shopItems.Add(new ShopItem
                        {
                            Id = Convert.ToInt32(rdr["Id"].ToString()),
                            Name = rdr["Name"].ToString(),
                            ImageUrl = rdr["ImageUrl"].ToString(),
                            Price = Convert.ToDouble(rdr["Price"].ToString()),
                            Bonus = rdr["Bonus"].ToString(),
                            Value = Convert.ToDouble(rdr["Value"].ToString()),
                            IsPremium = Convert.ToBoolean(rdr["IsPremium"].ToString())
                        });
                    }
                    return shopItems;
                }
            }
        }
    }
}
