using LeadManagement.Domain.Commands;
using LeadManagement.Domain.Entities;
using Mapster;

namespace LeadManagement.Application.Mapping
{
    public class LeadMapping
    {
        public LeadMapping()
        {
            TypeAdapterConfig<AddLeadCommand, Lead>.NewConfig()
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.FullName, src => src.FullName)
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Suburb, src => src.Suburb)
                .Map(dest => dest.Category, src => src.Category)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.CreateDate, src => DateTime.UtcNow)
                .TwoWays();

            TypeAdapterConfig<UpdateLeadCommand, Lead>.NewConfig()
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.FullName, src => src.FullName)
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Suburb, src => src.Suburb)
                .Map(dest => dest.Category, src => src.Category)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.UpdateDate, src => DateTime.UtcNow)
                .TwoWays();
        }
    }
}
