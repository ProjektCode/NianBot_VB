Imports Discord.Commands
Imports Discord

<Group("info")>
Public Class cmd_info 'Profile command not working. find out why
    Inherits ModuleBase(Of CommandContext)
    Dim masterClass As New class_MasterClass

    <Command("server")>
    Public Async Function serverCmd() As Task

        Dim g = Context.Guild
        Dim afk As Integer = g.AFKTimeout
        Dim seconds As Integer = afk Mod 60
        Dim minutes As Integer = afk / 60
        Dim time As Integer = minutes

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
                $"{time} minutes")


        Await Context.Channel.SendMessageAsync("", False, embed.Build())

    End Function

    <Command("profile")>
    Public Async Function profileCmd() As Task

        Dim guild = Context.Guild
        Dim user = Context.User

        Dim embed As New EmbedBuilder With {
            .Title = $"{user.Username}#{user.Discriminator}'s Profile",
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
                Context.User.Status)
        embed.AddField("Current Activity",
                user.Activity)
        embed.AddField("Avatar URL",
                    user.GetAvatarUrl)
        embed.AddField("Account Creation Date",
                user.CreatedAt)


        Await Context.Channel.SendMessageAsync("", False, embed.Build())

    End Function

End Class
