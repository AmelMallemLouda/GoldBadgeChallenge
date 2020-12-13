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
       // private Badges _badges;
        [TestInitialize]// This method will run first.
        [TestMethod]
        public void Arrange()
        {
            List<string> doors = new List<string>();
            doors.Add("D6");
            doors.Add("D7");
            _repo = new BadgesRepo();
           Badges _badges = new Badges(1,doors);
            _repo.AddNewBadge(1,doors);

        }
        [TestMethod]
        public void AddNewBadge_ShouldNotGetNull()
        {
           
            List<string> doors = new List<string>();
            BadgesRepo repo = new BadgesRepo();
            Badges badge = new Badges();

            repo.AddNewBadge(badge.BadgeId,doors);

            int expected = 1;
            int actual = repo.GetAllBadges().Count;

            Assert.AreEqual(expected, actual);

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

            Badges badge=new Badges(1, new List<string>{ "A1","A2"});
            Badges updatedBadge = new Badges(1, new List<string> { "D1", "D2" });
            BadgesRepo _repo = new BadgesRepo();
            _repo.AddNewBadge(1, new List<string>{ "A1","A2"});
            _repo.UpdateBadges(1, updatedBadge);
            Badges expected = updatedBadge;
            Badges actual = badge;
            Assert.AreNotEqual(expected, actual);
            
        }
        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue()
        {
            AddNewBadge_ShouldNotGetNull();// I need to have something to delete.
            BadgesRepo repo = new BadgesRepo();
            Badges badge = new Badges();
            repo.DeleteBadge(badge.BadgeId);// Delete the badge that we already created.
            int expected = 0;// We already have created one badge id we delete it we sould expect 0 badge.
            int actual = repo.GetAllBadges().Count;
            Assert.AreEqual(expected, actual);
            


        }

        [TestMethod]
        public void GetBadgeById_ShouldNotGetNull()
        {
            //Arrange
            BadgesRepo repo = new BadgesRepo();
            Badges BadgebyId = new Badges(1, new List<string> { });
            repo.AddNewBadge(1, new List<string> { });//Create a new badge with a specific ID
            //Act
            repo.GetBadgeById(BadgebyId.BadgeId);// get the new Badge that we ahve created with ID
            int expected = 1;// the ID  to use to get the badge
            int actual = BadgebyId.BadgeId;// it should be 1.
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
