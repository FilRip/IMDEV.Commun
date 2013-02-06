Namespace models

    Public Class droitGlobalNTFS

        Private _proprietaire As String
        Private _listeDroit As List(Of droitNTFS)
        Private _groupeProprietaire As String

        Public Property groupeProprietaire() As String
            Get
                Return _groupeProprietaire
            End Get
            Set(ByVal value As String)
                _groupeProprietaire = value
            End Set
        End Property

        Public Property proprietaire() As String
            Get
                Return _proprietaire
            End Get
            Set(ByVal value As String)
                _proprietaire = value
            End Set
        End Property

        Public Property listeDroit() As List(Of droitNTFS)
            Get
                Return _listeDroit
            End Get
            Set(ByVal value As List(Of droitNTFS))
                _listeDroit = value
            End Set
        End Property

    End Class

End Namespace
