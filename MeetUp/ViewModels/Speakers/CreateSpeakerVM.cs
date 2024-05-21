namespace MeetUp.ViewModels.Speakers
{
    public class CreateSpeakerVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string FaceBookImage { get; set; }
        public string TwitterImage { get; set; }
        public string InImage { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
