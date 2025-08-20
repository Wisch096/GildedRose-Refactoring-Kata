using System.Collections.Generic;
using GildedRoseKata.Updaters;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            var updater = ItemUpdaterFactory.For(item);
            updater.Update(item);
        }
    }
}