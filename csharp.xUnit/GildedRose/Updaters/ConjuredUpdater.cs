namespace GildedRoseKata.Updaters;

public class ConjuredUpdater : ItemUpdaterBase
{
    public override void Update(Item item)
    {
        DecreaseSellIn(item);
        DecreaseQuality(item, 2);
        if (IsExpired(item))
            DecreaseQuality(item, 2);
    }
}