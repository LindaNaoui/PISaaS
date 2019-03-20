using AutoMapper;
using PI.Web.Models;
using PI.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI.Web.Mappings
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>();

            CreateMap<RoomViewModel, Room>();
        }
    }
}