using LeadManagement.Domain.Entities;
using MediatR;

namespace LeadManagement.Domain.Queries;

public record GetAllLeadsQuery : IRequest<IEnumerable<Lead>>;

