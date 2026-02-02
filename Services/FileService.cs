using ClientServerCommunication.Models;
using System.Text.Json;

namespace ClientServerCommunication.Services
{
    public class FileService
    {
        private static readonly string _filePath =
            Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "files.json");

        private static List<SharedFile> _files = new();

        static FileService()
        {
            Load();
        }

        private static void Load()
        {
            if (!File.Exists(_filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
                File.WriteAllText(_filePath, "[]");
            }

            var json = File.ReadAllText(_filePath);
            _files = JsonSerializer.Deserialize<List<SharedFile>>(json) ?? new();
        }

        private static void Save()
        {
            var json = JsonSerializer.Serialize(_files, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(_filePath, json);
        }

        // =========================
        // Get files for group
        // =========================
        public List<SharedFile> GetFilesByGroup(int groupId)
        {
            return _files
                .Where(f => f.GroupId == groupId)
                .OrderBy(f => f.UploadedAt)
                .ToList();
        }

        // =========================
        // Add file
        // =========================
        public SharedFile AddFile(SharedFile file)
        {
            file.Id = _files.Count > 0 ? _files.Max(f => f.Id) + 1 : 1;
            file.UploadedAt = DateTime.Now;

            _files.Add(file);
            Save();
            return file;
        }

        // =========================
        // Get file by Id
        // =========================
        public SharedFile? GetFileById(int fileId)
        {
            return _files.FirstOrDefault(f => f.Id == fileId);
        }
    }
}
