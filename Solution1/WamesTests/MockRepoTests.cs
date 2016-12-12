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
        private List<games> testDb = new List<games>();
        private void FillTestData(int numberOfDataItems)
        {
            
            for(uint i=0; i < numberOfDataItems; i++)
            {
                testDb.Add(new games());
            }
        }
        [TestMethod]
        public void GamesRepoTest()
        {

            Mock<IRepository<games>> moqRepo = new Mock<IRepository<games>>();
            moqRepo.Setup(x => x.GetAllEtitiesFromDataBase()).Returns(testDb);

            FillTestData(10);
            var result = moqRepo.Object.GetAllEtitiesFromDataBase();
            int count=0;

            foreach (games game in result)
                count++;

            Assert.AreEqual(10, count);

        }
        [TestMethod]
        public void AddingRangeOfEntities()
        {
            Mock<IRepository<games>> moqRepo = new Mock<IRepository<games>>();
            moqRepo.Setup(x => x.GetAllEtitiesFromDataBase()).Returns(testDb);
            
            FillTestData(10);
            
            List<games> testlist = new List<games>();
            testlist.Add(new games());
            testlist.Add(new games());
            testlist.Add(new games());

            moqRepo.Object.AddRangeOfEntities(testlist);

            var result = moqRepo.Object.GetAllEtitiesFromDataBase();
            int count = 0;
            foreach (games game in result)
                count++;

            Assert.AreEqual(13, count);
        }
    }
}
