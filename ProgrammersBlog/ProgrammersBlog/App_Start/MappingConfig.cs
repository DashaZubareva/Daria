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
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Post, PostModel>());
           // AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Blog, BlogModel>());
           // AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<User, UserModel>());
           // AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentModel>());
        }
    }
}