using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoClaims
{
    public class KomodoClaimRepo
    {
        private Queue<KomodoClaim> _queueOfClaims = new Queue<KomodoClaim>();
        private int _claimIdCounter = 0;

        public void AddClaim(KomodoClaim claim)
        {
            claim.ClaimID = _claimIdCounter + 1;
            _queueOfClaims.Enqueue(claim);
            _claimIdCounter++;
        }

        public Queue<KomodoClaim> GetClaimsList()
        {
            return _queueOfClaims;
        }

        public bool TakeCareOfNextClaim()
        {
            int initialCount = _queueOfClaims.Count;

            _queueOfClaims.Dequeue();

            if (initialCount == (_queueOfClaims.Count + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public KomodoClaim ViewNextClaim()
        {
            return _queueOfClaims.Peek();
        }

        public KomodoClaim GetClaimByID(int claimId)
        {
            foreach (KomodoClaim claim in _queueOfClaims)
            {
                if (claim.ClaimID == claimId)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
