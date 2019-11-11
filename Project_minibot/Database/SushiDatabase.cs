using Project_minibot.Food;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_minibot
{
    class SushiDatabase : ISushi
    {
        private string _connection= @"Data Source=192.168.100.2,6589\lenovoInstance;Initial Catalog=JapaneseFood;User ID=sa;Password=445566";
        
        public void CreatSushi(Sushi sushi)
        {
            Logger.Logger.LoggerCreat("Project_minibot", "CreatSushi", Logger.Logger.LogStatus.DEBUG, "Создание объекта в базе данных");
            string query = $"insert into Sushi values({sushi.Number},'{sushi.Name}',{sushi.Price})";
            ConnectionAndCommand(query);
        }

        public void UpdateSushi(string name, int price)
        {
            Logger.Logger.LoggerCreat("Project_minibot", "UpdateSushi", Logger.Logger.LogStatus.DEBUG, "Обновление объекта в базе данных");
            string query = $"update Sushi set Sushi.price={price} where Sushi.name='{name}'";
            ConnectionAndCommand(query);
        }

        public void DeleteSushi(string name)
        {
            Logger.Logger.LoggerCreat("Project_minibot", "DeleteSushi", Logger.Logger.LogStatus.DEBUG, "Удаление объекта в базе данных");
            string query = $"delete from Sushi where Sushi.name='{name}'";
        }
        
        public List<Sushi> GetSushi()
        {
            Logger.Logger.LoggerCreat("Project_minibot", "GetSushi", Logger.Logger.LogStatus.DEBUG, "Считывание данных всех объектов из базы данных");
            List<Sushi> sushiList = new List<Sushi>();
            SqlConnection connection = new SqlConnection(connectionString: _connection);
            SqlCommand command = new SqlCommand(cmdText: $"select * from Sushi", connection: connection);
            Sushi sushiGet = new Sushi();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    sushiGet = new Sushi();
                    sushiGet.Number = (int)reader["number"];
                    sushiGet.Name = (string)reader[name: "name"];

                    if (!(reader[name: "price"] is DBNull))
                    {
                        sushiGet.Price = (int)reader[name: "price"];
                    }
                    else
                    {
                        Logger.Logger.LoggerCreat("Project_minibot.Database", "GetSushi", Logger.Logger.LogStatus.ERROR, "Пустая ссылка. Значение NULL");
                        throw new MyExceptionMessage(message: "Попытка использовать пустую ссылку");
                    }

                    sushiList.Add(sushiGet);
                }
            }

            return sushiList;
        }
        public Sushi GetSushiNumber( int numberList)
        {
            Logger.Logger.LoggerCreat("Project_minibot", "GetSushiNumber", Logger.Logger.LogStatus.DEBUG, "Считывание данных объекта из базы данных");
            SqlConnection connection = new SqlConnection(_connection);
            SqlCommand command = new SqlCommand($"select * from Sushi where Sushi.number={numberList}", connection);
            Sushi sushiGet = new Sushi();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    sushiGet.Number = (int)reader["number"];
                    sushiGet.Name = (string)reader["name"];
                    
                    if (!(reader[name: "price"] is DBNull))
                    {
                        sushiGet.Price = (int)reader[name: "price"];
                    }
                    else
                    {
                        Logger.Logger.LoggerCreat("Project_minibot", "GetSushiNumber", Logger.Logger.LogStatus.ERROR, "Пустая ссылка. Значение NULL");
                        throw new MyExceptionMessage(message: "Попытка использовать пустую ссылку");
                    }
                }
            }

            return sushiGet;
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