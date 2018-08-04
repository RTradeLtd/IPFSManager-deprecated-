using System;
using System.Diagnostics;
using System.Linq;

namespace WindowsIPFSController
{

    class Program
    {
        private static string pathExecutable = "ipfs.exe";
        private static IPFSManager ipfs;
        public static bool DEBUG;

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                args = Escape(args);
                string paths = "";
                foreach (string path in args)
                {
                    if (!path.Equals("--debug"))
                    {
                        paths += path + " ";
                    }
                    else
                    {
                        DEBUG = true;
                        Console.WriteLine("DEBUG MODE: ON");
                    }
                }
                HandleNewItem(paths.Trim());
            }
            else
            {
                Console.WriteLine("Usage: WindowsIPFSController.exe file/folder [file/folder] ...");
            }
        }

        static string[] Escape(string[] args)
        {
            return args.Select(s => s.Contains(" ") ? $"\"{s}\"" : s).ToArray();
        }

        static void HandleNewItem(string path)
        {
            ipfs = new IPFSManager(pathExecutable);
            ipfs.TryInit();
            ipfs.TryStartDaemon();
            ipfs.CopyPathToClipboard(ipfs.AddElement(path));
        }
    }
}
