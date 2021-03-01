Imports Discord
Imports Discord.Commands
Imports Microsoft.VisualBasic.ApplicationServices

<Group("math")>
Public Class cmd_math
    Inherits ModuleBase(Of CommandContext)

#Region "Add"

    <Command("add")>
    Public Async Function cmdAdd(ByVal num1 As Integer, <Remainder> ByVal num2 As Integer) As Task

        Dim sum = num1 + num2
        Dim user = Context.User
        Dim channel = Context.Channel

        Await channel.SendMessageAsync($"{user.Mention} the sum of the two specified numbers are {sum}")

    End Function

#End Region

#Region "Subtract"

    <Command("sub")>
    Public Async Function cmdSub(ByVal num1 As Integer, <Remainder> ByVal num2 As Integer) As Task

        Dim sum = num1 - num2
        Dim user = Context.User
        Dim channel = Context.Channel

        Await channel.SendMessageAsync($"{user.Mention} the sum of the two specified numbers are {sum}")

    End Function

#End Region

#Region "Multiply"

    <Command("multi")>
    Public Async Function cmdMulti(ByVal num1 As Integer, <Remainder> ByVal num2 As Integer) As Task

        Dim sum = num1 * num2
        Dim user = Context.User
        Dim channel = Context.Channel

        Await channel.SendMessageAsync($"{user.Mention} the sum of the two specified numbers are {sum}")

    End Function

#End Region

#Region "Divide"

    <Command("divide")>
    Public Async Function cmdDivide(num1 As Integer, <Remainder> num2 As Integer) As Task

        Dim sum = num1 / num2
        Dim user = Context.User
        Dim channel = Context.Channel

        Await channel.SendMessageAsync($"{user.Mention} the sum of the two specified numbers are {sum}")

    End Function

#End Region

End Class
