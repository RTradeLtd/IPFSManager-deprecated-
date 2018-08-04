using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsIPFSController
{
    class IPFSManager
    {
        private string pathExecutable;
        ArrayList elements = new ArrayList();
        private string jsonFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.ipfs\" +
                                      Properties.Settings.Default.JSONFileName;

        public IPFSManager(string exePath)
        {
            pathExecutable = exePath;
        }

        public void TryInit()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.ipfs"))
            {
                ExecuteCommand("init");
            }
        }

        public void TryStartDaemon()
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.ipfs\repo.lock"))
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = pathExecutable,
                        Arguments = "daemon",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    if (Program.DEBUG)
                    {
                        Console.WriteLine(line);
                    }
                    if (line.Equals("Daemon is ready"))
                    {
                        break;
                    }
                }
            }
        }

        public string AddElement(string filepath)
        {
            string hash = ExecuteCommand("add -r -Q -w " + filepath);
            FileType ft;
            FileAttributes attr = File.GetAttributes(filepath);

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                ft = FileType.FOLDER;
            }
            else
            {
                ft = FileType.FILE;
            }
            elements.Add(new IPFSElement(Path.GetFileName(filepath), filepath, hash, true, ft));
            if (!File.Exists(jsonFilePath))
            {
                File.Create(jsonFilePath);
            }
            string json = JsonConvert.SerializeObject(elements);
            File.WriteAllText(jsonFilePath, json);
            return hash;
        }

        public void CopyPathToClipboard(string hash)
        {
            Clipboard.SetText(ConvertHashToPath(hash));
            var notification = new System.Windows.Forms.NotifyIcon()
            {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
                BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                BalloonTipText = "Link copied to Clipboard"
            };

            // Display for 5 seconds.
            notification.ShowBalloonTip(2000);
            Thread.Sleep(2500);

            // The notification should be disposed when you don't need it anymore,
            // but doing so will immediately close the balloon if it's visible.
            notification.Dispose();
        }

        private string ConvertHashToPath(string hash)
        {
            if (hash.Equals(""))
            {
                if (Program.DEBUG)
                {
                    Console.WriteLine("Empty hash...");
                }
                return "";
            }
            return "https://ipfs.io/ipfs/" + hash;
        }

        private string ExecuteCommand(string args, bool returnOutput = true)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = pathExecutable,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            string output = "";
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                if (Program.DEBUG)
                {
                    Console.WriteLine(line);
                }
                output += line + "\n";
            }

            if (returnOutput)
            {
                return output;
            }
            return null;
        }
    }
}
