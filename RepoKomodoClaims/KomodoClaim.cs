using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoClaims
{
    public enum ClaimTypeEnum
    {
        Car = 1,
        Home,
        Theft,
    }
    public class KomodoClaim
    {
        public int ClaimID { get; set; }
        public ClaimTypeEnum ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if(DateOfClaim - DateOfIncident <= new TimeSpan(30, 0, 0, 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public KomodoClaim() { }
        public KomodoClaim(ClaimTypeEnum claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }

}
