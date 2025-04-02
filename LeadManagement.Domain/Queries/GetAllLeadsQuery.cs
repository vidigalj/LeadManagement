using LeadManagement.Domain.Entities;
using MediatR;

namespace LeadManagement.Domain.Queries;

public class GetAllLeadsQuery : IRequest<IEnumerable<Lead>>;
