using MyInventory2026.src.modules.provider.Domain.valueObject;

namespace MyInventory2026.src.modules.provider.Domain.aggregate;

public class Provider
{
    public ProviderId Id { get; init; }
    public ProviderName Name { get; init; }

    private Provider(ProviderId id, ProviderName name)
    {
        Id = id;
        Name = name;
    }

    public static Provider Create(string id, string name)
    {
        return new Provider(
            ProviderId.Create(id),
            ProviderName.Create(name)
        );
    }
}
