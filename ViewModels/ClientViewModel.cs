using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Test.DataAccess.Base;
using Test.Models;

namespace Test.ViewModels
{
    public class ClientViewModel : IEntity
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
    }
}