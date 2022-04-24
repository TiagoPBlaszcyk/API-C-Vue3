using AutoMapper;
using MS.Entities.Events;
using MS.Entities.Login;
using MS.Entities.Person;

namespace MS.Infra.Data.Config
{
    public class MappingConfig
    {
        //TODO: Generic Repository
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
