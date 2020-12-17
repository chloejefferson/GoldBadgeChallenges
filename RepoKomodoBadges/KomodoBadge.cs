using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoBadges
{
    public class KomodoBadge
    {
        public int BadgeId { get; set; }
        public List<string> Doors { get; set; }
        public KomodoBadge()
        {

        }

        public KomodoBadge(List<string> doors)
        {
            Doors = doors;
        }

        public KomodoBadge(int badgeId, List<string> doors)
        {
            BadgeId = badgeId;
            Doors = doors;
        }
    }
}
