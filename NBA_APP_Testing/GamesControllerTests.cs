using Microsoft.EntityFrameworkCore;
using NBA_Tracker.Controllers;
using NBA_Tracker.Data;

namespace NBA_APP_Testing
{
    [TestClass]
    public class GamesControllerTests
    {
        //class ars used in tests below 
        ApplicationDbContext _context; 
        GamesController controller; 

        public void TestInitialize()
        {
            //mock db
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;   

            _context = new ApplicationDbContext(options); 

            //add data to in-memory db

            //instantiate controller w/db depencdency for all tests
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