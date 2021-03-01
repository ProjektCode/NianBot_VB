Imports System.Runtime.InteropServices
Imports Discord.Commands
Imports Discord
Imports Discord.WebSocket


Module Master
    Public Class class_MasterClass
        Inherits ModuleBase
        Private rand As New Random

#Region "Random Color"
        Public Function randomEmbedColor()
            Dim colors() As Integer =
            {
                16711680, 'Red
                65280,    ' Green
                255,      ' Blue
                16777215, ' White
                10617087, ' Purple
                65535,    ' Light Blue
                16776960, ' Yellow
                16711935, ' Light Purple
                16751104, ' Orange
                16751586, ' Light Pink
                10682267, ' Light Green
                14423100, ' Crimson
                9055202,  ' Blue Violet
                15132410  ' Lavendar
            }

            Dim colorPicker As Integer = colors(rand.Next(0, colors.Length))
            Dim colour As UInteger = Convert.ToInt32(colorPicker)

            Return colour
        End Function
#End Region

#Region "Command Window Options"
        <DllImport("Kernel32.dll")>
        Public Shared Function GetConsoleWindow() As IntPtr

        End Function
        <DllImport("User32.dll")>
        Private Shared Function ShowWindow(hwd As IntPtr, cmdShow As Integer) As Boolean

        End Function

        Dim hwd As IntPtr = GetConsoleWindow()

        'Hides Window
        Public Function winHide()

            Return ShowWindow(hwd, 0)
        End Function


        Public Function winShow()

            Return ShowWindow(hwd, 1)
        End Function
#End Region

#Region "status"
        Public sList() As String = {
                "You hit me while I take your health | -help",
                "You struggle as I conquer the battlefield | -help",
                "My killcount go up from you feeding me | -help",
                "Ch'en in her sexy dress | -Help",
                "William being a cunt | -help",
                "Arknights is love, Arknights is life | -help",
                "Me being a beast | -help",
                "If anyone is gonna boost the server | -help",
                "Everyone masturbate to 2D Girls | -help",
                "Why no one is talking in this server | -help",
                "My Owner trying to debug me | -help",
                "How hot it is outside | -help"
             }
        Public sIndex As Integer = rand.Next(0, sList.Length)



#End Region

#Region "Misc"
        Public Function timeOut(g As SocketGuild)
            Dim afk As Integer = g.AFKTimeout
            Dim seconds As Integer = afk Mod 60
            Dim minutes As Integer = afk / 60
            Dim time As Integer = minutes
            Return time
        End Function
#End Region

    End Class
End Module