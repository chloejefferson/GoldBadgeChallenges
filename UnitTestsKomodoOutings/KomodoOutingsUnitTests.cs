using RepoKomodoOutings;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsKomodoOutings
{
    [TestClass]
    public class KomodoOutingsUnitTests
    {
        private KomodoOutingRepo _repo = new KomodoOutingRepo();
        private KomodoOuting _outing1 = new KomodoOuting();
        private KomodoOuting _outing2 = new KomodoOuting();
        private KomodoOuting _outing3 = new KomodoOuting();


        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoOutingRepo();
            _outing1 = new KomodoOuting(EventTypeEnum.Concert, 25, new DateTime(2020, 03, 01), 15);
            _outing2 = new KomodoOuting(EventTypeEnum.Golf, 40, new DateTime(2020, 06, 06), 40);
            _outing3 = new KomodoOuting(EventTypeEnum.Golf, 20, new DateTime(2020, 07, 01), 40);
            _repo.AddOutingToRepo(_outing1);
            _repo.AddOutingToRepo(_outing2);
            _repo.AddOutingToRepo(_outing3);

        }

        [TestMethod]
        public void AddOutingToRepo_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetOutingById(_outing1.EventId));
        }

        [TestMethod]
        public void GetAllOuting_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetAllOutings());
        }

        [TestMethod]
        public void GetOutingById_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetOutingById(_outing2.EventId));
        }
    }
}
