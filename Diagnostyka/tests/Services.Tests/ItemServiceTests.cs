using AutoFixture;
using Domain.Core;
using FluentAssertions;
using NSubstitute;
using Services;
using Xunit;

namespace Application.Tests;

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
        var items = _fixture.CreateMany<Item>(10).ToList();
        _repository.GetAllAsync(_ct).Returns(items);

        var result = await _itemService.GetAllAsync(_ct);

        result.Should().BeEquivalentTo(items);
    }
}