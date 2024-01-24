using Application.Inventory.Dtos;
using MediatR;

namespace Application.Inventory.CreateInventory
{
    public class CreateInventoryCommand : InventoryDto, IRequest<Unit>
    {
    }
}