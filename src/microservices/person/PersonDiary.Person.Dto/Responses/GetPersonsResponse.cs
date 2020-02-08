﻿using System.Collections.Generic;

namespace PersonDiary.Person.Dto
{
    public class GetPersonsResponseDto
    {
        public List<Person> Persons { get; set; }
        public int Count { get; set; }
    }
}
