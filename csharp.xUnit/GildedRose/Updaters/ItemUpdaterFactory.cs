using System;

namespace GildedRoseKata.Updaters;

public class ItemUpdaterFactory
{
    private const string AgedBrie = "Aged Brie";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";

    public static IItemUpdater For(Item item)
    {
        var name = item?.Name ?? string.Empty;

        if (name.Equals(Sulfuras, StringComparison.Ordinal))
            return new SulfurasUpdater();

        if (name.Equals(AgedBrie, StringComparison.Ordinal))
            return new AgedBrieUpdater();

        if (name.Equals(Backstage, StringComparison.Ordinal))
            return new BackstagePassUpdater();


        if (name.Contains("Conjured", StringComparison.OrdinalIgnoreCase) ||
            name.Contains("Conjurado", StringComparison.OrdinalIgnoreCase))
            return new ConjuredUpdater();

        return new NormalItemUpdater();
    }
}