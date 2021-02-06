Imports Discord
Imports Discord.Commands
Imports Discord.WebSocket

<Group("emotes")>
Public Class cmd_emotes
    Inherits ModuleBase(Of CommandContext)
    Dim masterClass As New class_MasterClass
    Private ReadOnly _client As New DiscordSocketClient

    <Command("all")>
    <Summary("All guild emotes")>
    Public Async Function guildEmotesCmd() As Task
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild
        Dim c = Context.Client

        Dim embed As New EmbedBuilder With {
            .Title = $"All guild emotes for usage do :EmoteName:",
            .ImageUrl = "https://i.imgur.com/vc241Ku.jpeg",
            .Description = "The full list of our custom guild emotes",
            .Color = New Color(masterClass.randomEmbedColor),
            .ThumbnailUrl = g.IconUrl,
            .Timestamp = Context.Message.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "*Emote Data*",
                    .IconUrl = g.IconUrl
                }
            }


        Dim emotes As String = ""
        Dim row As Integer = 0
        For Each emote As Emote In DirectCast(Context.Message.Channel, IGuildChannel).Guild.Emotes
            If emotes.Length + emote.Name.Length + 5 > 256 Then
                row += 1
                embed.AddField($"List #{row}", emotes)

                emotes = String.Empty
            End If

            emotes = emotes + "<:" + emote.Name + $":{emote.Id}>" + $" **{emote.Name}**" + Environment.NewLine
        Next
        embed.AddField($"List #{row + 1}", emotes)

        Await Context.Message.Channel.SendMessageAsync("", False, embed.Build())

    End Function

    <Command("search")>
    Private Async Function cmdSearch(<Remainder> emojiName As Emote) As Task
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild
        Dim c = Context.Client




        Dim emote As Emote = DirectCast(Context.Message.Channel, IGuildChannel).Guild.Emotes
        If emote.Name = emojiName.Name Then
            Await m.Channel.SendMessageAsync(emote.Url)
        End If


        'Dim emote = _client.Guilds.SelectMany(Function(x) x.Emotes).FirstOrDefault(Function(x) _
        '           x.Name.IndexOf(text, StringComparison.OrdinalIgnoreCase) <> -1)

        'If emote Is Nothing Then
        '    Await m.Channel.SendMessageAsync("Not found")

        'Else
        '    Await m.Channel.SendMessageAsync(emote.Url)
        'End If


        'Dim emoji = Nothing
        'If Emote.TryParse(text, emoji) Then
        '    Await m.Channel.SendMessageAsync(emoji.Url)
        'End If

    End Function

End Class
