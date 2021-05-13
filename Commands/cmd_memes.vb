Imports Discord.Commands
Imports Discord.WebSocket

<Group("meme")>
Public Class cmd_memes
    Inherits ModuleBase(Of CommandContext)

    Dim path As String = "D:\_Programming\DiscordBots\Nian_Bot-vb\Memes\"
    Dim rand As New Random

    <Command("rat")>
    Public Async Function rat(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "rat.png"}", $"{user.Mention} you rat.")
    End Function

    <Command("smirk")>
    Public Async Function smirk(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "smirk.jpg"}", $"{user.Mention} Get Good Scrub.")
    End Function

    <Command("shrug")>
    Public Async Function shrug(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "shrug.gif"}", $"{user.Mention} IDGAF.")
    End Function

    <Command("lol")>
    Public Async Function lol(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "lol.gif"}", $"{user.Mention} HAHAHAHAHAHAHAHAHA.")
    End Function

    <Command("dead")>
    Public Async Function dead(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + $"dead.gif"}", $"{user.Mention} I'm Dead.")
    End Function

    <Command("win")>
    Public Async Function winner(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "winner.gif"}", $"{user.Mention} Winner Winner Chicken Dinner.")
    End Function

    <Command("rage")>
    Public Async Function rage() As Task
        Dim a = Context.Message.Author

        Dim g As String() =
                {
                $"{path}rage-1.gif",
                $"{path}rage-2.gif"
                }
        Dim gif = g(rand.Next(0, g.Length))
        Dim m As String() =
            {
            "FUUUUUCKKKKK",
            $"{a.Mention} has had enough of this shit.",
            $"{a.Mention} has raged quit this conversation"
            }
        Dim mes = m(rand.Next(0, m.Length))


        Dim send = Context.Channel
        Await send.SendFileAsync(gif, mes)
    End Function

    <Command("bang")>
    Public Async Function bang(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "lol.gif"}", $"{user.Mention} BANG! Now Know Your Place.")
    End Function

    <Command("fight")>
    Public Async Function fight(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "fight.gif"}", $"{user.Mention} Time To Throw Some Hands.")
    End Function

    <Command("ok")>
    Public Async Function ok(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "ok.gif"}", $"{user.Mention} Ok......")
    End Function

    <Command("nom")>
    Public Async Function nom(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "nom.gif"}", $"{user.Mention}..... Nom.")
    End Function

    <Command("die")>
    Public Async Function die(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "die.gif"}", $"{user.Mention} You Ready To Die?")
    End Function

    <Command("cry")>
    Public Async Function cry(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "cry.gif"}", $"{user.Mention} Cry Me A River.")
    End Function

    <Command("jerk")>
    Public Async Function jerk(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "jerk.gif"}", $"{user.Mention} You Getting Your Arm Ready?")
    End Function

    <Command("fab")>
    Public Async Function fab(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "fab.gif"}", $"{user.Mention} Is Fabulous.")
    End Function

    <Command("friends")>
    Public Async Function friends(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "friends.gif"}", $"{user.Mention} Which One Are We?.")
    End Function

    <Command("sad")>
    Public Async Function sad(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "sad.gif"}", $"{user.Mention} Sad Boi.")
    End Function

    <Command("list")>
    Public Async Function list() As Task
        Dim send = Context.Channel

        Await send.SendMessageAsync("Full List coming soon")
    End Function

    <Command("roast")>
    Public Async Function roast(user As SocketUser) As Task
        Dim send = Context.Channel
        Await send.SendFileAsync($"{path + "roast.gif"}", $"Unforseen footage of {user.Mention}")
    End Function

End Class
