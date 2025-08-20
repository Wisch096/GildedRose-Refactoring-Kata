using Xunit;

namespace GildedRoseKata.Tests
{
    public class GildedRoseRulesTests
    {
        private static Item Item(string name, int sellIn, int quality)
            => new Item { Name = name, SellIn = sellIn, Quality = quality };

        private static void Tick(params Item[] items)
        {
            var app = new GildedRose(items);
            app.UpdateQuality();
        }

        [Fact]
        public void NormalItem_DegradesBy1_BeforeSellDate()
        {
            var item = Item("+5 Dexterity Vest", 10, 20);
            Tick(item);
            Assert.Equal(9, item.SellIn);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void NormalItem_DegradesBy2_AfterSellDate()
        {
            var item = Item("+5 Dexterity Vest", 0, 10);
            Tick(item);
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void Quality_NeverNegative()
        {
            var item = Item("Elixir of the Mongoose", 0, 0);
            Tick(item);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void AgedBrie_IncreasesQuality_UpTo50()
        {
            var item = Item("Aged Brie", 2, 49);
            Tick(item);
            Assert.Equal(1, item.SellIn);
            Assert.Equal(50, item.Quality);

            Tick(item);
            Assert.Equal(0, item.SellIn);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void Backstage_Increase_And_DropToZero_AfterConcert()
        {
            var item = Item("Backstage passes to a TAFKAL80ETC concert", 11, 10);
            Tick(item);
            Assert.Equal(10, item.SellIn);
            Assert.Equal(11, item.Quality);
            
            Tick(item);
            Assert.Equal(9, item.SellIn);
            Assert.Equal(13, item.Quality);
            
            item.SellIn = 5; item.Quality = 20;
            Tick(item);
            Assert.Equal(4, item.SellIn);
            Assert.Equal(23, item.Quality);
            
            item.SellIn = 0; item.Quality = 40;
            Tick(item);
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void Sulfuras_QualityAndSellIn_Unchanged()
        {
            var item = Item("Sulfuras, Hand of Ragnaros", 5, 80);
            Tick(item);
            Assert.Equal(5, item.SellIn);
            Assert.Equal(80, item.Quality);
        }

        [Theory]
        [InlineData("Conjured Mana Cake")]
        [InlineData("Conjurado Mana Cake")]
        public void Conjured_DegradesTwiceAsFast(string name)
        {
            var item = Item(name, 3, 10);
            Tick(item);
            Assert.Equal(2, item.SellIn);
            Assert.Equal(8, item.Quality);
            
            item.SellIn = 0; item.Quality = 10;
            Tick(item);
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(6, item.Quality);
        }
    }
}
