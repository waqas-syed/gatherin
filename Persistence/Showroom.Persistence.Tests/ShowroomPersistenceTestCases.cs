using Gatherin.Common;
using Gatherin.Domain.Model;
using Gatherin.Persistence.DatabasePipeline;
using Gatherin.Persistence.Ninject;
using Gatherin.Persistence.Repositories;
using Ninject;
using NUnit.Framework;

namespace Gatherin.Persistence.Tests
{
    [TestFixture]
    public class ShowroomPersistenceTestCases
    {
        private IKernel _kernel;

        [SetUp]
        public void Setup()
        {
            // Register the mappings between domain entities and MongoDB BSON documents to be stored
            MongoMapping.Register();
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
            var mongoConfiguration = _kernel.Get<IMongoConfiguration>();
            // Drop the database
            mongoConfiguration.MongoClient.DropDatabase(Constants.MongoDatabase);
        }
        
        [Test]
        public void AddNewCarTest_ChecksIfTheANewCarIsAddedAsExpectedToTheDatabase_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            var carRepository = _kernel.Get<ICarRepository>();
            Assert.IsNotNull(carRepository);
            // Prepare some data to test
            string name = "SL 500";
            string company = "Mercedes";
            string modelYear = "2017";
            string ownerEmail = "mercedes@123456-7.com";
            Car car = new Car(name, company, modelYear, ownerEmail);
            carRepository.Add(car);

            // Retrieve the car
            var retrievedCar = carRepository.GetInstance(car.Id);
            Assert.IsNotNull(retrievedCar);
            Assert.AreEqual(name, retrievedCar.Name);
            Assert.AreEqual(company, retrievedCar.Company);
            Assert.AreEqual(modelYear, retrievedCar.ModelYear);
            Assert.AreEqual(ownerEmail, retrievedCar.OwnerEmail);
        }

        [Test]
        public void UpdateCarTest_ChecksIfTheANewCarIsAddedAndThenUpdatedAsExpectedToTheDatabase_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            var carRepository = _kernel.Get<ICarRepository>();
            Assert.IsNotNull(carRepository);
            // Prepare some data to test
            string name = "SL 500";
            string company = "Mercedes";
            string modelYear = "2017";
            string ownerEmail = "mercedes@123456-7.com";
            Car car = new Car(name, company, modelYear, ownerEmail);
            carRepository.Add(car);

            // Retrieve the car
            var retrievedCar = carRepository.GetInstance(car.Id);
            Assert.IsNotNull(retrievedCar);
            Assert.AreEqual(name, retrievedCar.Name);
            Assert.AreEqual(company, retrievedCar.Company);
            Assert.AreEqual(modelYear, retrievedCar.ModelYear);
            Assert.AreEqual(ownerEmail, retrievedCar.OwnerEmail);

            // Prepare some data to update
            string name2 = "SL 501";
            string company2 = "Mercedes Benz";
            string modelYear2 = "2016";
            string ownerEmail2 = "mercedesbenz@123456-7.com";

            // Update the car
            car.UpdateCar(name2, company2, modelYear2, ownerEmail2);
            var updateResult = carRepository.Update(car);
            Assert.IsTrue(updateResult);

