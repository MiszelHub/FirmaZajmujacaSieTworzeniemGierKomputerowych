using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WamesRepository;
using System.Collections.Generic;

namespace WamesTests
{
    [TestClass]
    public class MockRepoTests
    {
        [TestMethod]
        public void GamesRepoTest()
        {
            Mock<IRepository<games>> moqRepo = new Mock<IRepository<games>>();
            games testGame = new games();
           
            moqRepo.Object.AddEntityToDatabase(testGame);

            var result = new List<games>();
            var tmp = moqRepo.Object.GetAllEtitiesFromDataBase();
            foreach (var item in tmp)
            {
                result.Add(item);
            }
            var expected = testGame;

            Assert.AreEqual<int>(expected.GetHashCode(), result[0].GetHashCode());

        }
    }
}
