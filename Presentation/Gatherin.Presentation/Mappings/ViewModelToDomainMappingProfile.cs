using AutoMapper;
using Gatherin.Domain.Model.GatherinAggregate;
using Gatherin.Presentation.ViewModels;

namespace Gatherin.Presentation.Mappings
{
    /// <summary>
    /// AutoMapper configuration for mapping for ViewModel to Domain model objects
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Initialize
        /// </summary>
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateGatheringFormModel, Gathering>();
            CreateMap<EditGatheringFormModel, Gathering>();
            CreateMap<AttendeeViewModel, Attendee>();
        }

        /// <summary>
        /// Name of the profile
        /// </summary>
        public override string ProfileName { get { return "ViewModelToDomainMappingProfile"; } }
    }
}