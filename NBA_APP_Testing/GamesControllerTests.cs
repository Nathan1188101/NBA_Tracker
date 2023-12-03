using Microsoft.EntityFrameworkCore;
using NBA_Tracker.Controllers;
using Microsoft.AspNetCore.Mvc;
using NBA_Tracker.Data;
using NBA_Tracker.Models;
using Microsoft.AspNetCore.Builder;

namespace NBA_APP_Testing
{
    [TestClass]
    public class GamesControllerTests
    {
        //class ars used in tests below 
        ApplicationDbContext _context; 
        GamesController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            //mock db
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;   

            _context = new ApplicationDbContext(options); 

            //add data to in-memory db
            var game = new Game { GameId = 1, Date = DateTime.Now, Location = "Boston", HomeTeamId = 2, AwayTeamId = 3 };

            //instantiate controller w/db depencdency for all tests
            controller = new GamesController(_context); 

        }

        #region "Index"
        [TestMethod]
        public void IndexReturnsView()
        {

            //act
            var result = (ViewResult)controller.Index().Result;

            //assert
            Assert.AreEqual("Index", result.ViewName);
            
        }

        [TestMethod]
        public void IndexReturnsGames()
        {
            //act
            var result = (ViewResult)controller.Index().Result;
            var model = (List<Game>)result.Model;

            //assert
            CollectionAssert.AreEqual(_context.Games.OrderBy(g => g.AwayTeam).ToList(), model);

        }
        #endregion


        #region "Create"
        [TestMethod]
        public void CreateGameRedirectsToIndex()
        {
            //arrange 
            var game = new Game { Date = DateTime.Now, Location = "Los Angeles", HomeTeamId = 4, AwayTeamId = 12 };

            //act 
            var result = controller.Create(game).Result;

            //assert - need to use IsInstanceOfType in this context as we are testing more than just a view here like in index. We are comparing/testing
            //         the type of result first from what has been created, and then testing/comparing the view name that is returned 
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));

            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectToActionResult.ActionName);

        }

        [TestMethod]
        public void CreateGameAddsToDatabase()
        {
            //arrange
            var initGameCount = _context.Games.Count(); //initializing game count 
            var game = new Game {Date = DateTime.Now, Location = "Sacremento", HomeTeamId = 44, AwayTeamId = 23};

            //act
            controller.Create(game);

            //assert        //incrementing     //comparing to the count 
            Assert.AreEqual(initGameCount + 1, _context.Games.Count());

        }

        [TestMethod]
        public void CreateInvalidGameReturnsErrorView()
        {
            //arrange
            var invalidGame = new Game { Date = DateTime.Now, Location = "New York", HomeTeamId = -1, AwayTeamId = 55 };
            controller.ModelState.AddModelError("HomeTeamId", "Cannot be negative");

            //act
            var result = controller.Create(invalidGame).Result;

            //assert - need to use IsInstanceOfType in this context as we are testing more than just a view here unlike in index. We are comparing/testing
            //         the type of result first from what has been created, and then testing/comparing the view name that is returned 
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName); 

        }

        [TestMethod]
        public void CreateNullGameReturnsView()
        {
            //arrange 
            Game nullGame = null; 

            //act
            var result = controller.Create(nullGame).Result;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult)); 

            var viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName); 

        }

        [TestMethod]
        public void CreateInvalidDateReturnsErrorView()
        {
            //arrange                    // creating a date before present day
            var invalidDate = new Game { Date = DateTime.Now.AddDays(-1), Location = "Brooklyn", HomeTeamId = 10, AwayTeamId = 75 };
            controller.ModelState.AddModelError("Date", "Date cannot be in the past (before present day)");

            //act
            var result = controller.Create(invalidDate).Result;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);

        }

        [TestMethod]
        public void CreateInvalidLocationReturnsErrorView() 
        { 
            var invalidLocation = new Game { }
        }

        #endregion

        //doing tests for delete might be easier, try going that route if you can't figure anything else out 

    }
}