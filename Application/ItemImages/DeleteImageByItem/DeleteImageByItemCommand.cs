using MediatR;

public class DelateImageByItemCommand : IRequest<Unit>
{
    public string ItemSku { get; set; } = default!;
    public DelateImageByItemCommand(string itemSku)
    {
        ItemSku = itemSku;
    }
}