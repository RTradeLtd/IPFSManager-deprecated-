using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using IPFSSystemTray.Properties;
using Newtonsoft.Json;
using Timer = System.Windows.Forms.Timer;

namespace IPFSSystemTray
{
    public partial class Epona : Form
    {

        private string pathExecutable = "ipfs.exe";
        private string jsonFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.ipfs\" +
                                      Properties.Settings.Default.JSONFileName;
        ArrayList elements = new ArrayList();
        public Epona()
        {
            InitializeComponent();
            InitializeListView();
            TryInit();
            TryStartDaemon();
        }

        private Timer timer1;
        private int lastElementCount = -1;

        public void InitTimer(int time)
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = time; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            parseIPFSObjects();
        }

        private void SystemTray_Load(object sender, EventArgs e)
        {
        }

        private void InitializeListView()
        {
            this.objectListView1.ShowImagesOnSubItems = true;
            this.objectListView1.SmallImageList = new ImageList();
            this.objectListView1.SmallImageList.ImageSize = new Size(35, 35);
            this.objectListView1.SmallImageList.Images.Add(Resources.File);
            this.objectListView1.SmallImageList.Images.Add(Resources.Folder);
            this.objectListView1.SmallImageList.Images.Add(Resources.Hyperlink);
            this.objectListView1.SmallImageList.Images.Add(Resources.Open);
            this.objectListView1.SmallImageList.Images.Add(Resources.Remove);
            this.objectListView1.SmallImageList.Images.Add(Resources.ToggleOn);
            this.objectListView1.SmallImageList.Images.Add(Resources.ToggleOff);
            this.objectListView1.CellClick += (sender, args) =>
            {
                switch (args.ColumnIndex)
                {
                    case 2:
                        ToggleActiveState(args.RowIndex);
                        break;
                    case 3:
                        SetHyperLinkToClipboard(args.RowIndex);
                        break;
                    case 4:
                        OpenFolderLocation(args.RowIndex);
                        break;
                    case 5:
                        RemoveFile(args.RowIndex);
                        break;
                };
            };

            this.IconCol.ImageGetter = delegate (object rowObject)
            {
                IPFSElement el = (IPFSElement)rowObject;
                if (el.FileType.Equals(FileType.FILE))
                    return 0;
                else
                    return 1;
            };
            this.ActiveCol.ImageGetter = delegate (object rowObject)
            {
                IPFSElement el = (IPFSElement)rowObject;
                if (el.Active)
                    return 5;
                else
                    return 6;
            };
            this.GetHyperlink.ImageGetter = delegate (object rowObject)
            {
                return 2;
            };
            this.OpenFolder.ImageGetter = delegate (object rowObject)
            {
                return 3;
            };
            this.Remove.ImageGetter = delegate (object rowObject)
            {
                return 4;
            };

            parseIPFSObjects();
            InitTimer(Properties.Settings.Default.RefreshRate);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // if click outside dialog -> Close Dlg
            if (m.Msg == 0x86) //0x86
            {
                if (this.Focused || IPFSSystemTray.IsVisible)
                {
                    if (!this.RectangleToScreen(this.DisplayRectangle).Contains(Cursor.Position))
                    {
                        this.Hide();
                        IPFSSystemTray.IsVisible = false;
                    }
                }
            }
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void SetHyperLinkToClipboard(int index)
        {
            IPFSElement el = (IPFSElement)elements[index];
            Clipboard.SetText("https://ipfs.io/ipfs/" + el.Hash);
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

        private void OpenFolderLocation(int index)
        {
            IPFSElement el = (IPFSElement)elements[index];
            if (el.FileType.Equals(FileType.FOLDER))
            {
                Process.Start("explorer.exe", el.Path);
            }
            else
            {
                Process.Start("explorer.exe", Path.GetDirectoryName(el.Path));
            }
        }

        private void RemoveFile(int index)
        {
            UnpinElement(((IPFSElement)elements[index]).Hash);
            objectListView1.RemoveObject(elements[index]);
            elements.RemoveAt(index);
            if (File.Exists(jsonFilePath))
            {
                string json = JsonConvert.SerializeObject(elements);
                File.WriteAllText(jsonFilePath, json);
            }
        }

        public void ToggleActiveState(int index)
        {
            IPFSElement el = (IPFSElement)elements[index];
            el.Active = !el.Active;
            if (File.Exists(jsonFilePath))
            {
                string json = JsonConvert.SerializeObject(elements);
                File.WriteAllText(jsonFilePath, json);
            }
            this.objectListView1.RefreshObjects(elements);

            if (el.Active)
            {
                AddElement(el.Path);
            }
            else
            {
                UnpinElement(el.Hash);
            }
        }

        private void parseIPFSObjects()
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                List<IPFSElement> tempElements = JsonConvert.DeserializeObject<List<IPFSElement>>(json);
                if (lastElementCount != tempElements.Count)
                {
                    elements = new ArrayList(tempElements);
                    this.objectListView1.SetObjects(elements);
                    lastElementCount = elements.Count;
                }
            }
            else
            {
                File.Create(jsonFilePath);
            }
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
                    if (proc.StandardOutput.ReadLine().Equals("Daemon is ready"))
                    {
                        break;
                    }
                }
            }
        }

        public string AddElement(string filepath)
        {
            return ExecuteCommand("add -r -Q -w " + filepath);
        }

        public string UnpinElement(string hash)
        {
            return ExecuteCommand("pin rm " + hash);
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
                output += proc.StandardOutput.ReadLine() + "\n";
            }

            Console.WriteLine(output);
            if (returnOutput)
            {
                return output;
            }
            return null;
        }
    }
}
