using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Code_First 
{
    public class Address : ICity, ICountry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AddressID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int PostalCode { get; set; }

        public string Street { get; set; }

        public void CreateClass(DBConnector context)
        {
            bool integer = false;
            int postalcode = 0;

            Console.Write("Enter Country name: ");
            string? countryname = Console.ReadLine();

            Console.Write("Enter City name: ");
            string? cityname = Console.ReadLine();

            Console.Write("Enter street: ");
            string? street = Console.ReadLine();

            {
                Console.Write("Enter postal code: ");
                string? input = Console.ReadLine();
                // verify that the input is a int
                try
                {
                    postalcode = int.Parse(input);
                    integer = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }

            } while (integer == false) ;


            var addresses = new Address
            {
                CountryName = countryname,
                CityName = cityname,
                Street = street,
                PostalCode = postalcode
            };

            context.Addresses.Add(addresses);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Address created.");
        }
    }
}

