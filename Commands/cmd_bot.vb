Imports Discord.Commands
Imports Discord.WebSocket

<Group("bot")>
Public Class cmd_bot
    Inherits ModuleBase(Of CommandContext)

    ReadOnly masterClass As New class_MasterClass

    <Command("hide")>
    Public Async Function cmdHide() As Task

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.Administrator Then
            masterClass.winHide()

            Await Context.Channel.SendMessageAsync("Why you trying to hide me?")
        Else
            Await Context.Channel.SendMessageAsync("This is only for the bot owner.")

        End If

    End Function

    <Command("show")>
    Public Async Function cmdShow() As Task
        Dim user = Context.User

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.Administrator Then
            masterClass.winShow()

            Await Context.Channel.SendMessageAsync($"HA {user.Mention} I have returned.")
        Else
            Await Context.Channel.SendMessageAsync("This is only for the bot owner.")

        End If

    End Function

    <Command("kill")>
    Public Async Function cmdKill() As Task

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.Administrator Then

            For Each p As Process In Process.GetProcesses
                If p.ProcessName = "NianBot" Then
                    Await Context.Channel.SendMessageAsync("Looks like it's my break time.")
                    Try
                        p.Kill()
                    Catch ex As Exception
                        Continue For
                    End Try
                End If
            Next

        End If

    End Function

End Class
