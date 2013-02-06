Public Class unRetourRequete
    Inherits System.Data.DataSet

    Public ReadOnly Property nbLignes()
        Get
            Try
                Return Tables(0).Rows.Count
            Catch ex As Exception
            End Try
            Return -1
        End Get
    End Property

    Public ReadOnly Property nbColonnes()
        Get
            Try
                Return Tables(0).Columns.Count
            Catch ex As Exception
            End Try
            Return -1
        End Get
    End Property

    Public Function recherche(ByVal contenu As String, Optional ByVal startLigne As Integer = 0) As Integer
        If ((startLigne > nbLignes - 1) Or (contenu = "")) Then Return -1
        For i = startLigne To nbLignes - 1
            For j = 0 To nbColonnes - 1
                Try
                    If (Tables(0).Rows(i).Item(j).ToString.LastIndexOf(contenu) >= 0) Then Return i
                Catch ex As Exception
                End Try
            Next
        Next
        Return -1
    End Function

End Class
