using LeadManagement.Application.Extensions;
using LeadManagement.Domain.Commands;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace LeadManagement.Application.Handlers
{
    public class UpdateLeadCommandHandler : IRequestHandler<UpdateLeadCommand, Unit>
    {
        private readonly IRepository<Lead> _repository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IEventStore _eventStore;
        private const decimal DISCOUNT = 0.9m;
        private const decimal MIN_PRICE_DISCOUNT = 500;


        public UpdateLeadCommandHandler(IRepository<Lead> repository, IEmailService emailService, IMapper mapper, IEventStore eventStore)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(UpdateLeadCommandHandler));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(UpdateLeadCommandHandler));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(UpdateLeadCommandHandler));
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(UpdateLeadCommandHandler));
        }

        public async Task<Unit> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetAsync(request.Id, cancellationToken);

            if (lead == null)
            {
                throw new Exception("Lead not found");
            }
            var leadEntity = _mapper.Map<Lead>(request);

            leadEntity.ApplyDiscount(DISCOUNT, MIN_PRICE_DISCOUNT);
            await _repository.UpdateAsync(leadEntity, cancellationToken);

            leadEntity.AdaptWithApply(leadEntity);
            await _eventStore.SaveAsync(leadEntity.DomainEvents, cancellationToken);
            await _emailService.SendEmailAsync(leadEntity.Email, $"Lead {leadEntity.Id} Accepted", $"Lead has been accepted and his prize will be updated from {request.Price} to {leadEntity.Price}");

            return Unit.Value;
        }
    }
}
