﻿using System.Collections.Generic;

namespace PersonDiary.GateWay.Dto
{
    public class GateWayGetPersonsResponseDto
    {
        public List<GateWayPerson> Persons { get; set; }
        public int Count { get; set; }
    }
}
