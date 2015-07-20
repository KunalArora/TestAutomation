using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TestRunner
{
    partial class BrotherTestRunner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Project");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Assembly", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrotherTestRunner));
            this.RunTimeEnv = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TestList = new System.Windows.Forms.Label();
            this.StartTestRun = new System.Windows.Forms.Button();
            this.TestListView = new System.Windows.Forms.TreeView();
            this.RefreshTests = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.BrowserType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EmailPackage = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StopTestRun = new System.Windows.Forms.Button();
            this.NUnitCmdLineOption = new System.Windows.Forms.RadioButton();
            this.NUnitAPIOption = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LiveCDServerTest = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TestRunReportLink = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.TestsToRun = new System.Windows.Forms.Label();
            this.GenerateRunReport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // RunTimeEnv
            // 
            this.RunTimeEnv.DisplayMember = "TEST";
            this.RunTimeEnv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RunTimeEnv.FormattingEnabled = true;
            this.RunTimeEnv.Items.AddRange(new object[] {
            "PROD",
            "SMOKE",
            "TEST",
            "UAT"});
            this.RunTimeEnv.Location = new System.Drawing.Point(33, 28);
            this.RunTimeEnv.Name = "RunTimeEnv";
            this.RunTimeEnv.Size = new System.Drawing.Size(102, 24);
            this.RunTimeEnv.TabIndex = 0;
            this.RunTimeEnv.SelectedIndexChanged += new System.EventHandler(this.RunTimeEnv_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Run Time Environment";
            // 
            // TestList
            // 
            this.TestList.AutoSize = true;
            this.TestList.Location = new System.Drawing.Point(13, 20);
            this.TestList.Name = "TestList";
            this.TestList.Size = new System.Drawing.Size(62, 17);
            this.TestList.TabIndex = 4;
            this.TestList.Text = "Test List";
            // 
            // StartTestRun
            // 
            this.StartTestRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.StartTestRun.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.StartTestRun.Location = new System.Drawing.Point(13, 71);
            this.StartTestRun.Name = "StartTestRun";
            this.StartTestRun.Size = new System.Drawing.Size(63, 23);
            this.StartTestRun.TabIndex = 5;
            this.StartTestRun.Text = "Run";
            this.StartTestRun.UseVisualStyleBackColor = true;
            this.StartTestRun.Click += new System.EventHandler(this.RunTests_Click);
            // 
            // TestListView
            // 
            this.TestListView.BackColor = System.Drawing.Color.LightGray;
            this.TestListView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TestListView.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TestListView.LineColor = System.Drawing.Color.Blue;
            this.TestListView.Location = new System.Drawing.Point(15, 37);
            this.TestListView.Name = "TestListView";
            treeNode1.Name = "Project";
            treeNode1.Text = "Project";
            treeNode2.Name = "Assembly";
            treeNode2.Text = "Assembly";
            this.TestListView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.TestListView.ShowLines = false;
            this.TestListView.Size = new System.Drawing.Size(432, 528);
            this.TestListView.TabIndex = 6;
            // 
            // RefreshTests
            // 
            this.RefreshTests.Enabled = false;
            this.RefreshTests.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RefreshTests.Location = new System.Drawing.Point(49, 15);
            this.RefreshTests.Name = "RefreshTests";
            this.RefreshTests.Size = new System.Drawing.Size(74, 32);
            this.RefreshTests.TabIndex = 7;
            this.RefreshTests.Text = "Refresh";
            this.RefreshTests.UseVisualStyleBackColor = true;
            this.RefreshTests.Click += new System.EventHandler(this.RefreshTests_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BrowserType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.EmailPackage);
            this.panel1.Controls.Add(this.RunTimeEnv);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(465, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 163);
            this.panel1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(35, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Browser Type";
            // 
            // BrowserType
            // 
            this.BrowserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BrowserType.FormattingEnabled = true;
            this.BrowserType.Items.AddRange(new object[] {
            "Headless",
            "Chrome"});
            this.BrowserType.Location = new System.Drawing.Point(33, 120);
            this.BrowserType.Name = "BrowserType";
            this.BrowserType.Size = new System.Drawing.Size(103, 24);
            this.BrowserType.TabIndex = 11;
            this.BrowserType.SelectedIndexChanged += new System.EventHandler(this.BrowserType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(30, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Email Validation";
            // 
            // EmailPackage
            // 
            this.EmailPackage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EmailPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmailPackage.FormattingEnabled = true;
            this.EmailPackage.Items.AddRange(new object[] {
            "BrotherEmail",
            "MailinatorEmail"});
            this.EmailPackage.Location = new System.Drawing.Point(33, 75);
            this.EmailPackage.Name = "EmailPackage";
            this.EmailPackage.Size = new System.Drawing.Size(102, 24);
            this.EmailPackage.TabIndex = 9;
            this.EmailPackage.SelectedIndexChanged += new System.EventHandler(this.EmailPackage_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.StopTestRun);
            this.panel2.Controls.Add(this.NUnitCmdLineOption);
            this.panel2.Controls.Add(this.StartTestRun);
            this.panel2.Controls.Add(this.NUnitAPIOption);
            this.panel2.Location = new System.Drawing.Point(465, 250);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 119);
            this.panel2.TabIndex = 9;
            // 
            // StopTestRun
            // 
            this.StopTestRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.StopTestRun.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.StopTestRun.Location = new System.Drawing.Point(87, 71);
            this.StopTestRun.Name = "StopTestRun";
            this.StopTestRun.Size = new System.Drawing.Size(63, 23);
            this.StopTestRun.TabIndex = 14;
            this.StopTestRun.Text = "Stop";
            this.StopTestRun.UseVisualStyleBackColor = true;
            this.StopTestRun.Click += new System.EventHandler(this.StopTestRun_Click);
            // 
            // NUnitCmdLineOption
            // 
            this.NUnitCmdLineOption.AutoSize = true;
            this.NUnitCmdLineOption.BackColor = System.Drawing.Color.LightGray;
            this.NUnitCmdLineOption.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.NUnitCmdLineOption.Location = new System.Drawing.Point(27, 40);
            this.NUnitCmdLineOption.Name = "NUnitCmdLineOption";
            this.NUnitCmdLineOption.Size = new System.Drawing.Size(127, 21);
            this.NUnitCmdLineOption.TabIndex = 13;
            this.NUnitCmdLineOption.Text = "NUnit Cmd Line";
            this.NUnitCmdLineOption.UseVisualStyleBackColor = false;
            this.NUnitCmdLineOption.CheckedChanged += new System.EventHandler(this.NUnitCmdLineOption_CheckedChanged);
            // 
            // NUnitAPIOption
            // 
            this.NUnitAPIOption.AutoSize = true;
            this.NUnitAPIOption.BackColor = System.Drawing.Color.LightGray;
            this.NUnitAPIOption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NUnitAPIOption.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.NUnitAPIOption.Location = new System.Drawing.Point(27, 17);
            this.NUnitAPIOption.Name = "NUnitAPIOption";
            this.NUnitAPIOption.Size = new System.Drawing.Size(89, 21);
            this.NUnitAPIOption.TabIndex = 12;
            this.NUnitAPIOption.Text = "NUnit API";
            this.NUnitAPIOption.UseVisualStyleBackColor = false;
            this.NUnitAPIOption.CheckedChanged += new System.EventHandler(this.NUnitAPIOption_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Environment Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Test Execution";
            // 
            // LiveCDServerTest
            // 
            this.LiveCDServerTest.AutoSize = true;
            this.LiveCDServerTest.Enabled = false;
            this.LiveCDServerTest.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LiveCDServerTest.Location = new System.Drawing.Point(466, 207);
            this.LiveCDServerTest.Name = "LiveCDServerTest";
            this.LiveCDServerTest.Size = new System.Drawing.Size(183, 21);
            this.LiveCDServerTest.TabIndex = 12;
            this.LiveCDServerTest.Text = "Testing Live CD Servers";
            this.LiveCDServerTest.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 479);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Test List";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.RefreshTests);
            this.panel3.Location = new System.Drawing.Point(466, 495);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(164, 65);
            this.panel3.TabIndex = 14;
            // 
            // TestRunReportLink
            // 
            this.TestRunReportLink.AutoSize = true;
            this.TestRunReportLink.Location = new System.Drawing.Point(466, 443);
            this.TestRunReportLink.Name = "TestRunReportLink";
            this.TestRunReportLink.Size = new System.Drawing.Size(86, 17);
            this.TestRunReportLink.TabIndex = 15;
            this.TestRunReportLink.TabStop = true;
            this.TestRunReportLink.Text = "Click to View";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(466, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Num Tests : ";
            // 
            // TestsToRun
            // 
            this.TestsToRun.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.TestsToRun.AutoSize = true;
            this.TestsToRun.Location = new System.Drawing.Point(528, 381);
            this.TestsToRun.Name = "TestsToRun";
            this.TestsToRun.Size = new System.Drawing.Size(0, 17);
            this.TestsToRun.TabIndex = 17;
            // 
            // GenerateRunReport
            // 
            this.GenerateRunReport.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.GenerateRunReport.Location = new System.Drawing.Point(467, 417);
            this.GenerateRunReport.Name = "GenerateRunReport";
            this.GenerateRunReport.Size = new System.Drawing.Size(124, 23);
            this.GenerateRunReport.TabIndex = 18;
            this.GenerateRunReport.Text = "Generate Run Report";
            this.GenerateRunReport.UseVisualStyleBackColor = true;
            this.GenerateRunReport.Click += new System.EventHandler(this.GenerateRunReport_Click);
            // 
            // BrotherTestRunner
            // 
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(646, 583);
            this.Controls.Add(this.GenerateRunReport);
            this.Controls.Add(this.TestsToRun);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TestRunReportLink);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LiveCDServerTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TestListView);
            this.Controls.Add(this.TestList);
            this.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BrotherTestRunner";
            this.Text = "BrotherTestRunner";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Load += new System.EventHandler(this.BrotherTestRunner_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox RunTimeEnv;
        private Label label1;
        private Label TestList;
        private Button StartTestRun;
        private TreeView TestListView;
        private Button RefreshTests;
        private Panel panel1;
        private Label label3;
        private ComboBox EmailPackage;
        private Label label4;
        private ComboBox BrowserType;
        private Panel panel2;
        private Label label5;
        private Label label2;
        private RadioButton NUnitAPIOption;
        private RadioButton NUnitCmdLineOption;
        private CheckBox LiveCDServerTest;
        private Button StopTestRun;
        private Label label6;
        private Panel panel3;
        private LinkLabel TestRunReportLink;
        private Label label7;
        private Label TestsToRun;
        private Button GenerateRunReport;
    }
}