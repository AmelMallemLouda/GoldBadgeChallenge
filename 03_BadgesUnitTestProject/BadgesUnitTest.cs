using _03_BadgesClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_BadgesUnitTestProject
{
    [TestClass]
    public class BadgesUnitTest
    {


        private BadgesRepo _repo;
        private Badges _badges;
        [TestInitialize]// This method will run first.
        [TestMethod]
        public void Arrange()
        {
            List<string> doors = new List<string>();
            doors.Add("D6");
            doors.Add("D7");
            _repo = new BadgesRepo();
            _badges = new Badges(1, doors);
            _repo.AddNewBadge(1,doors);

        }
        [TestMethod]
        public void AddNewBadge_ShouldNotGetNull()
        {
           List<string> doors = new List<string>();
            doors.Add("D6");
            doors.Add("D7");
           
            Badges newBadge = new Badges();
           newBadge.BadgeId = 1;
           newBadge.DoorName = doors;
          
            BadgesRepo badgerepo = new BadgesRepo();
            badgerepo.AddNewBadge(1,doors);
            Badges badge = badgerepo.GetBadgeById(1);
            Assert.IsNotNull(badge);
            
        }
        [TestMethod]
        public void GetAllBadges_ShouldNotGetNull()
        {
            Dictionary<int, List<string>> allBadges = _repo.GetAllBadges();
            Assert.IsNotNull(allBadges);
        }


        [TestMethod]
        public void UpdateBadges_shouldReturnTrue()
        {
            List<string> door = new List<string>();
            door.Add("D8");
           
            Badges newBadge = new Badges(3, door);

            
            bool wasUpdated = _repo.UpdateBadges(1, newBadge);
            Assert.IsTrue(wasUpdated);
        }
        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue()
        {
            Badges badges = new Badges();
            badges.BadgeId = 1;
            bool wasDeleted = _repo.DeleteBadge(1);
            Assert.IsTrue(wasDeleted);
        }
    }
}
