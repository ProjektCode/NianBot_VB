Imports System.IO
Imports Newtonsoft.Json

Public Class MasterConfig
    Public ReadOnly Property token As String
    Public ReadOnly Property prefix As String

    <JsonIgnore> Private Shared Filename As String = "config.json"

    <JsonConstructor>
    Public Sub New(Token As String, Prefix As String)
        Me.token = Token
        Me.prefix = Prefix
    End Sub


    Public Shared Function Load() As MasterConfig
        If File.Exists(Filename) Then
            Dim Json As String = File.ReadAllText(Filename)
            Return JsonConvert.DeserializeObject(Of MasterConfig)(Json)

        End If
        Return Create()
    End Function

    Private Shared Function Create() As MasterConfig
        Dim RawToken As String = Nothing
        Dim RawPrefix As String = Nothing

        Do While String.IsNullOrEmpty(RawToken)
            Console.Write("Enter Token: ")
            RawToken = Console.ReadLine
        Loop
        Do While String.IsNullOrEmpty(RawPrefix)
            Console.Write("Enter Prefix: ")
            RawPrefix = Console.ReadLine
        Loop



        Dim Config As New MasterConfig(RawToken, RawPrefix)
        Config.Save()
        Return Config
    End Function

    Private Sub Save()
        Dim Json As String = JsonConvert.SerializeObject(Me, Formatting.Indented)
        File.WriteAllText(Filename, Json)
    End Sub

End Class
