using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace World.Models
{
  public class City
  {
    private string _name;
    private int _id;
    private int _population;

    public City (int id, string name, int population)
    {
      _id = id;
      _name = name;
      _population = population;
    }

    public int GetId()
   {
     return _id;
   }

   public void SetId(int newId)
   {
     _id = newId;
   }

   public string GetName()
   {
     return _name;
   }

   public void SetName(string newName)
   {
     _name = newName;
   }

   public int GetPopulation()
   {
     return _population;
   }

   public void SetPopulation(int newPopulation)
   {
     _population = newPopulation;
   }

   public static List<City> GetAll()
   {
     List<City> allCities = new List<City>{};
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT id, name, population FROM city;";
     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

     while (rdr.Read())
     {
       int cityId = rdr.GetInt32(0);
       string cityName = rdr.GetString(1);
       int cityPopulation = rdr.GetInt32(2);
       City newCity= new City (cityId ,cityName, cityPopulation);
       allCities.Add(newCity);
     }

     conn.Close();

     if (conn != null)
     {
       conn.Dispose();
     }

     return allCities;

   }


   public static List<City> SortAscending()
   {
     List<City> allCitiesAscending = new List<City>{};
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT id, name, population FROM city ORDER by population ASC;";
     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

     while (rdr.Read())
     {
       int cityId = rdr.GetInt32(0);
       string cityName = rdr.GetString(1);
       int cityPopulation = rdr.GetInt32(2);
       City newCity= new City (cityId ,cityName, cityPopulation);
       allCitiesAscending.Add(newCity);
     }

     conn.Close();

     if (conn != null)
     {
       conn.Dispose();
     }

     return allCitiesAscending ;

   }

   public static List<City> SortDescending()
   {
     List<City> allCitiesDescending = new List<City>{};
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT id, name, population FROM city ORDER by population DESC;";
     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

     while (rdr.Read())
     {
       int cityId = rdr.GetInt32(0);
       string cityName = rdr.GetString(1);
       int cityPopulation = rdr.GetInt32(2);
       City newCity= new City (cityId ,cityName, cityPopulation);
       allCitiesDescending.Add(newCity);
     }

     conn.Close();

     if (conn != null)
     {
       conn.Dispose();
     }

     return allCitiesDescending ;

   }





 }
}
