namespace KindergartenManager.Models.Kindergarten
{
    public class ChildDetailsViewModel
    {
        public Guid Id { get; set; }
        public string ChildName { get; set; }
        public DateTime BirthDate { get; set; }
        public string GroupName { get; set; }
        public string TeacherName { get; set; }
        public string ParentContactInfo { get; set; }

        public List<FileToApiViewModel> FileToApiViewModels { get; set; } = new List<FileToApiViewModel>();

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
