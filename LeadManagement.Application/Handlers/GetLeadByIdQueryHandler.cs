using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Domain.Queries;
using MediatR;

namespace LeadManagement.Application.Handlers
{
    public class GetLeadByIdQueryHandler : IRequestHandler<GetLeadByIdQuery, Lead>
    {
        private readonly IRepository<Lead> _repository;

        public GetLeadByIdQueryHandler(IRepository<Lead> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(UpdateLeadCommandHandler));
        }

        public async Task<Lead> Handle(GetLeadByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.Id, cancellationToken);
        }
    }
}
