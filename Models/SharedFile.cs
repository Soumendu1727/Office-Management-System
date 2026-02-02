using System;

namespace ClientServerCommunication.Models
{
    public class SharedFile
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public int UploadedBy { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.Now;
    }
}
