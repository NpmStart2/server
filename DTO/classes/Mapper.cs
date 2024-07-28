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
<<<<<<< HEAD
            CreateMap<Comment,CommentDto>().ReverseMap();
=======
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

<<<<<<< HEAD
            CreateMap<DAL.Models.User, UserDto>();

            CreateMap<UserDto, DAL.Models.User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

=======
            CreateMap<DAL.Models.User, UserDto>().ReverseMap();
>>>>>>> origin/elishevaBranch
>>>>>>> 6e33b85f7494abd9e8ef81329e5133881dbb66c3
        }
    }
}
