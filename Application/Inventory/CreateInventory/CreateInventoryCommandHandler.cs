using Application.Inventory.CreateInventory;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace EcommerceShop.Application.Inventory.CreateInventory
{
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Unit>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public CreateInventoryCommandHandler(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = _mapper.Map<Domain.Entities.Inventory>(request);

            await _inventoryRepository.Create(inventory);

            return Unit.Value;
        }
    }
}
