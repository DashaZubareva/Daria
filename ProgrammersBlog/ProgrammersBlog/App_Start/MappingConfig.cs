using ProgrammersBlog.Models;
using ProgrammersBlogDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.App_Start
{
    public class MappingConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
              cfg.CreateMap<Post, PostModel>()
              .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments)).PreserveReferences();

                cfg.CreateMap<Blog, BlogModel>();
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<Comment, CommentModel>();
        });
           
        }
    }
}