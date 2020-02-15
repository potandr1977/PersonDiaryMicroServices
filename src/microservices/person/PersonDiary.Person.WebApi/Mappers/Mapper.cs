using System.Collections.Generic;
using System.Linq;
using PersonDiary.Person.Domain.Models;

namespace PersonDiary.Person.WebApi.Mappers
{
    public static class Mapper
    {
        public static PersonModel PersonDtoToModel(Person.Dto.Person personDto)
        {
            return new PersonModel
            {
               Id  = personDto.Id,
               Name = personDto.Name,
               Surname =  personDto.Surname,
               HasFile = personDto.HasFile
            };
        }
        
        public static Dto.Person PersonModelToDto(PersonModel personModel)
        {
            return new Dto.Person
            {
                Id  = personModel.Id,
                Name = personModel.Name,
                Surname =  personModel.Surname,
                HasFile = personModel.HasFile
            };
        }
        
        public static List<Dto.Person> PersonsModelToDto(List<PersonModel> personModels)
        {
            return personModels.Select(PersonModelToDto).ToList();
        }
        
    }
}