            // Retrieve the car one more time
            retrievedCar = carRepository.GetInstance(car.Id);
            Assert.IsNotNull(retrievedCar);
            Assert.AreEqual(name2, retrievedCar.Name);
            Assert.AreEqual(company2, retrievedCar.Company);
            Assert.AreEqual(modelYear2, retrievedCar.ModelYear);
            Assert.AreEqual(ownerEmail2, retrievedCar.OwnerEmail);
        }

        [Test]
        public void DeleteCarTest_ChecksIfTheANewCarIsAddedAndThenDeletedAsExpectedToTheDatabase_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            var carRepository = _kernel.Get<ICarRepository>();
            Assert.IsNotNull(carRepository);
            // Prepare some data to test
            string name = "SL 500";
            string company = "Mercedes";
            string modelYear = "2017";
            string ownerEmail = "mercedes@123456-7.com";
            Car car = new Car(name, company, modelYear, ownerEmail);
            carRepository.Add(car);

            // Retrieve the car
            var retrievedCar = carRepository.GetInstance(car.Id);
            Assert.IsNotNull(retrievedCar);
            Assert.AreEqual(name, retrievedCar.Name);
            Assert.AreEqual(company, retrievedCar.Company);
            Assert.AreEqual(modelYear, retrievedCar.ModelYear);
            Assert.AreEqual(ownerEmail, retrievedCar.OwnerEmail);

            // Prepare some data to update
            string name2 = "SL 501";
            string company2 = "Mercedes Benz";
            string modelYear2 = "2016";
            string ownerEmail2 = "mercedesbenz@123456-7.com";

            // Update the car
            car.UpdateCar(name2, company2, modelYear2, ownerEmail2);
            var updateResult = carRepository.Update(car);
            Assert.IsTrue(updateResult);

            // Retrieve the car one more time
            retrievedCar = carRepository.GetInstance(car.Id);
            Assert.IsNotNull(retrievedCar);
            Assert.AreEqual(name2, retrievedCar.Name);
            Assert.AreEqual(company2, retrievedCar.Company);
            Assert.AreEqual(modelYear2, retrievedCar.ModelYear);
            Assert.AreEqual(ownerEmail2, retrievedCar.OwnerEmail);

            // Delete the car
            var deleteResult = carRepository.Delete(car.Id);
            Assert.IsTrue(deleteResult);

            retrievedCar = carRepository.GetInstance(car.Id);
            Assert.IsNull(retrievedCar);
        }

        [Test]
        public void GetAllCarsTest_ChecksIfAllTheCarsStoredInTheDatabaseAreRetrievedAsExpected_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            var carRepository = _kernel.Get<ICarRepository>();
            Assert.IsNotNull(carRepository);
            // Prepare some data to test
            // Car # 1
            string name = "SL 500";
            string company = "Mercedes";
            string modelYear = "2014";
            string ownerEmail = "mercedes@123456-7.com";
            Car car = new Car(name, company, modelYear, ownerEmail);
            carRepository.Add(car);

            // Car # 2
            string name2 = "SL 502";
            string company2 = "Mercedes 2";
            string modelYear2 = "2016";
            string ownerEmail2 = "mercedes2@123456-7.com";
            Car car2 = new Car(name2, company2, modelYear2, ownerEmail2);
            carRepository.Add(car2);

            // Car # 3
            string name3 = "SL 503";
            string company3 = "Mercedes 3";
            string modelYear3 = "2017";
            string ownerEmail3 = "mercedes3@123456-7.com";
            Car car3 = new Car(name3, company3, modelYear3, ownerEmail3);
            carRepository.Add(car3);

            // Car # 4
            string name4 = "SL 504";
            string company4 = "Mercedes 4";
            string modelYear4 = "2016";
            string ownerEmail4 = "mercedes4@123456-7.com";
            Car car4 = new Car(name4, company4, modelYear4, ownerEmail4);
            carRepository.Add(car4);

            // Retrieve the cars
            var retrievedCar = carRepository.GetAllInstances();
            Assert.IsNotNull(retrievedCar);
            // Verify Car # 1
            Assert.AreEqual(4, retrievedCar.Count);
            Assert.AreEqual(name, retrievedCar[0].Name);
            Assert.AreEqual(company, retrievedCar[0].Company);
            Assert.AreEqual(modelYear, retrievedCar[0].ModelYear);
            Assert.AreEqual(ownerEmail, retrievedCar[0].OwnerEmail);

            // Verify Car # 2
            Assert.AreEqual(name2, retrievedCar[1].Name);
            Assert.AreEqual(company2, retrievedCar[1].Company);
            Assert.AreEqual(modelYear2, retrievedCar[1].ModelYear);
            Assert.AreEqual(ownerEmail2, retrievedCar[1].OwnerEmail);

            // Verify Car # 3
            Assert.AreEqual(name3, retrievedCar[2].Name);
            Assert.AreEqual(company3, retrievedCar[2].Company);
            Assert.AreEqual(modelYear3, retrievedCar[2].ModelYear);
            Assert.AreEqual(ownerEmail3, retrievedCar[2].OwnerEmail);

            // Verify Car # 4
            Assert.AreEqual(name4, retrievedCar[3].Name);
            Assert.AreEqual(company4, retrievedCar[3].Company);
            Assert.AreEqual(modelYear4, retrievedCar[3].ModelYear);
            Assert.AreEqual(ownerEmail4, retrievedCar[3].OwnerEmail);
        }

        [Test]
        public void GetAllCarsByEmailTest_ChecksIfAllTheCarsStoredInTheDatabaseWithASpecificEmailAreRetrievedAsExpected_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            var carRepository = _kernel.Get<ICarRepository>();
            Assert.IsNotNull(carRepository);
            // Prepare some data to test
            // Car # 1
            string name = "SL 500";
            string company = "Mercedes";
            string modelYear = "2014";
            string ownerEmail = "mercedes@123456-7.com";
            Car car = new Car(name, company, modelYear, ownerEmail);
            carRepository.Add(car);

            // Car # 2
            string name2 = "SL 502";
            string company2 = "Mercedes 2";
            string modelYear2 = "2016";
            string ownerEmail2 = "mercedes@123456-7.com";
            Car car2 = new Car(name2, company2, modelYear2, ownerEmail2);
            carRepository.Add(car2);

            // Car # 3
            string name3 = "SL 503";
            string company3 = "Mercedes 3";
            string modelYear3 = "2017";
            string ownerEmail3 = "mercedes3@123456-7.com";
            Car car3 = new Car(name3, company3, modelYear3, ownerEmail3);
            carRepository.Add(car3);

            // Car # 4
            string name4 = "SL 504";
            string company4 = "Mercedes 4";
            string modelYear4 = "2016";
            string ownerEmail4 = "mercedes@123456-7.com";
            Car car4 = new Car(name4, company4, modelYear4, ownerEmail4);
            carRepository.Add(car4);

            // Retrieve the cars by the email that is saved with 3 cars out of the above 4
            var retrievedCar = carRepository.GetAllCarByEmail(ownerEmail);
            Assert.IsNotNull(retrievedCar);
            // Verify Car # 1
            Assert.AreEqual(3, retrievedCar.Count);
            Assert.AreEqual(name, retrievedCar[0].Name);
            Assert.AreEqual(company, retrievedCar[0].Company);
            Assert.AreEqual(modelYear, retrievedCar[0].ModelYear);
            Assert.AreEqual(ownerEmail, retrievedCar[0].OwnerEmail);

            // Verify Car # 2
            Assert.AreEqual(name2, retrievedCar[1].Name);
            Assert.AreEqual(company2, retrievedCar[1].Company);
            Assert.AreEqual(modelYear2, retrievedCar[1].ModelYear);
            Assert.AreEqual(ownerEmail2, retrievedCar[1].OwnerEmail);

            // Verify Car # 4
            Assert.AreEqual(name4, retrievedCar[2].Name);
            Assert.AreEqual(company4, retrievedCar[2].Company);
            Assert.AreEqual(modelYear4, retrievedCar[2].ModelYear);
            Assert.AreEqual(ownerEmail4, retrievedCar[2].OwnerEmail);
        }
    }
}
