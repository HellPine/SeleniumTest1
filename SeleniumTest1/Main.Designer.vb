<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FormsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModdedTestsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StructureCheckingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.L1Step1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RunningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SingleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.FormsToolStripMenuItem, Me.RunningToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(767, 24)
        Me.MenuStrip1.TabIndex = 15
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'FormsToolStripMenuItem
        '
        Me.FormsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModdedTestsToolStripMenuItem})
        Me.FormsToolStripMenuItem.Name = "FormsToolStripMenuItem"
        Me.FormsToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.FormsToolStripMenuItem.Text = "Forms"
        '
        'ModdedTestsToolStripMenuItem
        '
        Me.ModdedTestsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StructureCheckingToolStripMenuItem, Me.L1Step1ToolStripMenuItem})
        Me.ModdedTestsToolStripMenuItem.Name = "ModdedTestsToolStripMenuItem"
        Me.ModdedTestsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ModdedTestsToolStripMenuItem.Text = "Tests"
        '
        'StructureCheckingToolStripMenuItem
        '
        Me.StructureCheckingToolStripMenuItem.Name = "StructureCheckingToolStripMenuItem"
        Me.StructureCheckingToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.StructureCheckingToolStripMenuItem.Text = "Structure Checking"
        '
        'L1Step1ToolStripMenuItem
        '
        Me.L1Step1ToolStripMenuItem.Name = "L1Step1ToolStripMenuItem"
        Me.L1Step1ToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.L1Step1ToolStripMenuItem.Text = "L1 Registration"
        '
        'RunningToolStripMenuItem
        '
        Me.RunningToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SingleToolStripMenuItem, Me.MainToolStripMenuItem})
        Me.RunningToolStripMenuItem.Name = "RunningToolStripMenuItem"
        Me.RunningToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.RunningToolStripMenuItem.Text = "Running"
        '
        'SingleToolStripMenuItem
        '
        Me.SingleToolStripMenuItem.Name = "SingleToolStripMenuItem"
        Me.SingleToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SingleToolStripMenuItem.Text = "Single"
        '
        'MainToolStripMenuItem
        '
        Me.MainToolStripMenuItem.Name = "MainToolStripMenuItem"
        Me.MainToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MainToolStripMenuItem.Text = "Batchs"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 521)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.Text = "Main"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModdedTestsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StructureCheckingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents L1Step1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunningToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SingleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
