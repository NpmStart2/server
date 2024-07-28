using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.classes
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<DAL.Models.Comment, CommentDto>()
                          .ForMember(dest => dest.User, opt =>
                               opt.MapFrom(src => src.User.Username))
                          .ForMember(dest => dest.Discussion, opt =>
                               opt.MapFrom(src => src.Discussion.Title))
                          .ReverseMap();

            CreateMap<DAL.Models.Discussion, DiscussionDto>()
                .ForMember(dest => dest.User, opt =>
                     opt.MapFrom(src => src.User.Username))
                .ReverseMap();

            CreateMap<DAL.Models.Subject, SubjectDto>().ReverseMap();

            CreateMap<DAL.Models.User, UserDto>().ReverseMap();
        }
    }
}
