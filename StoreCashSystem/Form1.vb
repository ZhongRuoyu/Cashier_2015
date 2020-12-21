Public Class Form1

    Dim totalCount As Single = 0
    Dim thingsCount As Integer = 0

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                AddItem()
        End Select
    End Sub

    Private Sub buttonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click
        Clean()
    End Sub

    Private Sub 取消CToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取消CToolStripMenuItem.Click
        Clean()
    End Sub

    Private Sub buttonAdd_Click(sender As Object, e As EventArgs) Handles buttonAdd.Click
        AddItem()
    End Sub

    Private Sub 添加项AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 添加项AToolStripMenuItem.Click
        AddItem()
    End Sub

    Private Sub buttonCash_Click(sender As Object, e As EventArgs) Handles buttonCash.Click
        Cash()
    End Sub

    Private Sub 结账TToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 结账TToolStripMenuItem.Click
        Cash()
    End Sub

    Private Sub 退出EToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出EToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Clean()
        buttonCancel.Focus()
        NumericUpDown1.Value = 0
        NumericUpDown2.Value = 0
        NumericUpDown1.Focus()
    End Sub

    Private Sub AddItem()
        Select Case MessageBox.Show("确认添加如下项目吗？" & vbCr &
                        "单价" & NumericUpDown1.Value.ToString &
                        " 数量" & NumericUpDown2.Value.ToString &
                        " 总价" & (NumericUpDown1.Value * NumericUpDown2.Value),
                        "正在添加项目", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            Case DialogResult.OK
                totalCount += NumericUpDown1.Value * NumericUpDown2.Value
                thingsCount += NumericUpDown2.Value
                ListBox1.Items.Add("单价" & NumericUpDown1.Value.ToString &
                                   " 数量" & NumericUpDown2.Value.ToString &
                                   " 总价" & (NumericUpDown1.Value * NumericUpDown2.Value))
                ListBox1.Items.Add("小计" & totalCount)
                NumericUpDown3.Value = totalCount
                totalCount = NumericUpDown3.Value
                Clean()
                ToolStripStatusLabel1.Text = "商品计数：" & thingsCount
            Case DialogResult.Cancel
                Clean()
        End Select
    End Sub

    Private Sub Cash()
        If thingsCount = 0 Then
            MessageBox.Show("当前还没有任何物品！", "结账错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Select Case MessageBox.Show("确认结账吗？" & vbCr &
                                    "当前共有" & thingsCount.ToString & "件商品，" &
                                    "金额" & totalCount.ToString & "元。", "结账确认",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            Case DialogResult.OK
                Dialog1.ShowDialog()
                Select Case Dialog1.DialogResult
                    Case DialogResult.OK
                        MessageBox.Show("已经成功结账。", "结账",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CashSucceed()
                    Case DialogResult.Cancel
                        CashCancel()
                End Select
            Case DialogResult.Cancel
                CashCancel()
        End Select
    End Sub

    Private Sub CashSucceed()
        ListBox1.Items.Add("以上物品已经结账：")
        ListBox1.Items.Add("共有" & thingsCount.ToString & "件商品，" &
                           "金额" & totalCount.ToString & "元。"）
        ListBox1.Items.Add("________________________")
        totalCount = 0
        thingsCount = 0
    End Sub

    Private Sub CashCancel()
        Select Case MessageBox.Show("结账已被取消。", "取消结账",
                            MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation)
            Case DialogResult.Abort
                DeleteThis()
                Exit Sub
            Case DialogResult.Retry
                Cash()
                Exit Sub
            Case DialogResult.Ignore
                Exit Sub
        End Select
    End Sub

    Private Sub DeleteThis()

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Select Case MessageBox.Show("确认退出吗？", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.No
                e.Cancel = True
            Case DialogResult.Yes
                e.Cancel = False
        End Select
    End Sub

End Class
