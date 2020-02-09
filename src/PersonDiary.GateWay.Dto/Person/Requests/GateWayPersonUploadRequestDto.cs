namespace PersonDiary.GateWay.Dto
{
    public class GateWayPersonUploadRequestDto
    {
        public int PersonId { get; set; }
        
        public byte[] Biography { get; set; }
    }
}