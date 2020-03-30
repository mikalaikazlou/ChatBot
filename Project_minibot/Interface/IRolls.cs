using System.Collections.Generic;
using Project_minibot.Food;

namespace Project_minibot
{
    interface IRolls
    {
        void CreatRolls(Rolls rolls);
        List <Rolls> GetRolls();
        void UpdateRolls(string name, int price);
        void DeleteRolls(string name);
    }
}