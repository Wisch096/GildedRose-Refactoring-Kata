using System;

namespace GildedRoseKata.Updaters;

public abstract class ItemUpdaterBase : IItemUpdater
{
    public new abstract void Update(Item item);

    protected static void DecreaseSellIn(Item item) => item.SellIn--;

    protected static void IncreaseQuality(Item item, int amount = 1)
    {
        item.Quality = Math.Min(50, item.Quality + amount);
    }

    protected static void DecreaseQuality(Item item, int amount = 1)
    {
        item.Quality = Math.Max(0, item.Quality - amount);
    }

    protected static bool IsExpired(Item item) => item.SellIn < 0;
}
