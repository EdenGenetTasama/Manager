using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Manager> managerList = new List<Manager>();
            string sql = "Data Source=DESKTOP-0MT6QTG;Initial Catalog=Manager;Integrated Security=True;Pooling=False";
            //AllManagerIn(sql);

            //AddingNewManger(sql);


            //UpdateInTable(sql);

            DeleteFromTable(2, sql);


        }



        private static void AllManagerIn(string stringConnection)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    string query = "SELECT * FROM Manager";
                    connection.Open();
                    SqlCommand commend = new SqlCommand(query, connection);
                    SqlDataReader reader = commend.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetString(1)} , {reader.GetString(2)} , {reader.GetString(3)},{reader.GetInt32(4)}");
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void AddingNewManger(string stringConnection)
        {
            try
            {

                Console.WriteLine("Enter fullName , yearOfBirth ,email, payment");
                string fullName = Console.ReadLine();
                string yearOfBirth = Console.ReadLine();
                string email = Console.ReadLine();
                int payment = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(stringConnection))
                {

                    string query = $@"INSERT INTO Manager(name , dateOfBirth , email , payment) values('{fullName}','{yearOfBirth}','{email}',{payment})";
                    connection.Open();
                    SqlCommand commend = new SqlCommand(query, connection);
                    int addToTable = commend.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private static void UpdateInTable(string stringConnection)
        {


            Console.WriteLine("Enter fullName , yearOfBirth ,email, payment ,and id");
            string fullName = Console.ReadLine();
            string yearOfBirth = Console.ReadLine();
            string email = Console.ReadLine();
            int payment = int.Parse(Console.ReadLine());
            int idFromUser = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                string query = $@"UPDATE Manager SET name = '{fullName}' , dateBirth = '{yearOfBirth}', email = '{email}', payment = '{payment}' WHERE Id = {idFromUser}";
                SqlCommand commend = new SqlCommand(query, connection);
                int updatToTable = commend.ExecuteNonQuery();
                connection.Close(); 
            }


        }

        private static void DeleteFromTable(int id, string stringConnection)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = $@"DELETE FROM Manager WHERE Id = {id}";
                    SqlCommand commend = new SqlCommand(query, connection);
                    int delete = commend.ExecuteNonQuery();
                    connection.Close();

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

