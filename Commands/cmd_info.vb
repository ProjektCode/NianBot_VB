Imports Discord.Commands
Imports Discord

<Group("info")>
Public Class cmd_info
    Inherits ModuleBase(Of CommandContext)
    Dim masterClass As New class_MasterClass

    <Command("server")>
    Public Async Function serverCmd() As Task
        Dim g = Context.Guild


        Dim embed As New EmbedBuilder With {
            .Title = $"{g.Name}'s information",
            .ImageUrl = "https://i.imgur.com/vc241Ku.jpeg",
            .Description = "Server Info",
            .Color = New Color(masterClass.randomEmbedColor),
            .ThumbnailUrl = g.IconUrl,
            .Timestamp = Context.Message.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "Server Data",
                    .IconUrl = g.IconUrl
                }
            }

        embed.AddField("Server's Birthday",
                g.CreatedAt)
        embed.AddField("Server Avatar URL",
                g.IconUrl)
        embed.AddField("Preferred Locale",
                g.PreferredLocale)
        embed.AddField("AFK Timeout Time",
                $"{masterClass.timeOut(g)} minutes")

        Await Context.Channel.SendMessageAsync("", False, embed.Build())
    End Function

    <Command("profile")>
    Public Async Function profileCmd() As Task

        Dim guild = Context.Guild
        Dim user = Context.User
        Dim channel = Context.Channel

        Dim embed As New EmbedBuilder With {
            .Title = $"{user.Username}*#{user.Discriminator}* 's Profile",
            .ImageUrl = "https://i.imgur.com/vc241Ku.jpeg",
            .Description = "Your user profile",
            .Color = New Color(masterClass.randomEmbedColor),
            .ThumbnailUrl = user.GetAvatarUrl,
            .Timestamp = Context.Message.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "Profile Data",
                    .IconUrl = guild.IconUrl
                }
            }

        embed.AddField("Your ID(#)",
                user.Discriminator)
        embed.AddField("Current status",
                user.Status) 'Keeps saying status offline
        embed.AddField("Avatar URL",
                    user.GetAvatarUrl)
        embed.AddField("Account Creation Date",
                user.CreatedAt.DateTime)

        Await channel.SendMessageAsync("", False, embed.Build())
    End Function

End Class
