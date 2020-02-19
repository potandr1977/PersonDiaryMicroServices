using System;

namespace PersonDiary.Person.Dto
{
    public class GateWayUpdateLifeEventDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime Eventdate { get; set; }
        
        public string Personfullname { get; set; }
        
        public int PersonId { get; set; }
    }
}