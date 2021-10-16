using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AssetMan.UseCases.Helpers
{
    public class MapperUtils
    {
        public static IMapper Mapper()
        {
            MapperConfiguration config;
            IMapper mapper;


            config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();

            return mapper;
        }
        
    }
}
