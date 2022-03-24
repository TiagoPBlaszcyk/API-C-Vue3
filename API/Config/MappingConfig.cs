using API.Data.ValueObjects;
using API.Model;
using AutoMapper;

namespace API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Person, PersonVO>().ReverseMap();
                config.CreateMap<Person, LoginVO>().ReverseMap();
                config.CreateMap<Events, EventsVO>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
