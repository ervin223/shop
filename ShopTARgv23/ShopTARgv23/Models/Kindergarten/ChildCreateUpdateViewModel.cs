using Microsoft.AspNetCore.Http;

namespace KindergartenManager.Models.Kindergarten
{
    public class ChildCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string ChildName { get; set; }
        public DateTime BirthDate { get; set; }
        public string GroupName { get; set; }
        public string TeacherName { get; set; }
        public string ParentContactInfo { get; set; }

        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
        public List<FileToApiViewModel> FileToApiViewModels { get; set; } = new List<FileToApiViewModel>();

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
