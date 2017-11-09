using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRental.Models;

namespace VideoRental.ViewModels
{
    public class RandomCustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}