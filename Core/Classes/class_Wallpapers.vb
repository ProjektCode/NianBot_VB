Public Class class_Wallpapers
    Private rand As New Random

#Region "Keywords"

    Public keywords() As String =
    {
    "anime",
    "league of legends",
    "valorant",
    "payday",
    "demon slayer",
    "game",
    "halo",
    "code geass",
    "japan",
    "minecraft",
    "basketball",
    "2b",
    "tohru",
    "lenn",
    "purge",
    "gun",
    "mecha",
    "dishonored",
    "rainbow six siege",
    "computers",
    "flowers",
    "tiger",
    "women",
    "men",
    "crossover",
    "kill la kill",
    "sinoalice",
    "arknights",
    "girls frontline",
    "memes",
    "honkai impact",
    "Logitech",
    "Corsair",
    "video games",
    "Zelda",
    "Princess Link",
    "Tracer",
    "Widowmaker",
    "Neeko",
    "NZXT",
    "minimalist",
    "minimalistic anime",
    "logo",
    "anime crossover",
    "robots",
    "rimuru",
    "c.c.",
    "ryuko",
    "ryuuko",
    "waifu",
    "rave",
    "cyberpunk",
    "cyber punk",
    "amd",
    "intel",
    "rtx",
    "gtx",
    "weapons",
    "genshin impact",
    "klee",
    "genshin impact jean",
    "genshin impact mona",
    "genshin impact lisa",
    "genshin impact Keqing",
    "genshin impact klee",
    "glorious",
    "keyboard",
    "keyboard switches",
    "escape front tarkov"
    }

    Public Function getWord()
        Dim word As String = Keywords(rand.Next(0, Keywords.Length))

        Return word
    End Function

#End Region

#Region "Websites"

    Public Function getSite()
        Dim sites As String() =
    {
        "https://wall.alphacoders.com/search.php?search=",
        "https://wallhaven.cc/search?q=",
        "https://wallpaperscraft.com/search/?query=",
        "https://www.pixiv.net/en/tags/",
        "https://www.artstation.com/search?q=",
        "https://wallpaperaccess.com/search?q=",
        "https://wallpaperplay.com/search?term=",
        "https://wallpapercave.com/search?q=",
        "https://www.wallpaperflare.com/search?wallpaper=",
        "https://www.wallpapermaiden.com/search?term="
    }


        Dim website As String = sites(rand.Next(0, sites.Length))

        Return website
    End Function
#End Region

#Region "Misc"

    Public path As String = "D:\Adobe Files\Photoshop Files\Pictures\"
#End Region

End Class
