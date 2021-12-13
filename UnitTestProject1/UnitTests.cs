using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data.Entity;
using Testapp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        public virtual Testapp.Database Object { get; }

        [TestMethod]
        public void AddDetails_Creates_New_Customer_In_Database()
        {
            // Arrange
            var mockSet = new Mock<DbSet<NewDatabase>>();

            var mockContext = new Mock<Testapp.Database>();
            mockContext.Setup(x => x)
            .Returns(new Testapp.Database { Name = "database", DatabaseID = "222" });

   



            //var fakeDatabase = new FakeDbSet<Database> { new Database { Name = "database", DatabaseID = "222" }};

            //mockdb.Setup(x => x.Set<Customer>())
            //    .Returns(new FakeDbSet<Customer>
            //     {
            //        new Customer { Forename = "Jeff", Surname = "Golding", Address = "11 Avenue", CustomerID = "111111111", DatabaseID = "222" }
            //      });


            // Act
            //var user = Functions.AddDetails(mockSet.Object, mockContext.Object);
            // Assert


        }
    }
}
