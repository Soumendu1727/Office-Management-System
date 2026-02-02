namespace ClientServerCommunication.Models
{
    public class ChatItem
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SenderId { get; set; }

        public string? MessageText { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }

        public DateTime SentAt { get; set; }

        public bool IsFile => FileName != null;
    }
}