namespace StudentPortal.Models.ViewModels
{
    public class AddStudentRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Subscribed { get; set; }
    }
}
