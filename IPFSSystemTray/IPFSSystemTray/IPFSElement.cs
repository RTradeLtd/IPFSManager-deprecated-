namespace IPFSSystemTray
{
    class IPFSElement
    {
        public string Name;
        public string Path;
        public string Hash;
        public bool Active;
        public FileType FileType;

        public IPFSElement()
        {

        }

        public IPFSElement(string name, string path, string hash, bool active, FileType filetype)
        {
            Name = name;
            Path = path;
            Hash = hash;
            Active = active;
            FileType = filetype;
        }

    }
}

public enum FileType
{
    FILE,
    FOLDER
}
