Imports System
Imports System.Data




Public Class Form1



    Dim dsFounds As New DataSet
    Dim xDsSet As New DataSet
    Dim InvCount As Boolean = False 'variables for table's
    Dim QuantCount As Boolean = False 'variable for quant column
    Dim ItemCount As Boolean = False 'variable for item column

    'reading from an excel file
    Private Sub ExcelConnection()
        Dim sfilename As String
        sfilename = "c:\ItemAndSku.xls"
        Dim xCon As New OleDb.OleDbConnection("PROVIDER=microsoft.jet.oledb.4.0;data source = " & sfilename & "; Extended Properties=""Excel 8.0;HDR=YES;""")
        Dim xCommand As New OleDb.OleDbCommand("SELECT * FROM [" & "ItemSku$" & "]", xCon)
        Dim da As New OleDb.OleDbDataAdapter(xCommand.CommandText, xCon)


        xCon.Open()
        da.Fill(xDsSet)
        xCon.Close()
        da.Dispose()
        xCon.Dispose()

    End Sub


    Private Sub btnfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        FindSku(xDsSet)
    End Sub

    Private Sub FindSku(ByVal ds As DataSet)
        Dim isNoWhere As Boolean = True
        Dim counter = 0
        Dim isFound As Boolean = False
        If TxtSKU.Text = "" Then Exit Sub


        For x = 0 To xDsSet.Tables(0).Rows.Count - 1
            If "*" & TxtSKU.Text = xDsSet.Tables(0).Rows(x).Item("SKU") Then 'set the text box with entry number and compares with excel list
                If dsFounds.Tables(0).Rows.Count = 0 Then
                    Dim rNew() As String = {xDsSet.Tables(0).Rows(x).Item("ItemNumber"), "1"}
                    dsFounds.Tables("Inventory").Rows.Add(rNew)
                    isFound = True
                    dgFoundsddd.Rows.Add(rNew)
                    isNoWhere = False
                    Exit For
                Else
                    For y = 0 To dsFounds.Tables(0).Rows.Count - 1

                        If dsFounds.Tables(0).Rows(y).Item("Item") = xDsSet.Tables(0).Rows(x).Item("ItemNumber") Then
                            dsFounds.Tables(0).Rows(y).Item("Quant") = dsFounds.Tables(0).Rows(y).Item("Quant") + 1
                            For z = 0 To dgFoundsddd.Rows.Count - 2
                                If dgFoundsddd.Rows(z).Cells(0).Value = dsFounds.Tables(0).Rows(y).Item("Item") Then
                                    dgFoundsddd.Rows(z).Cells(1).Value = dgFoundsddd.Rows(z).Cells(1).Value + 1
                                    isFound = True
                                    isNoWhere = False
                                    Exit For
                                End If
                            Next
                            isFound = True
                            isNoWhere = False
                            Exit For
                        Else : isFound = False
                        End If

                    Next

                    If isFound = False Then
                        Dim rNew() As String = {xDsSet.Tables(0).Rows(x).Item("ItemNumber"), 1}
                        dsFounds.Tables("Inventory").Rows.Add(rNew)
                        dgFoundsddd.Rows.Add(rNew)
                        isFound = True
                        isNoWhere = False
                        Exit For
                    Else
                        Exit For
                    End If
                End If
            End If
        Next

        If isNoWhere = True Then
            My.Computer.Audio.Play("C:\Buzz01.wav")
            Dim newSku As String = ""
            Do Until newSKU <> ""
                newSKU = InputBox("Enter ItemNumber", "Input")
            Loop
            Dim quant As Integer = InputBox("Please enter a quantity")
            Dim rNew() As String = {newSku, quant}
            dsFounds.Tables(0).Rows.Add(rNew)
            Dim rNew2() As String = {newSku, "*" & TxtSKU.Text}
            xDsSet.Tables(0).Rows.Add(rNew2)
            isNoWhere = False
        End If


        TxtSKU.Text = ""
        TxtSKU.Focus()

    End Sub


    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click

        ExportToCsv()

    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        Dim response As MsgBoxResult
        response = MsgBox("Do you want to close form?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm")
        If response = MsgBoxResult.Yes Then
            Me.Dispose()
        ElseIf response = MsgBoxResult.No Then
            Exit Sub
        End If


    End Sub

    Private Sub ExportToCsv()

        'Dim dt As DataTable = dsFounds.Tables(0)
        'Dim dr As DataRow

        Dim csvFile As String = "C:\Text.csv"
        Dim myWriter As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvFile, False)

        'For Each dt In dsFounds.Tables
        'For Each dr In dt.Rows
        'myWriter.WriteLine(dsFounds.Tables(0).Columns.Item("Quant"))
        myWriter.WriteLine("ItemNumber,Quantity")
        For x = 0 To dsFounds.Tables(0).Rows.Count - 1
            With dsFounds.Tables(0).Rows(x)
                myWriter.WriteLine(.Item("Item") & "," & .Item("Quant"))
            End With
        Next
        myWriter.Close()

    End Sub

    Private Sub TxtSKU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSKU.KeyPress
        ''''' handles the "enter" keypress when search textbox is focused
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
        End If
        If e.Handled = True Then
            btnFind.PerformClick()
        End If
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dsFounds As New DataSet


        Dim dcItem As New DataColumn("Item", System.Type.GetType("System.String", True, True))
        Dim dcQuant As New DataColumn("Quant", System.Type.GetType("System.Int32", True, True))

        'checks to see if the inventory table is already made
        If InvCount = False Then
            dsFounds.Tables.Add("Inventory")
            InvCount = True
        Else
            InvCount = True
        End If


        'checks to see if there is the item column in there already
        If ItemCount = False Then
            dsFounds.Tables("Inventory").Columns.Add("Item")
            ItemCount = True
        Else
            ItemCount = True
        End If


        'checks to see if there is a quant column in there already
        If QuantCount = False Then
            dsFounds.Tables("Inventory").Columns.Add("Quant")
            QuantCount = True
        Else
            QuantCount = True
        End If

        ExcelConnection()
    End Sub



End Class
