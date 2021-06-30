using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.DataAccess.Base;

namespace Test.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }

        #region relationships
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        #endregion
    }
}