using System;
using System.ComponentModel.DataAnnotations;

namespace Gatherin.Presentation.ViewModels
{
    /// <summary>
    /// Model for the creation of the Gathering
    /// </summary>
    public class CreateGatheringFormModel
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
        public CreateGatheringFormModel(string title, string description, DateTime dateOfMeeting, 
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

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Date Of Meeting")]
        public DateTime DateOfMeeting { get; set; }
        public bool IsVideoGathering { get; set; }
        public string VideoCallLink { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Area { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}