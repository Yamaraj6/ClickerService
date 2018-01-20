using ClickerRepository;
using ClickerRepository.Interfaces;
using ClickerService.Controllers;
using ClickerService.Models;
using NSubstitute;
using NUnit;
using NUnit.Framework;
using System;
using System.Data.SqlClient;

namespace ClickerServiceTests
{
    public class RankingServiceTests
    {
        [Test]
        public void ConvertToDouble_OnExecute_CheckIfValueIsCorrect()
        {
            Assert.AreEqual(2, PlayerRepository.ConvertToDouble("2"));
            Assert.AreEqual(DateTime.Now.Second, PlayerRepository.ConvertToDouble(DateTime.Now.Second));
            Assert.AreEqual(2.023131234, PlayerRepository.ConvertToDouble("2,023131234"));
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