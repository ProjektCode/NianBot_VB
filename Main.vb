Imports Discord
Imports Discord.WebSocket
Imports Discord.Net.Providers.WS4Net
Imports System.Threading

Module Main
    'Soon or later do a complete recode of your bot and Follow Anu6is bot tutorial.
    Private config As MasterConfig
    Private Client As DiscordSocketClient
    Private d_events As DiscordEvents
    Private commandHandle As CommandHandler
    Private t As Timer
    Private rand As New Random
    Dim mClass As New class_MasterClass

    Sub Main()
        RunBotASync.GetAwaiter.GetResult()
    End Sub

    Private Async Function RunBotASync() As Task
        Console.WriteLine("Now Loading Bot...")


        config = MasterConfig.Load

        Dim ClientConfig As New DiscordSocketConfig With {
           .DefaultRetryMode = Discord.RetryMode.AlwaysRetry,
            .LogLevel = LogSeverity.Info,
            .WebSocketProvider = WS4NetProvider.Instance
            }

        Client = New DiscordSocketClient(ClientConfig)
        d_events = New DiscordEvents(Client)
        commandHandle = New CommandHandler(config, Client)

        Await Client.LoginAsync(TokenType.Bot, config.token)
        Await Client.StartAsync()
        AddHandler Client.Ready, AddressOf Ready
        Await Task.Delay(Timeout.Infinite)
    End Function


    Private Function Ready() As Task 'Credit to Anu6is
        t = New Timer(Async Sub(__)
                          Await Client.SetGameAsync(mClass.sList.ElementAtOrDefault(mClass.sIndex), type:=ActivityType.Watching)
                          mClass.sIndex = If(mClass.sIndex + 1 = mClass.sList.Count, 0, mClass.sIndex + 1)
                      End Sub, Nothing, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(120))
        Return Task.CompletedTask
    End Function

End Module