namespace PersonDiary.Person.Domain.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public bool HasFile { get; set; }
    }
}