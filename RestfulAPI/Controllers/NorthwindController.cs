using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestfulAPI.Models;

namespace RestfulAPI.Controllers
{
    public class NorthwindController : ApiController
    {


        //action to get info about all customers
        public List<Customer> GetAllCustomers()
        {
            //create the ORM
            NorthwindEntities ORM = new NorthwindEntities();


            // get all customers form ORM
            List<Customer> customerList = ORM.Customers.ToList();


            //Return the list of customers
            return customerList;


        }
        [HttpGet]
        public List<Customer> GetCustomerByCity(string city)
        {
            //create orm
            NorthwindEntities ORM = new NorthwindEntities();

            //http://localhost:port/api/Northwind/GetCustomerByCity?city=Detroit

            //get customers by city

            return ORM.Customers.Where(x => x.City.ToLower() == city.ToLower()).ToList();
            // ORM.Customers.Where(x=>x.City.ToLower() == city.ToLower());

            //return customers by city list



            // return customerByCity;

        }
        public List<string> GetAllCities()
        {
            NorthwindEntities ORM = new NorthwindEntities();
            return ORM.Customers.Where(x => x.City != null).Select(x => x.City).Distinct().ToList();

        }
        [HttpGet]
        public List<Order> GetCustomerOrders(string customerID)
        {
            NorthwindEntities ORM = new NorthwindEntities();

            Customer c = ORM.Customers.Find(customerID);
            if (c != null)
            {

                return c.Orders.ToList();

            }
            return null;    // if the customer is not found. 
        }


        //list all customers by country
        [HttpGet]
        public List<Customer> CustomersByCountry(string country)
        {//http://localhost:port/api/Northwind/CustomersByCountry?country=France
            NorthwindEntities ORM = new NorthwindEntities();

            return ORM.Customers.Where(x => x.Country.ToLower() == country.ToLower()).ToList();

        }
        // action to get the last order made by a specific customer
        [HttpGet]
        public Order GetLastOrderOfCustomer(string customerID)
        {
           NorthwindEntities ORM = new NorthwindEntities();

            Customer c = ORM.Customers.Find(customerID.ToUpper());
            if (c != null)
            {
                List<Order> orders = c.Orders.OrderBy(x => x.OrderDate).ToList();

                return orders[orders.Count - 1];
            }
            return null;
        }


    }
}