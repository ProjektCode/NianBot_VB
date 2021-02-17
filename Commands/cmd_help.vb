Imports Discord.Commands
Imports Discord
Imports Discord.WebSocket

Public Class cmd_help
    Inherits ModuleBase(Of CommandContext)
    Dim masterClass As New class_MasterClass

    <Command("help")>
    Public Async Function helpCmd() As Task

        Dim bot = Context.Client
        Dim guild = Context.Guild
        Dim message = Context.Message
        Dim user = Context.User


        Dim embed As New EmbedBuilder With {
            .Author = New EmbedAuthorBuilder With {
                .IconUrl = bot.CurrentUser.GetAvatarUrl,
                .Name = bot.CurrentUser.Username
            },
            .Title = "Help command",
            .ImageUrl = "https://i.imgur.com/9riedqy.png", 'Gifs do work for this
            .Description = "List of commands with their specific arguments if one or more is needed",
            .Color = New Color(masterClass.randomEmbedColor),
            .ThumbnailUrl = guild.IconUrl,
            .Timestamp = message.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                .Text = "Help Command Embed",
                .IconUrl = bot.CurrentUser.GetAvatarUrl
            }
        }
        embed.AddField("FUN COMMANDS",
                "List of commands everyone can use")
        embed.AddField("emotes",
                "ex) -emotes < Will give you a list of the servers custom emotes.")
        embed.AddField("meme",
                "ex) -meme rat < Sends an image of a rat as it calls you a rat(WIP). For a List -meme list")
        embed.AddField("nick",
                "ex) -nick @Yourself New NickName < This will change your nickname. Even though you could change it by just right clicking your name.(CURRENTLY NOT WORKING)")
        embed.AddField("MINI GAMES",
                "List a random mini game commands using -games <commandname>")
        embed.AddField("war",
                "ex) -games war < Play a game of war where you face the bot and who ever has the higher number wins. The number is random.")
        embed.AddField("rnum",
                "ex) -games rnum 100 < Gives you a random number from 1-100. 100 can be any number.")
        embed.AddField("MATH COMMANDS",
                "If you're too lazy to do math in your head or using a calculator here you go. The seperator is a space")
        embed.AddField("add",
                "ex) -math add 1 2 < Returns 3.")
        embed.AddField("sub",
                "ex) -math sub 1 2 < Returns 1.")
        embed.AddField("multi",
                "ex) -math multi 1 2 < Returns 2.")
        embed.AddField("divide",
                "ex) -math divide 6 3 < Returns 2.")
        embed.AddField("WALLPAPERS",
                "List of commands revolving around wallpapers.")
        embed.AddField("get",
                "ex) -wall get KEYWORD < Replace keyword with your seatch word and it will send back a link with that given word from a random list of website.")
        embed.AddField("rwall",
                "ex) -wall rwall < Will send you a random link with a random keyword from our keyword list.")
        embed.AddField("host",
                "ex) -wall host < this will send you a random image I have installed on my desktop. You get to see my sauce.")
        embed.AddField("list",
                "ex) -wall list < Coming soon but will give you a list of all our keywords. More than likely in a pastebin link.")
        embed.AddField("INFO COMMANDS",
                "List of commands where you could get information about certain things.")
        embed.AddField("server",
                "ex) -info server < This gives you some information about our server.")
        embed.AddField("profile(NOT CURRENTLY WORKING)",
                "ex) -info profile < This gives some information about your discord profile.")
        embed.AddField("SHOP(COMING SOON)",
                "This will give you some links to certain websites our mods and admins go to get stuff.")
        embed.AddField("List",
                "ex) -info list < This will gie you a complete list of where we get certain things. If you wish to add something talk to a mod or admin.")
        embed.AddField("clothes(COMING SOON)",
                "ex) -info clothes <It will asks you if you want anime clothes or streetwear and then give you a list of websites.")
        embed.AddField("Figures & Posters(COMING SOON)",
                "ex) -info fp < Asks you some questions and gives you some links based on your answers.")
        embed.AddField("games",
                "ex) -info games < Gives you some links where you could get games cheaper from trustworthy websites(Sites used by our admins or mods and tested.)")

        Await message.Author.SendMessageAsync("", False, embed.Build())



        If DirectCast(Context.Message.Author, SocketGuildUser).GuildPermissions.KickMembers Then
            Dim e2 As New EmbedBuilder With {
                .Title = "Mod commands",
            .ImageUrl = "https://i.imgur.com/9riedqy.png", 'Gifs do work for this
            .Description = "List of commands with their specific arguments if one or more is needed",
            .Color = New Color(masterClass.randomEmbedColor),
            .ThumbnailUrl = guild.IconUrl,
            .Timestamp = message.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                .Text = "Help Command Embed",
                .IconUrl = bot.CurrentUser.GetAvatarUrl
                    }
             }
            e2.AddField("purge",
                "ex) -purge 100 < Deletes x amount of images. Need Weeb God role for command. amount is 1-100.")
            e2.AddField("MOD GROUP",
                "This is a group of commands only for the mods.")
            e2.AddField("kick",
                "ex) -mod kick @user < This will kick the mentioned user.")
            e2.AddField("ban",
                "ex) -mod ban @user < This will ban the mentioned user.")

            Await message.Author.SendMessageAsync("", False, e2.Build())
        End If
    End Function

#Region "new help command"
    'Public Async Function test() As Task
    '    Dim commands As List(Of CommandInfo) = _cServer.Commands.ToList
    '    Dim embedBuilder As EmbedBuilder = New EmbedBuilder()

    '    For Each command As CommandInfo In commands
    '        Dim embedFieldAlias As String = If(command.Aliases, "No Alias available" & vbLf)
    '        embedBuilder.AddField(embedFieldAlias, "----------")
    '        Dim embedFieldText As String = If(command.Summary, "No description available" & vbLf)
    '        embedBuilder.AddField(command.Name, embedFieldText)
    '    Next

    '    Await ReplyAsync("Here's a list of commands and their description: ", False, embedBuilder.Build())
    'End Function
#End Region



End Class
