using _01_CafeClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_CafeUnitTestProject
{


    [TestClass]
    public class CafeUnitTest
    {
        public Cafe caf = new Cafe();
        private CafeRepo _repo;
        private Cafe _cafe;
        [TestInitialize]  // We want this method to run before any other test
        public void Arrange()
        {
            _repo = new CafeRepo();// Accessible for all methods

            //Use our overloaded constructor . New up an istance with some values
            _cafe = new Cafe("espresso", "full-flavored concentrated form of coffe that is served in shots", 1, 3, new List<string>{"Coffe beans"});

            _repo.AddItemToMenu(_cafe);// added _cafe to the menu(we can see that in any method)

        }

        //Create

        [TestMethod]
        public void AddItemToMenu_ShouldGetNotNull()
        {
            // the 3 AAA


            //Arrange -->Setting up the playing field
            Cafe cafe = new Cafe();
            cafe.MealName = "coffe";
            CafeRepo caferepo = new CafeRepo();

            //Act-->Get/Rum the code we want

            caferepo.AddItemToMenu(cafe);

            Cafe menufromdirectory = caferepo.GetMenuitemByName("coffe");

            // Assert --> Use the asset class to verify the expected outcome

            Assert.IsNotNull(menufromdirectory);  //(We expect this to be not null.)
        }

        //Update

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            Cafe newCafe = new Cafe("Espresso", "full-flavored concentrated form of coffe that is served in shots", 1, 4, new List<string> { "Coffe beans" });

            //Act
            bool updateResult = _repo.UpdateItem("espresso", newCafe);

            Assert.IsTrue(updateResult);
        }


        //Delete

        [TestMethod]
        public void RemoveFromMenu_ShouldReturnTrue()
        {

            bool wasDeleted = _repo.RemoveFromMenu(_cafe.MealName);
            Assert.IsTrue(wasDeleted);
        }

        //Read
        [TestMethod]
        public void GetAllMenu_ShouldGetNotNull()
        {
           

           List<Cafe> cafe= _repo.GetMenuItems();
            Assert.IsNotNull(cafe);
        }


        //Helper Method
        [TestMethod]
        public void GetMenuitemByName_ShouldGetNotNull()
        {
            Cafe cafeByName = _repo.GetMenuitemByName("espresso");
            Assert.IsNotNull(cafeByName);
        }
    }




}
   

