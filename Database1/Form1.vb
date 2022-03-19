Imports System.Data.OleDb
Public Class Form1
    Dim pro As String
    Dim conString As String
    Dim command As String
    Dim myconnection As OleDbConnection = New OleDbConnection

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        pro = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\user\Documents\Customer.mdb"
        conString = pro
        myconnection.ConnectionString = conString
        myconnection.Open()
        command = "Insert into Customer ([CustomerID],[Full Names],[Address],[Business Name],[Location],[Credit Limit]) values ('" & txtCustomerID.Text & "' , '" & txtFullnames.Text & "' , '" & txtAddress.Text & "' ,'" & txtBusinessName.Text & "' , '" & txtLocation.Text & "','" & txtCreditlimit.Text & "')"
        Dim cmd As OleDbCommand = New OleDbCommand(command, myconnection)
        cmd.Parameters.Add(New OleDbParameter("CustomerID", CType(txtCustomerID.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Full Names", CType(txtFullnames.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Address", CType(txtAddress.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Business Name", CType(txtBusinessName.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Location", CType(txtLocation.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Credit Limit", CType(txtCreditlimit.Text, String)))

        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myconnection.Close()
            txtCustomerID.Clear()
            txtFullnames.Clear()
            txtAddress.Clear()
            txtBusinessName.Clear()
            txtLocation.Clear()
            txtCreditlimit.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
