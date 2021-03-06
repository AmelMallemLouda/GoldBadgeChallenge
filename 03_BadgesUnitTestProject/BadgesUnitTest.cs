﻿using _03_BadgesClassLibrary;
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
            _repo.CreateNewBadge(1,doors);

        }
        [TestMethod]
        public void AddNewBadge_ShouldNotGetNull()
        {
           
            List<string> doors = new List<string>();
            BadgesRepo repo = new BadgesRepo();
            Badges badge = new Badges();

            repo.CreateNewBadge(badge.BadgeId,doors);

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
            _repo.CreateNewBadge(1, new List<string>{ "A1","A2"});
            _repo.UpdateBadges(1, updatedBadge);
            Badges expected = updatedBadge;
            Badges actual = badge;
            Assert.AreNotEqual(expected, actual);
            
        }
        

        [TestMethod]
        public void GetBadgeById_ShouldNotGetNull()
        {
            //Arrange
            BadgesRepo repo = new BadgesRepo();
            Badges BadgebyId = new Badges(1, new List<string> { });
            repo.CreateNewBadge(1, new List<string> { });//Create a new badge with a specific ID
            //Act
            repo.GetBadgeById(BadgebyId.BadgeId);// get the new Badge that we ahve created with ID
            int expected = 1;// the ID  to use to get the badge
            int actual = BadgebyId.BadgeId;// it should be 1.
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
