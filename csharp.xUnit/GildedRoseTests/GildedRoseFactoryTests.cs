using GildedRoseKata.Updaters;
using Xunit;

namespace GildedRoseKata.Tests;

public class GildedRoseFactoryTests
{
    [Theory]
    [InlineData("Aged Brie", typeof(AgedBrieUpdater))]
    [InlineData("Sulfuras, Hand of Ragnaros", typeof(SulfurasUpdater))]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassUpdater))]
    [InlineData("Conjured Mana Cake", typeof(ConjuredUpdater))]
    [InlineData("Elixir of the Mongoose", typeof(NormalItemUpdater))]
    public void Factory_ReturnsExpectedUpdater(string name, System.Type expectedType)
    {
        var item = new Item { Name = name, SellIn = 1, Quality = 1 };
        var updater = ItemUpdaterFactory.For(item);
        Assert.IsType(expectedType, updater);
    }
}