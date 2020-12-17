using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoKomodoBadges;

namespace UnitTestsKomodoBadges
{
    [TestClass]
    public class KomodoBadgesUnitTests
    {
        private KomodoBadgeRepo _repo;
        private KomodoBadge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoBadgeRepo();
            List<string> badgeList = new List<string>();
            badgeList.Add("A1");
            badgeList.Add("A2");
            badgeList.Add("A3");
            _badge = new KomodoBadge(badgeList);
            _repo.AddABadge(_badge);
        }

        [TestMethod]
        public void AddABadge_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetBadgeByID(_badge.BadgeId));
        }

        [TestMethod]
        public void GetBadgeDictionary_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetBadgeDictionary());
        }

        [TestMethod]
        public void AddADoor_ShouldBeTrue()
        {
            Assert.IsTrue(_repo.AddADoor(_badge.BadgeId, "A4"));
        }

        [TestMethod]
        public void RemoveADoor_ShouldBeTrue()
        {
            Assert.IsTrue(_repo.RemoveADoor(_badge.BadgeId, "A1"));
        }

        [TestMethod]
        public void RemoveAllDoors_ShouldBeTrue()
        {
            Assert.IsTrue(_repo.RemoveAllDoors(_badge.BadgeId));
        }

        [TestMethod]
        public void GetBadgeByID_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetBadgeByID(_badge.BadgeId));
        }
    }
}
