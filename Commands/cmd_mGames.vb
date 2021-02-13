Imports Discord
Imports Discord.Commands

<Group("games")>
Public Class cmd_mGames
    Inherits ModuleBase(Of CommandContext)

#Region "war"
    <Command("war")>
    Public Async Function warCmd() As Task
        Dim user = Context.User
        Dim rand As New Random
        Dim botNum As Integer = rand.Next(1, 21)
        Dim userNum As Integer = rand.Next(1, 21)

        If userNum > botNum Then
            Await Context.Channel.SendMessageAsync($"{user.Mention} You win. My number was {botNum} and your number was {userNum}")

        Else
            If userNum = botNum Then
                Await Context.Channel.SendMessageAsync($"It would seem we have tied {user.Mention}. Our number was {userNum}")

            Else

                If userNum < botNum Then
                    Await Context.Channel.SendMessageAsync($"Looks like you are the loser {user.Mention}. My number was {botNum} and your number was {userNum}")

                End If
            End If
        End If

    End Function
#End Region

#Region "Random Number"
    <Command("rnum")>
    Public Async Function randomNum(<Remainder> num As Integer) As Task
        Dim user = Context.User
        Dim channel = Context.Channel
        Dim randNum As Integer
        Dim rand As New Random

        If num <= 1 Then
            Await channel.SendMessageAsync($"{user.Mention} the number you picked is less than or equal to 1. Please pick a number higher than 1.")
        Else
            randNum = rand.Next(1, num)

            Await channel.SendMessageAsync($"{user.Mention} the random number was {randNum}")
        End If

    End Function
#End Region

End Class
