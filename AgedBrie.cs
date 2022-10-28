using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GildedRose
{
    public class AgedBrie 
    {
        public void UpdateItem(Item item)
        {
            if (item.Quality < 50) IncreaseQuality(item);
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                if (item.Quality < 50) IncreaseQuality(item);
            }
        }

        private void IncreaseQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }

        private void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}
