using FluentValidation;
using LeadManagement.Application.Extensions;
using LeadManagement.Domain.Commands;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace LeadManagement.Application.Handlers
{
    public class AddLeadCommandHandler : IRequestHandler<AddLeadCommand, Guid>
    {
        private readonly IRepository<Lead> _repository;
        private readonly IValidator<AddLeadCommand> _validator;
        private readonly IMapper _mapper;
        private readonly IEventStore _eventStore;


        public AddLeadCommandHandler(IRepository<Lead> repository, IMapper mapper, IValidator<AddLeadCommand> validator, IEventStore eventStore)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(AddLeadCommandHandler));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(AddLeadCommandHandler));
            _validator = validator ?? throw new ArgumentNullException(nameof(AddLeadCommandHandler));
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(UpdateLeadCommandHandler));
        }

        public async Task<Guid> Handle(AddLeadCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var lead = _mapper.Map<Lead>(request);
            await _repository.AddAsync(lead, cancellationToken);

            lead.AdaptWithApply(lead);
            await _eventStore.SaveAsync(lead.DomainEvents, cancellationToken);


            return lead.Id;
        }
    }
}
