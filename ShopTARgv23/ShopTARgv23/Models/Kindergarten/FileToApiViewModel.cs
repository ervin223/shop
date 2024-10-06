namespace KindergartenManager.Models.Kindergarten
{
    public class FileToApiViewModel
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public string ExistingFilePath { get; set; } = string.Empty;
    }
}
