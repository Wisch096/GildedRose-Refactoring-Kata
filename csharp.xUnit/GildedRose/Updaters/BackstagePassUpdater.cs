namespace GildedRoseKata.Updaters;

public class BackstagePassUpdater : ItemUpdaterBase
{
    public override void Update(Item item)
    {
        IncreaseQuality(item, 1);

        if (item.SellIn <= 10)
            IncreaseQuality(item, 1);

        if (item.SellIn <= 5)
            IncreaseQuality(item, 1);
        
        DecreaseSellIn(item);
        
        if (IsExpired(item))
            item.Quality = 0;
    }
}