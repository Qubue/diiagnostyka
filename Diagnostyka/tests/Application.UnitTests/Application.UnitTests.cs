using Application.Item;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Application.UnitTests;

public class ItemServiceTests
{
    private readonly ItemService _itemService;
    private readonly IItemRepository _repository = Substitute.For<IItemRepository>();
    private readonly CancellationToken _ct = CancellationToken.None;
    private readonly Fixture _fixture = new ();
    
    public ItemServiceTests()
    {
        _itemService = new ItemService(_repository);
    }

    [Fact]
    public async Task ItemServiceTests_GetAllItems()
    {
        var items = _fixture.CreateMany<Domain.Item>(10).ToList();
        _repository.GetAllAsync(_ct).Returns(items);

        var result = await _itemService.GetAllAsync(_ct);

        result.Should().BeEquivalentTo(items);
    }
}