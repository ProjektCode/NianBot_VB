Imports Discord
Imports Discord.Commands
Imports Discord.WebSocket

<Group("t")>
<Summary("Tools for the server owners.")>
Public Class cmd_tools
    Inherits ModuleBase
    Dim mClass As New class_MasterClass


    <Command("image")>
    Private Async Function cmdImage() As Task
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild
        Dim b = Context.Client

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.Administrator Then
            Dim embed As New EmbedBuilder With {
                .Author = New EmbedAuthorBuilder With {
                .IconUrl = b.CurrentUser.GetAvatarUrl,
                .Name = b.CurrentUser.Username
            },
            .Title = $"Image Links",
            .Color = New Discord.Color(mClass.randomEmbedColor),
            .ThumbnailUrl = u.GetAvatarUrl,
            .Timestamp = m.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "ID Data",
                    .IconUrl = g.IconUrl
                }
            }

            embed.AddField("SL God-Grin", "https://i.imgur.com/fVHOiXP.jpg")
            embed.AddField("C.C. Sailor-Moon", "https://i.imgur.com/7c1tLdF.jpg")
            embed.AddField("Guild Icon", "https://i.imgur.com/qOMRZ4S.jpg")
            embed.AddField("Rules Banner", "https://i.imgur.com/eiSyQxa.png ")
            embed.AddField("Announcement Banner", "https://i.imgur.com/P0VHn4v.png")
            embed.AddField("Announcement Avatar", "https://i.imgur.com/qps60RV.png")
            embed.AddField("SL God-Chair", "https://i.imgur.com/GWFc2eX.png")

            Await Context.Message.Author.SendMessageAsync("", False, embed.Build())
        Else

            Await Context.Channel.SendMessageAsync("You do not have the required permissions for this command.")

        End If

    End Function

    <Command("id")>
    Public Async Function getId(ByVal user As IGuildUser) As Task
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.Administrator Then
            Dim embed As New EmbedBuilder With {
                .Author = New EmbedAuthorBuilder With {
                .IconUrl = u.GetAvatarUrl,
                .Name = u.Username
            },
            .Title = $"{user.Username}'s Id",
            .Color = New Discord.Color(mClass.randomEmbedColor),
            .ThumbnailUrl = user.GetAvatarUrl,
            .Timestamp = m.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "ID Data",
                    .IconUrl = g.IconUrl
                }
            }

            embed.AddField("ID", user.Id)

            Await Context.Message.Author.SendMessageAsync("", False, embed.Build())
        Else

            Await Context.Channel.SendMessageAsync("You do not have the required permissions for this command.")

        End If

    End Function

    <Command("embed")>
    Private Async Function cmdEmbed() As Task
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild
        Dim b = Context.Client

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.Administrator Then
            Dim embed As New EmbedBuilder With {
                .Author = New EmbedAuthorBuilder With {
                .IconUrl = b.CurrentUser.GetAvatarUrl,
                .Name = b.CurrentUser.Username
            },
            .Title = $"Embed Json",
            .Color = New Discord.Color(mClass.randomEmbedColor),
            .ThumbnailUrl = u.GetAvatarUrl,
            .Timestamp = m.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "ID Data",
                    .IconUrl = g.IconUrl
                }
            }
            embed.AddField("Base Embed", "https://hastebin.com/bupisimuni.json")
            embed.AddField("Announcement Embed", "https://hastebin.com/wipavedone.json")

            Await Context.Message.Author.SendMessageAsync("", False, embed.Build())
        Else

            Await Context.Channel.SendMessageAsync("You do not have the required permissions for this command.")

        End If

    End Function

    <Command("ids")>
    Private Async Function cmdIds() As Task
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild
        Dim b = Context.Client

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.Administrator Then
            Dim embed As New EmbedBuilder With {
                .Author = New EmbedAuthorBuilder With {
                .IconUrl = b.CurrentUser.GetAvatarUrl,
                .Name = b.CurrentUser.Username
            },
            .Title = $"Common IDs",
            .Color = New Discord.Color(mClass.randomEmbedColor),
            .ThumbnailUrl = u.GetAvatarUrl,
            .Timestamp = m.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "ID Data",
                    .IconUrl = g.IconUrl
                }
            }

            embed.AddField("MEMBERS", "----------")
            embed.AddField("Julian", "727762180555931718")
            embed.AddField("Leo", "248876564698103810")
            embed.AddField("William", "467186400484261890")
            embed.AddField("Harem King", "542438978301722644")
            embed.AddField("SERVER BOTS", "----------")
            embed.AddField("AniGame", "571027211407196161")
            embed.AddField("LaifuBot", "688202466315206661")
            embed.AddField("Rythm", "235088799074484224")
            embed.AddField("ServerStats", "458276816071950337")
            embed.AddField("ZeroTwo", "469610550159212554")
            embed.AddField("Nian", "464882353857101828")
            embed.AddField("Gawr Gura", "464229968717545473")

            Await Context.Message.Author.SendMessageAsync("", False, embed.Build())
        Else

            Await Context.Channel.SendMessageAsync("You do not have the required permissions for this command.")

        End If

    End Function

    <Command("format")>
    Private Async Function cmdFormat() As Task
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild
        Dim b = Context.Client

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.Administrator Then
            Dim embed As New EmbedBuilder With {
                .Author = New EmbedAuthorBuilder With {
                .IconUrl = b.CurrentUser.GetAvatarUrl,
                .Name = b.CurrentUser.Username
            },
            .Title = $"Format Help",
            .Color = New Discord.Color(mClass.randomEmbedColor),
            .ThumbnailUrl = u.GetAvatarUrl,
            .Timestamp = m.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "FORMAT INFORMATION",
                    .IconUrl = g.IconUrl
                }
            }
            embed.AddField("Website", "https://discohook.org/")
            embed.AddField("MENTIONS", "----------------")
            embed.AddField("User", "<@!user_id>")
            embed.AddField("Role", "<@&role_id>")
            embed.AddField("Channel", "<#channel_id>")
            embed.AddField("Emoji", "\:emojiname:")
            embed.AddField("TEXT FORMAT", "---------REMOVE SPACES-------")
            embed.AddField("FOR ANYTHING UNDERLINED", "You need the under score by pressing SHIFT + -")
            embed.AddField("Italics", "regular: * text * - underlined: _ _ * text * _ _")
            embed.AddField("Bold", "regular: * * text * * - underlined: _ _ * * text * * _ _")
            embed.AddField("Bold Italics", "regular: * * * text * * * - underlined: _ _ * * * text * * * _ _")
            embed.AddField("Underlined", "regular: _ _ text _ _ - strikethough: ~ ~ text ~ ~")
            embed.AddField("Spoiler", "regular: | | text | |")

            Await Context.Message.Author.SendMessageAsync("", False, embed.Build())
        Else

            Await Context.Channel.SendMessageAsync("You do not have the required permissions for this command.")

        End If
    End Function

End Class
