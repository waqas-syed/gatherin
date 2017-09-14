using Gatherin.Common;
using System;
using System.Collections.Generic;

namespace Gatherin.Domain.Model.GatherinAggregate
{
    public class Gathering
    {
        private string _id = Guid.NewGuid().ToString();
        private string _title;
        private DateTime _dateOfMeeting;
        private string _organizerEmail;
        private string _topic;
        private bool _isVideoGathering;
        private string _videoCallLink;
        private Location _location;
        private IList<string> _attendeesEmails = new List<string>();

        /// <summary>
        /// Initialize the gathering with all the elements
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="dateOfMeeting"></param>
        /// <param name="organizerEmail"></param>
        /// <param name="topic"></param>
        /// <param name="isVideoGathering"></param>
        /// <param name="videoCallLink"></param>
        /// <param name="location"></param>
        /// <param name="venue"></param>
        public Gathering(string title, string description, DateTime dateOfMeeting, string organizerEmail, 
            string topic, bool isVideoGathering, string videoCallLink, Location location, string venue)
        {
            Title = title;
            Description = description;
            DateOfMeeting = dateOfMeeting;
            OrganizerEmail = organizerEmail;
            Topic = topic;
            IsVideoGathering = isVideoGathering;
            VideoCallLink = videoCallLink;
            Location = location;
            Venue = venue;
        }

        /// <summary>
        /// Update the car with new values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="dateOfMeeting"></param>
        /// <param name="organizerEmail"></param>
        /// <param name="topic"></param>
        /// <param name="isVideoGathering"></param>
        /// <param name="videoCallLink"></param>
        /// <param name="location"></param>
        /// <param name="venue"></param>
        public void UpdateCar(string name, string description, DateTime dateOfMeeting, string organizerEmail,
            string topic, bool isVideoGathering, string videoCallLink, Location location, string venue)
        {
            _title = name;
            Description = description;
            DateOfMeeting = dateOfMeeting;
            OrganizerEmail = organizerEmail;
            Topic = topic;
            IsVideoGathering = isVideoGathering;
            VideoCallLink = videoCallLink;
            Location = location;
            Venue = venue;
        }

        /// <summary>
        /// Add a new member to the Gathering
        /// </summary>
        public void AddNewAttendeeToTheGathering(string email)
        {
            if (!_attendeesEmails.Contains(email))
            {
                _attendeesEmails.Add(email);
            }
        }

        /// <summary>
        /// All the topics supported on this platform
        /// </summary>
        public static List<string> AllTopics()
        {
            return new List<string>()
            {
                "Politics",
                "Sports",
                "Software",
                "Science",
                "Arts & Crafts"
            };
        }

        /// <summary>
        /// Id for the gathring
        /// </summary>
        public string Id { get { return _id; } }

