using System;
using System.ComponentModel.DataAnnotations;

namespace Gatherin.Presentation.ViewModels
{
    public class EditGatheringFormModel
    {
        /// <summary>
        /// Create a new gathering
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="dateOfMeeting"></param>
        /// <param name="isVideoGathering"></param>
        /// <param name="videoCallLink"></param>
        /// <param name="area"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public EditGatheringFormModel(string title, string description, DateTime dateOfMeeting,
            bool isVideoGathering, string videoCallLink, string area, decimal latitude, decimal longitude)
        {
            Title = title;
            Description = description;
            DateOfMeeting = dateOfMeeting;
            IsVideoGathering = isVideoGathering;
            VideoCallLink = videoCallLink;
            Area = area;
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Title
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date Of Meeting
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Date Of Meeting")]
        public DateTime DateOfMeeting { get; set; }

        /// <summary>
        /// Is this a video gathering
        /// </summary>
        public bool IsVideoGathering { get; set; }

        /// <summary>
        /// Link to the video call that is taking place
        /// </summary>
        public string VideoCallLink { get; set; }

        /// <summary>
        /// Area where this gathering will take place
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Area { get; set; }

        /// <summary>
        /// Latitude of the location
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Longitude of the location
        /// </summary>
        public decimal Longitude { get; set; }
    }
}