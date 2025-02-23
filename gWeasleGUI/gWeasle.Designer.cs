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
            this.actionCB = new System.Windows.Forms.ComboBox();
            this.GwStatus = new System.Windows.Forms.StatusStrip();
            this.gwToolsVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.GwGUIActions = new System.Windows.Forms.ToolStripStatusLabel();
            this.GwCurrentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.actionLBL = new System.Windows.Forms.Label();
            this.timeCB = new System.Windows.Forms.CheckBox();
            this.gwCmdHelpBtn = new System.Windows.Forms.Button();
            this.gweazleTips = new System.Windows.Forms.ToolTip(this.components);
            this.accessoptions = new System.Windows.Forms.PictureBox();
            this.removeDiskConfigBtn = new System.Windows.Forms.Button();
            this.gwDDSaveBtn = new System.Windows.Forms.Button();
            this.gwDDReloadBtn = new System.Windows.Forms.Button();
            this.gwDDfileBtn = new System.Windows.Forms.Button();
            this.gwDDRemoveTrackBtn = new System.Windows.Forms.Button();
            this.gwDDApplyTrackBtn = new System.Windows.Forms.Button();
            this.gwDDiamCB = new System.Windows.Forms.CheckBox();
            this.diskDefApplyBtn = new System.Windows.Forms.Button();
            this.newDiskConfigBtn = new System.Windows.Forms.Button();
            this.gwDiskConfigCB = new System.Windows.Forms.ComboBox();
            this.SelectNewFileBtn = new System.Windows.Forms.Button();
            this.SelectExistingFileBtn = new System.Windows.Forms.Button();
            this.gwSerialValue = new System.Windows.Forms.Label();
            this.gwDDcb = new System.Windows.Forms.CheckBox();
            this.gwNoClobberCB = new System.Windows.Forms.CheckBox();
            this.gwHardSectorsCB = new System.Windows.Forms.CheckBox();
            this.gwDDNewFileBtn = new System.Windows.Forms.Button();
            this.gwTagTB = new gWeasleGUI.vTextParam();
            this.driveTB = new gWeasleGUI.vTextParam();
            this.gwRevsTB = new gWeasleGUI.vTextParam();
            this.gwAdjustSpeedTB = new gWeasleGUI.vTextParam();
            this.gwFakeIndexTB = new gWeasleGUI.vTextParam();
            this.gwRetriesTB = new gWeasleGUI.vTextParam();
            this.gwDDsubformatTB = new gWeasleGUI.vTextParam();
            this.gwDDclockTB = new gWeasleGUI.vTextParam();
            this.gwDDimgbpsTB = new gWeasleGUI.vTextParam();
            this.gwDDgapbyteTB = new gWeasleGUI.vTextParam();
            this.gwDDgap4aTB = new gWeasleGUI.vTextParam();
            this.gwDDgap3TB = new gWeasleGUI.vTextParam();
            this.gwDDgap2TB = new gWeasleGUI.vTextParam();
            this.gwDDgap1TB = new gWeasleGUI.vTextParam();
            this.gwDDrpmTB = new gWeasleGUI.vTextParam();
            this.gwDDrateTB = new gWeasleGUI.vTextParam();
            this.gwDDhTB = new gWeasleGUI.vTextParam();
            this.gwDDinterleaveTB = new gWeasleGUI.vTextParam();
            this.gwDDidTB = new gWeasleGUI.vTextParam();
            this.gwDDhskewTB = new gWeasleGUI.vTextParam();
            this.gwDDcskewTB = new gWeasleGUI.vTextParam();
            this.gwDDbpsTB = new gWeasleGUI.vTextParam();
            this.gwDDformatTB = new gWeasleGUI.vTextParam();
            this.gwDDtracksTB = new gWeasleGUI.vTextParam();
            this.gwDDsectorsTB = new gWeasleGUI.vTextParam();
            this.gwDDStepTB = new gWeasleGUI.vTextParam();
            this.gwDDHeadsTB = new gWeasleGUI.vTextParam();
            this.gwDDCylsTB = new gWeasleGUI.vTextParam();
            this.diskDefNameTB = new gWeasleGUI.vTextParam();
            this.gwPortTB = new gWeasleGUI.vTextParam();
            this.busy1 = new System.Windows.Forms.PictureBox();
            this.GWTab = new System.Windows.Forms.TabControl();
            this.actionTab = new System.Windows.Forms.TabPage();
            this.outputTB = new System.Windows.Forms.TextBox();
            this.parmTab = new System.Windows.Forms.TabPage();
            this.gwDelaysCB = new System.Windows.Forms.CheckBox();
            this.gwTagLBL = new System.Windows.Forms.Label();
            this.gwReverseCB = new System.Windows.Forms.CheckBox();
            this.gwUseDiskDefFileCB = new System.Windows.Forms.CheckBox();
            this.gwOTTSPECSwapCB = new System.Windows.Forms.CheckBox();
            this.gwTSPECSwapCB = new System.Windows.Forms.CheckBox();
            this.driveLBL = new System.Windows.Forms.Label();
            this.gwNrLBL = new System.Windows.Forms.Label();
            this.gwNrTB = new gWeasleGUI.vTextParam();
            this.gwForceCB = new System.Windows.Forms.CheckBox();
            this.gwMotorOnCB = new System.Windows.Forms.CheckBox();
            this.gwLingerLBL = new System.Windows.Forms.Label();
            this.gwLingerTB = new gWeasleGUI.vTextParam();
            this.gwPassesLBL = new System.Windows.Forms.Label();
            this.gwPassesTB = new gWeasleGUI.vTextParam();
            this.gwOTTSPECOffsetsTB = new gWeasleGUI.vTextParam();
            this.gwOTTSPECOffsetsLBL = new System.Windows.Forms.Label();
            this.gwHFreqCB = new System.Windows.Forms.CheckBox();
            this.gwOutTracksLBL = new System.Windows.Forms.Label();
            this.gwOTTSPECStepTB = new gWeasleGUI.vTextParam();
            this.gwOTTSPECStepLBL = new System.Windows.Forms.Label();
            this.gwOTTSPECHeadsTB = new gWeasleGUI.vTextParam();
            this.gwOTTSPECHeadsLBL = new System.Windows.Forms.Label();
            this.gwOTTSPECCylTB = new gWeasleGUI.vTextParam();
            this.gwOTTSPECCylLBL = new System.Windows.Forms.Label();
            this.gwPreEraseCB = new System.Windows.Forms.CheckBox();
            this.gwRevsLBL = new System.Windows.Forms.Label();
            this.gwAdjustSpeedLBL = new System.Windows.Forms.Label();
            this.gwFakeIndexLBL = new System.Windows.Forms.Label();
            this.gwPLLPhaseTB = new gWeasleGUI.vTextParam();
            this.gwPLLPhaseLBL = new System.Windows.Forms.Label();
            this.gwPLLPeriodTB = new gWeasleGUI.vTextParam();
            this.gwPLLPeriodLBL = new System.Windows.Forms.Label();
            this.gwTSPECOffsetsTB = new gWeasleGUI.vTextParam();
            this.gwTSPECOffsetsLBL = new System.Windows.Forms.Label();
            this.gwTSPECStepTB = new gWeasleGUI.vTextParam();
            this.gwTSPECStepLBL = new System.Windows.Forms.Label();
            this.gwTSPECHeadsTB = new gWeasleGUI.vTextParam();
            this.gwTSPECHeadsLBL = new System.Windows.Forms.Label();
            this.gwTSPECCylTB = new gWeasleGUI.vTextParam();
            this.gwTSPECCylLBL = new System.Windows.Forms.Label();
            this.gwNoVerifyCB = new System.Windows.Forms.CheckBox();
            this.gwEraseBlankCB = new System.Windows.Forms.CheckBox();
            this.gwRawCB = new System.Windows.Forms.CheckBox();
            this.gwSeekRetriesTB = new gWeasleGUI.vTextParam();
            this.gwSeekRetriesLBL = new System.Windows.Forms.Label();
            this.gwRetriesLBL = new System.Windows.Forms.Label();
            this.GwFileDisplay = new System.Windows.Forms.Label();
            this.gwCylLBL = new System.Windows.Forms.Label();
            this.gwCylTB = new gWeasleGUI.vTextParam();
            this.additonalArgsLBL = new System.Windows.Forms.Label();
            this.additonalArgsTB = new gWeasleGUI.vTextParam();
            this.gwFormatTypeCB = new System.Windows.Forms.ComboBox();
            this.gwFormatTypeLBL = new System.Windows.Forms.Label();
            this.ddTab = new System.Windows.Forms.TabPage();
            this.gwDDImport = new System.Windows.Forms.ComboBox();
            this.gwDDfileLBL = new System.Windows.Forms.Label();
            this.gwDDtracksgroupBox = new System.Windows.Forms.GroupBox();
            this.gwDDsubformatLBL = new System.Windows.Forms.Label();
            this.gwDDclockLBL = new System.Windows.Forms.Label();
            this.gwDDimgbpsLBL = new System.Windows.Forms.Label();
            this.gwDDgapbyteLBL = new System.Windows.Forms.Label();
            this.gwDDgap4aLBL = new System.Windows.Forms.Label();
            this.gwDDgap3LBL = new System.Windows.Forms.Label();
            this.gwDDgap2LBL = new System.Windows.Forms.Label();
            this.gwDDgap1LBL = new System.Windows.Forms.Label();
            this.gwDDrpmLBL = new System.Windows.Forms.Label();
            this.gwDDrateLBL = new System.Windows.Forms.Label();
            this.gwDDhLBL = new System.Windows.Forms.Label();
            this.gwDDinterleaveLBL = new System.Windows.Forms.Label();
            this.gwDDidLBL = new System.Windows.Forms.Label();
            this.gwDDhskewLBL = new System.Windows.Forms.Label();
            this.gwDDcskewLBL = new System.Windows.Forms.Label();
            this.gwDDbpsLBL = new System.Windows.Forms.Label();
            this.gwDDformatLBL = new System.Windows.Forms.Label();
            this.gwDDtracksLBL = new System.Windows.Forms.Label();
            this.gwDDsectorsLBL = new System.Windows.Forms.Label();
            this.gwDDTrackListLB = new System.Windows.Forms.ListBox();
            this.gwDDStepLBL = new System.Windows.Forms.Label();
            this.gwDDheadsLBL = new System.Windows.Forms.Label();
            this.gwDDCylsLBL = new System.Windows.Forms.Label();
            this.diskDefsNameLBL = new System.Windows.Forms.Label();
            this.gwDiskConfigLBL = new System.Windows.Forms.Label();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.ProfileDelBtn = new System.Windows.Forms.Button();
            this.gwHostToolsVersionValue = new System.Windows.Forms.Label();
            this.gwHostToolsVersionLBL = new System.Windows.Forms.Label();
            this.SelectProfilePathBtn = new System.Windows.Forms.Button();
            this.ProfileClearBtn = new System.Windows.Forms.Button();
            this.SaveProfileBtn = new System.Windows.Forms.Button();
            this.ProfileNameLBL = new System.Windows.Forms.Label();
            this.ProfileNameTB = new gWeasleGUI.vTextParam();
            this.CmdProfileFileLBL = new System.Windows.Forms.Label();
            this.gwProfileSelLBL = new System.Windows.Forms.Label();
            this.OpenProfileBtn = new System.Windows.Forms.Button();
            this.gwProfileFileTB = new gWeasleGUI.vTextParam();
            this.gwPathSelectionLBL = new System.Windows.Forms.Label();
            this.SelectGWPathBtn = new System.Windows.Forms.Button();
            this.gwPathSelectionTB = new gWeasleGUI.vTextParam();
            this.deviceTab = new System.Windows.Forms.TabPage();
            this.gwAutoReloadBtn = new System.Windows.Forms.Button();
            this.gwReloadBtn = new System.Windows.Forms.Button();
            this.gwUSBRateValue = new System.Windows.Forms.Label();
            this.gwUSBRateLBL = new System.Windows.Forms.Label();
            this.gwSerialLBL = new System.Windows.Forms.Label();
            this.gwFirmwareValue = new System.Windows.Forms.Label();
            this.gwFirmwareLBL = new System.Windows.Forms.Label();
            this.gwMCUValue = new System.Windows.Forms.Label();
            this.gwMCULBL = new System.Windows.Forms.Label();
            this.gwModelValue = new System.Windows.Forms.Label();
            this.gwModelLBL = new System.Windows.Forms.Label();
            this.gwPortLBL = new System.Windows.Forms.Label();
            this.portsTab = new System.Windows.Forms.TabPage();
            this.refreshportsbtn = new System.Windows.Forms.Button();
            this.useportbtn = new System.Windows.Forms.Button();
            this.portbusdescValue = new System.Windows.Forms.Label();
            this.portbusdescLBL = new System.Windows.Forms.Label();
            this.portcaptionCB = new System.Windows.Forms.ComboBox();
            this.porterrordescValue = new System.Windows.Forms.Label();
            this.porterrordescLBL = new System.Windows.Forms.Label();
            this.portstatusValue = new System.Windows.Forms.Label();
            this.portstatusLBL = new System.Windows.Forms.Label();
            this.portserviceValue = new System.Windows.Forms.Label();
            this.pertserviceLBL = new System.Windows.Forms.Label();
            this.portClassGuidValue = new System.Windows.Forms.Label();
            this.portclassguidLBL = new System.Windows.Forms.Label();
            this.portdeviceIdValue = new System.Windows.Forms.Label();
            this.portdeviceIdLBL = new System.Windows.Forms.Label();
            this.portdescValue = new System.Windows.Forms.Label();
            this.portdescLBL = new System.Windows.Forms.Label();
            this.portnameValue = new System.Windows.Forms.Label();
            this.portnameLBL = new System.Windows.Forms.Label();
            this.portcaptionLBL = new System.Windows.Forms.Label();
            this.CmdProfileCB = new System.Windows.Forms.ComboBox();
            this.gwCmdProfileLBL = new System.Windows.Forms.Label();
            this.gwPLLLowPassTB = new gWeasleGUI.vTextParam();
            this.gwPLLLowPassLBL = new System.Windows.Forms.Label();
            this.GwStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accessoptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.busy1)).BeginInit();
            this.GWTab.SuspendLayout();
            this.actionTab.SuspendLayout();
            this.parmTab.SuspendLayout();
            this.ddTab.SuspendLayout();
            this.gwDDtracksgroupBox.SuspendLayout();
            this.optionsTab.SuspendLayout();
            this.deviceTab.SuspendLayout();
            this.portsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExecuteBtn
            // 
            this.ExecuteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteBtn.Location = new System.Drawing.Point(885, 503);
            this.ExecuteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(100, 28);
            this.ExecuteBtn.TabIndex = 5;
            this.ExecuteBtn.Text = "Execute";
            this.ExecuteBtn.UseVisualStyleBackColor = true;
            this.ExecuteBtn.Click += new System.EventHandler(this.ExecuteBtn_Click);
            // 
            // actionCB
            // 
            this.actionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionCB.FormattingEnabled = true;
            this.actionCB.Location = new System.Drawing.Point(75, 12);
            this.actionCB.Margin = new System.Windows.Forms.Padding(4);
            this.actionCB.Name = "actionCB";
            this.actionCB.Size = new System.Drawing.Size(91, 24);
            this.actionCB.TabIndex = 0;
            this.actionCB.SelectedIndexChanged += new System.EventHandler(this.actionCB_SelectedIndexChanged);
            // 
            // GwStatus
            // 
            this.GwStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.GwStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gwToolsVersion,
            this.GwGUIActions,
            this.GwCurrentStatus});
            this.GwStatus.Location = new System.Drawing.Point(0, 541);
            this.GwStatus.Name = "GwStatus";
            this.GwStatus.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.GwStatus.Size = new System.Drawing.Size(1055, 26);
            this.GwStatus.TabIndex = 5;
            this.GwStatus.Text = "Status";
            // 
            // gwToolsVersion
            // 
            this.gwToolsVersion.Name = "gwToolsVersion";
            this.gwToolsVersion.Size = new System.Drawing.Size(45, 20);
            this.gwToolsVersion.Text = "None";
            // 
            // GwGUIActions
            // 
            this.GwGUIActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GwGUIActions.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.GwGUIActions.IsLink = true;
            this.GwGUIActions.Name = "GwGUIActions";
            this.GwGUIActions.Size = new System.Drawing.Size(72, 20);
            this.GwGUIActions.Text = "UIActions";
            this.GwGUIActions.Visible = false;
            this.GwGUIActions.Click += new System.EventHandler(this.GwGUIActions_Click);
            // 
            // GwCurrentStatus
            // 
            this.GwCurrentStatus.Name = "GwCurrentStatus";
            this.GwCurrentStatus.Size = new System.Drawing.Size(49, 20);
            this.GwCurrentStatus.Text = "Status";
            // 
            // actionLBL
            // 
            this.actionLBL.AutoSize = true;
            this.actionLBL.Location = new System.Drawing.Point(17, 16);
            this.actionLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.actionLBL.Name = "actionLBL";
            this.actionLBL.Size = new System.Drawing.Size(44, 16);
            this.actionLBL.TabIndex = 6;
            this.actionLBL.Text = "Action";
            // 
            // timeCB
            // 
            this.timeCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timeCB.AutoSize = true;
            this.timeCB.Location = new System.Drawing.Point(617, 509);
            this.timeCB.Margin = new System.Windows.Forms.Padding(4);
            this.timeCB.Name = "timeCB";
            this.timeCB.Size = new System.Drawing.Size(150, 20);
            this.timeCB.TabIndex = 3;
            this.timeCB.Text = "Report Elapse Time";
            this.timeCB.UseVisualStyleBackColor = true;
            this.timeCB.CheckedChanged += new System.EventHandler(this.timeCB_CheckedChanged);
            // 
            // gwCmdHelpBtn
            // 
            this.gwCmdHelpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gwCmdHelpBtn.Location = new System.Drawing.Point(775, 503);
            this.gwCmdHelpBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gwCmdHelpBtn.Name = "gwCmdHelpBtn";
            this.gwCmdHelpBtn.Size = new System.Drawing.Size(103, 28);
            this.gwCmdHelpBtn.TabIndex = 4;
            this.gwCmdHelpBtn.Text = "Action Help";
            this.gwCmdHelpBtn.UseVisualStyleBackColor = true;
            this.gwCmdHelpBtn.Click += new System.EventHandler(this.gwCmdHelpBtn_Click);
            // 
            // accessoptions
            // 
            this.accessoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.accessoptions.Image = global::gWeasleGUI.Properties.Resources.Grey_Options;
            this.accessoptions.Location = new System.Drawing.Point(17, 502);
            this.accessoptions.Margin = new System.Windows.Forms.Padding(4);
            this.accessoptions.Name = "accessoptions";
            this.accessoptions.Size = new System.Drawing.Size(37, 34);
            this.accessoptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.accessoptions.TabIndex = 27;
            this.accessoptions.TabStop = false;
            this.gweazleTips.SetToolTip(this.accessoptions, "Options");
            this.accessoptions.Click += new System.EventHandler(this.accessoptions_Click);
            // 
            // removeDiskConfigBtn
            // 
            this.removeDiskConfigBtn.Location = new System.Drawing.Point(367, 46);
            this.removeDiskConfigBtn.Margin = new System.Windows.Forms.Padding(4);
            this.removeDiskConfigBtn.Name = "removeDiskConfigBtn";
            this.removeDiskConfigBtn.Size = new System.Drawing.Size(91, 28);
            this.removeDiskConfigBtn.TabIndex = 44;
            this.removeDiskConfigBtn.Text = "Remove";
            this.gweazleTips.SetToolTip(this.removeDiskConfigBtn, "Remove the selected config");
            this.removeDiskConfigBtn.UseVisualStyleBackColor = true;
            this.removeDiskConfigBtn.Click += new System.EventHandler(this.removeDiskConfigBtn_Click);
            // 
            // gwDDSaveBtn
            // 
            this.gwDDSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gwDDSaveBtn.Location = new System.Drawing.Point(159, 383);
            this.gwDDSaveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDSaveBtn.Name = "gwDDSaveBtn";
            this.gwDDSaveBtn.Size = new System.Drawing.Size(136, 28);
            this.gwDDSaveBtn.TabIndex = 74;
            this.gwDDSaveBtn.Text = "Save to file";
            this.gweazleTips.SetToolTip(this.gwDDSaveBtn, "Save to the config file");
            this.gwDDSaveBtn.UseVisualStyleBackColor = true;
            this.gwDDSaveBtn.Click += new System.EventHandler(this.gwDDSaveBtn_Click);
            // 
            // gwDDReloadBtn
            // 
            this.gwDDReloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gwDDReloadBtn.Location = new System.Drawing.Point(13, 383);
            this.gwDDReloadBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDReloadBtn.Name = "gwDDReloadBtn";
            this.gwDDReloadBtn.Size = new System.Drawing.Size(136, 28);
            this.gwDDReloadBtn.TabIndex = 73;
            this.gwDDReloadBtn.Text = "Reload from file";
            this.gweazleTips.SetToolTip(this.gwDDReloadBtn, "Reload the config file");
            this.gwDDReloadBtn.UseVisualStyleBackColor = true;
            this.gwDDReloadBtn.Click += new System.EventHandler(this.gwDDReloadBtn_Click);
            // 
            // gwDDfileBtn
            // 
            this.gwDDfileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gwDDfileBtn.Location = new System.Drawing.Point(915, 12);
            this.gwDDfileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDfileBtn.Name = "gwDDfileBtn";
            this.gwDDfileBtn.Size = new System.Drawing.Size(82, 28);
            this.gwDDfileBtn.TabIndex = 41;
            this.gwDDfileBtn.Text = "Open File";
            this.gweazleTips.SetToolTip(this.gwDDfileBtn, "Select  a Disk Definition File (*.cfg)");
            this.gwDDfileBtn.UseVisualStyleBackColor = true;
            this.gwDDfileBtn.Click += new System.EventHandler(this.gwDDfileBtn_Click);
            // 
            // gwDDRemoveTrackBtn
            // 
            this.gwDDRemoveTrackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gwDDRemoveTrackBtn.Enabled = false;
            this.gwDDRemoveTrackBtn.Location = new System.Drawing.Point(636, 167);
            this.gwDDRemoveTrackBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDRemoveTrackBtn.Name = "gwDDRemoveTrackBtn";
            this.gwDDRemoveTrackBtn.Size = new System.Drawing.Size(100, 28);
            this.gwDDRemoveTrackBtn.TabIndex = 70;
            this.gwDDRemoveTrackBtn.Text = "Remove";
            this.gweazleTips.SetToolTip(this.gwDDRemoveTrackBtn, "Remove Track set");
            this.gwDDRemoveTrackBtn.UseVisualStyleBackColor = true;
            this.gwDDRemoveTrackBtn.Click += new System.EventHandler(this.gwDDRemoveTrackBtn_Click);
            // 
            // gwDDApplyTrackBtn
            // 
            this.gwDDApplyTrackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gwDDApplyTrackBtn.Location = new System.Drawing.Point(636, 203);
            this.gwDDApplyTrackBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDApplyTrackBtn.Name = "gwDDApplyTrackBtn";
            this.gwDDApplyTrackBtn.Size = new System.Drawing.Size(100, 28);
            this.gwDDApplyTrackBtn.TabIndex = 71;
            this.gwDDApplyTrackBtn.Text = "Apply / Add";
            this.gweazleTips.SetToolTip(this.gwDDApplyTrackBtn, "Add or Update track set");
            this.gwDDApplyTrackBtn.UseVisualStyleBackColor = true;
            this.gwDDApplyTrackBtn.Click += new System.EventHandler(this.gwDDApplyTrackBtn_Click);
            // 
            // gwDDiamCB
            // 
            this.gwDDiamCB.AutoSize = true;
            this.gwDDiamCB.Location = new System.Drawing.Point(340, 36);
            this.gwDDiamCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDiamCB.Name = "gwDDiamCB";
            this.gwDDiamCB.Size = new System.Drawing.Size(51, 20);
            this.gwDDiamCB.TabIndex = 52;
            this.gwDDiamCB.Text = "iam";
            this.gweazleTips.SetToolTip(this.gwDDiamCB, "Index Address Mark (yes|no, default: yes)");
            this.gwDDiamCB.UseVisualStyleBackColor = true;
            // 
            // diskDefApplyBtn
            // 
            this.diskDefApplyBtn.Location = new System.Drawing.Point(788, 52);
            this.diskDefApplyBtn.Margin = new System.Windows.Forms.Padding(4);
            this.diskDefApplyBtn.Name = "diskDefApplyBtn";
            this.diskDefApplyBtn.Size = new System.Drawing.Size(100, 28);
            this.diskDefApplyBtn.TabIndex = 49;
            this.diskDefApplyBtn.Text = "Apply";
            this.gweazleTips.SetToolTip(this.diskDefApplyBtn, "Apply changes to this config");
            this.diskDefApplyBtn.UseVisualStyleBackColor = true;
            this.diskDefApplyBtn.Click += new System.EventHandler(this.diskDefApplyBtn_Click);
            // 
            // newDiskConfigBtn
            // 
            this.newDiskConfigBtn.Location = new System.Drawing.Point(275, 46);
            this.newDiskConfigBtn.Margin = new System.Windows.Forms.Padding(4);
            this.newDiskConfigBtn.Name = "newDiskConfigBtn";
            this.newDiskConfigBtn.Size = new System.Drawing.Size(91, 28);
            this.newDiskConfigBtn.TabIndex = 43;
            this.newDiskConfigBtn.Text = "New";
            this.gweazleTips.SetToolTip(this.newDiskConfigBtn, "New config");
            this.newDiskConfigBtn.UseVisualStyleBackColor = true;
            this.newDiskConfigBtn.Click += new System.EventHandler(this.newDiskConfigBtn_Click);
            // 
            // gwDiskConfigCB
            // 
            this.gwDiskConfigCB.FormattingEnabled = true;
            this.gwDiskConfigCB.Location = new System.Drawing.Point(109, 48);
            this.gwDiskConfigCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDiskConfigCB.Name = "gwDiskConfigCB";
            this.gwDiskConfigCB.Size = new System.Drawing.Size(160, 24);
            this.gwDiskConfigCB.TabIndex = 42;
            this.gweazleTips.SetToolTip(this.gwDiskConfigCB, "Loaded disk configs");
            this.gwDiskConfigCB.SelectedIndexChanged += new System.EventHandler(this.gwDiskConfigCB_SelectedIndexChanged);
            // 
            // SelectNewFileBtn
            // 
            this.SelectNewFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectNewFileBtn.Location = new System.Drawing.Point(925, 7);
            this.SelectNewFileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SelectNewFileBtn.Name = "SelectNewFileBtn";
            this.SelectNewFileBtn.Size = new System.Drawing.Size(77, 28);
            this.SelectNewFileBtn.TabIndex = 7;
            this.SelectNewFileBtn.Text = "New File";
            this.gweazleTips.SetToolTip(this.SelectNewFileBtn, "A file to be created");
            this.SelectNewFileBtn.UseVisualStyleBackColor = true;
            this.SelectNewFileBtn.Click += new System.EventHandler(this.SelectNewFileBtn_Click);
            // 
            // SelectExistingFileBtn
            // 
            this.SelectExistingFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectExistingFileBtn.Location = new System.Drawing.Point(840, 7);
            this.SelectExistingFileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SelectExistingFileBtn.Name = "SelectExistingFileBtn";
            this.SelectExistingFileBtn.Size = new System.Drawing.Size(77, 28);
            this.SelectExistingFileBtn.TabIndex = 6;
            this.SelectExistingFileBtn.Text = "Existing";
            this.gweazleTips.SetToolTip(this.SelectExistingFileBtn, "An existing image file");
            this.SelectExistingFileBtn.UseVisualStyleBackColor = true;
            this.SelectExistingFileBtn.Click += new System.EventHandler(this.SelectExistingFileBtn_Click);
            // 
            // gwSerialValue
            // 
            this.gwSerialValue.AutoSize = true;
            this.gwSerialValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gwSerialValue.Location = new System.Drawing.Point(88, 172);
            this.gwSerialValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwSerialValue.Name = "gwSerialValue";
            this.gwSerialValue.Size = new System.Drawing.Size(60, 17);
            this.gwSerialValue.TabIndex = 59;
            this.gwSerialValue.Text = "[Serial]";
            this.gweazleTips.SetToolTip(this.gwSerialValue, "Double-click to copy to clipboard");
            // 
            // gwDDcb
            // 
            this.gwDDcb.AutoSize = true;
            this.gwDDcb.Location = new System.Drawing.Point(348, 299);
            this.gwDDcb.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDcb.Name = "gwDDcb";
            this.gwDDcb.Size = new System.Drawing.Size(117, 20);
            this.gwDDcb.TabIndex = 128;
            this.gwDDcb.Text = "double density";
            this.gweazleTips.SetToolTip(this.gwDDcb, "drive interface density select");
            this.gwDDcb.UseVisualStyleBackColor = true;
            // 
            // gwNoClobberCB
            // 
            this.gwNoClobberCB.AutoSize = true;
            this.gwNoClobberCB.Location = new System.Drawing.Point(516, 42);
            this.gwNoClobberCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwNoClobberCB.Name = "gwNoClobberCB";
            this.gwNoClobberCB.Size = new System.Drawing.Size(98, 20);
            this.gwNoClobberCB.TabIndex = 129;
            this.gwNoClobberCB.Text = "No Clobber";
            this.gweazleTips.SetToolTip(this.gwNoClobberCB, "do not overwrite an existing file");
            this.gwNoClobberCB.UseVisualStyleBackColor = true;
            this.gwNoClobberCB.Visible = false;
            // 
            // gwHardSectorsCB
            // 
            this.gwHardSectorsCB.AutoSize = true;
            this.gwHardSectorsCB.Location = new System.Drawing.Point(348, 327);
            this.gwHardSectorsCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwHardSectorsCB.Name = "gwHardSectorsCB";
            this.gwHardSectorsCB.Size = new System.Drawing.Size(108, 20);
            this.gwHardSectorsCB.TabIndex = 130;
            this.gwHardSectorsCB.Text = "Hard Sectors";
            this.gweazleTips.SetToolTip(this.gwHardSectorsCB, "hard-sectored disk");
            this.gwHardSectorsCB.UseVisualStyleBackColor = true;
            // 
            // gwDDNewFileBtn
            // 
            this.gwDDNewFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gwDDNewFileBtn.Location = new System.Drawing.Point(826, 12);
            this.gwDDNewFileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDNewFileBtn.Name = "gwDDNewFileBtn";
            this.gwDDNewFileBtn.Size = new System.Drawing.Size(82, 28);
            this.gwDDNewFileBtn.TabIndex = 77;
            this.gwDDNewFileBtn.Text = "New File";
            this.gweazleTips.SetToolTip(this.gwDDNewFileBtn, "Create a Disk Definition File (*.cfg)");
            this.gwDDNewFileBtn.UseVisualStyleBackColor = true;
            this.gwDDNewFileBtn.Click += new System.EventHandler(this.gwDDNewFileBtn_Click);
            // 
            // gwTagTB
            // 
            this.gwTagTB.Location = new System.Drawing.Point(109, 39);
            this.gwTagTB.Name = "gwTagTB";
            this.gwTagTB.Size = new System.Drawing.Size(100, 22);
            this.gwTagTB.TabIndex = 133;
            this.gweazleTips.SetToolTip(this.gwTagTB, "use specified GitHub release tag");
            this.gwTagTB.ValidationFailure = false;
            // 
            // driveTB
            // 
            this.driveTB.Location = new System.Drawing.Point(317, 39);
            this.driveTB.Margin = new System.Windows.Forms.Padding(4);
            this.driveTB.Name = "driveTB";
            this.driveTB.Size = new System.Drawing.Size(29, 22);
            this.driveTB.TabIndex = 9;
            this.gweazleTips.SetToolTip(this.driveTB, "drive to read (default: A)");
            this.driveTB.ValidationFailure = false;
            // 
            // gwRevsTB
            // 
            this.gwRevsTB.Location = new System.Drawing.Point(115, 262);
            this.gwRevsTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwRevsTB.Name = "gwRevsTB";
            this.gwRevsTB.Size = new System.Drawing.Size(52, 22);
            this.gwRevsTB.TabIndex = 27;
            this.gweazleTips.SetToolTip(this.gwRevsTB, "number of revolutions to read per track");
            this.gwRevsTB.ValidationFailure = false;
            this.gwRevsTB.Visible = false;
            // 
            // gwAdjustSpeedTB
            // 
            this.gwAdjustSpeedTB.Location = new System.Drawing.Point(277, 294);
            this.gwAdjustSpeedTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwAdjustSpeedTB.Name = "gwAdjustSpeedTB";
            this.gwAdjustSpeedTB.Size = new System.Drawing.Size(52, 22);
            this.gwAdjustSpeedTB.TabIndex = 29;
            this.gweazleTips.SetToolTip(this.gwAdjustSpeedTB, "scale track data to effective drive");
            this.gwAdjustSpeedTB.ValidationFailure = false;
            // 
            // gwFakeIndexTB
            // 
            this.gwFakeIndexTB.Location = new System.Drawing.Point(115, 294);
            this.gwFakeIndexTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwFakeIndexTB.Name = "gwFakeIndexTB";
            this.gwFakeIndexTB.Size = new System.Drawing.Size(52, 22);
            this.gwFakeIndexTB.TabIndex = 28;
            this.gweazleTips.SetToolTip(this.gwFakeIndexTB, "fake index pulses");
            this.gwFakeIndexTB.ValidationFailure = false;
            // 
            // gwRetriesTB
            // 
            this.gwRetriesTB.Location = new System.Drawing.Point(115, 326);
            this.gwRetriesTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwRetriesTB.Name = "gwRetriesTB";
            this.gwRetriesTB.Size = new System.Drawing.Size(52, 22);
            this.gwRetriesTB.TabIndex = 30;
            this.gweazleTips.SetToolTip(this.gwRetriesTB, "number of retries per seek-retry");
            this.gwRetriesTB.ValidationFailure = false;
            // 
            // gwDDsubformatTB
            // 
            this.gwDDsubformatTB.Location = new System.Drawing.Point(423, 161);
            this.gwDDsubformatTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDsubformatTB.Name = "gwDDsubformatTB";
            this.gwDDsubformatTB.Size = new System.Drawing.Size(61, 22);
            this.gwDDsubformatTB.TabIndex = 69;
            this.gweazleTips.SetToolTip(this.gwDDsubformatTB, "Format code for these tracks");
            this.gwDDsubformatTB.ValidationFailure = false;
            // 
            // gwDDclockTB
            // 
            this.gwDDclockTB.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDclockTB.Location = new System.Drawing.Point(549, 33);
            this.gwDDclockTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDclockTB.Name = "gwDDclockTB";
            this.gwDDclockTB.Size = new System.Drawing.Size(69, 22);
            this.gwDDclockTB.TabIndex = 54;
            this.gweazleTips.SetToolTip(this.gwDDclockTB, "Clock");
            this.gwDDclockTB.ValidationFailure = false;
            // 
            // gwDDimgbpsTB
            // 
            this.gwDDimgbpsTB.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDimgbpsTB.Location = new System.Drawing.Point(261, 161);
            this.gwDDimgbpsTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDimgbpsTB.Name = "gwDDimgbpsTB";
            this.gwDDimgbpsTB.Size = new System.Drawing.Size(69, 22);
            this.gwDDimgbpsTB.TabIndex = 68;
            this.gweazleTips.SetToolTip(this.gwDDimgbpsTB, "Bytes per sector in IMG file (short sectors are padded)");
            this.gwDDimgbpsTB.ValidationFailure = false;
            // 
            // gwDDgapbyteTB
            // 
            this.gwDDgapbyteTB.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDgapbyteTB.Location = new System.Drawing.Point(96, 161);
            this.gwDDgapbyteTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDgapbyteTB.Name = "gwDDgapbyteTB";
            this.gwDDgapbyteTB.Size = new System.Drawing.Size(87, 22);
            this.gwDDgapbyteTB.TabIndex = 67;
            this.gweazleTips.SetToolTip(this.gwDDgapbyteTB, "Byte value used to fill the above gaps (0-255, default: auto)");
            this.gwDDgapbyteTB.ValidationFailure = false;
            // 
            // gwDDgap4aTB
            // 
            this.gwDDgap4aTB.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDgap4aTB.Location = new System.Drawing.Point(429, 129);
            this.gwDDgap4aTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDgap4aTB.Name = "gwDDgap4aTB";
            this.gwDDgap4aTB.Size = new System.Drawing.Size(61, 22);
            this.gwDDgap4aTB.TabIndex = 66;
            this.gweazleTips.SetToolTip(this.gwDDgap4aTB, "Post-Index Gap size (0-255, default: auto)");
            this.gwDDgap4aTB.ValidationFailure = false;
            // 
            // gwDDgap3TB
            // 
            this.gwDDgap3TB.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDgap3TB.Location = new System.Drawing.Point(301, 129);
            this.gwDDgap3TB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDgap3TB.Name = "gwDDgap3TB";
            this.gwDDgap3TB.Size = new System.Drawing.Size(61, 22);
            this.gwDDgap3TB.TabIndex = 65;
            this.gweazleTips.SetToolTip(this.gwDDgap3TB, "Post-DAM Gap size (0-255, default: auto)");
            this.gwDDgap3TB.ValidationFailure = false;
            // 
            // gwDDgap2TB
            // 
            this.gwDDgap2TB.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDgap2TB.Location = new System.Drawing.Point(192, 129);
            this.gwDDgap2TB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDgap2TB.Name = "gwDDgap2TB";
            this.gwDDgap2TB.Size = new System.Drawing.Size(51, 22);
            this.gwDDgap2TB.TabIndex = 64;
            this.gweazleTips.SetToolTip(this.gwDDgap2TB, "Post-IDAM Gap size (0-255, default: auto)");
            this.gwDDgap2TB.ValidationFailure = false;
            // 
            // gwDDgap1TB
            // 
            this.gwDDgap1TB.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDgap1TB.Location = new System.Drawing.Point(75, 129);
            this.gwDDgap1TB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDgap1TB.Name = "gwDDgap1TB";
            this.gwDDgap1TB.Size = new System.Drawing.Size(59, 22);
            this.gwDDgap1TB.TabIndex = 63;
            this.gweazleTips.SetToolTip(this.gwDDgap1TB, "Post-IAM Gap size (0-255, default: auto)");
            this.gwDDgap1TB.ValidationFailure = false;
            // 
            // gwDDrpmTB
            // 
            this.gwDDrpmTB.Location = new System.Drawing.Point(447, 97);
            this.gwDDrpmTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDrpmTB.Name = "gwDDrpmTB";
            this.gwDDrpmTB.Size = new System.Drawing.Size(61, 22);
            this.gwDDrpmTB.TabIndex = 62;
            this.gweazleTips.SetToolTip(this.gwDDrpmTB, "Disk spin speed in RPM (1-2000, default: 300)");
            this.gwDDrpmTB.ValidationFailure = false;
            // 
            // gwDDrateTB
            // 
            this.gwDDrateTB.Location = new System.Drawing.Point(336, 97);
            this.gwDDrateTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDrateTB.Name = "gwDDrateTB";
            this.gwDDrateTB.Size = new System.Drawing.Size(61, 22);
            this.gwDDrateTB.TabIndex = 61;
            this.gweazleTips.SetToolTip(this.gwDDrateTB, "Data rate in kbps (1-2000, default: auto)");
            this.gwDDrateTB.ValidationFailure = false;
            // 
            // gwDDhTB
            // 
            this.gwDDhTB.Location = new System.Drawing.Point(228, 97);
            this.gwDDhTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDhTB.Name = "gwDDhTB";
            this.gwDDhTB.Size = new System.Drawing.Size(51, 22);
            this.gwDDhTB.TabIndex = 60;
            this.gweazleTips.SetToolTip(this.gwDDhTB, "Head (aka H) byte value in each sector header (0-255, default: auto)");
            this.gwDDhTB.ValidationFailure = false;
            // 
            // gwDDinterleaveTB
            // 
            this.gwDDinterleaveTB.Location = new System.Drawing.Point(108, 97);
            this.gwDDinterleaveTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDinterleaveTB.Name = "gwDDinterleaveTB";
            this.gwDDinterleaveTB.Size = new System.Drawing.Size(59, 22);
            this.gwDDinterleaveTB.TabIndex = 59;
            this.gweazleTips.SetToolTip(this.gwDDinterleaveTB, "Sector interleave, N:1 (1-255, default: 1)");
            this.gwDDinterleaveTB.ValidationFailure = false;
            // 
            // gwDDidTB
            // 
            this.gwDDidTB.Location = new System.Drawing.Point(432, 33);
            this.gwDDidTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDidTB.Name = "gwDDidTB";
            this.gwDDidTB.Size = new System.Drawing.Size(61, 22);
            this.gwDDidTB.TabIndex = 53;
            this.gweazleTips.SetToolTip(this.gwDDidTB, "Sector ID (aka R) of logical first sector (0-255, default: 1)");
            this.gwDDidTB.ValidationFailure = false;
            // 
            // gwDDhskewTB
            // 
            this.gwDDhskewTB.Location = new System.Drawing.Point(549, 65);
            this.gwDDhskewTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDhskewTB.Name = "gwDDhskewTB";
            this.gwDDhskewTB.Size = new System.Drawing.Size(61, 22);
            this.gwDDhskewTB.TabIndex = 58;
            this.gweazleTips.SetToolTip(this.gwDDhskewTB, "Sector skew per head (0-255, default: 0)");
            this.gwDDhskewTB.ValidationFailure = false;
            // 
            // gwDDcskewTB
            // 
            this.gwDDcskewTB.Location = new System.Drawing.Point(389, 65);
            this.gwDDcskewTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDcskewTB.Name = "gwDDcskewTB";
            this.gwDDcskewTB.Size = new System.Drawing.Size(61, 22);
            this.gwDDcskewTB.TabIndex = 57;
            this.gweazleTips.SetToolTip(this.gwDDcskewTB, "Sector skew per cylinder (0-255, default: 0)");
            this.gwDDcskewTB.ValidationFailure = false;
            // 
            // gwDDbpsTB
            // 
            this.gwDDbpsTB.Location = new System.Drawing.Point(200, 65);
            this.gwDDbpsTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDbpsTB.Name = "gwDDbpsTB";
            this.gwDDbpsTB.Size = new System.Drawing.Size(112, 22);
            this.gwDDbpsTB.TabIndex = 56;
            this.gweazleTips.SetToolTip(this.gwDDbpsTB, "Bytes per sector (128, 256, 512, 1024, 2048, 4096, 8192)");
            this.gwDDbpsTB.ValidationFailure = false;
            // 
            // gwDDformatTB
            // 
            this.gwDDformatTB.Location = new System.Drawing.Point(232, 33);
            this.gwDDformatTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDformatTB.Name = "gwDDformatTB";
            this.gwDDformatTB.Size = new System.Drawing.Size(99, 22);
            this.gwDDformatTB.TabIndex = 51;
            this.gweazleTips.SetToolTip(this.gwDDformatTB, "Format for these tracks");
            this.gwDDformatTB.ValidationFailure = false;
            // 
            // gwDDtracksTB
            // 
            this.gwDDtracksTB.Location = new System.Drawing.Point(93, 33);
            this.gwDDtracksTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDtracksTB.Name = "gwDDtracksTB";
            this.gwDDtracksTB.Size = new System.Drawing.Size(71, 22);
            this.gwDDtracksTB.TabIndex = 50;
            this.gweazleTips.SetToolTip(this.gwDDtracksTB, "Track list or \"*\" for all unmatched tracks");
            this.gwDDtracksTB.ValidationFailure = false;
            // 
            // gwDDsectorsTB
            // 
            this.gwDDsectorsTB.Location = new System.Drawing.Point(93, 65);
            this.gwDDsectorsTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDsectorsTB.Name = "gwDDsectorsTB";
            this.gwDDsectorsTB.Size = new System.Drawing.Size(61, 22);
            this.gwDDsectorsTB.TabIndex = 55;
            this.gweazleTips.SetToolTip(this.gwDDsectorsTB, "Number of sectors (0-256, default: 0)");
            this.gwDDsectorsTB.ValidationFailure = false;
            // 
            // gwDDStepTB
            // 
            this.gwDDStepTB.Location = new System.Drawing.Point(869, 89);
            this.gwDDStepTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDStepTB.Name = "gwDDStepTB";
            this.gwDDStepTB.Size = new System.Drawing.Size(85, 22);
            this.gwDDStepTB.TabIndex = 48;
            this.gweazleTips.SetToolTip(this.gwDDStepTB, "Number of physical drive steps per image step (1-4)");
            this.gwDDStepTB.ValidationFailure = false;
            // 
            // gwDDHeadsTB
            // 
            this.gwDDHeadsTB.Location = new System.Drawing.Point(728, 89);
            this.gwDDHeadsTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDHeadsTB.Name = "gwDDHeadsTB";
            this.gwDDHeadsTB.Size = new System.Drawing.Size(85, 22);
            this.gwDDHeadsTB.TabIndex = 47;
            this.gweazleTips.SetToolTip(this.gwDDHeadsTB, "Number of heads/sides (1-2)");
            this.gwDDHeadsTB.ValidationFailure = false;
            // 
            // gwDDCylsTB
            // 
            this.gwDDCylsTB.BackColor = System.Drawing.SystemColors.Window;
            this.gwDDCylsTB.Location = new System.Drawing.Point(575, 89);
            this.gwDDCylsTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDCylsTB.Name = "gwDDCylsTB";
            this.gwDDCylsTB.Size = new System.Drawing.Size(85, 22);
            this.gwDDCylsTB.TabIndex = 46;
            this.gweazleTips.SetToolTip(this.gwDDCylsTB, "Number of cylinders (1-255)");
            this.gwDDCylsTB.ValidationFailure = false;
            // 
            // diskDefNameTB
            // 
            this.diskDefNameTB.Location = new System.Drawing.Point(619, 54);
            this.diskDefNameTB.Margin = new System.Windows.Forms.Padding(4);
            this.diskDefNameTB.Name = "diskDefNameTB";
            this.diskDefNameTB.Size = new System.Drawing.Size(160, 22);
            this.diskDefNameTB.TabIndex = 45;
            this.gweazleTips.SetToolTip(this.diskDefNameTB, "Disk Definition Name");
            this.diskDefNameTB.ValidationFailure = false;
            // 
            // gwPortTB
            // 
            this.gwPortTB.Location = new System.Drawing.Point(92, 21);
            this.gwPortTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwPortTB.Name = "gwPortTB";
            this.gwPortTB.Size = new System.Drawing.Size(80, 22);
            this.gwPortTB.TabIndex = 83;
            this.gweazleTips.SetToolTip(this.gwPortTB, "device name (COM/serial port)");
            this.gwPortTB.ValidationFailure = false;
            // 
            // busy1
            // 
            this.busy1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.busy1.Image = global::gWeasleGUI.Properties.Resources.RotatingRings;
            this.busy1.InitialImage = null;
            this.busy1.Location = new System.Drawing.Point(993, 496);
            this.busy1.Margin = new System.Windows.Forms.Padding(4);
            this.busy1.Name = "busy1";
            this.busy1.Size = new System.Drawing.Size(45, 41);
            this.busy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.busy1.TabIndex = 9;
            this.busy1.TabStop = false;
            // 
            // GWTab
            // 
            this.GWTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GWTab.Controls.Add(this.actionTab);
            this.GWTab.Controls.Add(this.parmTab);
            this.GWTab.Controls.Add(this.ddTab);
            this.GWTab.Controls.Add(this.optionsTab);
            this.GWTab.Controls.Add(this.deviceTab);
            this.GWTab.Controls.Add(this.portsTab);
            this.GWTab.Location = new System.Drawing.Point(17, 47);
            this.GWTab.Margin = new System.Windows.Forms.Padding(4);
            this.GWTab.Name = "GWTab";
            this.GWTab.SelectedIndex = 0;
            this.GWTab.Size = new System.Drawing.Size(1021, 452);
            this.GWTab.TabIndex = 2;
            this.GWTab.SelectedIndexChanged += new System.EventHandler(this.GWTab_SelectedIndexChanged);
            // 
            // actionTab
            // 
            this.actionTab.Controls.Add(this.outputTB);
            this.actionTab.Location = new System.Drawing.Point(4, 25);
            this.actionTab.Margin = new System.Windows.Forms.Padding(4);
            this.actionTab.Name = "actionTab";
            this.actionTab.Padding = new System.Windows.Forms.Padding(4);
            this.actionTab.Size = new System.Drawing.Size(1013, 423);
            this.actionTab.TabIndex = 0;
            this.actionTab.Text = "Action";
            this.actionTab.UseVisualStyleBackColor = true;
            // 
            // outputTB
            // 
            this.outputTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTB.BackColor = System.Drawing.SystemColors.HotTrack;
            this.outputTB.Font = new System.Drawing.Font("Ubuntu Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTB.ForeColor = System.Drawing.Color.Gold;
            this.outputTB.Location = new System.Drawing.Point(0, 0);
            this.outputTB.Margin = new System.Windows.Forms.Padding(4);
            this.outputTB.Multiline = true;
            this.outputTB.Name = "outputTB";
            this.outputTB.ReadOnly = true;
            this.outputTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTB.Size = new System.Drawing.Size(1009, 420);
            this.outputTB.TabIndex = 34;
            this.outputTB.WordWrap = false;
            // 
            // parmTab
            // 
            this.parmTab.Controls.Add(this.gwPLLLowPassTB);
            this.parmTab.Controls.Add(this.gwPLLLowPassLBL);
            this.parmTab.Controls.Add(this.gwDelaysCB);
            this.parmTab.Controls.Add(this.gwTagTB);
            this.parmTab.Controls.Add(this.gwTagLBL);
            this.parmTab.Controls.Add(this.gwReverseCB);
            this.parmTab.Controls.Add(this.gwHardSectorsCB);
            this.parmTab.Controls.Add(this.gwNoClobberCB);
            this.parmTab.Controls.Add(this.gwDDcb);
            this.parmTab.Controls.Add(this.gwUseDiskDefFileCB);
            this.parmTab.Controls.Add(this.gwOTTSPECSwapCB);
            this.parmTab.Controls.Add(this.gwTSPECSwapCB);
            this.parmTab.Controls.Add(this.driveLBL);
            this.parmTab.Controls.Add(this.driveTB);
            this.parmTab.Controls.Add(this.gwNrLBL);
            this.parmTab.Controls.Add(this.gwNrTB);
            this.parmTab.Controls.Add(this.gwForceCB);
            this.parmTab.Controls.Add(this.gwMotorOnCB);
            this.parmTab.Controls.Add(this.gwLingerLBL);
            this.parmTab.Controls.Add(this.gwLingerTB);
            this.parmTab.Controls.Add(this.gwPassesLBL);
            this.parmTab.Controls.Add(this.gwPassesTB);
            this.parmTab.Controls.Add(this.gwOTTSPECOffsetsTB);
            this.parmTab.Controls.Add(this.gwOTTSPECOffsetsLBL);
            this.parmTab.Controls.Add(this.gwHFreqCB);
            this.parmTab.Controls.Add(this.gwOutTracksLBL);
            this.parmTab.Controls.Add(this.gwOTTSPECStepTB);
            this.parmTab.Controls.Add(this.gwOTTSPECStepLBL);
            this.parmTab.Controls.Add(this.gwOTTSPECHeadsTB);
            this.parmTab.Controls.Add(this.gwOTTSPECHeadsLBL);
            this.parmTab.Controls.Add(this.gwOTTSPECCylTB);
            this.parmTab.Controls.Add(this.gwOTTSPECCylLBL);
            this.parmTab.Controls.Add(this.gwPreEraseCB);
            this.parmTab.Controls.Add(this.gwRevsTB);
            this.parmTab.Controls.Add(this.gwRevsLBL);
            this.parmTab.Controls.Add(this.gwAdjustSpeedTB);
            this.parmTab.Controls.Add(this.gwAdjustSpeedLBL);
            this.parmTab.Controls.Add(this.gwFakeIndexTB);
            this.parmTab.Controls.Add(this.gwFakeIndexLBL);
            this.parmTab.Controls.Add(this.gwPLLPhaseTB);
            this.parmTab.Controls.Add(this.gwPLLPhaseLBL);
            this.parmTab.Controls.Add(this.gwPLLPeriodTB);
            this.parmTab.Controls.Add(this.gwPLLPeriodLBL);
            this.parmTab.Controls.Add(this.gwTSPECOffsetsTB);
            this.parmTab.Controls.Add(this.gwTSPECOffsetsLBL);
            this.parmTab.Controls.Add(this.gwTSPECStepTB);
            this.parmTab.Controls.Add(this.gwTSPECStepLBL);
            this.parmTab.Controls.Add(this.gwTSPECHeadsTB);
            this.parmTab.Controls.Add(this.gwTSPECHeadsLBL);
            this.parmTab.Controls.Add(this.gwTSPECCylTB);
            this.parmTab.Controls.Add(this.gwTSPECCylLBL);
            this.parmTab.Controls.Add(this.gwNoVerifyCB);
            this.parmTab.Controls.Add(this.gwEraseBlankCB);
            this.parmTab.Controls.Add(this.gwRawCB);
            this.parmTab.Controls.Add(this.gwSeekRetriesTB);
            this.parmTab.Controls.Add(this.gwSeekRetriesLBL);
            this.parmTab.Controls.Add(this.gwRetriesTB);
            this.parmTab.Controls.Add(this.gwRetriesLBL);
            this.parmTab.Controls.Add(this.SelectNewFileBtn);
            this.parmTab.Controls.Add(this.SelectExistingFileBtn);
            this.parmTab.Controls.Add(this.GwFileDisplay);
            this.parmTab.Controls.Add(this.gwCylLBL);
            this.parmTab.Controls.Add(this.gwCylTB);
            this.parmTab.Controls.Add(this.additonalArgsLBL);
            this.parmTab.Controls.Add(this.additonalArgsTB);
            this.parmTab.Controls.Add(this.gwFormatTypeCB);
            this.parmTab.Controls.Add(this.gwFormatTypeLBL);
            this.parmTab.Location = new System.Drawing.Point(4, 25);
            this.parmTab.Margin = new System.Windows.Forms.Padding(4);
            this.parmTab.Name = "parmTab";
            this.parmTab.Padding = new System.Windows.Forms.Padding(4);
            this.parmTab.Size = new System.Drawing.Size(1013, 423);
            this.parmTab.TabIndex = 1;
            this.parmTab.Text = "Parameters";
            this.parmTab.UseVisualStyleBackColor = true;
            // 
            // gwDelaysCB
            // 
            this.gwDelaysCB.AutoSize = true;
            this.gwDelaysCB.Location = new System.Drawing.Point(348, 73);
            this.gwDelaysCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDelaysCB.Name = "gwDelaysCB";
            this.gwDelaysCB.Size = new System.Drawing.Size(72, 20);
            this.gwDelaysCB.TabIndex = 134;
            this.gwDelaysCB.Text = "Delays";
            this.gwDelaysCB.UseVisualStyleBackColor = true;
            // 
            // gwTagLBL
            // 
            this.gwTagLBL.AutoSize = true;
            this.gwTagLBL.Location = new System.Drawing.Point(69, 43);
            this.gwTagLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwTagLBL.Name = "gwTagLBL";
            this.gwTagLBL.Size = new System.Drawing.Size(32, 16);
            this.gwTagLBL.TabIndex = 132;
            this.gwTagLBL.Text = "Tag";
            // 
            // gwReverseCB
            // 
            this.gwReverseCB.AutoSize = true;
            this.gwReverseCB.Location = new System.Drawing.Point(348, 271);
            this.gwReverseCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwReverseCB.Name = "gwReverseCB";
            this.gwReverseCB.Size = new System.Drawing.Size(81, 20);
            this.gwReverseCB.TabIndex = 131;
            this.gwReverseCB.Text = "Reverse";
            this.gwReverseCB.UseVisualStyleBackColor = true;
            // 
            // gwUseDiskDefFileCB
            // 
            this.gwUseDiskDefFileCB.AutoSize = true;
            this.gwUseDiskDefFileCB.Location = new System.Drawing.Point(357, 42);
            this.gwUseDiskDefFileCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwUseDiskDefFileCB.Name = "gwUseDiskDefFileCB";
            this.gwUseDiskDefFileCB.Size = new System.Drawing.Size(140, 20);
            this.gwUseDiskDefFileCB.TabIndex = 10;
            this.gwUseDiskDefFileCB.Text = "Use Disk Defs File";
            this.gwUseDiskDefFileCB.UseVisualStyleBackColor = true;
            this.gwUseDiskDefFileCB.Visible = false;
            this.gwUseDiskDefFileCB.CheckedChanged += new System.EventHandler(this.gwUseDiskDefFileCB_CheckedChanged);
            // 
            // gwOTTSPECSwapCB
            // 
            this.gwOTTSPECSwapCB.AutoSize = true;
            this.gwOTTSPECSwapCB.Location = new System.Drawing.Point(436, 134);
            this.gwOTTSPECSwapCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwOTTSPECSwapCB.Name = "gwOTTSPECSwapCB";
            this.gwOTTSPECSwapCB.Size = new System.Drawing.Size(63, 20);
            this.gwOTTSPECSwapCB.TabIndex = 22;
            this.gwOTTSPECSwapCB.Tag = "hswap";
            this.gwOTTSPECSwapCB.Text = "Swap";
            this.gwOTTSPECSwapCB.UseVisualStyleBackColor = true;
            // 
            // gwTSPECSwapCB
            // 
            this.gwTSPECSwapCB.AutoSize = true;
            this.gwTSPECSwapCB.Location = new System.Drawing.Point(169, 134);
            this.gwTSPECSwapCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwTSPECSwapCB.Name = "gwTSPECSwapCB";
            this.gwTSPECSwapCB.Size = new System.Drawing.Size(63, 20);
            this.gwTSPECSwapCB.TabIndex = 17;
            this.gwTSPECSwapCB.Tag = "hswap";
            this.gwTSPECSwapCB.Text = "Swap";
            this.gwTSPECSwapCB.UseVisualStyleBackColor = true;
            // 
            // driveLBL
            // 
            this.driveLBL.AutoSize = true;
            this.driveLBL.Location = new System.Drawing.Point(267, 43);
            this.driveLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.driveLBL.Name = "driveLBL";
            this.driveLBL.Size = new System.Drawing.Size(39, 16);
            this.driveLBL.TabIndex = 127;
            this.driveLBL.Text = "Drive";
            // 
            // gwNrLBL
            // 
            this.gwNrLBL.AutoSize = true;
            this.gwNrLBL.Location = new System.Drawing.Point(20, 76);
            this.gwNrLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwNrLBL.Name = "gwNrLBL";
            this.gwNrLBL.Size = new System.Drawing.Size(61, 16);
            this.gwNrLBL.TabIndex = 126;
            this.gwNrLBL.Text = "Iterations";
            this.gwNrLBL.Visible = false;
            // 
            // gwNrTB
            // 
            this.gwNrTB.Location = new System.Drawing.Point(95, 73);
            this.gwNrTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwNrTB.Name = "gwNrTB";
            this.gwNrTB.Size = new System.Drawing.Size(44, 22);
            this.gwNrTB.TabIndex = 11;
            this.gwNrTB.ValidationFailure = false;
            this.gwNrTB.Visible = false;
            // 
            // gwForceCB
            // 
            this.gwForceCB.AutoSize = true;
            this.gwForceCB.Location = new System.Drawing.Point(348, 271);
            this.gwForceCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwForceCB.Name = "gwForceCB";
            this.gwForceCB.Size = new System.Drawing.Size(64, 20);
            this.gwForceCB.TabIndex = 38;
            this.gwForceCB.Text = "Force";
            this.gwForceCB.UseVisualStyleBackColor = true;
            // 
            // gwMotorOnCB
            // 
            this.gwMotorOnCB.AutoSize = true;
            this.gwMotorOnCB.Location = new System.Drawing.Point(348, 242);
            this.gwMotorOnCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwMotorOnCB.Name = "gwMotorOnCB";
            this.gwMotorOnCB.Size = new System.Drawing.Size(83, 20);
            this.gwMotorOnCB.TabIndex = 37;
            this.gwMotorOnCB.Text = "Motor On";
            this.gwMotorOnCB.UseVisualStyleBackColor = true;
            // 
            // gwLingerLBL
            // 
            this.gwLingerLBL.AutoSize = true;
            this.gwLingerLBL.Location = new System.Drawing.Point(385, 76);
            this.gwLingerLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwLingerLBL.Name = "gwLingerLBL";
            this.gwLingerLBL.Size = new System.Drawing.Size(44, 16);
            this.gwLingerLBL.TabIndex = 122;
            this.gwLingerLBL.Text = "Linger";
            this.gwLingerLBL.Visible = false;
            // 
            // gwLingerTB
            // 
            this.gwLingerTB.Location = new System.Drawing.Point(441, 73);
            this.gwLingerTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwLingerTB.Name = "gwLingerTB";
            this.gwLingerTB.Size = new System.Drawing.Size(44, 22);
            this.gwLingerTB.TabIndex = 14;
            this.gwLingerTB.ValidationFailure = false;
            this.gwLingerTB.Visible = false;
            // 
            // gwPassesLBL
            // 
            this.gwPassesLBL.AutoSize = true;
            this.gwPassesLBL.Location = new System.Drawing.Point(265, 76);
            this.gwPassesLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwPassesLBL.Name = "gwPassesLBL";
            this.gwPassesLBL.Size = new System.Drawing.Size(53, 16);
            this.gwPassesLBL.TabIndex = 120;
            this.gwPassesLBL.Text = "Passes";
            this.gwPassesLBL.Visible = false;
            // 
            // gwPassesTB
            // 
            this.gwPassesTB.Location = new System.Drawing.Point(328, 73);
            this.gwPassesTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwPassesTB.Name = "gwPassesTB";
            this.gwPassesTB.Size = new System.Drawing.Size(44, 22);
            this.gwPassesTB.TabIndex = 13;
            this.gwPassesTB.ValidationFailure = false;
            this.gwPassesTB.Visible = false;
            // 
            // gwOTTSPECOffsetsTB
            // 
            this.gwOTTSPECOffsetsTB.Location = new System.Drawing.Point(381, 196);
            this.gwOTTSPECOffsetsTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwOTTSPECOffsetsTB.Name = "gwOTTSPECOffsetsTB";
            this.gwOTTSPECOffsetsTB.Size = new System.Drawing.Size(157, 22);
            this.gwOTTSPECOffsetsTB.TabIndex = 24;
            this.gwOTTSPECOffsetsTB.ValidationFailure = false;
            this.gwOTTSPECOffsetsTB.Visible = false;
            // 
            // gwOTTSPECOffsetsLBL
            // 
            this.gwOTTSPECOffsetsLBL.AutoSize = true;
            this.gwOTTSPECOffsetsLBL.Location = new System.Drawing.Point(287, 199);
            this.gwOTTSPECOffsetsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwOTTSPECOffsetsLBL.Name = "gwOTTSPECOffsetsLBL";
            this.gwOTTSPECOffsetsLBL.Size = new System.Drawing.Size(48, 16);
            this.gwOTTSPECOffsetsLBL.TabIndex = 115;
            this.gwOTTSPECOffsetsLBL.Text = "Offsets";
            this.gwOTTSPECOffsetsLBL.Visible = false;
            // 
            // gwHFreqCB
            // 
            this.gwHFreqCB.AutoSize = true;
            this.gwHFreqCB.Location = new System.Drawing.Point(348, 214);
            this.gwHFreqCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwHFreqCB.Name = "gwHFreqCB";
            this.gwHFreqCB.Size = new System.Drawing.Size(124, 20);
            this.gwHFreqCB.TabIndex = 36;
            this.gwHFreqCB.Text = "High Frequency";
            this.gwHFreqCB.UseVisualStyleBackColor = true;
            // 
            // gwOutTracksLBL
            // 
            this.gwOutTracksLBL.AutoSize = true;
            this.gwOutTracksLBL.Location = new System.Drawing.Point(287, 76);
            this.gwOutTracksLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwOutTracksLBL.Name = "gwOutTracksLBL";
            this.gwOutTracksLBL.Size = new System.Drawing.Size(72, 16);
            this.gwOutTracksLBL.TabIndex = 117;
            this.gwOutTracksLBL.Text = "Out Tracks";
            this.gwOutTracksLBL.Visible = false;
            // 
            // gwOTTSPECStepTB
            // 
            this.gwOTTSPECStepTB.Location = new System.Drawing.Point(381, 164);
            this.gwOTTSPECStepTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwOTTSPECStepTB.Name = "gwOTTSPECStepTB";
            this.gwOTTSPECStepTB.Size = new System.Drawing.Size(45, 22);
            this.gwOTTSPECStepTB.TabIndex = 23;
            this.gwOTTSPECStepTB.Tag = "step";
            this.gwOTTSPECStepTB.ValidationFailure = false;
            this.gwOTTSPECStepTB.Visible = false;
            // 
            // gwOTTSPECStepLBL
            // 
            this.gwOTTSPECStepLBL.AutoSize = true;
            this.gwOTTSPECStepLBL.Location = new System.Drawing.Point(287, 167);
            this.gwOTTSPECStepLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwOTTSPECStepLBL.Name = "gwOTTSPECStepLBL";
            this.gwOTTSPECStepLBL.Size = new System.Drawing.Size(35, 16);
            this.gwOTTSPECStepLBL.TabIndex = 113;
            this.gwOTTSPECStepLBL.Text = "Step";
            this.gwOTTSPECStepLBL.Visible = false;
            // 
            // gwOTTSPECHeadsTB
            // 
            this.gwOTTSPECHeadsTB.Location = new System.Drawing.Point(381, 132);
            this.gwOTTSPECHeadsTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwOTTSPECHeadsTB.Name = "gwOTTSPECHeadsTB";
            this.gwOTTSPECHeadsTB.Size = new System.Drawing.Size(45, 22);
            this.gwOTTSPECHeadsTB.TabIndex = 21;
            this.gwOTTSPECHeadsTB.Tag = "h";
            this.gwOTTSPECHeadsTB.ValidationFailure = false;
            this.gwOTTSPECHeadsTB.Visible = false;
            // 
            // gwOTTSPECHeadsLBL
            // 
            this.gwOTTSPECHeadsLBL.AutoSize = true;
            this.gwOTTSPECHeadsLBL.Location = new System.Drawing.Point(287, 135);
            this.gwOTTSPECHeadsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwOTTSPECHeadsLBL.Name = "gwOTTSPECHeadsLBL";
            this.gwOTTSPECHeadsLBL.Size = new System.Drawing.Size(48, 16);
            this.gwOTTSPECHeadsLBL.TabIndex = 111;
            this.gwOTTSPECHeadsLBL.Text = "Heads";
            this.gwOTTSPECHeadsLBL.Visible = false;
            // 
            // gwOTTSPECCylTB
            // 
            this.gwOTTSPECCylTB.Location = new System.Drawing.Point(381, 100);
            this.gwOTTSPECCylTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwOTTSPECCylTB.Name = "gwOTTSPECCylTB";
            this.gwOTTSPECCylTB.Size = new System.Drawing.Size(157, 22);
            this.gwOTTSPECCylTB.TabIndex = 20;
            this.gwOTTSPECCylTB.Tag = "c";
            this.gwOTTSPECCylTB.ValidationFailure = false;
            this.gwOTTSPECCylTB.Visible = false;
            // 
            // gwOTTSPECCylLBL
            // 
            this.gwOTTSPECCylLBL.AutoSize = true;
            this.gwOTTSPECCylLBL.Location = new System.Drawing.Point(287, 103);
            this.gwOTTSPECCylLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwOTTSPECCylLBL.Name = "gwOTTSPECCylLBL";
            this.gwOTTSPECCylLBL.Size = new System.Drawing.Size(86, 16);
            this.gwOTTSPECCylLBL.TabIndex = 109;
            this.gwOTTSPECCylLBL.Text = "Cylinder Sets";
            this.gwOTTSPECCylLBL.Visible = false;
            // 
            // gwPreEraseCB
            // 
            this.gwPreEraseCB.AutoSize = true;
            this.gwPreEraseCB.Location = new System.Drawing.Point(348, 186);
            this.gwPreEraseCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwPreEraseCB.Name = "gwPreEraseCB";
            this.gwPreEraseCB.Size = new System.Drawing.Size(90, 20);
            this.gwPreEraseCB.TabIndex = 35;
            this.gwPreEraseCB.Text = "Pre-Erase";
            this.gwPreEraseCB.UseVisualStyleBackColor = true;
            // 
            // gwRevsLBL
            // 
            this.gwRevsLBL.AutoSize = true;
            this.gwRevsLBL.Location = new System.Drawing.Point(23, 266);
            this.gwRevsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwRevsLBL.Name = "gwRevsLBL";
            this.gwRevsLBL.Size = new System.Drawing.Size(78, 16);
            this.gwRevsLBL.TabIndex = 106;
            this.gwRevsLBL.Text = "Revolutions";
            this.gwRevsLBL.Visible = false;
            // 
            // gwAdjustSpeedLBL
            // 
            this.gwAdjustSpeedLBL.AutoSize = true;
            this.gwAdjustSpeedLBL.Location = new System.Drawing.Point(176, 298);
            this.gwAdjustSpeedLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwAdjustSpeedLBL.Name = "gwAdjustSpeedLBL";
            this.gwAdjustSpeedLBL.Size = new System.Drawing.Size(88, 16);
            this.gwAdjustSpeedLBL.TabIndex = 105;
            this.gwAdjustSpeedLBL.Text = "Adjust Speed";
            // 
            // gwFakeIndexLBL
            // 
            this.gwFakeIndexLBL.AutoSize = true;
            this.gwFakeIndexLBL.Location = new System.Drawing.Point(27, 298);
            this.gwFakeIndexLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwFakeIndexLBL.Name = "gwFakeIndexLBL";
            this.gwFakeIndexLBL.Size = new System.Drawing.Size(73, 16);
            this.gwFakeIndexLBL.TabIndex = 104;
            this.gwFakeIndexLBL.Text = "Fake Index";
            // 
            // gwPLLPhaseTB
            // 
            this.gwPLLPhaseTB.Location = new System.Drawing.Point(227, 228);
            this.gwPLLPhaseTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwPLLPhaseTB.Name = "gwPLLPhaseTB";
            this.gwPLLPhaseTB.Size = new System.Drawing.Size(45, 22);
            this.gwPLLPhaseTB.TabIndex = 26;
            this.gwPLLPhaseTB.Tag = "phase";
            this.gwPLLPhaseTB.ValidationFailure = false;
            // 
            // gwPLLPhaseLBL
            // 
            this.gwPLLPhaseLBL.AutoSize = true;
            this.gwPLLPhaseLBL.Location = new System.Drawing.Point(169, 231);
            this.gwPLLPhaseLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwPLLPhaseLBL.Name = "gwPLLPhaseLBL";
            this.gwPLLPhaseLBL.Size = new System.Drawing.Size(46, 16);
            this.gwPLLPhaseLBL.TabIndex = 100;
            this.gwPLLPhaseLBL.Text = "Phase";
            // 
            // gwPLLPeriodTB
            // 
            this.gwPLLPeriodTB.Location = new System.Drawing.Point(115, 228);
            this.gwPLLPeriodTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwPLLPeriodTB.Name = "gwPLLPeriodTB";
            this.gwPLLPeriodTB.Size = new System.Drawing.Size(45, 22);
            this.gwPLLPeriodTB.TabIndex = 25;
            this.gwPLLPeriodTB.Tag = "period";
            this.gwPLLPeriodTB.ValidationFailure = false;
            // 
            // gwPLLPeriodLBL
            // 
            this.gwPLLPeriodLBL.AutoSize = true;
            this.gwPLLPeriodLBL.Location = new System.Drawing.Point(20, 231);
            this.gwPLLPeriodLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwPLLPeriodLBL.Name = "gwPLLPeriodLBL";
            this.gwPLLPeriodLBL.Size = new System.Drawing.Size(79, 16);
            this.gwPLLPeriodLBL.TabIndex = 98;
            this.gwPLLPeriodLBL.Text = "PLL   Period";
            // 
            // gwTSPECOffsetsTB
            // 
            this.gwTSPECOffsetsTB.Location = new System.Drawing.Point(115, 196);
            this.gwTSPECOffsetsTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwTSPECOffsetsTB.Name = "gwTSPECOffsetsTB";
            this.gwTSPECOffsetsTB.Size = new System.Drawing.Size(157, 22);
            this.gwTSPECOffsetsTB.TabIndex = 19;
            this.gwTSPECOffsetsTB.ValidationFailure = false;
            // 
            // gwTSPECOffsetsLBL
            // 
            this.gwTSPECOffsetsLBL.AutoSize = true;
            this.gwTSPECOffsetsLBL.Location = new System.Drawing.Point(20, 199);
            this.gwTSPECOffsetsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwTSPECOffsetsLBL.Name = "gwTSPECOffsetsLBL";
            this.gwTSPECOffsetsLBL.Size = new System.Drawing.Size(48, 16);
            this.gwTSPECOffsetsLBL.TabIndex = 96;
            this.gwTSPECOffsetsLBL.Text = "Offsets";
            // 
            // gwTSPECStepTB
            // 
            this.gwTSPECStepTB.Location = new System.Drawing.Point(115, 164);
            this.gwTSPECStepTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwTSPECStepTB.Name = "gwTSPECStepTB";
            this.gwTSPECStepTB.Size = new System.Drawing.Size(45, 22);
            this.gwTSPECStepTB.TabIndex = 18;
            this.gwTSPECStepTB.Tag = "step";
            this.gwTSPECStepTB.ValidationFailure = false;
            // 
            // gwTSPECStepLBL
            // 
            this.gwTSPECStepLBL.AutoSize = true;
            this.gwTSPECStepLBL.Location = new System.Drawing.Point(20, 167);
            this.gwTSPECStepLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwTSPECStepLBL.Name = "gwTSPECStepLBL";
            this.gwTSPECStepLBL.Size = new System.Drawing.Size(35, 16);
            this.gwTSPECStepLBL.TabIndex = 94;
            this.gwTSPECStepLBL.Text = "Step";
            // 
            // gwTSPECHeadsTB
            // 
            this.gwTSPECHeadsTB.Location = new System.Drawing.Point(115, 132);
            this.gwTSPECHeadsTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwTSPECHeadsTB.Name = "gwTSPECHeadsTB";
            this.gwTSPECHeadsTB.Size = new System.Drawing.Size(45, 22);
            this.gwTSPECHeadsTB.TabIndex = 16;
            this.gwTSPECHeadsTB.Tag = "h";
            this.gwTSPECHeadsTB.ValidationFailure = false;
            // 
            // gwTSPECHeadsLBL
            // 
            this.gwTSPECHeadsLBL.AutoSize = true;
            this.gwTSPECHeadsLBL.Location = new System.Drawing.Point(20, 135);
            this.gwTSPECHeadsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwTSPECHeadsLBL.Name = "gwTSPECHeadsLBL";
            this.gwTSPECHeadsLBL.Size = new System.Drawing.Size(48, 16);
            this.gwTSPECHeadsLBL.TabIndex = 92;
            this.gwTSPECHeadsLBL.Text = "Heads";
            // 
            // gwTSPECCylTB
            // 
            this.gwTSPECCylTB.Location = new System.Drawing.Point(115, 100);
            this.gwTSPECCylTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwTSPECCylTB.Name = "gwTSPECCylTB";
            this.gwTSPECCylTB.Size = new System.Drawing.Size(157, 22);
            this.gwTSPECCylTB.TabIndex = 15;
            this.gwTSPECCylTB.Tag = "c";
            this.gwTSPECCylTB.ValidationFailure = false;
            // 
            // gwTSPECCylLBL
            // 
            this.gwTSPECCylLBL.AutoSize = true;
            this.gwTSPECCylLBL.Location = new System.Drawing.Point(20, 103);
            this.gwTSPECCylLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwTSPECCylLBL.Name = "gwTSPECCylLBL";
            this.gwTSPECCylLBL.Size = new System.Drawing.Size(86, 16);
            this.gwTSPECCylLBL.TabIndex = 90;
            this.gwTSPECCylLBL.Text = "Cylinder Sets";
            // 
            // gwNoVerifyCB
            // 
            this.gwNoVerifyCB.AutoSize = true;
            this.gwNoVerifyCB.Location = new System.Drawing.Point(348, 101);
            this.gwNoVerifyCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwNoVerifyCB.Name = "gwNoVerifyCB";
            this.gwNoVerifyCB.Size = new System.Drawing.Size(84, 20);
            this.gwNoVerifyCB.TabIndex = 32;
            this.gwNoVerifyCB.Text = "No Verify";
            this.gwNoVerifyCB.UseVisualStyleBackColor = true;
            // 
            // gwEraseBlankCB
            // 
            this.gwEraseBlankCB.AutoSize = true;
            this.gwEraseBlankCB.Location = new System.Drawing.Point(348, 158);
            this.gwEraseBlankCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwEraseBlankCB.Name = "gwEraseBlankCB";
            this.gwEraseBlankCB.Size = new System.Drawing.Size(106, 20);
            this.gwEraseBlankCB.TabIndex = 34;
            this.gwEraseBlankCB.Text = "Erase Empty";
            this.gwEraseBlankCB.UseVisualStyleBackColor = true;
            // 
            // gwRawCB
            // 
            this.gwRawCB.AutoSize = true;
            this.gwRawCB.Location = new System.Drawing.Point(348, 129);
            this.gwRawCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwRawCB.Name = "gwRawCB";
            this.gwRawCB.Size = new System.Drawing.Size(56, 20);
            this.gwRawCB.TabIndex = 33;
            this.gwRawCB.Text = "Raw";
            this.gwRawCB.UseVisualStyleBackColor = true;
            // 
            // gwSeekRetriesTB
            // 
            this.gwSeekRetriesTB.Location = new System.Drawing.Point(277, 326);
            this.gwSeekRetriesTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwSeekRetriesTB.Name = "gwSeekRetriesTB";
            this.gwSeekRetriesTB.Size = new System.Drawing.Size(47, 22);
            this.gwSeekRetriesTB.TabIndex = 31;
            this.gwSeekRetriesTB.ValidationFailure = false;
            // 
            // gwSeekRetriesLBL
            // 
            this.gwSeekRetriesLBL.AutoSize = true;
            this.gwSeekRetriesLBL.Location = new System.Drawing.Point(179, 330);
            this.gwSeekRetriesLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwSeekRetriesLBL.Name = "gwSeekRetriesLBL";
            this.gwSeekRetriesLBL.Size = new System.Drawing.Size(85, 16);
            this.gwSeekRetriesLBL.TabIndex = 86;
            this.gwSeekRetriesLBL.Text = "Seek Retries";
            // 
            // gwRetriesLBL
            // 
            this.gwRetriesLBL.AutoSize = true;
            this.gwRetriesLBL.Location = new System.Drawing.Point(53, 330);
            this.gwRetriesLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwRetriesLBL.Name = "gwRetriesLBL";
            this.gwRetriesLBL.Size = new System.Drawing.Size(50, 16);
            this.gwRetriesLBL.TabIndex = 85;
            this.gwRetriesLBL.Text = "Retries";
            // 
            // GwFileDisplay
            // 
            this.GwFileDisplay.AutoSize = true;
            this.GwFileDisplay.Location = new System.Drawing.Point(20, 14);
            this.GwFileDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GwFileDisplay.Name = "GwFileDisplay";
            this.GwFileDisplay.Size = new System.Drawing.Size(29, 16);
            this.GwFileDisplay.TabIndex = 50;
            this.GwFileDisplay.Text = "File";
            // 
            // gwCylLBL
            // 
            this.gwCylLBL.AutoSize = true;
            this.gwCylLBL.Location = new System.Drawing.Point(147, 76);
            this.gwCylLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwCylLBL.Name = "gwCylLBL";
            this.gwCylLBL.Size = new System.Drawing.Size(56, 16);
            this.gwCylLBL.TabIndex = 45;
            this.gwCylLBL.Text = "Cylinder";
            this.gwCylLBL.Visible = false;
            // 
            // gwCylTB
            // 
            this.gwCylTB.Location = new System.Drawing.Point(213, 73);
            this.gwCylTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwCylTB.Name = "gwCylTB";
            this.gwCylTB.Size = new System.Drawing.Size(44, 22);
            this.gwCylTB.TabIndex = 12;
            this.gwCylTB.ValidationFailure = false;
            this.gwCylTB.Visible = false;
            // 
            // additonalArgsLBL
            // 
            this.additonalArgsLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.additonalArgsLBL.AutoSize = true;
            this.additonalArgsLBL.Location = new System.Drawing.Point(29, 380);
            this.additonalArgsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.additonalArgsLBL.Name = "additonalArgsLBL";
            this.additonalArgsLBL.Size = new System.Drawing.Size(134, 16);
            this.additonalArgsLBL.TabIndex = 44;
            this.additonalArgsLBL.Text = "Additional Arguments";
            // 
            // additonalArgsTB
            // 
            this.additonalArgsTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.additonalArgsTB.Location = new System.Drawing.Point(179, 377);
            this.additonalArgsTB.Margin = new System.Windows.Forms.Padding(4);
            this.additonalArgsTB.Name = "additonalArgsTB";
            this.additonalArgsTB.Size = new System.Drawing.Size(804, 22);
            this.additonalArgsTB.TabIndex = 39;
            this.additonalArgsTB.ValidationFailure = false;
            // 
            // gwFormatTypeCB
            // 
            this.gwFormatTypeCB.FormattingEnabled = true;
            this.gwFormatTypeCB.Location = new System.Drawing.Point(116, 39);
            this.gwFormatTypeCB.Margin = new System.Windows.Forms.Padding(4);
            this.gwFormatTypeCB.Name = "gwFormatTypeCB";
            this.gwFormatTypeCB.Size = new System.Drawing.Size(141, 24);
            this.gwFormatTypeCB.TabIndex = 8;
            this.gwFormatTypeCB.SelectedIndexChanged += new System.EventHandler(this.gwFormatTypeCB_SelectedIndexChanged);
            // 
            // gwFormatTypeLBL
            // 
            this.gwFormatTypeLBL.AutoSize = true;
            this.gwFormatTypeLBL.Location = new System.Drawing.Point(20, 43);
            this.gwFormatTypeLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwFormatTypeLBL.Name = "gwFormatTypeLBL";
            this.gwFormatTypeLBL.Size = new System.Drawing.Size(84, 16);
            this.gwFormatTypeLBL.TabIndex = 43;
            this.gwFormatTypeLBL.Text = "Format Type";
            // 
            // ddTab
            // 
            this.ddTab.Controls.Add(this.gwDDNewFileBtn);
            this.ddTab.Controls.Add(this.gwDDImport);
            this.ddTab.Controls.Add(this.removeDiskConfigBtn);
            this.ddTab.Controls.Add(this.gwDDSaveBtn);
            this.ddTab.Controls.Add(this.gwDDReloadBtn);
            this.ddTab.Controls.Add(this.gwDDfileBtn);
            this.ddTab.Controls.Add(this.gwDDfileLBL);
            this.ddTab.Controls.Add(this.gwDDtracksgroupBox);
            this.ddTab.Controls.Add(this.gwDDStepTB);
            this.ddTab.Controls.Add(this.gwDDStepLBL);
            this.ddTab.Controls.Add(this.gwDDHeadsTB);
            this.ddTab.Controls.Add(this.gwDDheadsLBL);
            this.ddTab.Controls.Add(this.gwDDCylsTB);
            this.ddTab.Controls.Add(this.gwDDCylsLBL);
            this.ddTab.Controls.Add(this.diskDefApplyBtn);
            this.ddTab.Controls.Add(this.diskDefNameTB);
            this.ddTab.Controls.Add(this.diskDefsNameLBL);
            this.ddTab.Controls.Add(this.newDiskConfigBtn);
            this.ddTab.Controls.Add(this.gwDiskConfigLBL);
            this.ddTab.Controls.Add(this.gwDiskConfigCB);
            this.ddTab.Location = new System.Drawing.Point(4, 25);
            this.ddTab.Margin = new System.Windows.Forms.Padding(4);
            this.ddTab.Name = "ddTab";
            this.ddTab.Size = new System.Drawing.Size(1013, 423);
            this.ddTab.TabIndex = 2;
            this.ddTab.Text = "DiskDef Builder";
            this.ddTab.UseVisualStyleBackColor = true;
            // 
            // gwDDImport
            // 
            this.gwDDImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gwDDImport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gwDDImport.FormattingEnabled = true;
            this.gwDDImport.Location = new System.Drawing.Point(311, 383);
            this.gwDDImport.Name = "gwDDImport";
            this.gwDDImport.Size = new System.Drawing.Size(147, 24);
            this.gwDDImport.TabIndex = 76;
            this.gwDDImport.Visible = false;
            this.gwDDImport.SelectedIndexChanged += new System.EventHandler(this.gwDDImport_SelectedIndexChanged);
            // 
            // gwDDfileLBL
            // 
            this.gwDDfileLBL.AutoSize = true;
            this.gwDDfileLBL.Location = new System.Drawing.Point(24, 18);
            this.gwDDfileLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDfileLBL.MaximumSize = new System.Drawing.Size(400, 0);
            this.gwDDfileLBL.Name = "gwDDfileLBL";
            this.gwDDfileLBL.Size = new System.Drawing.Size(77, 16);
            this.gwDDfileLBL.TabIndex = 63;
            this.gwDDfileLBL.Text = "[File Name]";
            // 
            // gwDDtracksgroupBox
            // 
            this.gwDDtracksgroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDRemoveTrackBtn);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDsubformatTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDsubformatLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDclockTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDclockLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDApplyTrackBtn);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDimgbpsTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDimgbpsLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDgapbyteTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDgapbyteLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDgap4aTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDgap4aLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDgap3TB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDgap3LBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDgap2TB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDgap2LBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDgap1TB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDgap1LBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDrpmTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDrpmLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDrateTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDrateLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDhTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDhLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDinterleaveTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDinterleaveLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDidTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDidLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDhskewTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDhskewLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDcskewTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDcskewLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDiamCB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDbpsTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDbpsLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDformatTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDformatLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDtracksTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDtracksLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDsectorsTB);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDsectorsLBL);
            this.gwDDtracksgroupBox.Controls.Add(this.gwDDTrackListLB);
            this.gwDDtracksgroupBox.Location = new System.Drawing.Point(4, 133);
            this.gwDDtracksgroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDtracksgroupBox.Name = "gwDDtracksgroupBox";
            this.gwDDtracksgroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.gwDDtracksgroupBox.Size = new System.Drawing.Size(1003, 242);
            this.gwDDtracksgroupBox.TabIndex = 54;
            this.gwDDtracksgroupBox.TabStop = false;
            this.gwDDtracksgroupBox.Text = "Track Sets";
            // 
            // gwDDsubformatLBL
            // 
            this.gwDDsubformatLBL.AutoSize = true;
            this.gwDDsubformatLBL.Location = new System.Drawing.Point(337, 165);
            this.gwDDsubformatLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDsubformatLBL.Name = "gwDDsubformatLBL";
            this.gwDDsubformatLBL.Size = new System.Drawing.Size(73, 16);
            this.gwDDsubformatLBL.TabIndex = 58;
            this.gwDDsubformatLBL.Text = "SubFormat";
            // 
            // gwDDclockLBL
            // 
            this.gwDDclockLBL.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDclockLBL.AutoSize = true;
            this.gwDDclockLBL.Location = new System.Drawing.Point(500, 37);
            this.gwDDclockLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDclockLBL.Name = "gwDDclockLBL";
            this.gwDDclockLBL.Size = new System.Drawing.Size(39, 16);
            this.gwDDclockLBL.TabIndex = 56;
            this.gwDDclockLBL.Text = "clock";
            // 
            // gwDDimgbpsLBL
            // 
            this.gwDDimgbpsLBL.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDimgbpsLBL.AutoSize = true;
            this.gwDDimgbpsLBL.Location = new System.Drawing.Point(196, 165);
            this.gwDDimgbpsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDimgbpsLBL.Name = "gwDDimgbpsLBL";
            this.gwDDimgbpsLBL.Size = new System.Drawing.Size(55, 16);
            this.gwDDimgbpsLBL.TabIndex = 53;
            this.gwDDimgbpsLBL.Text = "img bps";
            // 
            // gwDDgapbyteLBL
            // 
            this.gwDDgapbyteLBL.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDgapbyteLBL.AutoSize = true;
            this.gwDDgapbyteLBL.Location = new System.Drawing.Point(28, 165);
            this.gwDDgapbyteLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDgapbyteLBL.Name = "gwDDgapbyteLBL";
            this.gwDDgapbyteLBL.Size = new System.Drawing.Size(57, 16);
            this.gwDDgapbyteLBL.TabIndex = 51;
            this.gwDDgapbyteLBL.Text = "gapbyte";
            // 
            // gwDDgap4aLBL
            // 
            this.gwDDgap4aLBL.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDgap4aLBL.AutoSize = true;
            this.gwDDgap4aLBL.Location = new System.Drawing.Point(372, 133);
            this.gwDDgap4aLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDgap4aLBL.Name = "gwDDgap4aLBL";
            this.gwDDgap4aLBL.Size = new System.Drawing.Size(46, 16);
            this.gwDDgap4aLBL.TabIndex = 49;
            this.gwDDgap4aLBL.Text = "gap4a";
            // 
            // gwDDgap3LBL
            // 
            this.gwDDgap3LBL.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDgap3LBL.AutoSize = true;
            this.gwDDgap3LBL.Location = new System.Drawing.Point(252, 133);
            this.gwDDgap3LBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDgap3LBL.Name = "gwDDgap3LBL";
            this.gwDDgap3LBL.Size = new System.Drawing.Size(38, 16);
            this.gwDDgap3LBL.TabIndex = 47;
            this.gwDDgap3LBL.Text = "gap3";
            // 
            // gwDDgap2LBL
            // 
            this.gwDDgap2LBL.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDgap2LBL.AutoSize = true;
            this.gwDDgap2LBL.Location = new System.Drawing.Point(143, 133);
            this.gwDDgap2LBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDgap2LBL.Name = "gwDDgap2LBL";
            this.gwDDgap2LBL.Size = new System.Drawing.Size(38, 16);
            this.gwDDgap2LBL.TabIndex = 45;
            this.gwDDgap2LBL.Text = "gap2";
            // 
            // gwDDgap1LBL
            // 
            this.gwDDgap1LBL.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gwDDgap1LBL.AutoSize = true;
            this.gwDDgap1LBL.Location = new System.Drawing.Point(28, 133);
            this.gwDDgap1LBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDgap1LBL.Name = "gwDDgap1LBL";
            this.gwDDgap1LBL.Size = new System.Drawing.Size(38, 16);
            this.gwDDgap1LBL.TabIndex = 43;
            this.gwDDgap1LBL.Text = "gap1";
            // 
            // gwDDrpmLBL
            // 
            this.gwDDrpmLBL.AutoSize = true;
            this.gwDDrpmLBL.Location = new System.Drawing.Point(407, 101);
            this.gwDDrpmLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDrpmLBL.Name = "gwDDrpmLBL";
            this.gwDDrpmLBL.Size = new System.Drawing.Size(30, 16);
            this.gwDDrpmLBL.TabIndex = 41;
            this.gwDDrpmLBL.Text = "rpm";
            // 
            // gwDDrateLBL
            // 
            this.gwDDrateLBL.AutoSize = true;
            this.gwDDrateLBL.Location = new System.Drawing.Point(288, 101);
            this.gwDDrateLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDrateLBL.Name = "gwDDrateLBL";
            this.gwDDrateLBL.Size = new System.Drawing.Size(36, 16);
            this.gwDDrateLBL.TabIndex = 39;
            this.gwDDrateLBL.Text = "Rate";
            // 
            // gwDDhLBL
            // 
            this.gwDDhLBL.AutoSize = true;
            this.gwDDhLBL.Location = new System.Drawing.Point(176, 101);
            this.gwDDhLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDhLBL.Name = "gwDDhLBL";
            this.gwDDhLBL.Size = new System.Drawing.Size(41, 16);
            this.gwDDhLBL.TabIndex = 37;
            this.gwDDhLBL.Text = "Head";
            // 
            // gwDDinterleaveLBL
            // 
            this.gwDDinterleaveLBL.AutoSize = true;
            this.gwDDinterleaveLBL.Location = new System.Drawing.Point(28, 101);
            this.gwDDinterleaveLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDinterleaveLBL.Name = "gwDDinterleaveLBL";
            this.gwDDinterleaveLBL.Size = new System.Drawing.Size(66, 16);
            this.gwDDinterleaveLBL.TabIndex = 35;
            this.gwDDinterleaveLBL.Text = "Interleave";
            // 
            // gwDDidLBL
            // 
            this.gwDDidLBL.AutoSize = true;
            this.gwDDidLBL.Location = new System.Drawing.Point(403, 37);
            this.gwDDidLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDidLBL.Name = "gwDDidLBL";
            this.gwDDidLBL.Size = new System.Drawing.Size(18, 16);
            this.gwDDidLBL.TabIndex = 33;
            this.gwDDidLBL.Text = "Id";
            // 
            // gwDDhskewLBL
            // 
            this.gwDDhskewLBL.AutoSize = true;
            this.gwDDhskewLBL.Location = new System.Drawing.Point(460, 69);
            this.gwDDhskewLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDhskewLBL.Name = "gwDDhskewLBL";
            this.gwDDhskewLBL.Size = new System.Drawing.Size(74, 16);
            this.gwDDhskewLBL.TabIndex = 31;
            this.gwDDhskewLBL.Text = "Skew head";
            // 
            // gwDDcskewLBL
            // 
            this.gwDDcskewLBL.AutoSize = true;
            this.gwDDcskewLBL.Location = new System.Drawing.Point(315, 69);
            this.gwDDcskewLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDcskewLBL.Name = "gwDDcskewLBL";
            this.gwDDcskewLBL.Size = new System.Drawing.Size(60, 16);
            this.gwDDcskewLBL.TabIndex = 29;
            this.gwDDcskewLBL.Text = "Skew cyl";
            // 
            // gwDDbpsLBL
            // 
            this.gwDDbpsLBL.AutoSize = true;
            this.gwDDbpsLBL.Location = new System.Drawing.Point(160, 69);
            this.gwDDbpsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDbpsLBL.Name = "gwDDbpsLBL";
            this.gwDDbpsLBL.Size = new System.Drawing.Size(30, 16);
            this.gwDDbpsLBL.TabIndex = 26;
            this.gwDDbpsLBL.Text = "bps";
            // 
            // gwDDformatLBL
            // 
            this.gwDDformatLBL.AutoSize = true;
            this.gwDDformatLBL.Location = new System.Drawing.Point(172, 37);
            this.gwDDformatLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDformatLBL.Name = "gwDDformatLBL";
            this.gwDDformatLBL.Size = new System.Drawing.Size(49, 16);
            this.gwDDformatLBL.TabIndex = 24;
            this.gwDDformatLBL.Text = "Format";
            // 
            // gwDDtracksLBL
            // 
            this.gwDDtracksLBL.AutoSize = true;
            this.gwDDtracksLBL.Location = new System.Drawing.Point(32, 37);
            this.gwDDtracksLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDtracksLBL.Name = "gwDDtracksLBL";
            this.gwDDtracksLBL.Size = new System.Drawing.Size(49, 16);
            this.gwDDtracksLBL.TabIndex = 22;
            this.gwDDtracksLBL.Text = "Tracks";
            // 
            // gwDDsectorsLBL
            // 
            this.gwDDsectorsLBL.AutoSize = true;
            this.gwDDsectorsLBL.Location = new System.Drawing.Point(28, 69);
            this.gwDDsectorsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDsectorsLBL.Name = "gwDDsectorsLBL";
            this.gwDDsectorsLBL.Size = new System.Drawing.Size(53, 16);
            this.gwDDsectorsLBL.TabIndex = 20;
            this.gwDDsectorsLBL.Text = "Sectors";
            // 
            // gwDDTrackListLB
            // 
            this.gwDDTrackListLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gwDDTrackListLB.FormattingEnabled = true;
            this.gwDDTrackListLB.ItemHeight = 16;
            this.gwDDTrackListLB.Location = new System.Drawing.Point(744, 22);
            this.gwDDTrackListLB.Margin = new System.Windows.Forms.Padding(4);
            this.gwDDTrackListLB.Name = "gwDDTrackListLB";
            this.gwDDTrackListLB.Size = new System.Drawing.Size(249, 212);
            this.gwDDTrackListLB.TabIndex = 72;
            this.gwDDTrackListLB.SelectedIndexChanged += new System.EventHandler(this.gwDDTrackListLB_SelectedIndexChanged);
            this.gwDDTrackListLB.SelectedValueChanged += new System.EventHandler(this.gwDDTrackListLB_SelectedValueChanged);
            // 
            // gwDDStepLBL
            // 
            this.gwDDStepLBL.AutoSize = true;
            this.gwDDStepLBL.Location = new System.Drawing.Point(823, 92);
            this.gwDDStepLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDStepLBL.Name = "gwDDStepLBL";
            this.gwDDStepLBL.Size = new System.Drawing.Size(35, 16);
            this.gwDDStepLBL.TabIndex = 53;
            this.gwDDStepLBL.Text = "Step";
            // 
            // gwDDheadsLBL
            // 
            this.gwDDheadsLBL.AutoSize = true;
            this.gwDDheadsLBL.Location = new System.Drawing.Point(669, 92);
            this.gwDDheadsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDheadsLBL.Name = "gwDDheadsLBL";
            this.gwDDheadsLBL.Size = new System.Drawing.Size(48, 16);
            this.gwDDheadsLBL.TabIndex = 52;
            this.gwDDheadsLBL.Text = "Heads";
            // 
            // gwDDCylsLBL
            // 
            this.gwDDCylsLBL.AutoSize = true;
            this.gwDDCylsLBL.Location = new System.Drawing.Point(501, 92);
            this.gwDDCylsLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDDCylsLBL.Name = "gwDDCylsLBL";
            this.gwDDCylsLBL.Size = new System.Drawing.Size(63, 16);
            this.gwDDCylsLBL.TabIndex = 51;
            this.gwDDCylsLBL.Text = "Cylinders";
            // 
            // diskDefsNameLBL
            // 
            this.diskDefsNameLBL.AutoSize = true;
            this.diskDefsNameLBL.Location = new System.Drawing.Point(564, 58);
            this.diskDefsNameLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.diskDefsNameLBL.Name = "diskDefsNameLBL";
            this.diskDefsNameLBL.Size = new System.Drawing.Size(44, 16);
            this.diskDefsNameLBL.TabIndex = 50;
            this.diskDefsNameLBL.Text = "Name";
            // 
            // gwDiskConfigLBL
            // 
            this.gwDiskConfigLBL.AutoSize = true;
            this.gwDiskConfigLBL.Location = new System.Drawing.Point(21, 52);
            this.gwDiskConfigLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwDiskConfigLBL.Name = "gwDiskConfigLBL";
            this.gwDiskConfigLBL.Size = new System.Drawing.Size(75, 16);
            this.gwDiskConfigLBL.TabIndex = 49;
            this.gwDiskConfigLBL.Text = "Disk Config";
            // 
            // optionsTab
            // 
            this.optionsTab.Controls.Add(this.ProfileDelBtn);
            this.optionsTab.Controls.Add(this.gwHostToolsVersionValue);
            this.optionsTab.Controls.Add(this.gwHostToolsVersionLBL);
            this.optionsTab.Controls.Add(this.SelectProfilePathBtn);
            this.optionsTab.Controls.Add(this.ProfileClearBtn);
            this.optionsTab.Controls.Add(this.SaveProfileBtn);
            this.optionsTab.Controls.Add(this.ProfileNameLBL);
            this.optionsTab.Controls.Add(this.ProfileNameTB);
            this.optionsTab.Controls.Add(this.CmdProfileFileLBL);
            this.optionsTab.Controls.Add(this.gwProfileSelLBL);
            this.optionsTab.Controls.Add(this.OpenProfileBtn);
            this.optionsTab.Controls.Add(this.gwProfileFileTB);
            this.optionsTab.Controls.Add(this.gwPathSelectionLBL);
            this.optionsTab.Controls.Add(this.SelectGWPathBtn);
            this.optionsTab.Controls.Add(this.gwPathSelectionTB);
            this.optionsTab.Location = new System.Drawing.Point(4, 25);
            this.optionsTab.Margin = new System.Windows.Forms.Padding(4);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Size = new System.Drawing.Size(1013, 423);
            this.optionsTab.TabIndex = 3;
            this.optionsTab.Text = "Options";
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // ProfileDelBtn
            // 
            this.ProfileDelBtn.Location = new System.Drawing.Point(843, 218);
            this.ProfileDelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ProfileDelBtn.Name = "ProfileDelBtn";
            this.ProfileDelBtn.Size = new System.Drawing.Size(119, 28);
            this.ProfileDelBtn.TabIndex = 87;
            this.ProfileDelBtn.Text = "Remove Profile";
            this.ProfileDelBtn.UseVisualStyleBackColor = true;
            this.ProfileDelBtn.Click += new System.EventHandler(this.ProfileDelBtn_Click);
            // 
            // gwHostToolsVersionValue
            // 
            this.gwHostToolsVersionValue.AutoSize = true;
            this.gwHostToolsVersionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gwHostToolsVersionValue.Location = new System.Drawing.Point(239, 55);
            this.gwHostToolsVersionValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwHostToolsVersionValue.Name = "gwHostToolsVersionValue";
            this.gwHostToolsVersionValue.Size = new System.Drawing.Size(73, 17);
            this.gwHostToolsVersionValue.TabIndex = 86;
            this.gwHostToolsVersionValue.Text = "[Version]";
            // 
            // gwHostToolsVersionLBL
            // 
            this.gwHostToolsVersionLBL.AutoSize = true;
            this.gwHostToolsVersionLBL.Location = new System.Drawing.Point(56, 55);
            this.gwHostToolsVersionLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwHostToolsVersionLBL.Name = "gwHostToolsVersionLBL";
            this.gwHostToolsVersionLBL.Size = new System.Drawing.Size(163, 16);
            this.gwHostToolsVersionLBL.TabIndex = 85;
            this.gwHostToolsVersionLBL.Text = "Host Tools current version";
            // 
            // SelectProfilePathBtn
            // 
            this.SelectProfilePathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectProfilePathBtn.Location = new System.Drawing.Point(863, 151);
            this.SelectProfilePathBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SelectProfilePathBtn.Name = "SelectProfilePathBtn";
            this.SelectProfilePathBtn.Size = new System.Drawing.Size(100, 28);
            this.SelectProfilePathBtn.TabIndex = 78;
            this.SelectProfilePathBtn.Text = "Select";
            this.SelectProfilePathBtn.UseVisualStyleBackColor = true;
            this.SelectProfilePathBtn.Click += new System.EventHandler(this.SelectProfilePathBtn_Click);
            // 
            // ProfileClearBtn
            // 
            this.ProfileClearBtn.Location = new System.Drawing.Point(323, 218);
            this.ProfileClearBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ProfileClearBtn.Name = "ProfileClearBtn";
            this.ProfileClearBtn.Size = new System.Drawing.Size(100, 28);
            this.ProfileClearBtn.TabIndex = 82;
            this.ProfileClearBtn.Text = "New Profile";
            this.ProfileClearBtn.UseVisualStyleBackColor = true;
            this.ProfileClearBtn.Click += new System.EventHandler(this.ProfileClearBtn_Click);
            // 
            // SaveProfileBtn
            // 
            this.SaveProfileBtn.Location = new System.Drawing.Point(163, 218);
            this.SaveProfileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SaveProfileBtn.Name = "SaveProfileBtn";
            this.SaveProfileBtn.Size = new System.Drawing.Size(152, 28);
            this.SaveProfileBtn.TabIndex = 81;
            this.SaveProfileBtn.Text = "Save Action Profile";
            this.SaveProfileBtn.UseVisualStyleBackColor = true;
            this.SaveProfileBtn.Click += new System.EventHandler(this.SaveProfileBtn_Click);
            // 
            // ProfileNameLBL
            // 
            this.ProfileNameLBL.AutoSize = true;
            this.ProfileNameLBL.Location = new System.Drawing.Point(51, 190);
            this.ProfileNameLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProfileNameLBL.Name = "ProfileNameLBL";
            this.ProfileNameLBL.Size = new System.Drawing.Size(44, 16);
            this.ProfileNameLBL.TabIndex = 65;
            this.ProfileNameLBL.Text = "Name";
            // 
            // ProfileNameTB
            // 
            this.ProfileNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileNameTB.Location = new System.Drawing.Point(105, 186);
            this.ProfileNameTB.Margin = new System.Windows.Forms.Padding(4);
            this.ProfileNameTB.Name = "ProfileNameTB";
            this.ProfileNameTB.Size = new System.Drawing.Size(856, 22);
            this.ProfileNameTB.TabIndex = 79;
            this.ProfileNameTB.ValidationFailure = false;
            // 
            // CmdProfileFileLBL
            // 
            this.CmdProfileFileLBL.AutoSize = true;
            this.CmdProfileFileLBL.Location = new System.Drawing.Point(51, 158);
            this.CmdProfileFileLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CmdProfileFileLBL.Name = "CmdProfileFileLBL";
            this.CmdProfileFileLBL.Size = new System.Drawing.Size(29, 16);
            this.CmdProfileFileLBL.TabIndex = 63;
            this.CmdProfileFileLBL.Text = "File";
            // 
            // gwProfileSelLBL
            // 
            this.gwProfileSelLBL.AutoSize = true;
            this.gwProfileSelLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gwProfileSelLBL.Location = new System.Drawing.Point(49, 121);
            this.gwProfileSelLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwProfileSelLBL.Name = "gwProfileSelLBL";
            this.gwProfileSelLBL.Size = new System.Drawing.Size(200, 29);
            this.gwProfileSelLBL.TabIndex = 60;
            this.gwProfileSelLBL.Text = "Command Profile";
            // 
            // OpenProfileBtn
            // 
            this.OpenProfileBtn.Location = new System.Drawing.Point(55, 218);
            this.OpenProfileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.OpenProfileBtn.Name = "OpenProfileBtn";
            this.OpenProfileBtn.Size = new System.Drawing.Size(100, 28);
            this.OpenProfileBtn.TabIndex = 80;
            this.OpenProfileBtn.Text = "Open";
            this.OpenProfileBtn.UseVisualStyleBackColor = true;
            this.OpenProfileBtn.Click += new System.EventHandler(this.SelectGWProfileBtn_Click);
            // 
            // gwProfileFileTB
            // 
            this.gwProfileFileTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gwProfileFileTB.Location = new System.Drawing.Point(89, 154);
            this.gwProfileFileTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwProfileFileTB.Name = "gwProfileFileTB";
            this.gwProfileFileTB.Size = new System.Drawing.Size(779, 22);
            this.gwProfileFileTB.TabIndex = 77;
            this.gwProfileFileTB.ValidationFailure = false;
            // 
            // gwPathSelectionLBL
            // 
            this.gwPathSelectionLBL.AutoSize = true;
            this.gwPathSelectionLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gwPathSelectionLBL.Location = new System.Drawing.Point(47, 22);
            this.gwPathSelectionLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwPathSelectionLBL.Name = "gwPathSelectionLBL";
            this.gwPathSelectionLBL.Size = new System.Drawing.Size(361, 29);
            this.gwPathSelectionLBL.TabIndex = 55;
            this.gwPathSelectionLBL.Text = "Path to GreaseWeazle host tools";
            // 
            // SelectGWPathBtn
            // 
            this.SelectGWPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectGWPathBtn.Location = new System.Drawing.Point(863, 73);
            this.SelectGWPathBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SelectGWPathBtn.Name = "SelectGWPathBtn";
            this.SelectGWPathBtn.Size = new System.Drawing.Size(100, 28);
            this.SelectGWPathBtn.TabIndex = 76;
            this.SelectGWPathBtn.Text = "Select";
            this.SelectGWPathBtn.UseVisualStyleBackColor = true;
            this.SelectGWPathBtn.Click += new System.EventHandler(this.SelectGWPathBtn_Click);
            // 
            // gwPathSelectionTB
            // 
            this.gwPathSelectionTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gwPathSelectionTB.Location = new System.Drawing.Point(55, 75);
            this.gwPathSelectionTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwPathSelectionTB.Name = "gwPathSelectionTB";
            this.gwPathSelectionTB.Size = new System.Drawing.Size(813, 22);
            this.gwPathSelectionTB.TabIndex = 75;
            this.gwPathSelectionTB.ValidationFailure = false;
            // 
            // deviceTab
            // 
            this.deviceTab.Controls.Add(this.gwAutoReloadBtn);
            this.deviceTab.Controls.Add(this.gwReloadBtn);
            this.deviceTab.Controls.Add(this.gwUSBRateValue);
            this.deviceTab.Controls.Add(this.gwUSBRateLBL);
            this.deviceTab.Controls.Add(this.gwSerialValue);
            this.deviceTab.Controls.Add(this.gwSerialLBL);
            this.deviceTab.Controls.Add(this.gwFirmwareValue);
            this.deviceTab.Controls.Add(this.gwFirmwareLBL);
            this.deviceTab.Controls.Add(this.gwMCUValue);
            this.deviceTab.Controls.Add(this.gwMCULBL);
            this.deviceTab.Controls.Add(this.gwModelValue);
            this.deviceTab.Controls.Add(this.gwModelLBL);
            this.deviceTab.Controls.Add(this.gwPortLBL);
            this.deviceTab.Controls.Add(this.gwPortTB);
            this.deviceTab.Location = new System.Drawing.Point(4, 25);
            this.deviceTab.Margin = new System.Windows.Forms.Padding(4);
            this.deviceTab.Name = "deviceTab";
            this.deviceTab.Size = new System.Drawing.Size(1013, 423);
            this.deviceTab.TabIndex = 4;
            this.deviceTab.Text = "Device";
            this.deviceTab.UseVisualStyleBackColor = true;
            // 
            // gwAutoReloadBtn
            // 
            this.gwAutoReloadBtn.Location = new System.Drawing.Point(406, 18);
            this.gwAutoReloadBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gwAutoReloadBtn.Name = "gwAutoReloadBtn";
            this.gwAutoReloadBtn.Size = new System.Drawing.Size(80, 28);
            this.gwAutoReloadBtn.TabIndex = 85;
            this.gwAutoReloadBtn.Text = "Auto Port";
            this.gwAutoReloadBtn.UseVisualStyleBackColor = true;
            this.gwAutoReloadBtn.Click += new System.EventHandler(this.gwAutoReloadBtn_Click);
            // 
            // gwReloadBtn
            // 
            this.gwReloadBtn.Location = new System.Drawing.Point(181, 18);
            this.gwReloadBtn.Margin = new System.Windows.Forms.Padding(4);
            this.gwReloadBtn.Name = "gwReloadBtn";
            this.gwReloadBtn.Size = new System.Drawing.Size(217, 28);
            this.gwReloadBtn.TabIndex = 84;
            this.gwReloadBtn.Text = "Reload GreaseWeazle Tools";
            this.gwReloadBtn.UseVisualStyleBackColor = true;
            this.gwReloadBtn.Click += new System.EventHandler(this.gwReloadBtn_Click);
            // 
            // gwUSBRateValue
            // 
            this.gwUSBRateValue.AutoSize = true;
            this.gwUSBRateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gwUSBRateValue.Location = new System.Drawing.Point(88, 209);
            this.gwUSBRateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwUSBRateValue.Name = "gwUSBRateValue";
            this.gwUSBRateValue.Size = new System.Drawing.Size(88, 17);
            this.gwUSBRateValue.TabIndex = 61;
            this.gwUSBRateValue.Text = "[USB Rate]";
            // 
            // gwUSBRateLBL
            // 
            this.gwUSBRateLBL.AutoSize = true;
            this.gwUSBRateLBL.Location = new System.Drawing.Point(7, 209);
            this.gwUSBRateLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwUSBRateLBL.Name = "gwUSBRateLBL";
            this.gwUSBRateLBL.Size = new System.Drawing.Size(67, 16);
            this.gwUSBRateLBL.TabIndex = 60;
            this.gwUSBRateLBL.Text = "USB Rate";
            // 
            // gwSerialLBL
            // 
            this.gwSerialLBL.AutoSize = true;
            this.gwSerialLBL.Location = new System.Drawing.Point(13, 172);
            this.gwSerialLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwSerialLBL.Name = "gwSerialLBL";
            this.gwSerialLBL.Size = new System.Drawing.Size(63, 16);
            this.gwSerialLBL.TabIndex = 58;
            this.gwSerialLBL.Text = "Serial No";
            // 
            // gwFirmwareValue
            // 
            this.gwFirmwareValue.AutoSize = true;
            this.gwFirmwareValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gwFirmwareValue.Location = new System.Drawing.Point(88, 135);
            this.gwFirmwareValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwFirmwareValue.Name = "gwFirmwareValue";
            this.gwFirmwareValue.Size = new System.Drawing.Size(83, 17);
            this.gwFirmwareValue.TabIndex = 57;
            this.gwFirmwareValue.Text = "[Firmware]";
            // 
            // gwFirmwareLBL
            // 
            this.gwFirmwareLBL.AutoSize = true;
            this.gwFirmwareLBL.Location = new System.Drawing.Point(15, 135);
            this.gwFirmwareLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwFirmwareLBL.Name = "gwFirmwareLBL";
            this.gwFirmwareLBL.Size = new System.Drawing.Size(62, 16);
            this.gwFirmwareLBL.TabIndex = 56;
            this.gwFirmwareLBL.Text = "Firmware";
            // 
            // gwMCUValue
            // 
            this.gwMCUValue.AutoSize = true;
            this.gwMCUValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gwMCUValue.Location = new System.Drawing.Point(88, 98);
            this.gwMCUValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwMCUValue.Name = "gwMCUValue";
            this.gwMCUValue.Size = new System.Drawing.Size(51, 17);
            this.gwMCUValue.TabIndex = 55;
            this.gwMCUValue.Text = "[MCU]";
            // 
            // gwMCULBL
            // 
            this.gwMCULBL.AutoSize = true;
            this.gwMCULBL.Location = new System.Drawing.Point(39, 98);
            this.gwMCULBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwMCULBL.Name = "gwMCULBL";
            this.gwMCULBL.Size = new System.Drawing.Size(37, 16);
            this.gwMCULBL.TabIndex = 54;
            this.gwMCULBL.Text = "MCU";
            // 
            // gwModelValue
            // 
            this.gwModelValue.AutoSize = true;
            this.gwModelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gwModelValue.Location = new System.Drawing.Point(88, 62);
            this.gwModelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwModelValue.Name = "gwModelValue";
            this.gwModelValue.Size = new System.Drawing.Size(61, 17);
            this.gwModelValue.TabIndex = 53;
            this.gwModelValue.Text = "[Model]";
            // 
            // gwModelLBL
            // 
            this.gwModelLBL.AutoSize = true;
            this.gwModelLBL.Location = new System.Drawing.Point(32, 62);
            this.gwModelLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwModelLBL.Name = "gwModelLBL";
            this.gwModelLBL.Size = new System.Drawing.Size(45, 16);
            this.gwModelLBL.TabIndex = 52;
            this.gwModelLBL.Text = "Model";
            // 
            // gwPortLBL
            // 
            this.gwPortLBL.AutoSize = true;
            this.gwPortLBL.Location = new System.Drawing.Point(49, 25);
            this.gwPortLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwPortLBL.Name = "gwPortLBL";
            this.gwPortLBL.Size = new System.Drawing.Size(31, 16);
            this.gwPortLBL.TabIndex = 50;
            this.gwPortLBL.Text = "Port";
            // 
            // portsTab
            // 
            this.portsTab.Controls.Add(this.refreshportsbtn);
            this.portsTab.Controls.Add(this.useportbtn);
            this.portsTab.Controls.Add(this.portbusdescValue);
            this.portsTab.Controls.Add(this.portbusdescLBL);
            this.portsTab.Controls.Add(this.portcaptionCB);
            this.portsTab.Controls.Add(this.porterrordescValue);
            this.portsTab.Controls.Add(this.porterrordescLBL);
            this.portsTab.Controls.Add(this.portstatusValue);
            this.portsTab.Controls.Add(this.portstatusLBL);
            this.portsTab.Controls.Add(this.portserviceValue);
            this.portsTab.Controls.Add(this.pertserviceLBL);
            this.portsTab.Controls.Add(this.portClassGuidValue);
            this.portsTab.Controls.Add(this.portclassguidLBL);
            this.portsTab.Controls.Add(this.portdeviceIdValue);
            this.portsTab.Controls.Add(this.portdeviceIdLBL);
            this.portsTab.Controls.Add(this.portdescValue);
            this.portsTab.Controls.Add(this.portdescLBL);
            this.portsTab.Controls.Add(this.portnameValue);
            this.portsTab.Controls.Add(this.portnameLBL);
            this.portsTab.Controls.Add(this.portcaptionLBL);
            this.portsTab.Location = new System.Drawing.Point(4, 25);
            this.portsTab.Margin = new System.Windows.Forms.Padding(4);
            this.portsTab.Name = "portsTab";
            this.portsTab.Size = new System.Drawing.Size(1013, 423);
            this.portsTab.TabIndex = 5;
            this.portsTab.Text = "Serial Ports";
            this.portsTab.UseVisualStyleBackColor = true;
            // 
            // refreshportsbtn
            // 
            this.refreshportsbtn.Location = new System.Drawing.Point(520, 19);
            this.refreshportsbtn.Margin = new System.Windows.Forms.Padding(4);
            this.refreshportsbtn.Name = "refreshportsbtn";
            this.refreshportsbtn.Size = new System.Drawing.Size(100, 28);
            this.refreshportsbtn.TabIndex = 104;
            this.refreshportsbtn.Text = "Refresh";
            this.refreshportsbtn.UseVisualStyleBackColor = true;
            this.refreshportsbtn.Click += new System.EventHandler(this.refreshportsbtn_Click);
            // 
            // useportbtn
            // 
            this.useportbtn.Location = new System.Drawing.Point(412, 18);
            this.useportbtn.Margin = new System.Windows.Forms.Padding(4);
            this.useportbtn.Name = "useportbtn";
            this.useportbtn.Size = new System.Drawing.Size(100, 28);
            this.useportbtn.TabIndex = 103;
            this.useportbtn.Text = "Use";
            this.useportbtn.UseVisualStyleBackColor = true;
            this.useportbtn.Click += new System.EventHandler(this.useportbtn_Click);
            // 
            // portbusdescValue
            // 
            this.portbusdescValue.AutoSize = true;
            this.portbusdescValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portbusdescValue.Location = new System.Drawing.Point(125, 98);
            this.portbusdescValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portbusdescValue.Name = "portbusdescValue";
            this.portbusdescValue.Size = new System.Drawing.Size(100, 17);
            this.portbusdescValue.TabIndex = 102;
            this.portbusdescValue.Text = "[Description]";
            // 
            // portbusdescLBL
            // 
            this.portbusdescLBL.AutoSize = true;
            this.portbusdescLBL.Location = new System.Drawing.Point(9, 98);
            this.portbusdescLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portbusdescLBL.Name = "portbusdescLBL";
            this.portbusdescLBL.Size = new System.Drawing.Size(101, 16);
            this.portbusdescLBL.TabIndex = 101;
            this.portbusdescLBL.Text = "Bus Description";
            // 
            // portcaptionCB
            // 
            this.portcaptionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portcaptionCB.FormattingEnabled = true;
            this.portcaptionCB.Location = new System.Drawing.Point(125, 21);
            this.portcaptionCB.Margin = new System.Windows.Forms.Padding(4);
            this.portcaptionCB.Name = "portcaptionCB";
            this.portcaptionCB.Size = new System.Drawing.Size(277, 24);
            this.portcaptionCB.TabIndex = 100;
            this.portcaptionCB.SelectedIndexChanged += new System.EventHandler(this.portcaptionCB_SelectedIndexChanged);
            // 
            // porterrordescValue
            // 
            this.porterrordescValue.AutoSize = true;
            this.porterrordescValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porterrordescValue.Location = new System.Drawing.Point(125, 320);
            this.porterrordescValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.porterrordescValue.Name = "porterrordescValue";
            this.porterrordescValue.Size = new System.Drawing.Size(142, 17);
            this.porterrordescValue.TabIndex = 99;
            this.porterrordescValue.Text = "[Error Description]";
            // 
            // porterrordescLBL
            // 
            this.porterrordescLBL.AutoSize = true;
            this.porterrordescLBL.Location = new System.Drawing.Point(79, 320);
            this.porterrordescLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.porterrordescLBL.Name = "porterrordescLBL";
            this.porterrordescLBL.Size = new System.Drawing.Size(36, 16);
            this.porterrordescLBL.TabIndex = 98;
            this.porterrordescLBL.Text = "Error";
            // 
            // portstatusValue
            // 
            this.portstatusValue.AutoSize = true;
            this.portstatusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portstatusValue.Location = new System.Drawing.Point(125, 283);
            this.portstatusValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portstatusValue.Name = "portstatusValue";
            this.portstatusValue.Size = new System.Drawing.Size(64, 17);
            this.portstatusValue.TabIndex = 97;
            this.portstatusValue.Text = "[Status]";
            // 
            // portstatusLBL
            // 
            this.portstatusLBL.AutoSize = true;
            this.portstatusLBL.Location = new System.Drawing.Point(68, 283);
            this.portstatusLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portstatusLBL.Name = "portstatusLBL";
            this.portstatusLBL.Size = new System.Drawing.Size(44, 16);
            this.portstatusLBL.TabIndex = 96;
            this.portstatusLBL.Text = "Status";
            // 
            // portserviceValue
            // 
            this.portserviceValue.AutoSize = true;
            this.portserviceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portserviceValue.Location = new System.Drawing.Point(125, 246);
            this.portserviceValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portserviceValue.Name = "portserviceValue";
            this.portserviceValue.Size = new System.Drawing.Size(72, 17);
            this.portserviceValue.TabIndex = 94;
            this.portserviceValue.Text = "[Service]";
            // 
            // pertserviceLBL
            // 
            this.pertserviceLBL.AutoSize = true;
            this.pertserviceLBL.Location = new System.Drawing.Point(60, 246);
            this.pertserviceLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pertserviceLBL.Name = "pertserviceLBL";
            this.pertserviceLBL.Size = new System.Drawing.Size(53, 16);
            this.pertserviceLBL.TabIndex = 93;
            this.pertserviceLBL.Text = "Service";
            // 
            // portClassGuidValue
            // 
            this.portClassGuidValue.AutoSize = true;
            this.portClassGuidValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portClassGuidValue.Location = new System.Drawing.Point(125, 209);
            this.portClassGuidValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portClassGuidValue.Name = "portClassGuidValue";
            this.portClassGuidValue.Size = new System.Drawing.Size(91, 17);
            this.portClassGuidValue.TabIndex = 92;
            this.portClassGuidValue.Text = "[ClassGuid]";
            // 
            // portclassguidLBL
            // 
            this.portclassguidLBL.AutoSize = true;
            this.portclassguidLBL.Location = new System.Drawing.Point(41, 209);
            this.portclassguidLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portclassguidLBL.Name = "portclassguidLBL";
            this.portclassguidLBL.Size = new System.Drawing.Size(72, 16);
            this.portclassguidLBL.TabIndex = 91;
            this.portclassguidLBL.Text = "Class Guid";
            // 
            // portdeviceIdValue
            // 
            this.portdeviceIdValue.AutoSize = true;
            this.portdeviceIdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portdeviceIdValue.Location = new System.Drawing.Point(125, 172);
            this.portdeviceIdValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portdeviceIdValue.Name = "portdeviceIdValue";
            this.portdeviceIdValue.Size = new System.Drawing.Size(87, 17);
            this.portdeviceIdValue.TabIndex = 90;
            this.portdeviceIdValue.Text = "[Device ID]";
            // 
            // portdeviceIdLBL
            // 
            this.portdeviceIdLBL.AutoSize = true;
            this.portdeviceIdLBL.Location = new System.Drawing.Point(44, 172);
            this.portdeviceIdLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portdeviceIdLBL.Name = "portdeviceIdLBL";
            this.portdeviceIdLBL.Size = new System.Drawing.Size(66, 16);
            this.portdeviceIdLBL.TabIndex = 89;
            this.portdeviceIdLBL.Text = "Device ID";
            // 
            // portdescValue
            // 
            this.portdescValue.AutoSize = true;
            this.portdescValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portdescValue.Location = new System.Drawing.Point(125, 135);
            this.portdescValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portdescValue.Name = "portdescValue";
            this.portdescValue.Size = new System.Drawing.Size(100, 17);
            this.portdescValue.TabIndex = 88;
            this.portdescValue.Text = "[Description]";
            // 
            // portdescLBL
            // 
            this.portdescLBL.AutoSize = true;
            this.portdescLBL.Location = new System.Drawing.Point(37, 135);
            this.portdescLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portdescLBL.Name = "portdescLBL";
            this.portdescLBL.Size = new System.Drawing.Size(75, 16);
            this.portdescLBL.TabIndex = 87;
            this.portdescLBL.Text = "Description";
            // 
            // portnameValue
            // 
            this.portnameValue.AutoSize = true;
            this.portnameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portnameValue.Location = new System.Drawing.Point(125, 62);
            this.portnameValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portnameValue.Name = "portnameValue";
            this.portnameValue.Size = new System.Drawing.Size(59, 17);
            this.portnameValue.TabIndex = 86;
            this.portnameValue.Text = "[Name]";
            // 
            // portnameLBL
            // 
            this.portnameLBL.AutoSize = true;
            this.portnameLBL.Location = new System.Drawing.Point(71, 62);
            this.portnameLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portnameLBL.Name = "portnameLBL";
            this.portnameLBL.Size = new System.Drawing.Size(44, 16);
            this.portnameLBL.TabIndex = 85;
            this.portnameLBL.Text = "Name";
            // 
            // portcaptionLBL
            // 
            this.portcaptionLBL.AutoSize = true;
            this.portcaptionLBL.Location = new System.Drawing.Point(83, 25);
            this.portcaptionLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portcaptionLBL.Name = "portcaptionLBL";
            this.portcaptionLBL.Size = new System.Drawing.Size(31, 16);
            this.portcaptionLBL.TabIndex = 84;
            this.portcaptionLBL.Text = "Port";
            // 
            // CmdProfileCB
            // 
            this.CmdProfileCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdProfileCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdProfileCB.FormattingEnabled = true;
            this.CmdProfileCB.Location = new System.Drawing.Point(223, 12);
            this.CmdProfileCB.Margin = new System.Windows.Forms.Padding(4);
            this.CmdProfileCB.Name = "CmdProfileCB";
            this.CmdProfileCB.Size = new System.Drawing.Size(801, 24);
            this.CmdProfileCB.TabIndex = 1;
            this.CmdProfileCB.SelectedIndexChanged += new System.EventHandler(this.CmdProfileCB_SelectedIndexChanged);
            // 
            // gwCmdProfileLBL
            // 
            this.gwCmdProfileLBL.AutoSize = true;
            this.gwCmdProfileLBL.Location = new System.Drawing.Point(175, 16);
            this.gwCmdProfileLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwCmdProfileLBL.Name = "gwCmdProfileLBL";
            this.gwCmdProfileLBL.Size = new System.Drawing.Size(45, 16);
            this.gwCmdProfileLBL.TabIndex = 56;
            this.gwCmdProfileLBL.Text = "Profile";
            // 
            // gwPLLLowPassTB
            // 
            this.gwPLLLowPassTB.Location = new System.Drawing.Point(348, 228);
            this.gwPLLLowPassTB.Margin = new System.Windows.Forms.Padding(4);
            this.gwPLLLowPassTB.Name = "gwPLLLowPassTB";
            this.gwPLLLowPassTB.Size = new System.Drawing.Size(45, 22);
            this.gwPLLLowPassTB.TabIndex = 135;
            this.gwPLLLowPassTB.Tag = "lowpass";
            this.gwPLLLowPassTB.ValidationFailure = false;
            // 
            // gwPLLLowPassLBL
            // 
            this.gwPLLLowPassLBL.AutoSize = true;
            this.gwPLLLowPassLBL.Location = new System.Drawing.Point(280, 231);
            this.gwPLLLowPassLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gwPLLLowPassLBL.Name = "gwPLLLowPassLBL";
            this.gwPLLLowPassLBL.Size = new System.Drawing.Size(61, 16);
            this.gwPLLLowPassLBL.TabIndex = 136;
            this.gwPLLLowPassLBL.Text = "Lowpass";
            // 
            // gWeazleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 567);
            this.Controls.Add(this.gwCmdProfileLBL);
            this.Controls.Add(this.CmdProfileCB);
            this.Controls.Add(this.GWTab);
            this.Controls.Add(this.accessoptions);
            this.Controls.Add(this.gwCmdHelpBtn);
            this.Controls.Add(this.busy1);
            this.Controls.Add(this.timeCB);
            this.Controls.Add(this.actionLBL);
            this.Controls.Add(this.GwStatus);
            this.Controls.Add(this.actionCB);
            this.Controls.Add(this.ExecuteBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "gWeazleFrm";
            this.Text = "gWeazleGUI";
            this.Load += new System.EventHandler(this.gWeasleFrm_Load);
            this.GwStatus.ResumeLayout(false);
            this.GwStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accessoptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.busy1)).EndInit();
            this.GWTab.ResumeLayout(false);
            this.actionTab.ResumeLayout(false);
            this.actionTab.PerformLayout();
            this.parmTab.ResumeLayout(false);
            this.parmTab.PerformLayout();
            this.ddTab.ResumeLayout(false);
            this.ddTab.PerformLayout();
            this.gwDDtracksgroupBox.ResumeLayout(false);
            this.gwDDtracksgroupBox.PerformLayout();
            this.optionsTab.ResumeLayout(false);
            this.optionsTab.PerformLayout();
            this.deviceTab.ResumeLayout(false);
            this.deviceTab.PerformLayout();
            this.portsTab.ResumeLayout(false);
            this.portsTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ExecuteBtn;
        private System.Windows.Forms.ComboBox actionCB;
        private System.Windows.Forms.StatusStrip GwStatus;
        private System.Windows.Forms.ToolStripStatusLabel GwCurrentStatus;
        private System.Windows.Forms.Label actionLBL;
        private System.Windows.Forms.CheckBox timeCB;
        private System.Windows.Forms.PictureBox busy1;
        private System.Windows.Forms.ToolStripStatusLabel gwToolsVersion;
        private System.Windows.Forms.Button gwCmdHelpBtn;
        private System.Windows.Forms.ToolTip gweazleTips;
        private System.Windows.Forms.PictureBox accessoptions;
        private System.Windows.Forms.TabControl GWTab;
        private System.Windows.Forms.TabPage actionTab;
        private System.Windows.Forms.TabPage parmTab;
        private System.Windows.Forms.TabPage ddTab;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.TabPage deviceTab;
        private System.Windows.Forms.TextBox outputTB;
        private System.Windows.Forms.Label gwCylLBL;
        private vTextParam gwCylTB;
        private System.Windows.Forms.Label additonalArgsLBL;
        private vTextParam additonalArgsTB;
        private System.Windows.Forms.ComboBox gwFormatTypeCB;
        private System.Windows.Forms.Label gwFormatTypeLBL;
        private System.Windows.Forms.Button removeDiskConfigBtn;
        private System.Windows.Forms.Button gwDDSaveBtn;
        private System.Windows.Forms.Button gwDDReloadBtn;
        private System.Windows.Forms.Button gwDDfileBtn;
        private System.Windows.Forms.Label gwDDfileLBL;
        private System.Windows.Forms.GroupBox gwDDtracksgroupBox;
        private System.Windows.Forms.Button gwDDRemoveTrackBtn;
        private vTextParam gwDDsubformatTB;
        private System.Windows.Forms.Label gwDDsubformatLBL;
        private vTextParam gwDDclockTB;
        private System.Windows.Forms.Label gwDDclockLBL;
        private System.Windows.Forms.Button gwDDApplyTrackBtn;
        private vTextParam gwDDimgbpsTB;
        private System.Windows.Forms.Label gwDDimgbpsLBL;
        private vTextParam gwDDgapbyteTB;
        private System.Windows.Forms.Label gwDDgapbyteLBL;
        private vTextParam gwDDgap4aTB;
        private System.Windows.Forms.Label gwDDgap4aLBL;
        private vTextParam gwDDgap3TB;
        private System.Windows.Forms.Label gwDDgap3LBL;
        private vTextParam gwDDgap2TB;
        private System.Windows.Forms.Label gwDDgap2LBL;
        private vTextParam gwDDgap1TB;
        private System.Windows.Forms.Label gwDDgap1LBL;
        private vTextParam gwDDrpmTB;
        private System.Windows.Forms.Label gwDDrpmLBL;
        private vTextParam gwDDrateTB;
        private System.Windows.Forms.Label gwDDrateLBL;
        private vTextParam gwDDhTB;
        private System.Windows.Forms.Label gwDDhLBL;
        private vTextParam gwDDinterleaveTB;
        private System.Windows.Forms.Label gwDDinterleaveLBL;
        private vTextParam gwDDidTB;
        private System.Windows.Forms.Label gwDDidLBL;
        private vTextParam gwDDhskewTB;
        private System.Windows.Forms.Label gwDDhskewLBL;
        private vTextParam gwDDcskewTB;
        private System.Windows.Forms.Label gwDDcskewLBL;
        private System.Windows.Forms.CheckBox gwDDiamCB;
        private vTextParam gwDDbpsTB;
        private System.Windows.Forms.Label gwDDbpsLBL;
        private vTextParam gwDDformatTB;
        private System.Windows.Forms.Label gwDDformatLBL;
        private vTextParam gwDDtracksTB;
        private System.Windows.Forms.Label gwDDtracksLBL;
        private vTextParam gwDDsectorsTB;
        private System.Windows.Forms.Label gwDDsectorsLBL;
        private System.Windows.Forms.ListBox gwDDTrackListLB;
        private vTextParam gwDDStepTB;
        private System.Windows.Forms.Label gwDDStepLBL;
        private vTextParam gwDDHeadsTB;
        private System.Windows.Forms.Label gwDDheadsLBL;
        private vTextParam gwDDCylsTB;
        private System.Windows.Forms.Label gwDDCylsLBL;
        private System.Windows.Forms.Button diskDefApplyBtn;
        private vTextParam diskDefNameTB;
        private System.Windows.Forms.Label diskDefsNameLBL;
        private System.Windows.Forms.Button newDiskConfigBtn;
        private System.Windows.Forms.Label gwDiskConfigLBL;
        private System.Windows.Forms.ComboBox gwDiskConfigCB;
        private System.Windows.Forms.Label gwPathSelectionLBL;
        private System.Windows.Forms.Button SelectGWPathBtn;
        private vTextParam gwPathSelectionTB;
        private System.Windows.Forms.Label gwPortLBL;
        private vTextParam gwPortTB;
        private System.Windows.Forms.Label gwFirmwareValue;
        private System.Windows.Forms.Label gwFirmwareLBL;
        private System.Windows.Forms.Label gwMCUValue;
        private System.Windows.Forms.Label gwMCULBL;
        private System.Windows.Forms.Label gwModelValue;
        private System.Windows.Forms.Label gwModelLBL;
        private System.Windows.Forms.Label gwUSBRateValue;
        private System.Windows.Forms.Label gwUSBRateLBL;
        private System.Windows.Forms.Label gwSerialValue;
        private System.Windows.Forms.Label gwSerialLBL;
        private System.Windows.Forms.Button SelectNewFileBtn;
        private System.Windows.Forms.Button SelectExistingFileBtn;
        private System.Windows.Forms.Label GwFileDisplay;
        private System.Windows.Forms.ComboBox CmdProfileCB;
        private System.Windows.Forms.Label gwCmdProfileLBL;
        private System.Windows.Forms.Label gwProfileSelLBL;
        private System.Windows.Forms.Button OpenProfileBtn;
        private vTextParam gwProfileFileTB;
        private System.Windows.Forms.Label gwOutTracksLBL;
        private vTextParam gwOTTSPECOffsetsTB;
        private System.Windows.Forms.Label gwOTTSPECOffsetsLBL;
        private vTextParam gwOTTSPECStepTB;
        private System.Windows.Forms.Label gwOTTSPECStepLBL;
        private vTextParam gwOTTSPECHeadsTB;
        private System.Windows.Forms.Label gwOTTSPECHeadsLBL;
        private vTextParam gwOTTSPECCylTB;
        private System.Windows.Forms.Label gwOTTSPECCylLBL;
        private System.Windows.Forms.CheckBox gwPreEraseCB;
        private vTextParam gwRevsTB;
        private System.Windows.Forms.Label gwRevsLBL;
        private vTextParam gwAdjustSpeedTB;
        private System.Windows.Forms.Label gwAdjustSpeedLBL;
        private vTextParam gwFakeIndexTB;
        private System.Windows.Forms.Label gwFakeIndexLBL;
        private vTextParam gwPLLPhaseTB;
        private System.Windows.Forms.Label gwPLLPhaseLBL;
        private vTextParam gwPLLPeriodTB;
        private System.Windows.Forms.Label gwPLLPeriodLBL;
        private vTextParam gwTSPECOffsetsTB;
        private System.Windows.Forms.Label gwTSPECOffsetsLBL;
        private vTextParam gwTSPECStepTB;
        private System.Windows.Forms.Label gwTSPECStepLBL;
        private vTextParam gwTSPECHeadsTB;
        private System.Windows.Forms.Label gwTSPECHeadsLBL;
        private vTextParam gwTSPECCylTB;
        private System.Windows.Forms.Label gwTSPECCylLBL;
        private System.Windows.Forms.CheckBox gwNoVerifyCB;
        private System.Windows.Forms.CheckBox gwEraseBlankCB;
        private System.Windows.Forms.CheckBox gwRawCB;
        private vTextParam gwSeekRetriesTB;
        private System.Windows.Forms.Label gwSeekRetriesLBL;
        private vTextParam gwRetriesTB;
        private System.Windows.Forms.Label gwRetriesLBL;
        private System.Windows.Forms.CheckBox gwHFreqCB;
        private System.Windows.Forms.Label gwLingerLBL;
        private vTextParam gwLingerTB;
        private System.Windows.Forms.Label gwPassesLBL;
        private vTextParam gwPassesTB;
        private System.Windows.Forms.CheckBox gwForceCB;
        private System.Windows.Forms.CheckBox gwMotorOnCB;
        private System.Windows.Forms.Label driveLBL;
        private vTextParam driveTB;
        private System.Windows.Forms.Label gwNrLBL;
        private vTextParam gwNrTB;
        private System.Windows.Forms.CheckBox gwOTTSPECSwapCB;
        private System.Windows.Forms.CheckBox gwTSPECSwapCB;
        private System.Windows.Forms.CheckBox gwUseDiskDefFileCB;
        private System.Windows.Forms.Label CmdProfileFileLBL;
        private System.Windows.Forms.Label ProfileNameLBL;
        private vTextParam ProfileNameTB;
        private System.Windows.Forms.Button SaveProfileBtn;
        private System.Windows.Forms.Button SelectProfilePathBtn;
        private System.Windows.Forms.Button ProfileClearBtn;
        private System.Windows.Forms.Button gwReloadBtn;
        private System.Windows.Forms.TabPage portsTab;
        private System.Windows.Forms.Label portserviceValue;
        private System.Windows.Forms.Label pertserviceLBL;
        private System.Windows.Forms.Label portClassGuidValue;
        private System.Windows.Forms.Label portclassguidLBL;
        private System.Windows.Forms.Label portdeviceIdValue;
        private System.Windows.Forms.Label portdeviceIdLBL;
        private System.Windows.Forms.Label portdescValue;
        private System.Windows.Forms.Label portdescLBL;
        private System.Windows.Forms.Label portnameValue;
        private System.Windows.Forms.Label portnameLBL;
        private System.Windows.Forms.Label portcaptionLBL;
        private System.Windows.Forms.Label porterrordescValue;
        private System.Windows.Forms.Label porterrordescLBL;
        private System.Windows.Forms.Label portstatusValue;
        private System.Windows.Forms.Label portstatusLBL;
        private System.Windows.Forms.ComboBox portcaptionCB;
        private System.Windows.Forms.Label portbusdescValue;
        private System.Windows.Forms.Label portbusdescLBL;
        private System.Windows.Forms.Label gwHostToolsVersionValue;
        private System.Windows.Forms.Label gwHostToolsVersionLBL;
        private System.Windows.Forms.Button useportbtn;
        private System.Windows.Forms.CheckBox gwDDcb;
        private System.Windows.Forms.Button ProfileDelBtn;
        private System.Windows.Forms.CheckBox gwHardSectorsCB;
        private System.Windows.Forms.CheckBox gwNoClobberCB;
        private System.Windows.Forms.ComboBox gwDDImport;
        private System.Windows.Forms.Button gwDDNewFileBtn;
        private System.Windows.Forms.ToolStripStatusLabel GwGUIActions;
        private System.Windows.Forms.Button gwAutoReloadBtn;
        private System.Windows.Forms.Button refreshportsbtn;
        private System.Windows.Forms.CheckBox gwReverseCB;
        private vTextParam gwTagTB;
        private System.Windows.Forms.Label gwTagLBL;
        private System.Windows.Forms.CheckBox gwDelaysCB;
        private vTextParam gwPLLLowPassTB;
        private System.Windows.Forms.Label gwPLLLowPassLBL;
    }
}

