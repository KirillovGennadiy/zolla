﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Models;
using Test.ViewModels;

namespace Test.App_Start.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Client, ClientViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}