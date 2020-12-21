Imports System.Windows.Forms

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = Form1.NumericUpDown3.Value
    End Sub

    Private Sub NumericUpDown2_Enter(sender As Object, e As EventArgs) Handles NumericUpDown2.Enter
        If NumericUpDown2.Value < NumericUpDown1.Value Then
            Label4.Visible = True
        Else
            Label4.Visible = False
            OK_Button.Enabled = True
        End If
        If NumericUpDown2.Value >= NumericUpDown1.Value Then
            NumericUpDown3.Value = NumericUpDown2.Value - NumericUpDown1.Value
        End If
    End Sub

    Private Sub NumericUpDown2_Leave(sender As Object, e As EventArgs) Handles NumericUpDown2.Leave
        If NumericUpDown2.Value < NumericUpDown1.Value Then
            Label4.Visible = True
        Else
            Label4.Visible = False
            OK_Button.Enabled = True
        End If
        If NumericUpDown2.Value >= NumericUpDown1.Value Then
            NumericUpDown3.Value = NumericUpDown2.Value - NumericUpDown1.Value
        End If
    End Sub

    Private Sub Dialog1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            If NumericUpDown2.Value >= NumericUpDown1.Value Then
                Me.AcceptButton = OK_Button
            End If
        End If
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If NumericUpDown2.Value >= NumericUpDown1.Value Then
            NumericUpDown3.Value = NumericUpDown2.Value - NumericUpDown1.Value
            OK_Button.Enabled = True
        End If
    End Sub

    Private Sub Dialog1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If NumericUpDown2.Value < NumericUpDown1.Value Then
            OK_Button.Enabled = False
            Label4.Visible = True
            e.Cancel = True
        End If
    End Sub
End Class
