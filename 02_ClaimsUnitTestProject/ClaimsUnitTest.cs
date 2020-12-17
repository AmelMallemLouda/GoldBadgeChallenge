using _02_ClaimsClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_ClaimsUnitTestProject
{
    [TestClass]
    public class ClaimsUnitTest
    {
        //declare  _claimsRepo and _claims
        private ClaimsRepo _claimsRepo;
        private Claims _claims;


        [TestInitialize]// This method will run first.

        [TestMethod]
        public void Arrange()
        {  
             // Assign an instance to _claimsRepo and _claims
            _claimsRepo = new ClaimsRepo();// Accessible for all methods
            //  New up an istance with some values.
            _claims = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.0, DateTime.Parse("04/25/2019"), DateTime.Parse("04/25/2020"));
            _claimsRepo.CreateClaims(_claims);// added _claims to the menu(we can see that in any method);
        }
        [TestMethod]
        public void AddClaimToList_ShouldGetNotNull()
        {
            //Arrange -->Setting up the playing field
            Claims claim = new Claims();
            claim.ID = 1;
            ClaimsRepo claimrepo = new ClaimsRepo();
            //Act
            claimrepo.CreateClaims(claim);
            Claims claimMenu = claimrepo.GetClaimById(1);
            //Assert
            Assert.IsNotNull(claimMenu);
        }

        [TestMethod]
        //Read 
        public void GetAllClaims_ShouldNotGetNull()
        {
            Queue<Claims> allClaims = _claimsRepo.GetAllClaims();
            Assert.IsNotNull(allClaims);
        }



        //Update

        [TestMethod]
        public void UpdateClaim_ShouldReturnTrue()
        {
            //Arrange
            Claims Newclaim = new Claims(2, ClaimType.Car, "Car accident on 465.", 400.0, DateTime.Parse("04/26/2019"), DateTime.Parse("04/25/2020"));
            //Act
            bool updateClaim = _claimsRepo.UpdateClaim(1, Newclaim); 
            //Assert
            Assert.IsTrue(updateClaim);

        }

        //Delete

        [TestMethod]
        public void RemoveClaim_ShouldReturnTrue()
        {
            
            bool removeclaim=_claimsRepo.RemoveClaim(1);
            Assert.IsTrue(removeclaim);
        }


        //Helper method
        [TestMethod]
        public void GetClaimById_ShouldGetNotNull( )
        {
            Claims claimById = _claimsRepo.GetClaimById(1);
            Assert.IsNotNull(claimById);
        }
    }
}
