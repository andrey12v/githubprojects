Imports System
Imports System.Data


Public Class Form1

    Dim xDsSet As New DataSet
    Dim InvCount As Boolean = False 'variables for table's
    Dim QuantCount As Boolean = False 'variable for quant column
    Dim ItemCount As Boolean = False 'variable for item column
    Dim ExistCount As Boolean = False 'variable for item column

    'reading from an excel file
    Private Sub ExcelConnection()
        Dim dafound As Boolean = False
        Dim sfilename As String

        sfilename = "c:\ItemAndSku.xls"
        Try

            Dim xCon As New OleDb.OleDbConnection("PROVIDER=microsoft.jet.oledb.4.0;data source = " & sfilename & "; Extended Properties=""Excel 8.0;HDR=YES;""")
            Dim xCommand As New OleDb.OleDbCommand("SELECT * FROM [" & "ItemSku$" & "]", xCon)
            Dim da As New OleDb.OleDbDataAdapter(xCommand.CommandText, xCon)
            xCon.Open()
            da.Fill(xDsSet)
            xCon.Close()
            da.Dispose()
            xCon.Dispose()

        Catch exp As Exception

            OpenFileDialog1.Title = "Please select a file"
            OpenFileDialog1.InitialDirectory = "C:\"
            OpenFileDialog1.ShowDialog()


            sfilename = OpenFileDialog1.FileName
            Dim strSheet As String = "ItemSku"

            Dim xCon As New OleDb.OleDbConnection("PROVIDER=microsoft.jet.oledb.4.0;data source = " & sfilename & "; Extended Properties=""Excel 8.0;HDR=YES;""")
            Dim xCommand As New OleDb.OleDbCommand("SELECT * FROM [" & strSheet & "$]", xCon)
            Dim da As New OleDb.OleDbDataAdapter(xCommand.CommandText, xCon)

            Try
                xCon.Open()
                da.Fill(xDsSet)

            Catch ex As Exception
                Dim response As MsgBoxResult
                response = MsgBox("There was an error in loading the Excel file, Click Retry to find another file or Cancel to Quit", MsgBoxStyle.Information + MsgBoxStyle.RetryCancel, "Error")
                If response = MsgBoxResult.Retry Then
                    ExcelConnection()
                ElseIf response = MsgBoxResult.Cancel Then
                    Me.Close()
                End If


            End Try
            xCon.Close()
            da.Dispose()
            xCon.Dispose()


        End Try
    End Sub


    Private Sub btnfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        FindSku(xDsSet)
    End Sub

    Private Sub FindSku(ByVal ds As DataSet)

        Dim counter = 0
        Dim isFoundInDB As Boolean = False
        Dim isFound As Boolean = False
        If TxtSKU.Text = "" Then Exit Sub

        'MessageBox.Show(xDsSet.Tables(0).Rows(xDsSet.Tables(0).Rows.Count - 1).Item("SKU"))

        For i = 0 To xDsSet.Tables(0).Rows.Count - 1
            If "*" & TxtSKU.Text = xDsSet.Tables(0).Rows(i).Item("SKU") Then 'set the text box with entry number and compares with excel list

                If dgFoundsddd.Rows.Count = 1 Then
                    dgFoundsddd.Rows.Add(xDsSet.Tables(0).Rows(i).Item("ItemNumber"), "1", "1")
                    isFoundInDB = True
                    Exit For
                Else

                    For j = 0 To dgFoundsddd.Rows.Count - 1
                        If dgFoundsddd.Rows(j).Cells(0).Value = xDsSet.Tables(0).Rows(i).Item("ItemNumber") Then
                            dgFoundsddd.Rows(j).Cells(1).Value = dgFoundsddd.Rows(j).Cells(1).Value + 1
                            isFound = True
                            Exit For
                        Else
                            isFound = False
                        End If
                    Next

                    If isFound = False Then
                        dgFoundsddd.Rows.Add(xDsSet.Tables(0).Rows(i).Item("ItemNumber"), "1", "1")
                        isFound = True
                    End If
                    isFoundInDB = True
                    Exit For
                End If
            End If
        Next

        If isFoundInDB = False Then
            My.Computer.Audio.Play("C:\Buzz01.wav")
            Dim newSku As String = ""
            newSku = InputBox("Enter ItemNumber", "Input")
            If newSku = "" Then
                Exit Sub
            End If
            Dim quant As String = InputBox("Please enter a quantity")
            If quant = "" Then
                quant = 0
                Exit Sub
            End If
            xDsSet.Tables(0).Rows.Add(newSku, "*" & TxtSKU.Text)
            dgFoundsddd.Rows.Add(newSku, quant, "0")
            isFoundInDB = True
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
        Dim isFound As Boolean = False
        Dim exceptionCheck As Boolean = False

        For i = 0 To dgFoundsddd.Rows.Count - 2
            If dgFoundsddd.Rows(i).Cells(2).Value = 1 Then
                isFound = True
            End If
        Next

        If isFound = True Then
            Try

                SaveFileDialog1.Title = "Please select a location to save existing items"
                SaveFileDialog1.InitialDirectory = "C:\"
                SaveFileDialog1.FileName = "Existing Items (" & Date.Now.Month & "-" & Date.Now.Day & "-" & DateTime.Now.Year & ")"
                SaveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"

                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim csvFile As String = SaveFileDialog1.FileName
                    Dim myWriter As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvFile, False)
                    myWriter.WriteLine("ItemNumber, Quantity")
                    For i = 0 To dgFoundsddd.Rows.Count - 2
                        If dgFoundsddd.Rows(i).Cells(2).Value = 1 Then
                            myWriter.WriteLine(dgFoundsddd.Rows(i).Cells(0).Value & "," & dgFoundsddd.Rows(i).Cells(1).Value.ToString())
                        End If
                    Next
                    myWriter.Close()
                End If

            Catch ex As Exception
                exceptionCheck = True
                MessageBox.Show(ex.Message)
            End Try

        End If

        Try
            SaveFileDialog1.Title = "Please select a location to save non existing items"
            SaveFileDialog1.InitialDirectory = "C:\"
            SaveFileDialog1.FileName = "Non Existing Items (" & Date.Now.Month & "-" & Date.Now.Day & "-" & DateTime.Now.Year & ")"
            SaveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"

            If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim csvFile As String = SaveFileDialog1.FileName
                Dim myWriter As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvFile, False)
                myWriter.WriteLine("ItemNumber, Quantity")
                For i = 0 To dgFoundsddd.Rows.Count - 2
                    If dgFoundsddd.Rows(i).Cells(2).Value = 0 Then
                        myWriter.WriteLine(dgFoundsddd.Rows(i).Cells(0).Value & "," & dgFoundsddd.Rows(i).Cells(1).Value.ToString())
                    End If
                Next
                myWriter.Close()
            End If

        Catch ex As Exception
            exceptionCheck = True
            MessageBox.Show(ex.Message)
        End Try

        If exceptionCheck = False Then
            MessageBox.Show("Items were exported succesfully")
        End If


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
        ExcelConnection()
    End Sub


    Private Sub clrbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clrbtn.Click
        Dim response As MsgBoxResult
        response = MsgBox("Are you sure you want to clear the Scanned Item's", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm")

        If response = MsgBoxResult.Yes Then
            dgFoundsddd.Rows.Clear()
        ElseIf response = MsgBoxResult.No Then
            Exit Sub
        End If


    End Sub
End Class
