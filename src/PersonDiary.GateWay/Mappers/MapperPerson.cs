using System.Linq;
using PersonDiary.GateWay.Dto;
using PersonDiary.Person.Dto;

namespace PersonDiary.GateWay.Mappers
{
    public static class MapperPerson
    {
        public static GetPersonRequestDto GateWayGetPersonDtoToPersonDto(GateWayGetPersonRequestDto gateWayGetPersonRequestDto)
        {
            return new GetPersonRequestDto
            {
               Id  = gateWayGetPersonRequestDto.Id
            };
        }
        public static GetPersonsRequestDto GateWayGetPersonsDtoToPersonDto(GateWayGetPersonsRequestDto gateWayGetPersonsRequestDto)
        {
            return new GetPersonsRequestDto
            {
                 PageNo = gateWayGetPersonsRequestDto.PageNo,
                 PageSize = gateWayGetPersonsRequestDto.PageSize
            };
        }
        public static UpdatePersonRequestDto GateWayUpdatePersonDtoToPersonDto(GateWayUpdatePersonRequestDto gateWayGetPersonsRequestDto)
        {
            return new UpdatePersonRequestDto
            {
                Person = new Person.Dto.Person{
                    Id = gateWayGetPersonsRequestDto.Id,
                    Name = gateWayGetPersonsRequestDto.Name, 
                    Surname = gateWayGetPersonsRequestDto.Surname,
                    HasFile =gateWayGetPersonsRequestDto.HasFile
                }
            };
        }
        public static DeletePersonRequestDto GateWayDeletePersonDtoToPersonDto(GateWayDeletePersonRequestDto gateWayDeletePersonRequestDto)
        {
            return new DeletePersonRequestDto
            {
                Id  = gateWayDeletePersonRequestDto.Id
            };
        }
        public static GateWayGetPersonResponseDto GetPersonDtoToGateWayDto(GetPersonResponseDto getPersonRequestDto)
        {
            return new GateWayGetPersonResponseDto
            {
                Person = new GateWayPerson{
                    Id = getPersonRequestDto.Person.Id,
                    Name = getPersonRequestDto.Person.Name, 
                    Surname = getPersonRequestDto.Person.Surname,
                    HasFile = getPersonRequestDto.Person.HasFile
                }
            };
        }
        public static GateWayGetPersonsResponseDto GetPersonsDtoToGateWayDto(GetPersonsResponseDto gateWayGetPersonsRequestDto)
        {
            return new GateWayGetPersonsResponseDto
            {
                Persons = gateWayGetPersonsRequestDto.Persons.Select(p=> new GateWayPerson()
                {
                    Id = p.Id, 
                    Name = p.Name, 
                    Surname = p.Surname,
                    HasFile = p.HasFile
                }).ToList()
            };
        }
        
    }
}