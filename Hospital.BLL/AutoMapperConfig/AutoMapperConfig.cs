using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.AutoMapperConfig
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Clinic, Clinicdto>().ReverseMap();
            CreateMap<ClinicAvailableDay,ClinicAvailableDaydto>().ReverseMap();
            CreateMap<Appointment, Appointmentdto>().ReverseMap();
            CreateMap<Room, Roomdto>().ReverseMap();
            CreateMap<Salary, Salarydto>().ReverseMap();
       //     CreateMap<Raydto, Ray>()
       //.ForMember(dest => dest.RayImage, opt => opt.Ignore());

       //     CreateMap<Ray, RayViewModel>()
       //         .ForMember(dest => dest.RayImageBase64, opt => opt.MapFrom(src =>
       //             src.RayImage != null ? Convert.ToBase64String(src.RayImage) : null));
        }
    }
}
