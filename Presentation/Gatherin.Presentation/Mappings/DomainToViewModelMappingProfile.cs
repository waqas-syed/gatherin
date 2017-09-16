using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Gatherin.Domain.Model.GatherinAggregate;
using Gatherin.Presentation.ViewModels;

namespace Gatherin.Presentation.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Gathering, GatheringViewModel>();
            CreateMap<Attendee, AttendeeViewModel>();
        }

        public override string ProfileName { get { return "DomainToViewModelMappingProfile"; } }
    }
}