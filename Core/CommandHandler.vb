Imports System.Reflection
Imports System.Runtime.Remoting.Contexts
Imports System.Windows.Forms
Imports Discord
Imports Discord.Commands
Imports Discord.WebSocket

Public Class CommandHandler

    Private config As MasterConfig
    Private WithEvents client As DiscordSocketClient
    Private command As CommandService
    Private services As IServiceProvider

    Public Sub New(config As MasterConfig, client As DiscordSocketClient)

        Me.config = config
        Me.client = client

        Dim commandConfig As New CommandServiceConfig With {
            .DefaultRunMode = RunMode.Async,
            .LogLevel = LogSeverity.Error,
            .CaseSensitiveCommands = False
        }
        command = New CommandService(commandConfig)
        command.AddModulesAsync(Assembly.GetEntryAssembly(), services).GetAwaiter()


    End Sub

    Private Async Function ExecuteCommand(rawMessage As SocketMessage) As Task Handles client.MessageReceived
        Dim Message As IUserMessage = CType(rawMessage, IUserMessage)
        Dim Context = New SocketCommandContext(client, Message)

        If Message Is Nothing OrElse Message.Author.IsBot Then
            Return
        End If

        Dim argPos As Integer = 0

        If Not (Message.HasStringPrefix(config.prefix, argPos) OrElse Message.HasMentionPrefix(client.CurrentUser, argPos)) Then
            Return

        End If

        Dim commandContext As New CommandContext(client, Message)
        Dim commandResult As IResult = Await command.ExecuteAsync(commandContext, argPos, services)

        If Not commandResult.IsSuccess AndAlso commandResult.Error <> CommandError.UnknownCommand Then
            Await Context.Channel.SendMessageAsync(commandResult.ErrorReason)

        End If

    End Function



End Class
