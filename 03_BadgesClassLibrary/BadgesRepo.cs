using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesClassLibrary
{
    public class BadgesRepo
    {
        

        public Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();
        public List<Badges> badgelist = new List<Badges>();
        public Badges badges = new Badges();
      



        //Create
        public void CreateNewBadge(int badgeid, List<string> doors)
        {
            _badges.Add(badgeid, doors); 


        }

        //Read
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badges;
        }

        //Update

        public bool UpdateBadges(int id, Badges newBadge)
        {
            Badges oldBadge = GetBadgeById(id);
            if (oldBadge != null)
            {
                oldBadge.BadgeId = newBadge.BadgeId;
                oldBadge.DoorName = newBadge.DoorName;

                return true;
            }
            else
            {
                return false;
            }
        }




        //Helper method

        public Badges GetBadgeById(int id)
        {
            if (_badges.ContainsKey(id))// used  Dictionary<int, List<string>> made sur it has int id as key
            {
                Badges badge = new Badges(id);// called my second constructor with int id as parameter.
                badge.DoorName = _badges[id];
                return badge;
            }
            return null;
        }

    }

}
            
