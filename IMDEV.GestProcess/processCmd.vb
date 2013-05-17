Public Class processCmd

    Public Shared Function executeEtRetourne(ByVal filename As String, Optional ByVal param As String = "") As String
        Dim retour As String = ""
        Dim p As New System.Diagnostics.Process

        p.StartInfo.RedirectStandardError = True
        p.StartInfo.RedirectStandardInput = True
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.FileName = filename
        p.StartInfo.Arguments = param
        p.StartInfo.UseShellExecute = False
        p.StartInfo.Verb = "Open"
        p.StartInfo.CreateNoWindow = True

        p.Start()

        Return p.StandardOutput.ReadToEnd()
    End Function

    Public Shared Sub executeEtBrancheSortie(ByVal filename As String, ByVal callBack As System.Diagnostics.DataReceivedEventHandler, Optional ByVal param As String = "")
        Dim p As New Process

        p.StartInfo.RedirectStandardError = True
        p.StartInfo.RedirectStandardInput = True
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.FileName = filename
        p.StartInfo.Arguments = param
        p.StartInfo.UseShellExecute = False
        p.StartInfo.Verb = "Open"
        p.StartInfo.CreateNoWindow = True

        AddHandler p.OutputDataReceived, callBack
        AddHandler p.ErrorDataReceived, callBack

        p.Start()
        p.BeginOutputReadLine()
        p.BeginErrorReadLine()
    End Sub

End Class
