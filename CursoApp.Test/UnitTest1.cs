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

            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .EnableSensitiveDataLogging()
                .UseSqlServer("Data Source = DESKTOP-9OSHMEA\\SQLEXPRESS; Initial Catalog = Flopi4; Integrated Security = True")
                .Options;
        }

        [TestMethod]
        public void TestCreacionDB__ok()
        {

            using (var context = new AppDbContext(dbContextOptions))
            {
                
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                /*
                 * EnsureCreated(), is very important. This creates the in-memory database using the current entity classes and EF Core configuration of your application.
                 */

                Assert.IsTrue(context.Estados.Count<Estados>().Equals(5));

                List<Estados> Estados = context.Estados.ToList();

                Assert.AreEqual("Nuevo", Estados.ElementAtOrDefault(0).Descripcion);
                Assert.AreEqual("Activo", Estados.ElementAtOrDefault(1).Descripcion);
                Assert.AreEqual("Inactivo", Estados.ElementAtOrDefault(2).Descripcion);
                Assert.AreEqual("Suspendido", Estados.ElementAtOrDefault(3).Descripcion);
                Assert.AreEqual("Baja", Estados.ElementAtOrDefault(4).Descripcion);

                Assert.AreEqual("Argentina", context.Paises.First().Descripcion);


                PreguntasFreq preg = new PreguntasFreq(1, "¿Qué es esto?", "Una respuesta");

                Assert.AreEqual("¿Qué es esto?", preg.Pregunta.ToString());

                //context.Database.EnsureDeleted();



            }

        }

        [TestMethod]
        public void PreguntasFreq_metodos_ok()
        {
            PreguntasFreq preg = new PreguntasFreq(1, "¿Qué es esto?", "Una respuesta");

            Assert.AreEqual("¿Qué es esto?", preg.Pregunta.ToString());
            Assert.AreEqual("Una respuesta", preg.Respuesta.ToString());
            Assert.AreEqual(1, preg.idEntidad);



        }

        [TestMethod]
        public void Cursos_metodos_ok()
        {
            Cursos curso1 = new Cursos(1, "Prueba de creación",1 , 1);
            
            Assert.AreEqual(1, curso1.idEntidad);
            Assert.AreEqual("Prueba de creación", curso1.Titulo);

        }


    }
}