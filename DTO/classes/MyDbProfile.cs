using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.classes
{
    public class MyDbProfile : Profile
    {
        public MyDbProfile() 
        {
            CreateMap<DAL.Models.Comment, Comment>()
               .ForMember(dest => dest.User, opt =>
                    opt.MapFrom(src => src.User.Username))
               .ForMember(dest => dest.Discussion, opt =>
                    opt.MapFrom(src => src.Discussion.Title))
               .ReverseMap();

            CreateMap<DAL.Models.Discussion, Discussion>()
                .ForMember(dest => dest.User, opt =>
                     opt.MapFrom(src => src.User.Username))
                .ReverseMap();

            CreateMap<DAL.Models.Subject, Subject>().ReverseMap();

            CreateMap<DAL.Models.User, User>().ReverseMap();
        }
    }
}
