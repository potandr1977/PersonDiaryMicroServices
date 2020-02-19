﻿using System.Collections.Generic;

namespace PersonDiary.Person.Dto
{
    public class GateWayGetPersonsResponseDto
    {
        public List<GateWayPerson> Persons { get; set; }
        public int Count { get; set; }
    }
}
