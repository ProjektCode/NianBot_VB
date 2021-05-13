Imports Discord.Commands
Imports Discord.WebSocket

<Group("bot")>
Public Class cmd_bot
    Inherits ModuleBase(Of CommandContext)
    ReadOnly masterClass As New class_MasterClass

    <Command("hide")>
    Public Async Function cmdHide() As Task
        Dim author = Context.Message.Author
        If DirectCast(author, SocketGuildUser).GuildPermissions.Administrator Then
            If author.Id = 248876564698103810 Then
                masterClass.winHide()

                Await Context.Channel.SendMessageAsync("Why you trying to hide me?")
            Else
                Await Context.Channel.SendMessageAsync("This is only for the bot owner.")

            End If
        End If
    End Function

    <Command("show")>
    Public Async Function cmdShow() As Task
        Dim author = Context.Message.Author

        If DirectCast(author, SocketGuildUser).GuildPermissions.Administrator Then
            If author.Id = 248876564698103810 Then
                masterClass.winShow()

                Await Context.Channel.SendMessageAsync($"HA {author.Mention} I have returned.")
            Else
                Await Context.Channel.SendMessageAsync("This is only for the bot owner.")
            End If
        End If
    End Function

    <Command("kill")>
    Public Async Function cmdKill() As Task
        Dim author = Context.Message.Author
        If DirectCast(author, SocketGuildUser).GuildPermissions.Administrator Then
            If author.Id = 248876564698103810 Then
                For Each p As Process In Process.GetProcesses
                    If p.ProcessName = "NianBot" Then
                        Try
                            Await Context.Channel.SendMessageAsync("Looks like it's my break time.")
                            p.Kill()
                        Catch ex As Exception
                            Continue For
                        End Try
                    End If
                Next
            End If
        End If
    End Function
End Class
