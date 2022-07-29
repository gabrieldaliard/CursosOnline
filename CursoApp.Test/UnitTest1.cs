using CursoApp.Shared.DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace CursoApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        public readonly DbContextOptions<AppDbContext> dbContextOptions;

        public UnitTest1()
        {
            // Build DbContextOptions
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("Name=DefaultConnection")
                .Options;
        }

        [TestMethod]
        public void TestMethod1()
        {

            using (var context = new AppDbContext(dbContextOptions))
            {

                context.Database.EnsureCreated();
                /*
                 * EnsureCreated(), is very important. This creates the in-memory database using the current entity classes and EF Core configuration of your application.
                 */

                
                Assert.AreEqual("Argentina", context.Paises.First().Descripcion);

            }

        }
    }
}