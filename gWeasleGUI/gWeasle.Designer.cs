namespace gWeasleGUI
{
    partial class gWeazleFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gWeazleFrm));
            this.ExecuteBtn = new System.Windows.Forms.Button();
            this.SelectExistingFileBtn = new System.Windows.Forms.Button();
            this.actionCB = new System.Windows.Forms.ComboBox();
            this.GwStatus = new System.Windows.Forms.StatusStrip();
            this.gwToolsVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.GwCurrentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.actionLBL = new System.Windows.Forms.Label();
            this.GwFileDisplay = new System.Windows.Forms.Label();
            this.outputTB = new System.Windows.Forms.TextBox();
            this.timeCB = new System.Windows.Forms.CheckBox();
            this.gwPortTB = new System.Windows.Forms.TextBox();
            this.gwPortLBL = new System.Windows.Forms.Label();
            this.gwRawCB = new System.Windows.Forms.CheckBox();
            this.gwFormatTypeLBL = new System.Windows.Forms.Label();
            this.gwFormatTypeCB = new System.Windows.Forms.ComboBox();
            this.additonalArgsTB = new System.Windows.Forms.TextBox();
            this.additonalArgsLBL = new System.Windows.Forms.Label();
            this.gwCmdHelpBtn = new System.Windows.Forms.Button();
            this.gwEraseBlankCB = new System.Windows.Forms.CheckBox();
            this.gwNoVerifyCB = new System.Windows.Forms.CheckBox();
            this.driveTB = new System.Windows.Forms.TextBox();
            this.driveLBL = new System.Windows.Forms.Label();
            this.SelectNewFileBtn = new System.Windows.Forms.Button();
            this.gweazleTips = new System.Windows.Forms.ToolTip(this.components);
            this.accessoptions = new System.Windows.Forms.PictureBox();
            this.gwCylTB = new System.Windows.Forms.TextBox();
            this.gwCylLBL = new System.Windows.Forms.Label();
            this.gwpathcontainer = new System.Windows.Forms.Panel();
            this.closeGWOptionsBtn = new System.Windows.Forms.Button();
            this.acceptGWLocationBtn = new System.Windows.Forms.Button();
            this.gwPathSelectionLBL = new System.Windows.Forms.Label();
            this.SelectGWPathBtn = new System.Windows.Forms.Button();
            this.gwPathSelectionTB = new System.Windows.Forms.TextBox();
            this.busy1 = new System.Windows.Forms.PictureBox();
            this.diskdefsLBL = new System.Windows.Forms.Label();
            this.diskdefsBtn = new System.Windows.Forms.Button();
            this.GwStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accessoptions)).BeginInit();
            this.gwpathcontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busy1)).BeginInit();
            this.SuspendLayout();
            // 
            // ExecuteBtn
            // 
            this.ExecuteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteBtn.Location = new System.Drawing.Point(652, 389);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(75, 23);
            this.ExecuteBtn.TabIndex = 2;
            this.ExecuteBtn.Text = "Execute";
            this.ExecuteBtn.UseVisualStyleBackColor = true;
            this.ExecuteBtn.Click += new System.EventHandler(this.ExecuteBtn_Click);
            // 
            // SelectExistingFileBtn
            // 
            this.SelectExistingFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectExistingFileBtn.Location = new System.Drawing.Point(645, 9);
            this.SelectExistingFileBtn.Name = "SelectExistingFileBtn";
            this.SelectExistingFileBtn.Size = new System.Drawing.Size(58, 23);
            this.SelectExistingFileBtn.TabIndex = 3;
            this.SelectExistingFileBtn.Text = "Existing";
            this.gweazleTips.SetToolTip(this.SelectExistingFileBtn, "An existing image file");
            this.SelectExistingFileBtn.UseVisualStyleBackColor = true;
            this.SelectExistingFileBtn.Click += new System.EventHandler(this.SelectExistingFileBtn_Click);
            // 
            // actionCB
            // 
            this.actionCB.FormattingEnabled = true;
            this.actionCB.Location = new System.Drawing.Point(56, 10);
            this.actionCB.Name = "actionCB";
            this.actionCB.Size = new System.Drawing.Size(69, 21);
            this.actionCB.TabIndex = 4;
            this.actionCB.SelectedIndexChanged += new System.EventHandler(this.actionCB_SelectedIndexChanged);
            // 
            // GwStatus
            // 
            this.GwStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gwToolsVersion,
            this.GwCurrentStatus});
            this.GwStatus.Location = new System.Drawing.Point(0, 419);
            this.GwStatus.Name = "GwStatus";
            this.GwStatus.Size = new System.Drawing.Size(779, 22);
            this.GwStatus.TabIndex = 5;
            this.GwStatus.Text = "Status";
            // 
            // gwToolsVersion
            // 
            this.gwToolsVersion.Name = "gwToolsVersion";
            this.gwToolsVersion.Size = new System.Drawing.Size(36, 17);
            this.gwToolsVersion.Text = "None";
            // 
            // GwCurrentStatus
            // 
            this.GwCurrentStatus.Name = "GwCurrentStatus";
            this.GwCurrentStatus.Size = new System.Drawing.Size(39, 17);
            this.GwCurrentStatus.Text = "Status";
            // 
            // actionLBL
            // 
            this.actionLBL.AutoSize = true;
            this.actionLBL.Location = new System.Drawing.Point(13, 13);
            this.actionLBL.Name = "actionLBL";
            this.actionLBL.Size = new System.Drawing.Size(37, 13);
            this.actionLBL.TabIndex = 6;
            this.actionLBL.Text = "Action";
            // 
            // GwFileDisplay
            // 
            this.GwFileDisplay.AutoSize = true;
            this.GwFileDisplay.Location = new System.Drawing.Point(131, 14);
            this.GwFileDisplay.Name = "GwFileDisplay";
            this.GwFileDisplay.Size = new System.Drawing.Size(23, 13);
            this.GwFileDisplay.TabIndex = 7;
            this.GwFileDisplay.Text = "File";
            // 
            // outputTB
            // 
            this.outputTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTB.BackColor = System.Drawing.SystemColors.HotTrack;
            this.outputTB.Font = new System.Drawing.Font("Ubuntu Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTB.ForeColor = System.Drawing.Color.Gold;
            this.outputTB.Location = new System.Drawing.Point(13, 100);
            this.outputTB.Multiline = true;
            this.outputTB.Name = "outputTB";
            this.outputTB.ReadOnly = true;
            this.outputTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTB.Size = new System.Drawing.Size(754, 283);
            this.outputTB.TabIndex = 1;
            this.outputTB.WordWrap = false;
            // 
            // timeCB
            // 
            this.timeCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timeCB.AutoSize = true;
            this.timeCB.Location = new System.Drawing.Point(444, 393);
            this.timeCB.Name = "timeCB";
            this.timeCB.Size = new System.Drawing.Size(119, 17);
            this.timeCB.TabIndex = 8;
            this.timeCB.Text = "Report Elapse Time";
            this.timeCB.UseVisualStyleBackColor = true;
            this.timeCB.CheckedChanged += new System.EventHandler(this.timeCB_CheckedChanged);
            // 
            // gwPortTB
            // 
            this.gwPortTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gwPortTB.Location = new System.Drawing.Point(377, 391);
            this.gwPortTB.Name = "gwPortTB";
            this.gwPortTB.Size = new System.Drawing.Size(61, 20);
            this.gwPortTB.TabIndex = 10;
            // 
            // gwPortLBL
            // 
            this.gwPortLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gwPortLBL.AutoSize = true;
            this.gwPortLBL.Location = new System.Drawing.Point(345, 394);
            this.gwPortLBL.Name = "gwPortLBL";
            this.gwPortLBL.Size = new System.Drawing.Size(26, 13);
            this.gwPortLBL.TabIndex = 11;
            this.gwPortLBL.Text = "Port";
            // 
            // gwRawCB
            // 
            this.gwRawCB.AutoSize = true;
            this.gwRawCB.Location = new System.Drawing.Point(198, 43);
            this.gwRawCB.Name = "gwRawCB";
            this.gwRawCB.Size = new System.Drawing.Size(48, 17);
            this.gwRawCB.TabIndex = 12;
            this.gwRawCB.Text = "Raw";
            this.gwRawCB.UseVisualStyleBackColor = true;
            this.gwRawCB.CheckedChanged += new System.EventHandler(this.gwRawCB_CheckedChanged);
            // 
            // gwFormatTypeLBL
            // 
            this.gwFormatTypeLBL.AutoSize = true;
            this.gwFormatTypeLBL.Location = new System.Drawing.Point(13, 44);
            this.gwFormatTypeLBL.Name = "gwFormatTypeLBL";
            this.gwFormatTypeLBL.Size = new System.Drawing.Size(66, 13);
            this.gwFormatTypeLBL.TabIndex = 14;
            this.gwFormatTypeLBL.Text = "Format Type";
            // 
            // gwFormatTypeCB
            // 
            this.gwFormatTypeCB.FormattingEnabled = true;
            this.gwFormatTypeCB.Location = new System.Drawing.Point(85, 41);
            this.gwFormatTypeCB.Name = "gwFormatTypeCB";
            this.gwFormatTypeCB.Size = new System.Drawing.Size(107, 21);
            this.gwFormatTypeCB.TabIndex = 15;
            // 
            // additonalArgsTB
            // 
            this.additonalArgsTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.additonalArgsTB.Location = new System.Drawing.Point(372, 68);
            this.additonalArgsTB.Name = "additonalArgsTB";
            this.additonalArgsTB.Size = new System.Drawing.Size(395, 20);
            this.additonalArgsTB.TabIndex = 16;
            // 
            // additonalArgsLBL
            // 
            this.additonalArgsLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.additonalArgsLBL.AutoSize = true;
            this.additonalArgsLBL.Location = new System.Drawing.Point(260, 71);
            this.additonalArgsLBL.Name = "additonalArgsLBL";
            this.additonalArgsLBL.Size = new System.Drawing.Size(106, 13);
            this.additonalArgsLBL.TabIndex = 17;
            this.additonalArgsLBL.Text = "Additional Arguments";
            // 
            // gwCmdHelpBtn
            // 
            this.gwCmdHelpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gwCmdHelpBtn.Location = new System.Drawing.Point(569, 389);
            this.gwCmdHelpBtn.Name = "gwCmdHelpBtn";
            this.gwCmdHelpBtn.Size = new System.Drawing.Size(77, 23);
            this.gwCmdHelpBtn.TabIndex = 18;
            this.gwCmdHelpBtn.Text = "Action Help";
            this.gwCmdHelpBtn.UseVisualStyleBackColor = true;
            this.gwCmdHelpBtn.Click += new System.EventHandler(this.gwCmdHelpBtn_Click);
            // 
            // gwEraseBlankCB
            // 
            this.gwEraseBlankCB.AutoSize = true;
            this.gwEraseBlankCB.Location = new System.Drawing.Point(252, 43);
            this.gwEraseBlankCB.Name = "gwEraseBlankCB";
            this.gwEraseBlankCB.Size = new System.Drawing.Size(85, 17);
            this.gwEraseBlankCB.TabIndex = 19;
            this.gwEraseBlankCB.Text = "Erase Empty";
            this.gwEraseBlankCB.UseVisualStyleBackColor = true;
            // 
            // gwNoVerifyCB
            // 
            this.gwNoVerifyCB.AutoSize = true;
            this.gwNoVerifyCB.Location = new System.Drawing.Point(341, 43);
            this.gwNoVerifyCB.Name = "gwNoVerifyCB";
            this.gwNoVerifyCB.Size = new System.Drawing.Size(69, 17);
            this.gwNoVerifyCB.TabIndex = 20;
            this.gwNoVerifyCB.Text = "No Verify";
            this.gwNoVerifyCB.UseVisualStyleBackColor = true;
            // 
            // driveTB
            // 
            this.driveTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.driveTB.Location = new System.Drawing.Point(316, 391);
            this.driveTB.Name = "driveTB";
            this.driveTB.Size = new System.Drawing.Size(23, 20);
            this.driveTB.TabIndex = 21;
            // 
            // driveLBL
            // 
            this.driveLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.driveLBL.AutoSize = true;
            this.driveLBL.Location = new System.Drawing.Point(278, 394);
            this.driveLBL.Name = "driveLBL";
            this.driveLBL.Size = new System.Drawing.Size(32, 13);
            this.driveLBL.TabIndex = 22;
            this.driveLBL.Text = "Drive";
            // 
            // SelectNewFileBtn
            // 
            this.SelectNewFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectNewFileBtn.Location = new System.Drawing.Point(709, 9);
            this.SelectNewFileBtn.Name = "SelectNewFileBtn";
            this.SelectNewFileBtn.Size = new System.Drawing.Size(58, 23);
            this.SelectNewFileBtn.TabIndex = 23;
            this.SelectNewFileBtn.Text = "New File";
            this.gweazleTips.SetToolTip(this.SelectNewFileBtn, "A file to be created");
            this.SelectNewFileBtn.UseVisualStyleBackColor = true;
            this.SelectNewFileBtn.Click += new System.EventHandler(this.SelectNewFileBtn_Click);
            // 
            // accessoptions
            // 
            this.accessoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.accessoptions.Image = global::gWeasleGUI.Properties.Resources.Grey_Options;
            this.accessoptions.Location = new System.Drawing.Point(13, 388);
            this.accessoptions.Name = "accessoptions";
            this.accessoptions.Size = new System.Drawing.Size(28, 28);
            this.accessoptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.accessoptions.TabIndex = 27;
            this.accessoptions.TabStop = false;
            this.gweazleTips.SetToolTip(this.accessoptions, "Options");
            this.accessoptions.Click += new System.EventHandler(this.accessoptions_Click);
            // 
            // gwCylTB
            // 
            this.gwCylTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gwCylTB.Location = new System.Drawing.Point(744, 41);
            this.gwCylTB.Name = "gwCylTB";
            this.gwCylTB.Size = new System.Drawing.Size(23, 20);
            this.gwCylTB.TabIndex = 24;
            // 
            // gwCylLBL
            // 
            this.gwCylLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gwCylLBL.AutoSize = true;
            this.gwCylLBL.Location = new System.Drawing.Point(694, 44);
            this.gwCylLBL.Name = "gwCylLBL";
            this.gwCylLBL.Size = new System.Drawing.Size(44, 13);
            this.gwCylLBL.TabIndex = 25;
            this.gwCylLBL.Text = "Cylinder";
            // 
            // gwpathcontainer
            // 
            this.gwpathcontainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gwpathcontainer.BackColor = System.Drawing.Color.LightGray;
            this.gwpathcontainer.Controls.Add(this.closeGWOptionsBtn);
            this.gwpathcontainer.Controls.Add(this.acceptGWLocationBtn);
            this.gwpathcontainer.Controls.Add(this.gwPathSelectionLBL);
            this.gwpathcontainer.Controls.Add(this.SelectGWPathBtn);
            this.gwpathcontainer.Controls.Add(this.gwPathSelectionTB);
            this.gwpathcontainer.Location = new System.Drawing.Point(56, 139);
            this.gwpathcontainer.Name = "gwpathcontainer";
            this.gwpathcontainer.Size = new System.Drawing.Size(647, 199);
            this.gwpathcontainer.TabIndex = 26;
            this.gwpathcontainer.Visible = false;
            // 
            // closeGWOptionsBtn
            // 
            this.closeGWOptionsBtn.Location = new System.Drawing.Point(477, 162);
            this.closeGWOptionsBtn.Name = "closeGWOptionsBtn";
            this.closeGWOptionsBtn.Size = new System.Drawing.Size(75, 23);
            this.closeGWOptionsBtn.TabIndex = 4;
            this.closeGWOptionsBtn.Text = "Cancel";
            this.closeGWOptionsBtn.UseVisualStyleBackColor = true;
            this.closeGWOptionsBtn.Click += new System.EventHandler(this.closeGWOptionsBtn_Click);
            // 
            // acceptGWLocationBtn
            // 
            this.acceptGWLocationBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptGWLocationBtn.Location = new System.Drawing.Point(558, 162);
            this.acceptGWLocationBtn.Name = "acceptGWLocationBtn";
            this.acceptGWLocationBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptGWLocationBtn.TabIndex = 3;
            this.acceptGWLocationBtn.Text = "Use Path";
            this.acceptGWLocationBtn.UseVisualStyleBackColor = true;
            this.acceptGWLocationBtn.Click += new System.EventHandler(this.acceptGWLocationBtn_Click);
            // 
            // gwPathSelectionLBL
            // 
            this.gwPathSelectionLBL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gwPathSelectionLBL.AutoSize = true;
            this.gwPathSelectionLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gwPathSelectionLBL.Location = new System.Drawing.Point(59, 56);
            this.gwPathSelectionLBL.Name = "gwPathSelectionLBL";
            this.gwPathSelectionLBL.Size = new System.Drawing.Size(280, 24);
            this.gwPathSelectionLBL.TabIndex = 2;
            this.gwPathSelectionLBL.Text = "Path to GreaseWeazle host tools";
            // 
            // SelectGWPathBtn
            // 
            this.SelectGWPathBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SelectGWPathBtn.Location = new System.Drawing.Point(534, 81);
            this.SelectGWPathBtn.Name = "SelectGWPathBtn";
            this.SelectGWPathBtn.Size = new System.Drawing.Size(75, 23);
            this.SelectGWPathBtn.TabIndex = 1;
            this.SelectGWPathBtn.Text = "Select";
            this.SelectGWPathBtn.UseVisualStyleBackColor = true;
            this.SelectGWPathBtn.Click += new System.EventHandler(this.SelectGWPathBtn_Click);
            // 
            // gwPathSelectionTB
            // 
            this.gwPathSelectionTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gwPathSelectionTB.Location = new System.Drawing.Point(63, 83);
            this.gwPathSelectionTB.Name = "gwPathSelectionTB";
            this.gwPathSelectionTB.Size = new System.Drawing.Size(475, 20);
            this.gwPathSelectionTB.TabIndex = 0;
            // 
            // busy1
            // 
            this.busy1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.busy1.Image = global::gWeasleGUI.Properties.Resources.RotatingRings;
            this.busy1.InitialImage = null;
            this.busy1.Location = new System.Drawing.Point(733, 383);
            this.busy1.Name = "busy1";
            this.busy1.Size = new System.Drawing.Size(34, 33);
            this.busy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.busy1.TabIndex = 9;
            this.busy1.TabStop = false;
            // 
            // diskdefsLBL
            // 
            this.diskdefsLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.diskdefsLBL.AutoSize = true;
            this.diskdefsLBL.Location = new System.Drawing.Point(53, 394);
            this.diskdefsLBL.MaximumSize = new System.Drawing.Size(300, 0);
            this.diskdefsLBL.Name = "diskdefsLBL";
            this.diskdefsLBL.Size = new System.Drawing.Size(41, 13);
            this.diskdefsLBL.TabIndex = 28;
            this.diskdefsLBL.Text = "Default";
            // 
            // diskdefsBtn
            // 
            this.diskdefsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diskdefsBtn.Location = new System.Drawing.Point(212, 389);
            this.diskdefsBtn.Name = "diskdefsBtn";
            this.diskdefsBtn.Size = new System.Drawing.Size(61, 23);
            this.diskdefsBtn.TabIndex = 29;
            this.diskdefsBtn.Text = "Disk Defs";
            this.diskdefsBtn.UseVisualStyleBackColor = true;
            this.diskdefsBtn.Click += new System.EventHandler(this.diskdefsBtn_Click);
            // 
            // gWeazleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 441);
            this.Controls.Add(this.diskdefsBtn);
            this.Controls.Add(this.accessoptions);
            this.Controls.Add(this.gwpathcontainer);
            this.Controls.Add(this.gwCylLBL);
            this.Controls.Add(this.gwCylTB);
            this.Controls.Add(this.SelectNewFileBtn);
            this.Controls.Add(this.driveLBL);
            this.Controls.Add(this.driveTB);
            this.Controls.Add(this.gwNoVerifyCB);
            this.Controls.Add(this.gwEraseBlankCB);
            this.Controls.Add(this.gwCmdHelpBtn);
            this.Controls.Add(this.additonalArgsLBL);
            this.Controls.Add(this.additonalArgsTB);
            this.Controls.Add(this.gwFormatTypeCB);
            this.Controls.Add(this.gwFormatTypeLBL);
            this.Controls.Add(this.gwRawCB);
            this.Controls.Add(this.gwPortLBL);
            this.Controls.Add(this.gwPortTB);
            this.Controls.Add(this.busy1);
            this.Controls.Add(this.timeCB);
            this.Controls.Add(this.actionLBL);
            this.Controls.Add(this.GwStatus);
            this.Controls.Add(this.actionCB);
            this.Controls.Add(this.SelectExistingFileBtn);
            this.Controls.Add(this.ExecuteBtn);
            this.Controls.Add(this.outputTB);
            this.Controls.Add(this.GwFileDisplay);
            this.Controls.Add(this.diskdefsLBL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "gWeazleFrm";
            this.Text = "gWeazleGUI";
            this.Load += new System.EventHandler(this.gWeasleFrm_Load);
            this.GwStatus.ResumeLayout(false);
            this.GwStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accessoptions)).EndInit();
            this.gwpathcontainer.ResumeLayout(false);
            this.gwpathcontainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busy1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ExecuteBtn;
        private System.Windows.Forms.Button SelectExistingFileBtn;
        private System.Windows.Forms.ComboBox actionCB;
        private System.Windows.Forms.StatusStrip GwStatus;
        private System.Windows.Forms.ToolStripStatusLabel GwCurrentStatus;
        private System.Windows.Forms.Label actionLBL;
        private System.Windows.Forms.Label GwFileDisplay;
        private System.Windows.Forms.TextBox outputTB;
        private System.Windows.Forms.CheckBox timeCB;
        private System.Windows.Forms.PictureBox busy1;
        private System.Windows.Forms.TextBox gwPortTB;
        private System.Windows.Forms.Label gwPortLBL;
        private System.Windows.Forms.ToolStripStatusLabel gwToolsVersion;
        private System.Windows.Forms.CheckBox gwRawCB;
        private System.Windows.Forms.Label gwFormatTypeLBL;
        private System.Windows.Forms.ComboBox gwFormatTypeCB;
        private System.Windows.Forms.TextBox additonalArgsTB;
        private System.Windows.Forms.Label additonalArgsLBL;
        private System.Windows.Forms.Button gwCmdHelpBtn;
        private System.Windows.Forms.CheckBox gwEraseBlankCB;
        private System.Windows.Forms.CheckBox gwNoVerifyCB;
        private System.Windows.Forms.TextBox driveTB;
        private System.Windows.Forms.Label driveLBL;
        private System.Windows.Forms.Button SelectNewFileBtn;
        private System.Windows.Forms.ToolTip gweazleTips;
        private System.Windows.Forms.TextBox gwCylTB;
        private System.Windows.Forms.Label gwCylLBL;
        private System.Windows.Forms.Panel gwpathcontainer;
        private System.Windows.Forms.TextBox gwPathSelectionTB;
        private System.Windows.Forms.Button acceptGWLocationBtn;
        private System.Windows.Forms.Label gwPathSelectionLBL;
        private System.Windows.Forms.Button SelectGWPathBtn;
        private System.Windows.Forms.PictureBox accessoptions;
        private System.Windows.Forms.Button closeGWOptionsBtn;
        private System.Windows.Forms.Label diskdefsLBL;
        private System.Windows.Forms.Button diskdefsBtn;
    }
}