        /// <summary>
        /// Name of the gathering
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                Assertion.AssertStringNotNullorEmpty(value);
                _title = value;
            }
        }

        /// <summary>
        /// Description for the gathering
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// When the eeting would take place
        /// </summary>
        public DateTime DateOfMeeting { get { return _dateOfMeeting; }
            private set
            {
                Assertion.AssertDateIsNotMinValue(value);
                _dateOfMeeting = value;
            }
        }

        /// <summary>
        /// Email of the organizer
        /// </summary>
        public string OrganizerEmail
        {
            get { return _organizerEmail; }
            private set
            {
                Assertion.AssertStringNotNullorEmpty(value);
                Assertion.IsEmailValid(value);
                _organizerEmail = value;
            }
        }

        /// <summary>
        /// The topic that will be of the gathering
        /// </summary>
        public string Topic
        {
            get { return _topic; }
            private set
            {
                Assertion.AssertStringNotNullorEmpty(value);
                _topic = value;
            }
        }

        /// <summary>
        /// Is this a video gathering
        /// </summary>
        public bool IsVideoGathering
        {
            get { return _isVideoGathering; }
            private set { _isVideoGathering = value; }
        }

        /// <summary>
        /// Link to video cal, like Google Meet or Hangouts
        /// </summary>
        public string VideoCallLink
        {
            get { return _videoCallLink; }
            private set
            {
                if (_isVideoGathering)
                {
                    Assertion.AssertStringNotNullorEmpty(value);
                    _videoCallLink = value;
                }
            }
        }

        /// <summary>
        /// Location
        /// </summary>
        public Location Location
        {
            get { return _location; }
            private set
            {
                if (value != null)
                {
                    _location = value;
                }
            }
        }

        /// <summary>
        /// Venue like a restaurant or a Coffee Shop
        /// </summary>
        public string Venue { get; private set; }

        /// <summary>
        /// lsit of emails for the peope who are attending our event
        /// </summary>
        public IList<string> AttendeesEmails
        {
            get { return _attendeesEmails; } 
        }

        /// <summary>
        /// Builder pattern inducer for the Gathering aggregate
        /// </summary>
        public class GatheringBuilder
        {
            private string _title;
            private string _description;
            private DateTime _dateOfMeeting;
            private string _organizerEmail;
            private string _topic;
            private bool _isVideoGathering;
            private string _videoCallLink;
            private Location _location;
            private string _venue;

            /// <summary>
            /// Title
            /// </summary>
            /// <returns></returns>
            public GatheringBuilder Title(string title)
            {
                _title = title;
                return this;
            }

            /// <summary>
            /// Description
            /// </summary>
            /// <param name="description"></param>
            /// <returns></returns>
            public GatheringBuilder Description(string description)
            {
                _description = description;
                return this;
            }

            /// <summary>
            /// Date of the meeting
            /// </summary>
            /// <param name="dateOfMeeting"></param>
            /// <returns></returns>
            public GatheringBuilder DateOfMeeting(DateTime dateOfMeeting)
            {
                _dateOfMeeting = dateOfMeeting;
                return this;
            }
            
            /// <summary>
            /// Email of the the organizer of the gathering
            /// </summary>
            /// <param name="organizerEmail"></param>
            /// <returns></returns>
            public GatheringBuilder OrganizerEmail(string organizerEmail)
            {
                _organizerEmail = organizerEmail;
                return this;
            }

            /// <summary>
            /// Topic of the gathering
            /// </summary>
            /// <param name="topic"></param>
            /// <returns></returns>
            public GatheringBuilder Topic(string topic)
            {
                _topic = topic;
                return this;
            }

            /// <summary>
            /// Will the gathering take place on the video
            /// </summary>
            /// <param name="isVideoGathering"></param>
            /// <returns></returns>
            public GatheringBuilder IsVideoGathering(bool isVideoGathering)
            {
                _isVideoGathering = isVideoGathering;
                return this;
            }

            /// <summary>
            /// Link of the video meeting
            /// </summary>
            /// <param name="videoCallLink"></param>
            /// <returns></returns>
            public GatheringBuilder VideoCallLink(string videoCallLink)
            {
                _videoCallLink = videoCallLink;
                return this;
            }

            /// <summary>
            /// Location
            /// </summary>
            /// <param name="location"></param>
            /// <returns></returns>
            public GatheringBuilder Location(Location location)
            {
                _location = location;
                return this;
            }

            /// <summary>
            /// Venue of the gathering
            /// </summary>
            /// <param name="venue"></param>
            /// <returns></returns>
            public GatheringBuilder Venue(string venue)
            {
                _venue = venue;
                return this;
            }

            /// <summary>
            /// Build the instance for Gathering
            /// </summary>
            /// <returns></returns>
            public Gathering Build()
            {
                return new Gathering(_title, _description, _dateOfMeeting, _organizerEmail, _topic,
                    _isVideoGathering, _videoCallLink, _location, _venue);
            }
        }
    }
}
