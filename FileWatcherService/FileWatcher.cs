using System;
using System.IO;

namespace FileWatcherService
{
    public class FileWatcher
    {
        public FileWatcher()
        {
            var fileSystemWatcher = new FileSystemWatcher(PathLocation());
            fileSystemWatcher.Created += _fileWatcher_Created;
            fileSystemWatcher.Deleted += _fileWatcher_Deleted;
            fileSystemWatcher.Changed += _fileWatcher_Changed;
            fileSystemWatcher.Renamed += _fileWatcher_Changed;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private string PathLocation()
        {
            string value;
            try
            {
                value = System.Configuration.ConfigurationManager.AppSettings["location"];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return value;
        }

        private void _fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Logger.Log($"File Changed: Path{e.FullPath}, Name: {e.Name}");
        }

        private void _fileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Logger.Log($"File Deleted: Path{e.FullPath}, Name: {e.Name}");
        }

        private void _fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Logger.Log($"File Created: Path{e.FullPath}, Name: {e.Name}");
        }
    }
}