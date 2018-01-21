using ClickerRepository;
using ClickerService.Controllers;
using ClickerService.Models;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ClickerServiceTests
{
    public class Tests
    {
        [Test]
        public void Top20Players_RankingTest_CheckIfDatabaseValueIsCorrect()
        {
            var players = AddPlayers(100);
            var ranking = GetRanking();

            players.Sort((x, y) => ((Double)y.TotalEarnings).CompareTo((Double)x.TotalEarnings));

            for (int i = 0; i < 20; i++)
            {
                Assert.IsTrue(players[i].TotalEarnings == ranking.GetValueOrDefault(i + 1).Score);
            }

            DeletePlayers(100);
        } 

        private List<Player> AddPlayers(int numberOfPlayers)
        {
            Random rand = new Random();
            List<Player> players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player
                {
                    Id = i.ToString(),
                    IdFacebook = Guid.NewGuid().ToString(),
                    Name = i.ToString(),
                    Diamonds = 0,
                    Money = 0,
                    FirstLogin = DateTime.Now,
                    LastLogout = DateTime.Now,
                    ImageUrl = "a",
                    Country = "Poland",
                    MaxClickMultiplier = rand.NextDouble() * 10000,
                    MaxCps = rand.NextDouble() * 10000,
                    TotalClicks = rand.NextDouble() * 10000,
                    TotalEarnings = rand.NextDouble() * 10000
                });
            }
            for (int i = 0; i < numberOfPlayers; i++)
            {
                WebRequest requestAddPlayers = WebRequest.Create("http://testserviceclicker.hostingasp.pl/api/player");
                requestAddPlayers.ContentType = "application/json";
                requestAddPlayers.Method = "POST";
                using (var streamWriter = requestAddPlayers.GetRequestStream())
                {
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(players[i]));
                    streamWriter.Write(byteArray, 0, byteArray.Length);
                    streamWriter.Close();
                }
                var response = (HttpWebResponse)requestAddPlayers.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            return players;
        }

        private Dictionary<int, RankingPlayer> GetRanking()
        {
            WebRequest requestGetRank = WebRequest.Create("http://testserviceclicker.hostingasp.pl/api/rankings/1");
            requestGetRank.ContentType = "application/json";
            requestGetRank.Method = "POST";
            using (var streamWriter = requestGetRank.GetRequestStream())
            {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(
                new Ranking
                {
                    rankingType = RankingType.FromTo,
                    statName = "TotalEarnings",
                    offsetBackward = 1,
                    offsetForward = 21
                }));
                streamWriter.Write(byteArray, 0, byteArray.Length);
                streamWriter.Close();
            }
            var response = (HttpWebResponse)requestGetRank.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Dictionary<int, RankingPlayer>>(result);
            }
        }

        private void DeletePlayers(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                WebRequest requestAddPlayers = WebRequest.Create("http://testserviceclicker.hostingasp.pl/api/player/"+i);
                requestAddPlayers.Method = "POST";

                var response = (HttpWebResponse)requestAddPlayers.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
        }

        [Test]
        public void CheckPlayerShopItemPostAndGet()
        {
            AddPlayers(1);
            var shopItems = AddPlayerShopItems();
            var databaseShopItems = GetPlayerShopItems();
            foreach (int key in shopItems.Keys)
            {
                Assert.IsTrue(shopItems.GetValueOrDefault(key).Equals(databaseShopItems.GetValueOrDefault(key)));
            }
            DeletePlayers(1);
        }

        private Dictionary<int, int> AddPlayerShopItems()
        {
            WebRequest request = WebRequest.Create("http://testserviceclicker.hostingasp.pl/api/playershopitem/0");
            request.ContentType = "application/json";
            request.Method = "POST";
            var dictionary = new Dictionary<int, int>();
            using (var streamWriter = request.GetRequestStream())
            {
                for (int i = 0; i < 3; i++)
                {
                    dictionary.Add(i, i);
                }
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dictionary));
                streamWriter.Write(byteArray, 0, byteArray.Length);
                streamWriter.Close();
            }
            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
            return dictionary;
        }

        private Dictionary<int, int> GetPlayerShopItems()
        {
            WebRequest request = WebRequest.Create("http://testserviceclicker.hostingasp.pl/api/playershopitem/0");
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Dictionary<int, int>>(result);
            }
        }
    }
}