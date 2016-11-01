<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtSKU = New System.Windows.Forms.TextBox
        Me.Btn1 = New System.Windows.Forms.Button
        Me.btnFind = New System.Windows.Forms.Button
        Me.Btn3 = New System.Windows.Forms.Button
        Me.dgFoundsddd = New System.Windows.Forms.DataGridView
        Me.ItemNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Exist = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.clrbtn = New System.Windows.Forms.Button
        CType(Me.dgFoundsddd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtSKU
        '
        Me.TxtSKU.Location = New System.Drawing.Point(42, 23)
        Me.TxtSKU.Name = "TxtSKU"
        Me.TxtSKU.Size = New System.Drawing.Size(258, 20)
        Me.TxtSKU.TabIndex = 0
        '
        'Btn1
        '
        Me.Btn1.Location = New System.Drawing.Point(12, 304)
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(171, 24)
        Me.Btn1.TabIndex = 1
        Me.Btn1.Text = "Export to CSV"
        Me.Btn1.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(306, 15)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(90, 35)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "Input entry"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'Btn3
        '
        Me.Btn3.Location = New System.Drawing.Point(337, 301)
        Me.Btn3.Name = "Btn3"
        Me.Btn3.Size = New System.Drawing.Size(68, 30)
        Me.Btn3.TabIndex = 3
        Me.Btn3.Text = "Exit"
        Me.Btn3.UseVisualStyleBackColor = True
        '
        'dgFoundsddd
        '
        Me.dgFoundsddd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFoundsddd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemNumber, Me.Quant, Me.Exist})
        Me.dgFoundsddd.Location = New System.Drawing.Point(12, 56)
        Me.dgFoundsddd.Name = "dgFoundsddd"
        Me.dgFoundsddd.Size = New System.Drawing.Size(393, 231)
        Me.dgFoundsddd.TabIndex = 4
        '
        'ItemNumber
        '
        Me.ItemNumber.HeaderText = "ItemNumber"
        Me.ItemNumber.Name = "ItemNumber"
        Me.ItemNumber.Width = 250
        '
        'Quant
        '
        Me.Quant.HeaderText = "Quantity"
        Me.Quant.Name = "Quant"
        '
        'Exist
        '
        Me.Exist.HeaderText = "Exist"
        Me.Exist.Name = "Exist"
        Me.Exist.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "(*.xls)|*.xls"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "(*.csv)|*.csv"
        '
        'clrbtn
        '
        Me.clrbtn.Location = New System.Drawing.Point(207, 304)
        Me.clrbtn.Name = "clrbtn"
        Me.clrbtn.Size = New System.Drawing.Size(75, 24)
        Me.clrbtn.TabIndex = 5
        Me.clrbtn.Text = "Clear List"
        Me.clrbtn.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 350)
        Me.Controls.Add(Me.clrbtn)
        Me.Controls.Add(Me.dgFoundsddd)
        Me.Controls.Add(Me.Btn3)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.Btn1)
        Me.Controls.Add(Me.TxtSKU)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Scan"
        CType(Me.dgFoundsddd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSKU As System.Windows.Forms.TextBox
    Friend WithEvents Btn1 As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents Btn3 As System.Windows.Forms.Button
    Friend WithEvents dgFoundsddd As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents clrbtn As System.Windows.Forms.Button
    Friend WithEvents ItemNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Exist As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
