using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.DataAccess.Base;

namespace Test.Models
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }

        #region relationships
        public virtual ICollection<Order> Orders { get; set; }
        #endregion
    }
}