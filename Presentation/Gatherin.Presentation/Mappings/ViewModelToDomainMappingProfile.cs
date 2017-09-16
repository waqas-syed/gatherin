using AutoMapper;
using Gatherin.Domain.Model.GatherinAggregate;
using Gatherin.Presentation.ViewModels;

namespace Gatherin.Presentation.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateGatheringFormModel, Gathering>();
            CreateMap<EditGatheringFormModel, Gathering>();
            CreateMap<AttendeeViewModel, Attendee>();
        }

        public override string ProfileName { get { return "ViewModelToDomainMappingProfile"; } }
    }
}