Imports Discord
Imports Discord.Commands
Imports Discord.WebSocket

Public Class cmd_purge
    Inherits ModuleBase(Of CommandContext)

    <Command("purge")>
    <RequireBotPermission(GuildPermission.ManageMessages)>
    Public Async Function purgeCmd(<Remainder> amount As Integer) As Task

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.ManageMessages Then
            If amount <= 0 Then
                Await ReplyAsync("The amount of messages to remove must be positive.")
                Return
            End If

            Dim messages = Await Context.Channel.GetMessagesAsync(Context.Message, Direction.Before, amount).FlattenAsync()
            Dim filteredMessages = messages.Where(Function(x) (DateTimeOffset.UtcNow - x.Timestamp).TotalDays <= 14)
            Dim count = filteredMessages.Count()

            If count = 0 Then
                Await ReplyAsync("Nothing to delete.")
            Else
                Await (TryCast(Context.Channel, ITextChannel)).DeleteMessagesAsync(filteredMessages)
                Await ReplyAsync($"I've done my job. {count} {(If(count > 1, "messages have", "message has"))} been annihilated.")
            End If

        Else
            Await Context.Message.Channel.SendMessageAsync("You do not have the required permissions to use this command.")

        End If

    End Function
End Class
