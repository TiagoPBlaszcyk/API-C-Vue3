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
                config.CreateMap<PersonVO, Person>();
                config.CreateMap<Person, PersonVO>();
            });

            return mappingConfig;
        }
    }
}
