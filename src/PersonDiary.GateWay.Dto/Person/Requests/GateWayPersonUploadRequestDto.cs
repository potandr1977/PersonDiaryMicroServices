namespace PersonDiary.Person.Dto
{
    public class GateWayPersonUploadRequestDto
    {
        public int PersonId { get; set; }
        
        public byte[] Biography { get; set; }
    }
}