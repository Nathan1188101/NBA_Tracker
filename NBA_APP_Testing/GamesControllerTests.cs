using Microsoft.EntityFrameworkCore;
using NBA_Tracker.Controllers;
using Microsoft.AspNetCore.Mvc;
using NBA_Tracker.Data;
using NBA_Tracker.Models;

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

        [TestMethod]
        public void IndexReturnsView()
        {

            //arrange 


            //act

            //assert
            
        }
    }
}