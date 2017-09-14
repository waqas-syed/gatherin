using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gatherin.Domain.Model.GatherinAggregate;
using NUnit.Framework;

namespace Gatherin.Domain.Model.Tests
{
    [TestFixture]
    public class GatheringTestCases
    {
        // All mandatory and optional parameters are provided, so instance should be craeted fine
        [Test]
        public void
            CreatenewGatheringTest_VerifiesThatANewGatheringIsCreatedSuccessfully_VeirifiesByTheSecuredInstance()
        {
            string title = "Painters Get Around";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9);
            string organizerEmail = "thisisit@123456789-0";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            var gathering = new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build();

            Assert.IsNotNull(gathering);
            Assert.AreEqual(title, gathering.Title);
            Assert.AreEqual(description, gathering.Description);
            Assert.AreEqual(dateOfMeeting, gathering.DateOfMeeting);
            Assert.AreEqual(organizerEmail, gathering.OrganizerEmail);
            Assert.AreEqual(topic, gathering.Topic);
            Assert.IsNotNull(gathering.Location);
            Assert.AreEqual(location.Latitude, gathering.Location.Latitude);
            Assert.AreEqual(location.Longitude, gathering.Location.Longitude);
            Assert.AreEqual(location.Area, gathering.Location.Area);
            Assert.AreEqual(venue, gathering.Venue);
            Assert.AreEqual(isVideoMeeting, gathering.IsVideoGathering);
            Assert.AreEqual(videoCallLink, gathering.VideoCallLink);
        }

        // Only mandatory parameters are provided, so instance should be created fine even though there are not 
        // optional parameters provided
        [Test]
        public void
            CreatenNewGatheringSuccessTest_VerifiesThatANewGatheringIsCreatedSuccessfullyWhenProvidedOnlyWithRequiredParameters_VeirifiesByTheSecuredInstance()
        {
            string title = "Painters Get Around";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9);
            string organizerEmail = "thisisit@123456789-0";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");

            var gathering = new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Build();

            Assert.IsNotNull(gathering);
            Assert.AreEqual(title, gathering.Title);
            Assert.AreEqual(description, gathering.Description);
            Assert.AreEqual(dateOfMeeting, gathering.DateOfMeeting);
            Assert.AreEqual(organizerEmail, gathering.OrganizerEmail);
            Assert.AreEqual(topic, gathering.Topic);
            Assert.IsNotNull(gathering.Location);
            Assert.AreEqual(location.Latitude, gathering.Location.Latitude);
            Assert.AreEqual(location.Longitude, gathering.Location.Longitude);
            Assert.AreEqual(location.Area, gathering.Location.Area);
        }

        // Title is missing
        [Test]
        public void
            CreateNewGatheringFailTest_TitleIsMissingSoTheBuildingOfTheInstanceWillThrowAnError_VerifiesByTheRaisedException()
        {
            string title = "";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9);
            string organizerEmail = "thisisit@123456789-0";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

           Assert.That(() => new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build(),
                Throws.TypeOf<NullReferenceException>());
        }

        // DateTime has Min value
        [Test]
        public void
            CreateNewGatheringFailTest_DateOfMeetingIsMissingSoTheBuildingOfTheInstanceWillThrowAnError_VerifiesByTheRaisedException()
        {
            string title = "Badass Gathering";
            string description = "We painters are a different lot";
            //DateTime dateOfMeeting = DateTime.Now.AddDays(9);
            string organizerEmail = "thisisit@123456789-0";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            Assert.That(() => new Gathering.GatheringBuilder().Title(title).Description(description)
                .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build(), 
                Throws.TypeOf<InvalidOperationException>());
        }

        // Organizer Email is missing
        [Test]
        public void
            CreateNewGatheringFailTest_OrganizerEmailIsMissingSoTheBuildingOfTheInstanceWillThrowAnError_VerifiesByTheRaisedException()
        {
            string title = "Badass Gathering";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9);
            string organizerEmail = null;
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            Assert.That(() => new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                    .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                    .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build(),
                Throws.TypeOf<NullReferenceException>());
        }

        // Organizer Email is not in Email format
        [Test]
        public void
            CreateNewGatheringFailTest_OrganizerEmailIsInWrongFormatSoTheBuildingOfTheInstanceWillThrowAnError_VerifiesByTheRaisedException()
        {
            string title = "Badass Gathering";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9);
            string organizerEmail = "abcdefgkgifueoe.com";
            string topic = Gathering.AllTopics()[0];
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            Assert.That(() => new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                    .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                    .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build(),
                Throws.TypeOf<InvalidOperationException>());
        }

        // Topic is missing
        [Test]
        public void
            CreateNewGatheringFailTest_TopicIsMissingSoTheBuildingOfTheInstanceWillThrowAnError_VerifiesByTheRaisedException()
        {
            string title = "Badass Gathering";
            string description = "We painters are a different lot";
            DateTime dateOfMeeting = DateTime.Now.AddDays(9);
            string organizerEmail = "thisisit@123456789-0";
            string topic = null;
            Location location = new Location(23.45M, 73.31M, "F-6, Islamabad, Pakistan");
            string venue = "Chaye Khana";
            bool isVideoMeeting = false;
            string videoCallLink = null;

            Assert.That(() => new Gathering.GatheringBuilder().Title(title).Description(description).DateOfMeeting(dateOfMeeting)
                    .OrganizerEmail(organizerEmail).Topic(topic).Location(location).Venue(venue)
                    .IsVideoGathering(isVideoMeeting).VideoCallLink(videoCallLink).Build(),
                Throws.TypeOf<NullReferenceException>());
        }

        // Latitude is missing
        [Test]
        public void
            CreateNewGatheringFailTest_LatitudeIsMissingSoTheBuildingOfTheInstanceWillThrowAnError_VerifiesByTheRaisedException()
        {
            Assert.That(() => new Location(0, 73.31M, "F-6, Islamabad, Pakistan"),
                Throws.TypeOf<InvalidOperationException>());
        }

        // Longitude is missing
        [Test]
        public void
            CreateNewGatheringFailTest_LongitudeIsMissingSoTheBuildingOfTheInstanceWillThrowAnError_VerifiesByTheRaisedException()
        {
            Assert.That(() => new Location(23.44M, 0M, "F-6, Islamabad, Pakistan"),
                Throws.TypeOf<InvalidOperationException>());
        }

        // Area is missing
        [Test]
        public void
            CreateNewGatheringFailTest_AreaIsMissingSoTheBuildingOfTheInstanceWillThrowAnError_VerifiesByTheRaisedException()
        {
            Assert.That(() => new Location(23.44M, 73.31M, ""),
                Throws.TypeOf<NullReferenceException>());
        }
    }
}
