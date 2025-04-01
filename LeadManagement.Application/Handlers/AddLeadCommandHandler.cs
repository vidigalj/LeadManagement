using LeadManagement.Domain.Commands;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;

namespace LeadManagement.Application.Handlers
{
    public class AddLeadCommandHandler
    {
        private readonly IRepository<Lead> _repository;

        public AddLeadCommandHandler(IRepository<Lead> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(AddLeadCommandHandler));
        }

        public async Task<Guid> Handle(AddLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = new Lead
            {
                FirstName = request.FirstName,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Suburb = request.Suburb,
                Category = request.Category,
                Description = request.Description,
                Price = request.Price,
                Status = request.Status
            };

            await _repository.AddAsync(lead, cancellationToken);

            return lead.Id;
        }
    }
}
