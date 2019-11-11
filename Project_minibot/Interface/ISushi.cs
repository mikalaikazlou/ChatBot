using System.Collections.Generic;
using Project_minibot.Food;

namespace Project_minibot
{
    interface ISushi
    {
        void CreatSushi(Sushi sushi);
        List<Sushi> GetSushi();
        void UpdateSushi(string name, int price);
        void DeleteSushi(string name);
    }
}