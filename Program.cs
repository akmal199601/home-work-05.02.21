using System;
using System.Data.SqlClient;

namespace sqlperson
{
    class Program
    {


        static void Main(string[] args)

        {
            {
                string conString = @"Data source =DESKTOP-1B6122J; initial catalog = Person; user=sa:password = Root123.";
                SqlConnection connection = new SqlConnection(conString);
                try
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Вы успешно подключены");
                    }
                    Console.WriteLine(@"Пожалуйста, выберите действие: 
                                 1. Select all
                                 2. Insert
                                 3. Select By Id
                                 4. Update 
                                 5. Delete ");
                    SqlCommand command = connection.CreateCommand();
                    int action = Convert.ToInt32(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            command.CommandText = $"Select * from Person";
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["ID"]}, LastName: {reader["LastName"]}, " +
                                    $"FirstName: {reader["FirstName"]}, MiddleName: {reader["MiddleName"]}, BirthDate: {reader["BirthDate"]}, ");
                            }
                            break;
                        case 2:
                            var LastName = ConsoleReadLineWithText("Введите фамилию");
                            var FirstName = ConsoleReadLineWithText("Введите Имя");
                            var MiddleName = ConsoleReadLineWithText("Введите Отчество");
                            var BirthDate = ConsoleReadLineWithText("Введите Дата рождения");
                            command.CommandText = "Insert into Person(" +
                                "LastName," +
                                "FirstName," +
                                "MiddleName," +
                                "BirthDate ) Values(" +
                                $"'{LastName}'," +
                                $"'{FirstName}'," +
                                $"'{MiddleName}'," +
                                $"'{BirthDate}')"
                                ;
                            var result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                Console.WriteLine("Человек успешно добавлен!");
                            }
                            break;
                        case 3:
                            int amalsozi = Convert.ToInt32(Console.ReadLine());
                            command.CommandText = $"select * from person where id = {amalsozi}";
                            var reader2 = command.ExecuteReader();
                            while (reader2.Read())
                            {
                                Console.WriteLine($"ID: {reader2["ID"]}, LastName: {reader2["LastName"]}, " +
                                    $"FirstName: {reader2["FirstName"]}, MiddleName: {reader2["MiddleName"]}, BirthDate: {reader2["BirthDate"]},");
                            }
                            break;
                        case 4:
                            var updateLastName = ConsoleReadLineWithText("Введите фамилию");
                            var updateFirstName = ConsoleReadLineWithText("Введите Имя");
                            var updateMiddleName = ConsoleReadLineWithText("Введите Отчество");
                            var updateBirthDate = ConsoleReadLineWithText("Введите Дата рождения");
                            var updateID = ConsoleReadLineWithText("Enter ID");
                            command.CommandText = "update Person set " +
                                "LastName = " + $"'{updateLastName}'," +
                                "FirstName =  " + $"'{updateFirstName}'," +
                                "MiddleName = " + $"'{updateMiddleName}'," +
                                "BirthDate = " + $"'{updateBirthDate}'" +
                                "where id = " + $"'{updateID}'"
                            ;
                            var result1 = command.ExecuteNonQuery();
                            if (result1 > 0)
                            {
                                Console.WriteLine("Человек успешно обновлен!");
                            }
                            break;
                        case 5:
                            var delete = ConsoleReadLineWithText("Удалить по ID");
                            command.CommandText = $"delete from Person where id = {delete}";
                            var reader4 = command.ExecuteNonQuery();
                            if (reader4 > 0)
                            {
                                Console.WriteLine("Человек удален успешно");
                            }
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                    Console.WriteLine("Отключено=Разеденено");
                }
                Console.ReadKey();
            }
           

        }

        private static object ConsoleReadLineWithText(string v)
        {
            throw new NotImplementedException();
        }
    }
}


   