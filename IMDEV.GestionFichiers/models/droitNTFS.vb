Namespace models

    Public Class droitNTFS

        Private _nom As String
        Private _emplacement As String
        Private _acces As System.Security.AccessControl.FileSystemRights
        Private _typeAcces As System.Security.AccessControl.AccessControlType
        Private _typeEmplacement As TYPE_FICHIER
        Private _droitHerite As Boolean

        Public Enum TYPE_FICHIER
            FICHIER
            REPERTOIRE
        End Enum

        Public Property nom() As String
            Get
                Return _nom
            End Get
            Set(ByVal value As String)
                _nom = value
            End Set
        End Property

        Public Property acces() As System.Security.AccessControl.FileSystemRights
            Get
                Return _acces
            End Get
            Set(ByVal value As System.Security.AccessControl.FileSystemRights)
                _acces = value
            End Set
        End Property

        Public Property typeAcces() As System.Security.AccessControl.AccessControlType
            Get
                Return _typeAcces
            End Get
            Set(ByVal value As System.Security.AccessControl.AccessControlType)
                _typeAcces = value
            End Set
        End Property

        Public Property emplacement() As String
            Get
                Return _emplacement
            End Get
            Set(ByVal value As String)
                _emplacement = value
            End Set
        End Property

        Public Function sauve() As Boolean
            ' TODO Sauve les nouveaux droits de cet utilisateur
        End Function

        Public Property typeEmplacement() As TYPE_FICHIER
            Get
                Return _typeEmplacement
            End Get
            Set(ByVal value As TYPE_FICHIER)
                _typeEmplacement = value
            End Set
        End Property

        Public Property estDroitHerite() As Boolean
            Get
                Return _droitHerite
            End Get
            Set(ByVal value As Boolean)
                _droitHerite = value
            End Set
        End Property

    End Class

End Namespace
