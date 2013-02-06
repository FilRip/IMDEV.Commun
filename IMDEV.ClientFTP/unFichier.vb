Public Class unFichier

    Public Enum TYPE_FICHIER
        TYPE_FICHIER = 0
        TYPE_DOSSIER = 1
    End Enum

    Private _nom As String
    Private _extension As String
    Private _taille As Long
    Private _dateModif As DateTime
    Private _dateCreation As DateTime
    Private _dateDernierAcces As DateTime
    Private _type As TYPE_FICHIER
    Private _droit As Integer
    Private _attribut As System.IO.FileAttributes

    ''' <summary>
    ''' Retourne le répertoire ou est stocké ce fichier, si la propriété "nom" contient aussi le répertoire
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property repertoire() As String
        Get
            Return IO.Path.GetFullPath(_nom)
        End Get
    End Property

    ''' <summary>
    ''' Retourne uniquement l'extension du fichier
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property extension()
        Get
            Return IO.Path.GetExtension(_nom)
        End Get
    End Property

    ''' <summary>
    ''' Retourne ou défini les attributs de ce fichier
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property attribut() As System.IO.FileAttributes
        Get
            Return _attribut
        End Get
        Set(ByVal value As System.IO.FileAttributes)
            _attribut = value
        End Set
    End Property

    ''' <summary>
    ''' Lire les infos sur un fichier physique
    ''' Lit : la taille, les dates, les attributs
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function lireInfo() As Boolean
        Dim fs As IO.FileInfo
        Try
            fs = New IO.FileInfo(_nom)
            _attribut = fs.Attributes
            _taille = fs.Length
            _datecreation = fs.CreationTimeUtc
            _datemodif = fs.LastWriteTimeUtc
            _dateDernierAcces = fs.LastAccessTimeUtc
            Return True
        Catch ex As Exception
        Finally
            fs = Nothing
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Ecrire les infos sur le fichier physique
    ''' Ecrit : les dates, les attributs
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ecrireInfo() As Boolean
        Dim fs As IO.FileInfo
        Try
            fs = New IO.FileInfo(_nom)
            fs.Attributes = _attribut
            fs.CreationTimeUtc = _datecreation
            fs.LastWriteTimeUtc = _datemodif
            fs.LastAccessTimeUtc = _dateDernierAcces
            Return True
        Catch ex As Exception
        Finally
            fs = Nothing
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Retourne le nom du fichier
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property nomFichier() As String
        Get
            Return IO.Path.GetFileName(_nom)
        End Get
    End Property

    ''' <summary>
    ''' Nom complet, avec répertoire au besoin
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property nomComplet() As String
        Get
            Return _nom
        End Get
        Set(ByVal value As String)
            _nom = value
        End Set
    End Property

    ''' <summary>
    ''' Date de la dernière modification du fichier
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property dateModif() As DateTime
        Get
            Return _datemodif
        End Get
        Set(ByVal value As DateTime)
            _datemodif = value
        End Set
    End Property

    ''' <summary>
    ''' Date de création du fichier
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property dateCreation() As DateTime
        Get
            Return _datecreation
        End Get
        Set(ByVal value As DateTime)
            _datecreation = value
        End Set
    End Property

    ''' <summary>
    ''' Date du dernière accès à ce fichier
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property dateDernierAcces() As DateTime
        Get
            Return _dateDernierAcces
        End Get
        Set(ByVal value As DateTime)
            _dateDernierAcces = value
        End Set
    End Property

    ''' <summary>
    ''' Taille du fichier
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property taille() As Long
        Get
            Return _taille
        End Get
        Set(ByVal value As Long)
            _taille = value
        End Set
    End Property

    ''' <summary>
    ''' Type, si c'est un fichier ou un dossier
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property type() As TYPE_FICHIER
        Get
            Return _type
        End Get
        Set(ByVal value As TYPE_FICHIER)
            _type = value
        End Set
    End Property

    ''' <summary>
    ''' Renomme le fichier
    ''' </summary>
    ''' <param name="nouveauNom">Nouveau nom avec emplacement au besoin</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function renomme(ByVal nouveauNom As String) As Boolean
        Try
            IO.File.Move(_nom, nouveauNom)
            _nom = nouveauNom
            Return True
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Efface ce fichier
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Cet objet doit etre supprimé du coup après</remarks>
    Public Function efface() As Boolean
        Try
            IO.File.Delete(_nom)
            Return True
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Copier le fichier dans un autre emplacement
    ''' </summary>
    ''' <param name="destination">Destination de la copie, avec emplacement</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function copier(ByVal destination As String) As unFichier
        ' TODO : Gérer la copie d'un dossier
        Try
            If ((IO.Path.GetFullPath(destination) = repertoire) And (IO.Path.GetFileName(destination) = nomFichier)) Then Return Nothing

            If (Not (IO.Directory.Exists(IO.Path.GetFullPath(destination)))) Then
                If (IO.Directory.CreateDirectory(IO.Path.GetFullPath(destination)) Is Nothing) Then Return Nothing
            End If
            If (_type = TYPE_FICHIER.TYPE_DOSSIER) Then
                Dim liste As New List(Of unFichier)
                Dim f As unFichier

                For Each n As String In IO.Directory.GetFileSystemEntries(_nom)
                    f = New unFichier
                    f.nomComplet = n
                    ' TODO : Les sous dossiers ne sont pas gérés, sont remis à la racine du coup
                    ' il faut réussir a dissocier les sous dossiers a copier des sous dossiers parent de l'emplacement a copier
                    If (f.copier(destination) Is Nothing) Then Return Nothing
                Next
            Else
                IO.File.Copy(_nom, destination)
                Dim f As New unFichier
                f.attribut = _attribut
                f.dateCreation = _dateCreation
                f.dateDernierAcces = _dateDernierAcces
                f.dateModif = _dateModif
                f.nomComplet = destination
                f.taille = _taille
                f.type = _type
                Return f
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

End Class
