<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class f_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsmiLoadDBs = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiClearV = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tv1 = New System.Windows.Forms.TreeView()
        Me.rtb = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExploreDir = New System.Windows.Forms.Button()
        Me.btnSelDir = New System.Windows.Forms.Button()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tsmiTray = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiLoadDBs, Me.tsmiBackup, Me.tsmiClearV, Me.tsmiSettings, Me.tsmiTray, Me.tsmiClose})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmiLoadDBs
        '
        Me.tsmiLoadDBs.Name = "tsmiLoadDBs"
        Me.tsmiLoadDBs.Size = New System.Drawing.Size(101, 20)
        Me.tsmiLoadDBs.Text = "Load Databases"
        '
        'tsmiBackup
        '
        Me.tsmiBackup.Name = "tsmiBackup"
        Me.tsmiBackup.Size = New System.Drawing.Size(58, 20)
        Me.tsmiBackup.Text = "Backup"
        '
        'tsmiClearV
        '
        Me.tsmiClearV.Name = "tsmiClearV"
        Me.tsmiClearV.Size = New System.Drawing.Size(90, 20)
        Me.tsmiClearV.Text = "Clear Verbose"
        '
        'tsmiSettings
        '
        Me.tsmiSettings.Name = "tsmiSettings"
        Me.tsmiSettings.Size = New System.Drawing.Size(61, 20)
        Me.tsmiSettings.Text = "Settings"
        '
        'tsmiClose
        '
        Me.tsmiClose.Name = "tsmiClose"
        Me.tsmiClose.Size = New System.Drawing.Size(48, 20)
        Me.tsmiClose.Text = "Close"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 304)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslStatus
        '
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(73, 17)
        Me.tsslStatus.Text = "Data Source:"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(151, 17)
        Me.ToolStripStatusLabel1.Text = Global.BackupSQLDB.My.MySettings.Default.dbSrc
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(374, 17)
        Me.ToolStripStatusLabel2.Spring = True
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(187, 17)
        Me.ToolStripStatusLabel3.Text = "Created by Marc (http://marc.ma)"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(7, 78)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tv1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtb)
        Me.SplitContainer1.Size = New System.Drawing.Size(787, 219)
        Me.SplitContainer1.SplitterDistance = 168
        Me.SplitContainer1.TabIndex = 3
        '
        'tv1
        '
        Me.tv1.CheckBoxes = True
        Me.tv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv1.HideSelection = False
        Me.tv1.HotTracking = True
        Me.tv1.Indent = 25
        Me.tv1.ItemHeight = 20
        Me.tv1.Location = New System.Drawing.Point(0, 0)
        Me.tv1.Name = "tv1"
        Me.tv1.Size = New System.Drawing.Size(168, 219)
        Me.tv1.TabIndex = 1
        '
        'rtb
        '
        Me.rtb.BackColor = System.Drawing.Color.Black
        Me.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb.Location = New System.Drawing.Point(0, 0)
        Me.rtb.Name = "rtb"
        Me.rtb.ReadOnly = True
        Me.rtb.Size = New System.Drawing.Size(615, 219)
        Me.rtb.TabIndex = 2
        Me.rtb.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnExploreDir)
        Me.GroupBox1.Controls.Add(Me.btnSelDir)
        Me.GroupBox1.Controls.Add(Me.txtLocation)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(790, 44)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'btnExploreDir
        '
        Me.btnExploreDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExploreDir.Location = New System.Drawing.Point(711, 13)
        Me.btnExploreDir.Name = "btnExploreDir"
        Me.btnExploreDir.Size = New System.Drawing.Size(72, 23)
        Me.btnExploreDir.TabIndex = 8
        Me.btnExploreDir.Text = "Explore"
        Me.btnExploreDir.UseVisualStyleBackColor = True
        '
        'btnSelDir
        '
        Me.btnSelDir.Location = New System.Drawing.Point(7, 13)
        Me.btnSelDir.Name = "btnSelDir"
        Me.btnSelDir.Size = New System.Drawing.Size(113, 23)
        Me.btnSelDir.TabIndex = 7
        Me.btnSelDir.Text = "Backup Location:"
        Me.btnSelDir.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BackupSQLDB.My.MySettings.Default, "buLocation", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtLocation.Location = New System.Drawing.Point(126, 15)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(578, 20)
        Me.txtLocation.TabIndex = 5
        Me.txtLocation.Text = Global.BackupSQLDB.My.MySettings.Default.buLocation
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'tsmiTray
        '
        Me.tsmiTray.Name = "tsmiTray"
        Me.tsmiTray.Size = New System.Drawing.Size(44, 20)
        Me.tsmiTray.Text = "Hide"
        '
        'f_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(800, 326)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "f_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BackupSQL by Marc"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents tsmiSettings As ToolStripMenuItem
    Friend WithEvents tsmiClose As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslStatus As ToolStripStatusLabel
    Friend WithEvents tsmiLoadDBs As ToolStripMenuItem
    Friend WithEvents tsmiBackup As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tv1 As TreeView
    Friend WithEvents rtb As RichTextBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnSelDir As Button
    Friend WithEvents btnExploreDir As Button
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tsmiClearV As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents tsmiTray As ToolStripMenuItem
End Class
