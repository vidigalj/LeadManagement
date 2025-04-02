using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Domain.Queries;
using MediatR;

namespace LeadManagement.Application.Handlers
{
    public class GetAllLeadsByStatusQueryHandler : IRequestHandler<GetAllByStatusLeadsQuery, IEnumerable<Lead>>
    {
        private readonly ILeadRepository _repository;

        public GetAllLeadsByStatusQueryHandler(ILeadRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(UpdateLeadCommandHandler));
        }

        public async Task<IEnumerable<Lead>> Handle(GetAllByStatusLeadsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllByStatusAsync(request.Status, cancellationToken);
        }
    }
}
