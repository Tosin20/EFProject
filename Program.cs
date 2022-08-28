using System;
using System.Linq;
using EFProject.Models;
using EntityFramework.Exceptions.Common;
using Microsoft.Data.SqlClient;

namespace EFProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           // EFCoreInsert();
           // EFCoreUpdate();
            EFCoreDelete();
        }

        static void EFCoreInsert()
        {
            try
            {
                var db = new airportdbContext();
                var airp = new Passenger();
                airp.passId = 1;
                airp.Dob = new DateTime(1990, 12, 12);
                airp.FirstName = "Seun";
                airp.LastName = "Tayo";
                airp.PhoneNo = "08042476221";
                airp.Class = "Economy";
                db.Passengers.Add(airp);
                var noOfInsertRows = db.SaveChanges();
                Console.WriteLine($"{noOfInsertRows} row(s) was inserted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }

        static void EFCoreUpdate()
        {
            try
            {
                var db = new airportdbContext();
            var npassenger=    db.Passengers.Where(x => x.passId == 0).FirstOrDefault();
            npassenger.FirstName = "Tayo";
            npassenger.Class = "Business";

            db.Update(npassenger);
          var updatedRows =  db.SaveChanges();
          Console.WriteLine($"{updatedRows} row(s) was updated successfully");

            }
            catch (UniqueConstraintException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }

        static void EFCoreDelete()
        {
            try
            {
                var db = new airportdbContext();
                var npassenger = db.Passengers.Where(x => x.passId == 0).FirstOrDefault();
                

                db.Passengers.Remove(npassenger);
                var deletedRow = db.SaveChanges();
                Console.WriteLine($"{deletedRow} row(s) was deleted successfully");

            }
            catch (UniqueConstraintException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }
       
    }
}
