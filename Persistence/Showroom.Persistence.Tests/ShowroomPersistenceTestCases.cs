using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using NUnit.Framework;
using Showroom.Common;
using Showroom.Domain.Model;
using Showroom.Persistence.DatabasePipeline;
using Showroom.Persistence.Ninject;
using Showroom.Persistence.Repositories;

namespace Showroom.Persistence.Tests
{
    [TestFixture]
    public class ShowroomPersistenceTestCases
    {
        private IKernel _kernel;

        [SetUp]
        public void Setup()
        {
            // Initialize Ninject to load dependencies
            _kernel = new StandardKernel();
            _kernel.Load<PersistenceNinjectModule>();
            var mongoConfiguration = _kernel.Get<IMongoConfiguration>();
            // Drop the database
            mongoConfiguration.MongoClient.DropDatabase(Constants.MongoDatabase);
        }

        [TearDown]
        public void TearDown()
        {
            
        }
        
        [Test]
        public void AddNewCarTest_ChecksIfTheANewCarIsAddedAsExpectedToTheDatabase_VerifiesByTheReturnedValue()
        {
            var carRepository = _kernel.Get<IRepository<Car>>();
            Assert.IsNotNull(carRepository);
            string name = "SL 500";
            string company = "Mercedes";
            string modelYear = "2017";
            string ownerEmail = "mercedes@123456-7.com";
            Car car = new Car(name, company, modelYear, ownerEmail);
            
        }
    }
}
