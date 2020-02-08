using PersonDiary.GateWay.Dto;
using PersonDiary.Person.Dto;

namespace PersonDiary.GateWay.Mappers
{
    public static class Mapper
    {
        public static GetPersonRequestDto GateWayGetPersonDtoToPersonDto(GateWayGetPersonDto gateWayGetPersonDto)
        {
            return new GetPersonRequestDto
            {
               Id  = gateWayGetPersonDto.Id
            };
        }
        public static GetPersonsRequestDto GateWayGetPersonsDtoToPersonDto(GateWayGetPersonsDto gateWayGetPersonsDto)
        {
            return new GetPersonsRequestDto
            {
                 PageNo = gateWayGetPersonsDto.PageNo,
                 PageSize = gateWayGetPersonsDto.PageSize
            };
        }
        public static UpdatePersonRequestDto GateWayUpdatePersonDtoToPersonDto(GateWayUpdatePersonDto gateWayGetPersonsDto)
        {
            return new UpdatePersonRequestDto
            {
                Person = new Person.Dto.Person{
                    Id = gateWayGetPersonsDto.Id,
                    Name = gateWayGetPersonsDto.Name, 
                    Surname = gateWayGetPersonsDto.Surname,
                    HasFile =gateWayGetPersonsDto.HasFile
                }
            };
        }
        public static DeletePersonRequestDto GateWayDeletePersonDtoToPersonDto(GateWayDeletePersonDto gateWayDeletePersonDto)
        {
            return new DeletePersonRequestDto
            {
                Id  = gateWayDeletePersonDto.Id
            };
        }
    }
}