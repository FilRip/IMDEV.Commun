Public Class gestionProcessus

    ''' <summary>
    ''' Teste si un processus est actuellement en mémoire/cours d'exécution
    ''' </summary>
    ''' <param name="nomprocessus">Nom du processus (généralement nom de l'EXE)</param>
    ''' <returns>True si au moins UNE instance du processus est en mémoire/cours d'exécution</returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessusEnMemoire(ByVal nomprocessus As String) As Boolean
        Dim ListeProcessus As System.Diagnostics.Process() = Process.GetProcesses
        Dim Processus As System.Diagnostics.Process

        For Each Processus In ListeProcessus
            If (LCase(Processus.ProcessName) = LCase(nomprocessus)) Then Return True
        Next
        Return False
    End Function

    ''' <summary>
    ''' Retourne le pointeur, type Process, d'un processus en mémoire/en cours d'exécution
    ''' </summary>
    ''' <param name="nomprocessus">Nom du processus (généralement nom de l'EXE)</param>
    ''' <returns>Objet de type Processus contenant/pointant sur le processus trouvé en mémoire</returns>
    ''' <remarks></remarks>
    Private Shared Function PointeurProcessusEnMemoire(ByVal nomprocessus As String) As Process
        Dim ListeProcessus As System.Diagnostics.Process() = Process.GetProcesses
        Dim Processus As System.Diagnostics.Process

        For Each Processus In ListeProcessus
            If (LCase(Processus.ProcessName) = LCase(nomprocessus)) Then Return Processus
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Force/stop un processus actuellement en mémoire
    ''' </summary>
    ''' <param name="nomprocessus">Nom du processus (généralement nom de l'EXE)</param>
    ''' <remarks></remarks>
    Public Shared Sub TuerProcessus(ByVal nomprocessus As String)
        Dim p As Process

        If (ProcessusEnMemoire(nomprocessus)) Then
            p = PointeurProcessusEnMemoire(nomprocessus)
            Try
                p.Kill()
            Catch ex As Exception
                Try
                    p.CloseMainWindow()
                Catch ex2 As Exception
                    ' Impossible de tuer l'application ?!
                    ' Attention au boucle infinie (tentative de tuer le processus indéfiniement
                End Try
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Exécute un programme, lance un processus
    ''' </summary>
    ''' <param name="nomfichier">Nom du processus à exécuter (généralement nom de l'EXE)</param>
    ''' <returns>True si le processus a pu être lancé, sinon False</returns>
    ''' <remarks></remarks>
    Public Shared Function LanceFichier(ByVal nomfichier As String, Optional ByVal parametres As String = "", Optional ByVal attendreFinExecution As Boolean = False) As Boolean
        Dim monProcess As Process = Nothing

        Try
            If ((nomfichier.StartsWith("http://")) Or (nomfichier.StartsWith("ftp://"))) Then
                Process.Start(nomfichier)
                Return True
            Else
                If (Not (IO.File.Exists(nomfichier))) Then Return False
                monProcess = New Process
                With monProcess
                    .StartInfo.FileName = nomfichier
                    .StartInfo.Arguments = parametres
                    .StartInfo.Verb = "Open"
                    .StartInfo.CreateNoWindow = True
                    .Start()
                    If (attendreFinExecution) Then .WaitForExit()
                End With
            End If
        Catch ex As Exception
            Return False
        Finally
            Try
                monProcess.Close()
            Catch ex As Exception
            End Try
            monProcess = Nothing
        End Try
        Return True
    End Function

End Class
