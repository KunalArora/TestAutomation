namespace TestRunner
{
    partial class SetCDServers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetCDServers));
            this.SelectCDServers = new System.Windows.Forms.CheckedListBox();
            this.SetServers = new System.Windows.Forms.Button();
            this.CancelServerSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectCDServers
            // 
            this.SelectCDServers.BackColor = System.Drawing.Color.Azure;
            this.SelectCDServers.CheckOnClick = true;
            this.SelectCDServers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectCDServers.FormattingEnabled = true;
            this.SelectCDServers.Items.AddRange(new object[] {
            "Live Site - Web1",
            "Live Site - Web2",
            "Live Site - Web5",
            "Live Site - Web6"});
            this.SelectCDServers.Location = new System.Drawing.Point(40, 21);
            this.SelectCDServers.Name = "SelectCDServers";
            this.SelectCDServers.Size = new System.Drawing.Size(118, 124);
            this.SelectCDServers.TabIndex = 0;
            this.SelectCDServers.ThreeDCheckBoxes = true;
            this.SelectCDServers.SelectedIndexChanged += new System.EventHandler(this.SelectCDServers_SelectedIndexChanged);
            // 
            // SetServers
            // 
            this.SetServers.Location = new System.Drawing.Point(25, 155);
            this.SetServers.Name = "SetServers";
            this.SetServers.Size = new System.Drawing.Size(60, 23);
            this.SetServers.TabIndex = 1;
            this.SetServers.Text = "Set";
            this.SetServers.UseVisualStyleBackColor = true;
            this.SetServers.Click += new System.EventHandler(this.SetServers_Click);
            // 
            // CancelServerSelection
            // 
            this.CancelServerSelection.Location = new System.Drawing.Point(121, 155);
            this.CancelServerSelection.Name = "CancelServerSelection";
            this.CancelServerSelection.Size = new System.Drawing.Size(59, 23);
            this.CancelServerSelection.TabIndex = 2;
            this.CancelServerSelection.Text = "Cancel";
            this.CancelServerSelection.UseVisualStyleBackColor = true;
            this.CancelServerSelection.Click += new System.EventHandler(this.CancelServerSelection_Click);
            // 
            // SetCDServers
            // 
            this.ClientSize = new System.Drawing.Size(205, 196);
            this.Controls.Add(this.CancelServerSelection);
            this.Controls.Add(this.SetServers);
            this.Controls.Add(this.SelectCDServers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetCDServers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select CD Servers";
            this.Load += new System.EventHandler(this.SetCDServers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox SelectCDServers;
        private System.Windows.Forms.Button SetServers;
        private System.Windows.Forms.Button CancelServerSelection;

    }
}