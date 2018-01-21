using ClickerRepository;
using ClickerRepository.Interfaces;
using ClickerService.Controllers;
using ClickerService.Models;
using Newtonsoft.Json;
using NSubstitute;
using NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace ClickerServiceTests
{
    public class RankingServiceTests
    {
        [Test]
        public void ConvertToDouble_OnExecute_CheckIfValueIsCorrect()
        {
            AddPlayers();
            DeletePlayers();

     //           WebRequest webRequest = WebRequest.Create("http://testserviceclicker.hostingasp.pl/api/player/1223456");
     //    WebResponse webResponse = webRequest.GetResponse();
     //   Stream dataStream = webResponse.GetResponseStream();
     //    StreamReader reader = new StreamReader(dataStream);
     //      string responseFromServer = reader.ReadToEnd();

        }

        private void AddPlayers()
        {
            Random rand = new Random();
            List<Player> players = new List<Player>();
            for (int i = 0; i < 1000; i++)
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
            for (int i = 0; i < 1000; i++)
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
        }

        private void DeletePlayers()
        {
            for (int i = 0; i < 1000; i++)
            {
                WebRequest requestAddPlayers = WebRequest.Create("http://testserviceclicker.hostingasp.pl/api/player"+i);
                requestAddPlayers.ContentType = "application/json";
                requestAddPlayers.Method = "POST";

                var response = (HttpWebResponse)requestAddPlayers.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
        }

        [Test]
        public void GetTime_OnExecute_CheckIfTimeIsCorrect()
        {
            var timeRepository = Substitute.For<TimeRepository>();
            var timeController = new TimeController(timeRepository);
            Assert.IsTrue(timeRepository.GetTime().Second == DateTime.Now.Second);
        }
    }
}