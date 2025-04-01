using LeadManagement.Domain.Commands;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using MediatR;

namespace LeadManagement.Application.Handlers
{
    public class UpdateLeadCommandHandler : IRequestHandler<UpdateLeadCommand>
    {
        private readonly IRepository<Lead> _repository;

        public UpdateLeadCommandHandler(IRepository<Lead> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(UpdateLeadCommandHandler));
        }

        public async Task<Unit> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetAsync(request.Id, cancellationToken);

            if (lead == null)
            {
                throw new Exception("Lead not found");
            }

            lead.FirstName = request.FirstName;
            lead.FullName = request.FullName;
            lead.PhoneNumber = request.PhoneNumber;
            lead.Email = request.Email;
            lead.Suburb = request.Suburb;
            lead.Category = request.Category;
            lead.Description = request.Description;
            lead.Price = request.Price;
            lead.Status = request.Status;
            lead.UpdateDate = DateTime.UtcNow;

            await _repository.UpdateAsync(lead, cancellationToken);

            return Unit.Value;
        }
    }
}
