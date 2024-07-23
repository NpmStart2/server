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
            CreateMap<Comment,CommentDto>().ReverseMap();
        }
    }
}
