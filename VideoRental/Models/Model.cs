using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;

namespace VideoRental.Models
{
    public class Model : DbContext
    {
        public Model(DbContextOptions<Model> options) : base(options)
        {

        }
    }
}