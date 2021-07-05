using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.ViewModels
{
    public class IndexViewModel<T> where T: class
    {
        // ParentId is for an object that is dependent on another object 
        public int? ParentId { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int Total { get; set; }
        public List<T> Items { get; set; }

        // True if able to go to next page
        public bool HasNext => ItemsPerPage * (CurrentPage + 1) < Total;

        // True if able to go to previous page
        public bool HasPrev => CurrentPage > 0;

        // Get number of pages
        public int PagesCount => Total % ItemsPerPage == 0 ? Total / ItemsPerPage : (Total / ItemsPerPage) + 1;

        public IndexViewModel()
        {
            CurrentPage = 0;
            Total = 0;
            Items = new List<T>();
        }
    }
}