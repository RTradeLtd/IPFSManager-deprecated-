namespace IPFSSystemTray
{
    partial class Epona
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.IconCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NameCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ActiveCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.GetHyperlink = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OpenFolder = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Remove = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.IconCol);
            this.objectListView1.AllColumns.Add(this.NameCol);
            this.objectListView1.AllColumns.Add(this.ActiveCol);
            this.objectListView1.AllColumns.Add(this.GetHyperlink);
            this.objectListView1.AllColumns.Add(this.OpenFolder);
            this.objectListView1.AllColumns.Add(this.Remove);
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.BackColor = System.Drawing.SystemColors.Window;
            this.objectListView1.CausesValidation = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IconCol,
            this.NameCol,
            this.ActiveCol,
            this.GetHyperlink,
            this.OpenFolder,
            this.Remove});
            this.objectListView1.CopySelectionOnControlC = false;
            this.objectListView1.CopySelectionOnControlCUsesDragSource = false;
            this.objectListView1.HasCollapsibleGroups = false;
            this.objectListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.objectListView1.HeaderUsesThemes = false;
            this.objectListView1.IsSearchOnSortColumn = false;
            this.objectListView1.Location = new System.Drawing.Point(1, -1);
            this.objectListView1.MultiSelect = false;
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.SelectAllOnControlA = false;
            this.objectListView1.SelectColumnsMenuStaysOpen = false;
            this.objectListView1.SelectColumnsOnRightClick = false;
            this.objectListView1.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.objectListView1.ShowFilterMenuOnRightClick = false;
            this.objectListView1.ShowGroups = false;
            this.objectListView1.ShowHeaderInAllViews = false;
            this.objectListView1.ShowSortIndicators = false;
            this.objectListView1.Size = new System.Drawing.Size(800, 450);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.TabStop = false;
            this.objectListView1.UpdateSpaceFillingColumnsWhenDraggingColumnDivider = false;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFilterIndicator = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // IconCol
            // 
            this.IconCol.AspectName = "";
            this.IconCol.AutoCompleteEditor = false;
            this.IconCol.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.IconCol.Groupable = false;
            this.IconCol.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IconCol.Hideable = false;
            this.IconCol.IsEditable = false;
            this.IconCol.Searchable = false;
            this.IconCol.ShowTextInHeader = false;
            this.IconCol.Sortable = false;
            this.IconCol.Text = "";
            this.IconCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IconCol.UseFiltering = false;
            this.IconCol.Width = 40;
            // 
            // NameCol
            // 
            this.NameCol.AspectName = "Name";
            this.NameCol.AutoCompleteEditor = false;
            this.NameCol.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.NameCol.Groupable = false;
            this.NameCol.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameCol.Hideable = false;
            this.NameCol.IsEditable = false;
            this.NameCol.MaximumWidth = 135;
            this.NameCol.MinimumWidth = 135;
            this.NameCol.Searchable = false;
            this.NameCol.ShowTextInHeader = false;
            this.NameCol.Sortable = false;
            this.NameCol.Text = "Name";
            this.NameCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameCol.UseFiltering = false;
            this.NameCol.Width = 135;
            // 
            // ActiveCol
            // 
            this.ActiveCol.AspectName = "";
            this.ActiveCol.AutoCompleteEditor = false;
            this.ActiveCol.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ActiveCol.Groupable = false;
            this.ActiveCol.Hideable = false;
            this.ActiveCol.IsEditable = false;
            this.ActiveCol.MaximumWidth = 50;
            this.ActiveCol.MinimumWidth = 50;
            this.ActiveCol.Searchable = false;
            this.ActiveCol.ShowTextInHeader = false;
            this.ActiveCol.Sortable = false;
            this.ActiveCol.Text = "";
            this.ActiveCol.UseFiltering = false;
            this.ActiveCol.Width = 50;
            // 
            // GetHyperlink
            // 
            this.GetHyperlink.AspectName = "";
            this.GetHyperlink.AutoCompleteEditor = false;
            this.GetHyperlink.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.GetHyperlink.Groupable = false;
            this.GetHyperlink.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GetHyperlink.Hideable = false;
            this.GetHyperlink.IsEditable = false;
            this.GetHyperlink.MaximumWidth = 50;
            this.GetHyperlink.MinimumWidth = 50;
            this.GetHyperlink.Searchable = false;
            this.GetHyperlink.ShowTextInHeader = false;
            this.GetHyperlink.Sortable = false;
            this.GetHyperlink.Text = "";
            this.GetHyperlink.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GetHyperlink.UseFiltering = false;
            this.GetHyperlink.Width = 50;
            // 
            // OpenFolder
            // 
            this.OpenFolder.AspectName = "";
            this.OpenFolder.AutoCompleteEditor = false;
            this.OpenFolder.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.OpenFolder.Groupable = false;
            this.OpenFolder.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OpenFolder.Hideable = false;
            this.OpenFolder.IsEditable = false;
            this.OpenFolder.MaximumWidth = 50;
            this.OpenFolder.MinimumWidth = 50;
            this.OpenFolder.Searchable = false;
            this.OpenFolder.ShowTextInHeader = false;
            this.OpenFolder.Sortable = false;
            this.OpenFolder.Text = "";
            this.OpenFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OpenFolder.UseFiltering = false;
            this.OpenFolder.Width = 50;
            // 
            // Remove
            // 
            this.Remove.AutoCompleteEditor = false;
            this.Remove.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.Remove.Groupable = false;
            this.Remove.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Remove.IsEditable = false;
            this.Remove.MaximumWidth = 50;
            this.Remove.MinimumWidth = 50;
            this.Remove.Searchable = false;
            this.Remove.ShowTextInHeader = false;
            this.Remove.Sortable = false;
            this.Remove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Remove.UseFiltering = false;
            this.Remove.Width = 50;
            // 
            // Epona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.objectListView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Epona";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SystemTray_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn IconCol;
        private BrightIdeasSoftware.OLVColumn NameCol;
        private BrightIdeasSoftware.OLVColumn ActiveCol;
        private BrightIdeasSoftware.OLVColumn GetHyperlink;
        private BrightIdeasSoftware.OLVColumn OpenFolder;
        private BrightIdeasSoftware.OLVColumn Remove;
    }
}

