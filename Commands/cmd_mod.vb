Imports Discord.Commands
Imports Discord
Imports Discord.WebSocket

<Group("mod")>
Public Class cmd_mod
    Inherits ModuleBase
    Dim masterClass As New class_MasterClass

    <Command("kick")>
    <RequireBotPermission(GuildPermission.KickMembers)>
    Public Async Function kick(ByVal user As SocketGuildUser, <Remainder> ByVal reason As String) As Task
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild
        Dim c = Context.Channel

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.KickMembers Then
            Dim embed As New EmbedBuilder With {
                .Author = New EmbedAuthorBuilder With {
                .IconUrl = u.GetAvatarUrl,
                .Name = u.Username
            },
            .Title = $"{user.Username}'s Kick Information",
            .ImageUrl = "https://i.imgur.com/vc241Ku.jpeg",
            .Description = "Please make sure you follow the rules next time.",
            .Color = New Color(masterClass.randomEmbedColor),
            .ThumbnailUrl = user.GetAvatarUrl,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "Kick Data",
                    .IconUrl = g.IconUrl
                }
            }
            embed.AddField("Nickname", user.Nickname)
            embed.AddField("Reason", reason)
            embed.AddField("Time of kick", m.Timestamp)

            Await user.SendMessageAsync("", False, embed.Build())
            Await c.SendMessageAsync("", False, embed.Build())
            Await user.KickAsync(reason)

        Else
            Await c.SendMessageAsync("You do not have the required permissions to use this command.")

        End If

    End Function

    <Command("ban")>
    <RequireBotPermission(GuildPermission.BanMembers)>
    Public Async Function ban(ByVal user As IGuildUser, <Remainder> ByVal reason As String) As Task
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild

        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.BanMembers Then
            Dim embed As New EmbedBuilder With {
                .Author = New EmbedAuthorBuilder With {
                .IconUrl = u.GetAvatarUrl,
                .Name = u.Username
            },
            .Title = $"{user.Username}'s Ban Information",
            .ImageUrl = "https://i.imgur.com/vc241Ku.jpeg",
            .Description = "Please make sure you follow the rules next time.",
            .Color = New Color(masterClass.randomEmbedColor),
            .ThumbnailUrl = user.GetAvatarUrl,
            .Timestamp = m.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "Ban Data",
                    .IconUrl = g.IconUrl
                }
            }

            embed.AddField("Reason", reason)
            embed.AddField("Reason", reason)
            embed.AddField("Time of ban", m.Timestamp)

            Await user.SendMessageAsync("", False, embed.Build())
            Await Context.Channel.SendMessageAsync("", False, embed.Build())
            Await user.BanAsync(reason)
        Else

            Await Context.Channel.SendMessageAsync("You do not have the required permissions for this command.")

        End If

    End Function

End Class
