Public Class mainForm

    Dim timedTache As IMDEV.Threading.ThreadPoolManager
    Dim stackWorker As IMDEV.Threading.ThreadStack.threadStack
    Dim nbTacheEmpilee As Integer

#Region "delegate"

    Delegate Sub delegateAjoutTexte(ByVal texte As String)
    Private Sub ajoutTexte(ByVal texte As String)
        RichTextBox1.AppendText(texte)
    End Sub
    Private Sub invokeAjoutTexte(ByVal texte As String)
        Me.Invoke(New delegateAjoutTexte(AddressOf ajoutTexte), texte)
    End Sub

#End Region

#Region "Multi timed task"

    Private Sub btnStartThreads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartThreads.Click
        timedTache = New IMDEV.Threading.ThreadPoolManager()
        timedTache.addJob(AddressOf threadCallBack, 1, 1000)
        timedTache.addJob(AddressOf threadCallBack, 2, 500, 1000)
    End Sub

    Private Sub threadCallBack(ByVal param As Object)
        invokeAjoutTexte("Thread " & param.ToString() & " callback" & vbCrLf)
    End Sub

    Private Sub btnStopThreads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopThreads.Click
        timedTache.stopAllJobs()
    End Sub

    Private Sub btnNbThread_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNbThread.Click
        RichTextBox1.AppendText("Nb threads : " & timedTache.nbThreads.ToString() & vbCrLf)
    End Sub

#End Region

#Region "Programmation parallele"

    Private Sub btnForSequentiel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForSequentiel.Click
        RichTextBox1.Clear()
        Dim t As Long
        Dim temp As Double
        t = Now.Ticks
        For i = 1 To 1000
            temp = i + New Random(Now.Millisecond).Next(i) + Math.Asin(New Random(Now.Millisecond).Next(360))
            temp = temp - i
            temp = temp * Math.Sin(New Random(Now.Millisecond).Next(360))
            Threading.Thread.Sleep(1)
            'RichTextBox1.AppendText("Boucle " & i.ToString() & vbCrLf)
        Next
        RichTextBox1.AppendText("Temps seq. : " & (Now.Ticks - t).ToString() & vbCrLf)
    End Sub

    Private Sub btnForParallele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForParallele.Click
        RichTextBox1.Clear()
        Dim t As Long
        t = Now.Ticks
        ParallelTasks.Parallel.For(0, 1000, AddressOf iteration)
        RichTextBox1.AppendText("Temps parallel : " & (Now.Ticks - t).ToString() & vbCrLf)
    End Sub

    Private Sub iteration(ByVal i As Integer)
        Dim temp As Double
        temp = i + New Random(Now.Millisecond).Next(i) + Math.Asin(New Random(Now.Millisecond).Next(360))
        temp = temp - i
        temp = temp * Math.Sin(New Random(Now.Millisecond).Next(360))
        Threading.Thread.Sleep(1)
        'invokeAjoutTexte("Boucle " & i.ToString() & vbCrLf)
    End Sub

#End Region

#Region "Taches empilées"

    Private Sub btnEmpileTache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpileTache.Click
        If (stackWorker Is Nothing) Then
            stackWorker = New IMDEV.Threading.ThreadStack.threadStack()
        End If
        Dim maTache As IMDEV.Threading.ThreadStack.aTask
        Dim args As New Hashtable
        nbTacheEmpilee += 1
        args.Add("num", nbTacheEmpilee)
        maTache = New IMDEV.Threading.ThreadStack.aTask()
        maTache.doWorkHandler = AddressOf callBackTacheEmpilee
        maTache.runCompletedHandler = AddressOf TerminateTacheEmpilee
        maTache.arguments = args
        stackWorker.addTask(maTache)
    End Sub

    Private Sub callBackTacheEmpilee(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        invokeAjoutTexte("Traite tache empilee num : " & e.Argument.item("num") & vbCrLf)
        For i As Integer = 0 To 10000
            invokeAjoutTexte("Tache " & e.Argument.item("num").ToString() & " it : " & i.ToString() & vbCrLf)
        Next
        e.Result = e.Argument.item("num")
    End Sub

    Private Sub TerminateTacheEmpilee(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ajoutTexte("Tache empilee " & e.Result.ToString() & " terminee" & vbCrLf)
    End Sub

    Private Sub btnNbTacheEmpilee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNbTacheEmpilee.Click
        If (stackWorker IsNot Nothing) Then
            ajoutTexte("Nombre de tache en attente : " & stackWorker.nbTasks.ToString() & vbCrLf)
        End If
    End Sub

#End Region

End Class
