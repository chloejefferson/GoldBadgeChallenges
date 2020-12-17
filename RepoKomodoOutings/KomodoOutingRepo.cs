using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoOutings
{
    public class KomodoOutingRepo
    {
        private readonly List<KomodoOuting> _outingRepo = new List<KomodoOuting>();
        private int _outingIdCounter = 0;

        public void AddOutingToRepo(KomodoOuting outing)
        {
            outing.EventId = _outingIdCounter + 1;
            _outingRepo.Add(outing);
            _outingIdCounter++;
        }

        public List<KomodoOuting> GetAllOutings()
        {
            return _outingRepo;
        }

        public KomodoOuting GetOutingById(int id)
        {
            foreach (KomodoOuting outing in _outingRepo)
            {
                if (outing.EventId == id)
                {
                    return outing;
                }
            }
            return null;
        }

        //private readonly List<KomodoOutingList> _outingListRepo = new List<KomodoOutingList>();

        //public void AddOutingListToRepo (KomodoOutingList outingList)
        //{
            //_outingListRepo.Add(outingList);
        //}

        //public void GetOutingListByName(string listName)
        //{
            //foreach (KomodoOutingList outlingList in _outingListRepo)
            //{
                //if (outlingList.ListName == listName)
                //{
                    //return outlingList;
                //}
            //}
            //return null;
        //}

    }
}
