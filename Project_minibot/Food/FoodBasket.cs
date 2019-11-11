using System.Collections.Generic;

namespace Project_minibot
{
    class FoodBasket
    {
        private List<JapaneseFood> _listFood;

        public FoodBasket(List<JapaneseFood> orderList)
        {
            _listFood = orderList;
        }
 
        public int SumSushi
        {
            get
            {
                int result = new int();
                foreach (JapaneseFood food in _listFood)
                {
                    result += food.Price;
                }

                return result;
            }
        }

        public int SumRolls
        {
            get
            {
                int result = new int();
                foreach (JapaneseFood food in _listFood)
                {
                    result += food.Price;
                }
                
                return result;
            }
        }
    }
}