Imports System.Diagnostics
Imports System.Text
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO



Public Module Module1

    Private WithEvents CAPSCM As New ContextMenu
    Private WithEvents SCRLKCM As New ContextMenu
    Private WithEvents NUMLKCM As New ContextMenu

    Dim CAPSIcon As New NotifyIcon
    Dim SCRLKIcon As New NotifyIcon
    Dim NUMLKIcon As New NotifyIcon

    Dim WithEvents t As New Timer

    Public HideOff_caps As Boolean = True
    Public HideOff_screen As Boolean = True
    Public HideOff_num As Boolean = True

    public W As New About

    Private Sub CreateMenu()

        Try
            CAPSCM.MenuItems.Add(New MenuItem("Settings", New EventHandler(AddressOf AboutBox)))

            CAPSCM.MenuItems.Add(New MenuItem("Exit", New EventHandler(AddressOf ExitApp)))



        Catch obEx As Exception
            Throw obEx
        End Try


        Try
            NUMLKCM.MenuItems.Add(New MenuItem("Settings", New EventHandler(AddressOf AboutBox)))

            NUMLKCM.MenuItems.Add(New MenuItem("Exit", New EventHandler(AddressOf ExitApp)))

        Catch obEx As Exception
            Throw obEx
        End Try


        Try
            SCRLKCM.MenuItems.Add(New MenuItem("Settings", New EventHandler(AddressOf AboutBox)))

            SCRLKCM.MenuItems.Add(New MenuItem("Exit", New EventHandler(AddressOf ExitApp)))

        Catch obEx As Exception
            Throw obEx
        End Try
    End Sub

    Public Sub AboutBox()
        W = New About
        W.Show()
    End Sub

    Public Sub ExitApp()
        Application.DoEvents()
        Application.Exit()
        End
    End Sub

    Public Sub ToggleHideWhenOffCaps()
        HideOff_caps = True
    End Sub

    Public Sub ToggleHideWhenOffScreen()
        HideOff_screen = True
    End Sub

    Public Sub ToggleHideWhenOffNum()
        HideOff_num = True
    End Sub

    Sub Main()

        'Dim b() As Byte = My.Resources.Interop_IWshRuntimeLibrary

        'If Not IO.File.Exists([Assembly].GetExecutingAssembly().Location & "\Interop.IWshRuntimeLibrary.dll") Then
        '    My.Computer.FileSystem.WriteAllBytes([Assembly].GetExecutingAssembly().Location & "\Interop.IWshRuntimeLibrary.dll", b, False)
        'End If

        CreateMenu()

        CAPSIcon.ContextMenu = CAPSCM
        SCRLKIcon.ContextMenu = SCRLKCM
        NUMLKIcon.ContextMenu = NUMLKCM

        With t
            .Interval = 2000
            .Start()
        End With

        Do
            Application.DoEvents()
        Loop

    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs) Handles t.Tick

        With CAPSIcon
            If My.Computer.Keyboard.CapsLock Then
                .Icon = My.Resources.C_ON
                .Visible = True
            Else
                .Icon = My.Resources.C_OFF
                If HideOff_caps Then
                    .Visible = False
                Else
                    .Visible = True
                End If

            End If
        End With


        With SCRLKIcon
            If My.Computer.Keyboard.ScrollLock Then
                .Icon = My.Resources.SON
                .Visible = True
            Else
                .Icon = My.Resources.SOFF
                If HideOff_screen Then
                    .Visible = False
                Else
                    .Visible = True
                End If

            End If
        End With


        With NUMLKIcon
            If My.Computer.Keyboard.NumLock Then
                .Icon = My.Resources.NON
                .Visible = True
            Else
                .Icon = My.Resources.NOFF
                If HideOff_num Then
                    .Visible = False
                Else
                    .Visible = True
                End If

            End If
        End With


    End Sub

End Module
