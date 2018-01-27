Imports IWshRuntimeLibrary
Imports System.IO
Imports System.Reflection



Public Class About


    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Reload()

        CheckBox1.Checked = My.Settings.Chide
        CheckBox2.Checked = My.Settings.Shide
        CheckBox3.Checked = My.Settings.Nhide
        CheckBox4.Checked = My.Settings.StartAtBoot

        My.Settings.Save()
    End Sub

    Sub UpdateSettings()
        My.Settings.Reload()

        My.Settings.Chide = CheckBox1.Checked
        My.Settings.Shide = CheckBox2.Checked
        My.Settings.Nhide = CheckBox3.Checked
        My.Settings.StartAtBoot = CheckBox4.Checked

        My.Settings.Save()
    End Sub

    Private Sub CheckedChange(sender As Object, e As eventargs) Handles CheckBox1.checkedchanged, checkbox2.checkedchanged, checkbox3.checkedchanged
        HideOff_caps = W.CheckBox1.Checked
        HideOff_screen = W.CheckBox2.Checked
        HideOff_num = W.CheckBox3.Checked
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged

        If CheckBox4.Checked Then
            Try


                Dim StartupFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)

                If Not IO.File.Exists(StartupFolder & "\GSNotifier.lnk") Then

                    Dim WshShell As WshShellClass = New WshShellClass
                    Dim MyShortcut As IWshRuntimeLibrary.IWshShortcut
                    MyShortcut = CType(WshShell.CreateShortcut(StartupFolder & "\GSNotifier.lnk"), IWshRuntimeLibrary.IWshShortcut)
                    MyShortcut.TargetPath = ApplicationPath()
                    MyShortcut.Save()
                End If

            Catch ex As Exception
                Throw ex
            End Try

        Else
            Try
                Dim StartupFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                IO.File.Delete(StartupFolder & "\GSNotifier.lnk")
            Catch ex As Exception
                Throw ex
            End Try
        End If


    End Sub

    'Equivalent of Application.StartupPath in Windows.Forms
    Private Function ApplicationPath() As String
        Return Path.GetDirectoryName([Assembly].GetExecutingAssembly().Location & "\CapsBlockNumIconNotifier.exe")
    End Function


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Diagnostics.Process.Start("https://github.com/SmokeyTheBandicoot/GameShardsNotifyIcon")
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Diagnostics.Process.Start("https://twitter.com/gameshardsSW")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Diagnostics.Process.Start("https://t.co/WJPdNVm6Sq")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Diagnostics.Process.Start("https://www.facebook.com/gameshardsSTB/")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UpdateSettings()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UpdateSettings()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class