Imports Discord.Commands
Imports Discord
Imports Discord.WebSocket

Public Class cmd_nick 'Command currently not working figure out why
    Inherits ModuleBase(Of CommandContext)

    <Command("nick")>
    <RequireBotPermission(GuildPermission.ManageNicknames)>
    Public Async Function nick(ByVal user As SocketGuildUser, <Remainder> n As String) As Task
        Dim m = Context.Message.Channel

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.ChangeNickname Then
            If user IsNot Context.Message.Author Or user Is Nothing Then
                user = Context.Message.Author
                Await user.ModifyAsync(Sub(u) u.Nickname = n)
                Await m.SendMessageAsync($"{user.Mention}'s Nickname has been changed.")
            Else
                Await user.ModifyAsync(Sub(u) u.Nickname = n)
                Await m.SendMessageAsync($"{user.Mention}'s Nickname has been changed.")

            End If
        End If

    End Function

End Class
