using Project_minibot.Food;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_minibot.Database
{
    class RollsDatabase : IRolls
    {
        private string _connection= @"Data Source=192.168.100.2,6589\lenovoInstance;Initial Catalog=JapaneseFood;User ID=sa;Password=445566";
        
        public void CreatRolls (Rolls rolls)
        {
            Logger.Logger.LoggerCreat("Project_minibot.Database", "CreatRolls", Logger.Logger.LogStatus.DEBUG, "Создание объекта в базе данных");
            string query = $"insert into Rolls values('{rolls.Name}',{rolls.Price},{rolls.Number})";
            ConnectionAndCommand(query);
        }

        public void UpdateRolls(string name, int price)
        {
            Logger.Logger.LoggerCreat("Project_minibot.Database", "UpdateRolls", Logger.Logger.LogStatus.DEBUG, "Обновление объекта в базе данных");
            string query = $"update Rolls set Rolls.price={price} where Rolls.name='{name}'";
            ConnectionAndCommand(query);
        }

        public void DeleteRolls(string name)
        {
            Logger.Logger.LoggerCreat("ConsoleApp1.Database", "DeleteRolls", Logger.Logger.LogStatus.DEBUG, "Удаление объекта в базе данных");
            string query = $"delete from Rolls where Rolls.name='{name}'";
        }
        
        public List<Rolls>  GetRolls()
        {
            Logger.Logger.LoggerCreat("Project_minibot.Database", "GetRolls", Logger.Logger.LogStatus.DEBUG, "Считывание данных всех объектов из базы данных");
            List<Rolls> rollsList = new List<Rolls>();
            SqlConnection connection = new SqlConnection(connectionString: _connection);
            SqlCommand command = new SqlCommand(cmdText: $"select * from Rolls", connection: connection);
            Rolls rollsGet = new Rolls();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            using (reader)
            {
                while (reader.Read())
                {
                    rollsGet= new Rolls();
                    rollsGet.Number = (int) reader["number"];
                    rollsGet.Name = (string) reader[name: "name"];
                    
                    if (!(reader[name: "price"] is DBNull))
                    {
                        rollsGet.Price = (int) reader[name: "price"];
                    }
                    else
                    {
                        Logger.Logger.LoggerCreat("Project_minibot.Database", "GetRolls", Logger.Logger.LogStatus.ERROR, "Пустая ссылка. Значение NULL");
                        throw new MyExceptionMessage(message: "Попытка использовать пустую ссылку");
                    }
                    rollsList.Add(rollsGet);
                }
            }
            return rollsList;
        }

        public Rolls GetRollsNumber(int numberList)
        {
            Logger.Logger.LoggerCreat("Project_minibot.Database", " GetRollsNumber", Logger.Logger.LogStatus.DEBUG,"Считывание данных объекта из базы данных");
            SqlConnection connection = new SqlConnection(_connection);
            SqlCommand command = new SqlCommand($"select * from Rolls where Rolls.number={numberList}", connection);
            Rolls rollsGet = new Rolls();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    rollsGet.Number = (int) reader["number"];
                    rollsGet.Name = (string) reader["name"];
                    if (!(reader[name: "price"] is DBNull))
                    {
                        rollsGet.Price = (int) reader[name: "price"];
                    }
                    else
                    {
                        Logger.Logger.LoggerCreat("Project_minibot.Database", "GetRollsNumber", Logger.Logger.LogStatus.ERROR,"Пустая ссылка. Значение NULL");
                        throw new MyExceptionMessage(message: "Попытка использовать пустую ссылку");
                    }
                }

                return rollsGet;
            }
        }

        private void ConnectionAndCommand(string query)
        {
            SqlConnection connection =new SqlConnection(_connection);
            SqlCommand command=new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }
    }
}