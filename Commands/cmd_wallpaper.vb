Imports Discord
Imports Discord.Commands


<Group("wall")>
Public Class cmd_wallpaper
    Inherits ModuleBase(Of CommandContext)
    Dim wall As New class_Wallpapers
    Dim masterClass As New class_MasterClass

    <Command("search")>
    <Summary("Gives a link of wallpapers with your chosen keyword")>
    Public Async Function wallpaperCmd(<Remainder> text As String) As Task

        Dim t_Text As String = Replace(text, " ", "+")
        Await Context.Channel.SendMessageAsync(wall.getSite + t_Text)

    End Function

    <Command("rwall")>
    <Summary("Gives a random wallpaper link with a random keyword")>
    Public Async Function randomWallpaperCmd() As Task
        Dim Text As String = Replace(wall.getWord, " ", "+")
        Await Context.Channel.SendMessageAsync(wall.getSite + Text)
    End Function

    <Command("host")>
    <Summary("Sends a random image from the hosts' computer")>
    Public Async Function cmdImage() As Task
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild
        Dim c = Context.Client

        Dim rnd As New Random
        Dim jpg() As String = IO.Directory.GetFiles(wall.path, "*.jpg", IO.SearchOption.TopDirectoryOnly)
        Dim png() As String = IO.Directory.GetFiles(wall.path, "*.png", IO.SearchOption.TopDirectoryOnly)
        Dim allImages() As String = jpg.Union(png).ToArray()
        Dim image As String = allImages(rnd.Next(0, allImages.Count - 1))

        Await m.Channel.SendFileAsync(image)
    End Function

    <Command("list")>
    <Summary("Gives a list of all of our keywords for our wallpaper command")>
    Public Async Function cmdList() As Task 'Make it so once the field gets full create a new field.
        Dim m = Context.Message
        Dim u = Context.User
        Dim g = Context.Guild
        Dim c = Context.Client

        Dim embed As New EmbedBuilder With {
            .Title = $"Wallpaper keyword list",
            .ImageUrl = "https://i.imgur.com/vc241Ku.jpeg",
            .Description = "The full list of keywords in our random wallpaper list",
            .Color = New Color(masterClass.randomEmbedColor),
            .ThumbnailUrl = g.IconUrl,
            .Timestamp = Context.Message.Timestamp,
            .Footer = New EmbedFooterBuilder With {
                    .Text = "Keyword Data",
                    .IconUrl = g.IconUrl
                }
            }

        Dim row As Integer = 0
        Dim words As String = String.Empty

        For Each keyword As String In wall.keywords
            'If appending the keyword to the list of words exceeds 256
            'don't append, but instead add the existing words to a field.
            If words.Length + keyword.Length + 7 > 256 Then
                row += 1
                embed.AddField($"List #{row}", words) 'Add words to field

                'reset words
                words = String.Empty
            End If

            words = words + keyword + " **|** "
        Next

        'The add condition within the for loop is only entered when we are
        'about to exceed to field length. Any string under the max 
        'length would exit the loop without being added. Add it here
        embed.AddField($"List #{row + 1}", words)

        Await m.Channel.SendMessageAsync("", False, embed.Build())
    End Function

End Class
