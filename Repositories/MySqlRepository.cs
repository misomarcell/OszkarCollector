using Domain.Models;
using Domain.Pages;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class MySqlRepository : IRepository
    {
        MySqlConnection Connection;

        public MySqlRepository()
        {
            Connection = new MySqlConnection("server=127.0.0.1;user id=root;password=root;port=3306;database=oszkar;");
            Connection.Open();
        }

        public int AddRide(RidePage page)
        {

            MySqlCommand command = new MySqlCommand(@"INSERT INTO `rides` (`uri`, `price`, `vehicle_brand`, `vehicle_model`, `vehicle_year`, `driver_username`, `driver_uri`) 
                VALUES (@Uri, @Price, @VehicleBrand, @VehicleModel, @VehicleYear, @DriverUsername, @DriverUri);", Connection);
            command.Parameters.AddWithValue("Uri", page.PageUri.ToString());
            command.Parameters.AddWithValue("Price", page.Price);
            command.Parameters.AddWithValue("VehicleBrand", page.Vehicle.Brand);
            command.Parameters.AddWithValue("VehicleModel", page.Vehicle.Model);
            command.Parameters.AddWithValue("VehicleYear", page.Vehicle.Year);
            command.Parameters.AddWithValue("DriverUsername", page.Driver.Username);
            command.Parameters.AddWithValue("DriverUri", page.Driver.UserPage.ToString());           

            command.ExecuteNonQuery();
            return (int)command.LastInsertedId;
        }

        public List<RidePage> GetRides(int page)
        {
            MySqlCommand command = new MySqlCommand($@"SELECT * FROM `rides` ORDER BY `vehicle_year` DESC LIMIT 25 OFFSET {page * 25};", Connection);
            var result = command.ExecuteReader();

            var rides = new List<RidePage>();
            while(result.Read())
            {
                var ride = new RidePage()
                {
                    Id = result.GetInt32(0),
                    PageUri = new Uri(result.GetString(1)),
                    Price = result.GetString(2),
                    Vehicle = new Vehicle()
                    {
                        Brand = result.GetString(3),
                        Model = result.GetString(4),
                        Year = result.GetInt32(5)
                    },                
                    Driver = new Driver()
                    {
                        Username = result.GetString(6),
                        UserPage = new Uri(result.GetString(7))
                    }
                };

                rides.Add(ride);          
            }

            return rides;
        }

        public RidePage GetRide(string id)
        {
            throw new NotImplementedException();
        }

        public void Clean()
        {
            MySqlCommand command = new MySqlCommand(@"TRUNCATE TABLE `rides`;", Connection);
            command.ExecuteNonQuery();
        }
    }
}