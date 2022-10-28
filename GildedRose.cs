using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (IsDefaultItems(i)) //default products with default rule of decrease quality by 1
                {
                    DefaultItemRules(i);
                }

                if (Items[i].Name == "Aged Brie")
                {
                    AgedBrieRules(i);
                }

                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    BackstagePassesRules(i);
                }
            }
        }

        private void DefaultItemRules(int i)
        {
            if (Items[i].Quality > 0)
                DecreaseQuality(i);
            DecreaseSellIn(i);

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Quality > 0)
                {
                    DecreaseQuality(i);
                }
            }
        }

        private void AgedBrieRules(int i)
        {
            if (Items[i].Quality < 50) IncreaseQuality(i);
            DecreaseSellIn(i);

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Quality < 50) IncreaseQuality(i);
            }
        }
        
        private bool IsDefaultItems(int i)
        {
            return Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[i].Name != "Sulfuras, Hand of Ragnaros";
        }

        private void BackstagePassesRules(int i)
        {
            if (Items[i].Quality < 50) IncreaseQuality(i);
            switch (Items[i].SellIn < 11)
            {
                case true:
                {
                    switch (Items[i].Quality < 50)
                    {
                        case true:
                            IncreaseQuality(i);
                            break;
                    }

                    break;
                }
            }

            switch (Items[i].SellIn < 6)
            {
                case true:
                {
                    switch (Items[i].Quality < 50)
                    {
                        case true:
                            IncreaseQuality(i);
                            break;
                    }

                    

                    break;
                }
            }
            DecreaseSellIn(i);

            if (Items[i].SellIn < 0)
            {
                Items[i].Quality = 0;
            }
        }

        private void IncreaseQuality(int i)
        {
            Items[i].Quality = Items[i].Quality + 1;
        }

        private void DecreaseQuality(int i)
        {
            Items[i].Quality = Items[i].Quality - 1;
        }

        private void DecreaseSellIn(int i)
        {
            Items[i].SellIn = Items[i].SellIn - 1;
        }
    }
}
