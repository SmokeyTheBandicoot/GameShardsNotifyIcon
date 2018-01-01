Imports System.Diagnostics
Imports System.Text
Imports System.Windows.Forms



Public Module Module1

    Private mobNotifyIcon As NotifyIcon
    Private WithEvents mobContextMenu As ContextMenu

    Dim CAPSIcon As NotifyIcon
    Dim SCRLKIcon As NotifyIcon
    Dim NUMLKIcon As NotifyIcon

    Private Sub CreateMenu()
        Try
            mobContextMenu.MenuItems.Add(New MenuItem("Toggle CAPS", New EventHandler(AddressOf ToggleCAPS)))

            mobContextMenu.MenuItems.Add(New MenuItem("Toggle BlockNum", New EventHandler(AddressOf ToggleBlockNum)))

            mobContextMenu.MenuItems.Add(New MenuItem("Toggle ScreenLock", New EventHandler(AddressOf ToggleScreenLock)))

            mobContextMenu.MenuItems.Add("-")

            mobContextMenu.MenuItems.Add(New MenuItem("About", New EventHandler(AddressOf AboutBox)))

            mobContextMenu.MenuItems.Add(New MenuItem("Exit", New EventHandler(AddressOf ExitApp)))

        Catch obEx As Exception
            Throw obEx
        End Try
    End Sub

    Public Sub ToggleCAPS()

    End Sub

    Public Sub ToggleBlockNUM()

    End Sub

    Public Sub ToggleScreenLock()

    End Sub

    Public Sub AboutBox()

    End Sub

    Public Sub ExitApp()

    End Sub

    Sub Main()
        CreateMenu()

        With CAPSIcon
            .Icon =
        End With
    End Sub

End Module
