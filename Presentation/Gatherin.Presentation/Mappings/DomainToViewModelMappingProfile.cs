using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Gatherin.Domain.Model.GatherinAggregate;
using Gatherin.Presentation.ViewModels;

namespace Gatherin.Presentation.Mappings
{
    /// <summary>
    /// AutoMapper configuration for mapping for Domain Model objects to ViewModel objects
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Gathering, GatheringViewModel>();
            CreateMap<Attendee, AttendeeViewModel>();
        }

        /// <summary>
        /// Name of the profile
        /// </summary>
        public override string ProfileName { get { return "DomainToViewModelMappingProfile"; } }
    }
}