using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Domain.Queries;
using MediatR;

namespace LeadManagement.Application.Handlers
{
    public class GetAllLeadsQueryHandler : IRequestHandler<GetAllLeadsQuery, IEnumerable<Lead>>
    {
        private readonly IRepository<Lead> _repository;

        public GetAllLeadsQueryHandler(IRepository<Lead> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(UpdateLeadCommandHandler));
        }

        public async Task<IEnumerable<Lead>> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
