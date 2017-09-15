using Gatherin.Common;
using Gatherin.Domain.Model.GatherinAggregate;
using Gatherin.Persistence.DatabasePipeline;
using Gatherin.Persistence.Ninject;
using Gatherin.Persistence.Repositories;
using Ninject;
using NUnit.Framework;
using System;

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
        public void AddNewGatheringTest_ChecksIfTheANewGatheringIsAddedAsExpectedToTheDatabase_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            var gatheringRepository = _kernel.Get<IGatheringRepository>();
            Assert.IsNotNull(gatheringRepository);
            string title = "Painters Get Around";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9).Date;
            string organizerEmail = "thisisit@123456789-0.com";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            var gathering = new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build();
            gatheringRepository.Add(gathering);

            // Retrieve the Gathering
            var retrievedGathering = gatheringRepository.GetInstance(gathering.Id);
            Assert.IsNotNull(retrievedGathering);
            Assert.AreEqual(title, retrievedGathering.Title);
            Assert.AreEqual(description, retrievedGathering.Description);
            Assert.AreEqual(dateOfMeeting, retrievedGathering.DateOfMeeting);
            Assert.AreEqual(organizerEmail, retrievedGathering.OrganizerEmail);
            Assert.AreEqual(topic, retrievedGathering.Topic);
            Assert.IsNotNull(retrievedGathering.Location);
            Assert.AreEqual(location.Latitude, retrievedGathering.Location.Latitude);
            Assert.AreEqual(location.Longitude, retrievedGathering.Location.Longitude);
            Assert.AreEqual(location.Area, retrievedGathering.Location.Area);
            Assert.AreEqual(venue, retrievedGathering.Venue);
            Assert.AreEqual(isVideoMeeting, retrievedGathering.IsVideoGathering);
            Assert.AreEqual(videoCallLink, retrievedGathering.VideoCallLink);
        }
        
        [Test]
        public void UpdateGatheringTest_ChecksIfTheANewGatheringIsAddedAndThenUpdatedAsExpectedToTheDatabase_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            var gatheringRepository = _kernel.Get<IGatheringRepository>();
            Assert.IsNotNull(gatheringRepository);
            string title = "Painters Get Around";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9).Date;
            string organizerEmail = "thisisit@123456789-0.com";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            var gathering = new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build();
            gatheringRepository.Add(gathering);

            // Retrieve the Gathering
            var retrievedGathering = gatheringRepository.GetInstance(gathering.Id);
            Assert.IsNotNull(retrievedGathering);
            Assert.AreEqual(title, retrievedGathering.Title);
            Assert.AreEqual(description, retrievedGathering.Description);
            Assert.AreEqual(dateOfMeeting, retrievedGathering.DateOfMeeting);
            Assert.AreEqual(organizerEmail, retrievedGathering.OrganizerEmail);
            Assert.AreEqual(topic, retrievedGathering.Topic);
            Assert.IsNotNull(retrievedGathering.Location);
            Assert.AreEqual(location.Latitude, retrievedGathering.Location.Latitude);
            Assert.AreEqual(location.Longitude, retrievedGathering.Location.Longitude);
            Assert.AreEqual(location.Area, retrievedGathering.Location.Area);
            Assert.AreEqual(venue, retrievedGathering.Venue);
            Assert.AreEqual(isVideoMeeting, retrievedGathering.IsVideoGathering);
            Assert.AreEqual(videoCallLink, retrievedGathering.VideoCallLink);

            string title2 = "Painters Get Around 2";
            string description2 = "We painters are a different lot 2";
            DateTime dateOfMeeting2 = DateTime.Now.AddDays(10).Date;
            string organizerEmail2 = "thisisit@123456789-2.com";
            string topic2 = Gathering.AllTopics()[1];
            Location location2 = new Location(23.47M, 73.33M, "F-7, Islamabad, Pakistan");
            string venue2 = "Attrio Cafe";
            bool isVideoMeeting2 = false;
            string videoCallLink2 = null;

            retrievedGathering.UpdateCar(title2, description2, dateOfMeeting2, organizerEmail2, topic2, 
                isVideoMeeting2, videoCallLink2, location2, venue2);
            gatheringRepository.Update(retrievedGathering);

            // Retrieve the Gathering
            retrievedGathering = gatheringRepository.GetInstance(gathering.Id);
            Assert.IsNotNull(retrievedGathering);
            Assert.AreEqual(title2, retrievedGathering.Title);
            Assert.AreEqual(description2, retrievedGathering.Description);
            Assert.AreEqual(dateOfMeeting2, retrievedGathering.DateOfMeeting);
            Assert.AreEqual(organizerEmail2, retrievedGathering.OrganizerEmail);
            Assert.AreEqual(topic2, retrievedGathering.Topic);
            Assert.IsNotNull(retrievedGathering.Location);
            Assert.AreEqual(location2.Latitude, retrievedGathering.Location.Latitude);
            Assert.AreEqual(location2.Longitude, retrievedGathering.Location.Longitude);
            Assert.AreEqual(location2.Area, retrievedGathering.Location.Area);
            Assert.AreEqual(venue2, retrievedGathering.Venue);
            Assert.AreEqual(isVideoMeeting2, retrievedGathering.IsVideoGathering);
            Assert.AreEqual(videoCallLink2, retrievedGathering.VideoCallLink);
        }
        
        [Test]
        public void DeleteGatheringTest_ChecksIfTheANewGatheringIsAddedAndThenDeletedAsExpectedToTheDatabase_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            var gatheringRepository = _kernel.Get<IGatheringRepository>();
            Assert.IsNotNull(gatheringRepository);
            string title = "Painters Get Around";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9).Date;
            string organizerEmail = "thisisit@123456789-0.com";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            var gathering = new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build();
            gatheringRepository.Add(gathering);

            // Retrieve the Gathering
            var retrievedGathering = gatheringRepository.GetInstance(gathering.Id);
            Assert.IsNotNull(retrievedGathering);
            Assert.AreEqual(title, retrievedGathering.Title);
            Assert.AreEqual(description, retrievedGathering.Description);
            Assert.AreEqual(dateOfMeeting, retrievedGathering.DateOfMeeting);
            Assert.AreEqual(organizerEmail, retrievedGathering.OrganizerEmail);
            Assert.AreEqual(topic, retrievedGathering.Topic);
            Assert.IsNotNull(retrievedGathering.Location);
            Assert.AreEqual(location.Latitude, retrievedGathering.Location.Latitude);
            Assert.AreEqual(location.Longitude, retrievedGathering.Location.Longitude);
            Assert.AreEqual(location.Area, retrievedGathering.Location.Area);
            Assert.AreEqual(venue, retrievedGathering.Venue);
            Assert.AreEqual(isVideoMeeting, retrievedGathering.IsVideoGathering);
            Assert.AreEqual(videoCallLink, retrievedGathering.VideoCallLink);

            string title2 = "Painters Get Around 2";
            string description2 = "We painters are a different lot 2";
            DateTime dateOfMeeting2 = DateTime.Now.AddDays(10).Date;
            string organizerEmail2 = "thisisit@123456789-2.com";
            string topic2 = Gathering.AllTopics()[1];
            Location location2 = new Location(23.47M, 73.33M, "F-7, Islamabad, Pakistan");
            string venue2 = "Attrio Cafe";
            bool isVideoMeeting2 = false;
            string videoCallLink2 = null;

            retrievedGathering.UpdateCar(title2, description2, dateOfMeeting2, organizerEmail2, topic2,
                isVideoMeeting2, videoCallLink2, location2, venue2);
            gatheringRepository.Update(retrievedGathering);

            // Retrieve the Gathering
            retrievedGathering = gatheringRepository.GetInstance(gathering.Id);
            Assert.IsNotNull(retrievedGathering);
            Assert.AreEqual(title2, retrievedGathering.Title);
            Assert.AreEqual(description2, retrievedGathering.Description);
            Assert.AreEqual(dateOfMeeting2, retrievedGathering.DateOfMeeting);
            Assert.AreEqual(organizerEmail2, retrievedGathering.OrganizerEmail);
            Assert.AreEqual(topic2, retrievedGathering.Topic);
            Assert.IsNotNull(retrievedGathering.Location);
            Assert.AreEqual(location2.Latitude, retrievedGathering.Location.Latitude);
            Assert.AreEqual(location2.Longitude, retrievedGathering.Location.Longitude);
            Assert.AreEqual(location2.Area, retrievedGathering.Location.Area);
            Assert.AreEqual(venue2, retrievedGathering.Venue);
            Assert.AreEqual(isVideoMeeting2, retrievedGathering.IsVideoGathering);
            Assert.AreEqual(videoCallLink2, retrievedGathering.VideoCallLink);

            string gatheringId = retrievedGathering.Id;
            // Delete the Gathering
            var deleteResult = gatheringRepository.Delete(gatheringId);
            Assert.IsTrue(deleteResult);

            var retrievedGathering2 = gatheringRepository.GetInstance(gatheringId);
            Assert.IsNull(retrievedGathering2);
        }

        
        [Test]
        public void GetAllCGatheringsTest_ChecksIfAllTheGatheringsStoredInTheDatabaseAreRetrievedAsExpected_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            // Gathering # 1
            var gatheringRepository = _kernel.Get<IGatheringRepository>();
            Assert.IsNotNull(gatheringRepository);
            string title = "Painters Get Around";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9).Date;
            string organizerEmail = "thisisit@123456789-0.com";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            var gathering = new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build();
            gatheringRepository.Add(gathering);

            // Gathering # 2
            string title2 = "Painters Get Around 2 ";
            string description2 = "We painters are a different lot 2";
            DateTime dateOfMeeting2 = DateTime.Now.AddDays(10).Date;
            string organizerEmail2 = "thisisit@123456789-2.com";
            string topic2 = Gathering.AllTopics()[1];
            Location location2 = new Location(23.41M, 73.39M, "F-7, Islamabad, Pakistan");
            string venue2 = "Attrio Cafe";
            bool isVideoMeeting2 = true;
            string videoCallLink2 = "https://dummygooglemeet.com/12343767docvnwb20t585jhetycghwrffgffd";

            var gathering2 = new Gathering.GatheringBuilder().Title(title2).Description(description2)
                .DateOfMeeting(dateOfMeeting2).OrganizerEmail(organizerEmail2).Topic(topic2).Location(location2)
                .Venue(venue2).IsVideoGathering(isVideoMeeting2).VideoCallLink(videoCallLink2)
                .Build();
            gatheringRepository.Add(gathering2);

            // Gathering # 3
            string title3 = "Painters Get Around 3";
            string description3 = "We painters are a different lot 3";
            DateTime dateOfMeeting3 = DateTime.Now.AddDays(8).Date;
            string organizerEmail3 = "thisisit@123456789-3.com";
            string topic3 = Gathering.AllTopics()[2];
            Location location3 = new Location(23.57M, 73.43M, "F-8, Islamabad, Pakistan");
            string venue3 = "Pizza Hut";
            bool isVideoMeeting3 = true;
            string videoCallLink3 = "https://dummygooglemeet.com/12343767docvnwb20t585jhetycghwrf6654323d";

            var gathering3 = new Gathering.GatheringBuilder().Title(title3).Description(description3)
                .DateOfMeeting(dateOfMeeting3).OrganizerEmail(organizerEmail3).Topic(topic3).Location(location3)
                .Venue(venue3).IsVideoGathering(isVideoMeeting3).VideoCallLink(videoCallLink3)
                .Build();
            gatheringRepository.Add(gathering3);

            // Gathering # 4
            string title4 = "Painters Get Around 4";
            string description4 = "We painters are a different lot 4";
            DateTime dateOfMeeting4 = DateTime.Now.AddDays(12).Date;
            string organizerEmail4 = "thisisit@123456789-4.com";
            string topic4 = Gathering.AllTopics()[3];
            Location location4 = new Location(23.97M, 73.73M, "F-9, Islamabad, Pakistan");
            string venue4 = "Fatima Jinnah Park";
            bool isVideoMeeting4 = false;
            string videoCallLink4 = "";

            var gathering4 = new Gathering.GatheringBuilder().Title(title4).Description(description4)
                .DateOfMeeting(dateOfMeeting4).OrganizerEmail(organizerEmail4).Topic(topic4).Location(location4)
                .Venue(venue4).IsVideoGathering(isVideoMeeting4).VideoCallLink(videoCallLink4)
                .Build();
            gatheringRepository.Add(gathering4);

            // Retrieve the Gathering
            var retrievedGatherings = gatheringRepository.GetAllInstances();
            Assert.IsNotNull(retrievedGatherings);

            // Verify Gathering # 1
            Assert.AreEqual(title, retrievedGatherings[0].Title);
            Assert.AreEqual(description, retrievedGatherings[0].Description);
            Assert.AreEqual(dateOfMeeting, retrievedGatherings[0].DateOfMeeting);
            Assert.AreEqual(organizerEmail, retrievedGatherings[0].OrganizerEmail);
            Assert.AreEqual(topic, retrievedGatherings[0].Topic);
            Assert.IsNotNull(retrievedGatherings[0].Location);
            Assert.AreEqual(location.Latitude, retrievedGatherings[0].Location.Latitude);
            Assert.AreEqual(location.Longitude, retrievedGatherings[0].Location.Longitude);
            Assert.AreEqual(location.Area, retrievedGatherings[0].Location.Area);
            Assert.AreEqual(venue, retrievedGatherings[0].Venue);
            Assert.AreEqual(isVideoMeeting, retrievedGatherings[0].IsVideoGathering);
            Assert.IsTrue(string.IsNullOrEmpty(retrievedGatherings[0].VideoCallLink));

            // Verify Gathering # 2
            Assert.AreEqual(title2, retrievedGatherings[1].Title);
            Assert.AreEqual(description2, retrievedGatherings[1].Description);
            Assert.AreEqual(dateOfMeeting2, retrievedGatherings[1].DateOfMeeting);
            Assert.AreEqual(organizerEmail2, retrievedGatherings[1].OrganizerEmail);
            Assert.AreEqual(topic2, retrievedGatherings[1].Topic);
            Assert.IsNotNull(retrievedGatherings[1].Location);
            Assert.AreEqual(location2.Latitude, retrievedGatherings[1].Location.Latitude);
            Assert.AreEqual(location2.Longitude, retrievedGatherings[1].Location.Longitude);
            Assert.AreEqual(location2.Area, retrievedGatherings[1].Location.Area);
            Assert.AreEqual(venue2, retrievedGatherings[1].Venue);
            Assert.AreEqual(isVideoMeeting2, retrievedGatherings[1].IsVideoGathering);
            Assert.IsFalse(string.IsNullOrEmpty(retrievedGatherings[1].VideoCallLink));

            // Verify Gathering # 3
            Assert.AreEqual(title3, retrievedGatherings[2].Title);
            Assert.AreEqual(description3, retrievedGatherings[2].Description);
            Assert.AreEqual(dateOfMeeting3, retrievedGatherings[2].DateOfMeeting);
            Assert.AreEqual(organizerEmail3, retrievedGatherings[2].OrganizerEmail);
            Assert.AreEqual(topic3, retrievedGatherings[2].Topic);
            Assert.IsNotNull(retrievedGatherings[2].Location);
            Assert.AreEqual(location3.Latitude, retrievedGatherings[2].Location.Latitude);
            Assert.AreEqual(location3.Longitude, retrievedGatherings[2].Location.Longitude);
            Assert.AreEqual(location3.Area, retrievedGatherings[2].Location.Area);
            Assert.AreEqual(venue3, retrievedGatherings[2].Venue);
            Assert.AreEqual(isVideoMeeting3, retrievedGatherings[2].IsVideoGathering);
            Assert.IsFalse(string.IsNullOrEmpty(retrievedGatherings[2].VideoCallLink));

            // Verify Gathering # 4
            Assert.AreEqual(title4, retrievedGatherings[3].Title);
            Assert.AreEqual(description4, retrievedGatherings[3].Description);
            Assert.AreEqual(dateOfMeeting4, retrievedGatherings[3].DateOfMeeting);
            Assert.AreEqual(organizerEmail4, retrievedGatherings[3].OrganizerEmail);
            Assert.AreEqual(topic4, retrievedGatherings[3].Topic);
            Assert.IsNotNull(retrievedGatherings[3].Location);
            Assert.AreEqual(location4.Latitude, retrievedGatherings[3].Location.Latitude);
            Assert.AreEqual(location4.Longitude, retrievedGatherings[3].Location.Longitude);
            Assert.AreEqual(location4.Area, retrievedGatherings[3].Location.Area);
            Assert.AreEqual(venue4, retrievedGatherings[3].Venue);
            Assert.AreEqual(isVideoMeeting4, retrievedGatherings[3].IsVideoGathering);
            Assert.IsTrue(string.IsNullOrEmpty(retrievedGatherings[3].VideoCallLink));
        }
        
        [Test]
        public void GetAllGatheringsByEmailTest_ChecksIfAllTheGatheringsStoredInTheDatabaseWithASpecificEmailAreRetrievedAsExpected_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            // Gathering # 1
            var gatheringRepository = _kernel.Get<IGatheringRepository>();
            Assert.IsNotNull(gatheringRepository);
            string title = "Painters Get Around";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9).Date;
            string organizerEmail = "thisisit@123456789-0.com";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            var gathering = new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build();
            gatheringRepository.Add(gathering);

            // Gathering # 2
            string title2 = "Painters Get Around 2 ";
            string description2 = "We painters are a different lot 2";
            DateTime dateOfMeeting2 = DateTime.Now.AddDays(10).Date;
            string organizerEmail2 = "thisisit@123456789-0.com";
            string topic2 = Gathering.AllTopics()[1];
            Location location2 = new Location(23.41M, 73.39M, "F-7, Islamabad, Pakistan");
            string venue2 = "Attrio Cafe";
            bool isVideoMeeting2 = true;
            string videoCallLink2 = "https://dummygooglemeet.com/12343767docvnwb20t585jhetycghwrffgffd";

            var gathering2 = new Gathering.GatheringBuilder().Title(title2).Description(description2)
                .DateOfMeeting(dateOfMeeting2).OrganizerEmail(organizerEmail2).Topic(topic2).Location(location2)
                .Venue(venue2).IsVideoGathering(isVideoMeeting2).VideoCallLink(videoCallLink2)
                .Build();
            gatheringRepository.Add(gathering2);

            // Gathering # 3
            string title3 = "Painters Get Around 3";
            string description3 = "We painters are a different lot 3";
            DateTime dateOfMeeting3 = DateTime.Now.AddDays(8).Date;
            string organizerEmail3 = "thisisit@123456789-3.com";
            string topic3 = Gathering.AllTopics()[2];
            Location location3 = new Location(23.57M, 73.43M, "F-8, Islamabad, Pakistan");
            string venue3 = "Pizza Hut";
            bool isVideoMeeting3 = true;
            string videoCallLink3 = "https://dummygooglemeet.com/12343767docvnwb20t585jhetycghwrf6654323d";

            var gathering3 = new Gathering.GatheringBuilder().Title(title3).Description(description3)
                .DateOfMeeting(dateOfMeeting3).OrganizerEmail(organizerEmail3).Topic(topic3).Location(location3)
                .Venue(venue3).IsVideoGathering(isVideoMeeting3).VideoCallLink(videoCallLink3)
                .Build();
            gatheringRepository.Add(gathering3);

            // Gathering # 4
            string title4 = "Painters Get Around 4";
            string description4 = "We painters are a different lot 4";
            DateTime dateOfMeeting4 = DateTime.Now.AddDays(12).Date;
            string organizerEmail4 = "thisisit@123456789-0.com";
            string topic4 = Gathering.AllTopics()[3];
            Location location4 = new Location(23.97M, 73.73M, "F-9, Islamabad, Pakistan");
            string venue4 = "Fatima Jinnah Park";
            bool isVideoMeeting4 = false;
            string videoCallLink4 = "";

            var gathering4 = new Gathering.GatheringBuilder().Title(title4).Description(description4)
                .DateOfMeeting(dateOfMeeting4).OrganizerEmail(organizerEmail4).Topic(topic4).Location(location4)
                .Venue(venue4).IsVideoGathering(isVideoMeeting4).VideoCallLink(videoCallLink4)
                .Build();
            gatheringRepository.Add(gathering4);

            // Retrieve the Gathering
            var retrievedGatherings = gatheringRepository.GetAllGatheringsByEmail(organizerEmail);
            Assert.IsNotNull(retrievedGatherings);

            // Verify Gathering # 1
            Assert.AreEqual(title, retrievedGatherings[0].Title);
            Assert.AreEqual(description, retrievedGatherings[0].Description);
            Assert.AreEqual(dateOfMeeting, retrievedGatherings[0].DateOfMeeting);
            Assert.AreEqual(organizerEmail, retrievedGatherings[0].OrganizerEmail);
            Assert.AreEqual(topic, retrievedGatherings[0].Topic);
            Assert.IsNotNull(retrievedGatherings[0].Location);
            Assert.AreEqual(location.Latitude, retrievedGatherings[0].Location.Latitude);
            Assert.AreEqual(location.Longitude, retrievedGatherings[0].Location.Longitude);
            Assert.AreEqual(location.Area, retrievedGatherings[0].Location.Area);
            Assert.AreEqual(venue, retrievedGatherings[0].Venue);
            Assert.AreEqual(isVideoMeeting, retrievedGatherings[0].IsVideoGathering);
            Assert.IsTrue(string.IsNullOrEmpty(retrievedGatherings[0].VideoCallLink));

            // Verify Gathering # 2
            Assert.AreEqual(title2, retrievedGatherings[1].Title);
            Assert.AreEqual(description2, retrievedGatherings[1].Description);
            Assert.AreEqual(dateOfMeeting2, retrievedGatherings[1].DateOfMeeting);
            Assert.AreEqual(organizerEmail2, retrievedGatherings[1].OrganizerEmail);
            Assert.AreEqual(topic2, retrievedGatherings[1].Topic);
            Assert.IsNotNull(retrievedGatherings[1].Location);
            Assert.AreEqual(location2.Latitude, retrievedGatherings[1].Location.Latitude);
            Assert.AreEqual(location2.Longitude, retrievedGatherings[1].Location.Longitude);
            Assert.AreEqual(location2.Area, retrievedGatherings[1].Location.Area);
            Assert.AreEqual(venue2, retrievedGatherings[1].Venue);
            Assert.AreEqual(isVideoMeeting2, retrievedGatherings[1].IsVideoGathering);
            Assert.IsFalse(string.IsNullOrEmpty(retrievedGatherings[1].VideoCallLink));
            
            // Verify Gathering # 4
            Assert.AreEqual(title4, retrievedGatherings[2].Title);
            Assert.AreEqual(description4, retrievedGatherings[2].Description);
            Assert.AreEqual(dateOfMeeting4, retrievedGatherings[2].DateOfMeeting);
            Assert.AreEqual(organizerEmail4, retrievedGatherings[2].OrganizerEmail);
            Assert.AreEqual(topic4, retrievedGatherings[2].Topic);
            Assert.IsNotNull(retrievedGatherings[2].Location);
            Assert.AreEqual(location4.Latitude, retrievedGatherings[2].Location.Latitude);
            Assert.AreEqual(location4.Longitude, retrievedGatherings[2].Location.Longitude);
            Assert.AreEqual(location4.Area, retrievedGatherings[2].Location.Area);
            Assert.AreEqual(venue4, retrievedGatherings[2].Venue);
            Assert.AreEqual(isVideoMeeting4, retrievedGatherings[2].IsVideoGathering);
            Assert.IsTrue(string.IsNullOrEmpty(retrievedGatherings[2].VideoCallLink));
        }

        [Test]
        public void AddNewAttendeeTest_ChecksIfTheANewAttendeeIsAddedAsExpectedToTheDatabase_VerifiesByTheReturnedValue()
        {
            // Get the repository to perform operations
            var gatheringRepository = _kernel.Get<IGatheringRepository>();
            Assert.IsNotNull(gatheringRepository);
            string title = "Painters Get Around";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9).Date;
            string organizerEmail = "thisisit@123456789-0.com";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            var gathering = new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build();
            gatheringRepository.Add(gathering);

            // Retrieve the Gathering
            var retrievedGathering = gatheringRepository.GetInstance(gathering.Id);
            Assert.IsNotNull(retrievedGathering);
            //Assert.AreEqual(0, retrievedGathering.AttendeesEmails.Count);

            string attendeeName1 = "Khaleesi";
            string attendeeEmail1 = "daenerys@targareyan123456789-0.com";
            gatheringRepository.AddNewAttendeeToList(gathering.Id, new Attendee(attendeeName1, attendeeEmail1));

            string attendeeName2 = "Jon Snow";
            string attendeeEmail2 = "aegon@targareyan123456789-0.com";
            gatheringRepository.AddNewAttendeeToList(gathering.Id, new Attendee(attendeeName2, attendeeEmail2));

            string attendeeName3 = "Night King";
            string attendeeEmail3 = "ice@eyes123456789-0.com";
            gatheringRepository.AddNewAttendeeToList(gathering.Id, new Attendee(attendeeName3, attendeeEmail3));

            string attendeeName4 = "Tormund";
            string attendeeEmail4 = "tormund@wildling123456789-0.com";
            gatheringRepository.AddNewAttendeeToList(gathering.Id, new Attendee(attendeeName4, attendeeEmail4));

            // Get the gathering again
            var retrievedGathering2 = gatheringRepository.GetAllGatheringsByEmail(organizerEmail);
            Assert.IsNotNull(retrievedGathering2);
            Assert.AreEqual(4, retrievedGathering2[0].Attendees.Count);

            // Attendee # 1
            Assert.AreEqual(attendeeName1, retrievedGathering2[0].Attendees[0].FullName);
            Assert.AreEqual(attendeeEmail1, retrievedGathering2[0].Attendees[0].Email);

            // Attendee # 2
            Assert.AreEqual(attendeeName2, retrievedGathering2[0].Attendees[1].FullName);
            Assert.AreEqual(attendeeEmail2, retrievedGathering2[0].Attendees[1].Email);

            // Attendee # 3
            Assert.AreEqual(attendeeName3, retrievedGathering2[0].Attendees[2].FullName);
            Assert.AreEqual(attendeeEmail3, retrievedGathering2[0].Attendees[2].Email);

            // Attendee # 4
            Assert.AreEqual(attendeeName4, retrievedGathering2[0].Attendees[3].FullName);
            Assert.AreEqual(attendeeEmail4, retrievedGathering2[0].Attendees[3].Email);
        }
    }
}
