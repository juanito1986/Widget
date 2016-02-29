using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RepositoryMvcApplication.Entities;
using RepositoryMvcApplication.Models;

namespace RepositoryMvcApplication
{
    public class Mapping : IMapping
    {
        public IMapper ConfigureMapper()
        {
            MapperConfiguration MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Widget, WidgetDto>().ReverseMap();
            });
            IMapper mapper = MapperConfiguration.CreateMapper();
            return mapper;
        }

        public IMapper ConfigureReverseMapper()
        {
            MapperConfiguration MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WidgetDto, Widget>().ReverseMap();
            });
            IMapper mapper = MapperConfiguration.CreateMapper();
            return mapper;
        }
    }
}