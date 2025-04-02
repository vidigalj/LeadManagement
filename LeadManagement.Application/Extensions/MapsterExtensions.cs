using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Events;
using Mapster;

namespace LeadManagement.Application.Extensions;

public static class MapsterExtensions
{
    public static TDestination AdaptWithApply<TSource, TDestination>(this TSource source, TDestination destination)
        where TDestination : class
    {
        source.Adapt(destination);
        if (destination is Lead lead)
        {
            lead.Apply(new LeadUpdated(
                lead.Id,
                lead.FirstName,
                lead.FullName,
                lead.PhoneNumber,
                lead.Email,
                lead.Suburb,
                lead.Category,
                lead.Description,
                lead.Price,
                lead.Status,
                lead.UpdateDate
                ));
        }
        return destination;
    }
}
