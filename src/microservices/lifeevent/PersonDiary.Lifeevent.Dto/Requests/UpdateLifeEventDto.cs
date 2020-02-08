using System;

namespace PersonDiary.Lifeevent.Dto
{
    public class UpdateLifeEventDto 
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime Eventdate { get; set; }
        
        public string Personfullname { get; set; }
        
        public int PersonId { get; set; }
    }
}
