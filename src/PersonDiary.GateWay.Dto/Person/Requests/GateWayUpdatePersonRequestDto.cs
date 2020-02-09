using System;

namespace PersonDiary.GateWay.Dto
{
    public class GateWayUpdatePersonRequestDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public bool HasFile { get; set; }
    }
}