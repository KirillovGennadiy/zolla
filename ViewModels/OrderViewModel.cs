using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.DataAccess.Base;

namespace Test.ViewModels
{
    public class OrderViewModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public int ClientId { get; set; }
    }
}