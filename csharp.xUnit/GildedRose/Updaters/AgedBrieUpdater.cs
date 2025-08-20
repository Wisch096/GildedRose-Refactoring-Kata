namespace GildedRoseKata.Updaters;

public class AgedBrieUpdater : ItemUpdaterBase
{
    public override void Update(Item item)
    {
        DecreaseSellIn(item);
        IncreaseQuality(item);
        if(IsExpired(item))
            IncreaseQuality(item, 1);
    }
}