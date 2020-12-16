using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoKomodoClaims;

namespace UnitTestsKomodoClaims
{
    [TestClass]
    public class KomodoClaimsUnitTests
    {
        private KomodoClaimRepo _repo;
        private KomodoClaim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoClaimRepo();
            _claim = new KomodoClaim(ClaimTypeEnum.Home, "My house caught on fire.", 5000, new DateTime(2020, 12, 14), new DateTime(2020, 12, 15));
            _repo.AddClaim(_claim);
        }

        [TestMethod]
        public void AddClaim_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetClaimByID(_claim.ClaimID));
        }

        [TestMethod]
        public void GetClaimsList_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetClaimsList());
        }

        [TestMethod]
        public void TakeCareOfNextClaim_ShouldBeTrue()
        {
            Assert.IsTrue(_repo.TakeCareOfNextClaim());
        }

        [TestMethod]
        public void ViewNextClaim_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.ViewNextClaim());
        }

        [TestMethod]
        public void GetClaimById_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetClaimByID(_claim.ClaimID));
        }
    }
}
