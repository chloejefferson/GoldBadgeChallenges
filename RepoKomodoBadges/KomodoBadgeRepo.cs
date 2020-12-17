using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoBadges
{
    public class KomodoBadgeRepo
    {
        private readonly Dictionary<int, KomodoBadge> _badgeDictionary = new Dictionary<int, KomodoBadge>();
        private int _badgeIdCounter = 10000;

        public void AddABadge(KomodoBadge badge)
        {
            badge.BadgeId = _badgeIdCounter + 1;
            _badgeDictionary.Add(badge.BadgeId, badge);
            _badgeIdCounter++;
        }

        public Dictionary<int, KomodoBadge> GetBadgeDictionary()
        {
            return _badgeDictionary;
        }

        public bool AddADoor(int badgeId, string door)
        {
            KomodoBadge badge = GetBadgeByID(badgeId);

            if (badge == null)
            {
                return false;
            }

            int initialCount = badge.Doors.Count;
            badge.Doors.Add(door);

            if (initialCount == (badge.Doors.Count - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveADoor(int badgeId, string door)
        {
            KomodoBadge badge = GetBadgeByID(badgeId);

            if (badge == null)
            {
                return false;
            }

            int initialCount = badge.Doors.Count;
            badge.Doors.Remove(door);

            if (initialCount == (badge.Doors.Count + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAllDoors(int badgeId)
        {
            KomodoBadge badge = GetBadgeByID(badgeId);

            if (badge == null)
            {
                return false;
            }
            badge.Doors.Clear();

            if (badge.Doors.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public KomodoBadge GetBadgeByID(int badgeId)
        {
            foreach(var badge in _badgeDictionary.Values)
            {
                if (badge.BadgeId == badgeId)
                {
                    return badge;
                }
            }
            return null;
        }
    }
}
