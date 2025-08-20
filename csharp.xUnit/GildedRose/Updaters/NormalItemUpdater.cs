namespace GildedRoseKata.Updaters;

public class NormalItemUpdater : ItemUpdaterBase
{
    public override void Update(Item item)
    {
        DecreaseSellIn(item);
        DecreaseQuality(item, 1);
        if(IsExpired(item))
            DecreaseQuality(item, 1);
    }
}