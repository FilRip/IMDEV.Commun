Public Class Logger

    Private _fichierLog As System.IO.StreamWriter
    Private _initLog As Boolean
    Private _nomEnCours As String
    Private _niveauEnCours As String
    Private Shared _instance As New Logger

    Public Shared Function getInstance() As Logger
        If (_instance Is Nothing) Then _instance = New Logger
        Return _instance
    End Function

    ''' <summary>
    ''' Niveau d'alerte du message a écrire dans le log
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum LOG_LEVEL
        INFO = 0
        WARNING = 1
        ERREURS = 2
        DEBUG = 3
    End Enum

    ''' <summary>
    ''' Retourne le nom/emplacement du fichier de log si il a déjà été initialisé/pret par LogCreerFichier
    ''' </summary>
    ''' <returns>Nom/emplacement du fichier de log en cours ou chaine vide si pas initialisé</returns>
    ''' <remarks></remarks>
    Public Function LogRetourneNomFichier() As String
        If (_initLog) Then Return _nomEnCours Else Return ""
    End Function

    ''' <summary>
    ''' Ferme le fichier de log (dévérouille le fichier en accès exclusif)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LogFermerLog()
        If (_initLog) Then
            _fichierLog.Close()
            _initLog = False
        End If
    End Sub

    ''' <summary>
    ''' Initialise le système de log, ouvre le fichier en création (ou en ajout si il existe déjà)
    ''' </summary>
    ''' <param name="nom">nom/emplacement du fichier de log</param>
    ''' <returns>True = Fichier ouvert et pret, sinon False (fichier inexistant ou déjà vérouillé par un autre processus)</returns>
    ''' <remarks></remarks>
    Public Function LogCreerFichier(ByVal nom As String, Optional ByVal sql As Boolean = False) As Boolean
        If ((nom = "") Or ((_initLog) And (nom <> _nomEnCours))) Then Return False
        Try
            If (_initLog And nom = _nomEnCours) Then Return True
            Dim sortiefichier As System.IO.FileStream
            If (IO.File.Exists(nom)) Then
                sortiefichier = New System.IO.FileStream(nom, IO.FileMode.Append)
            Else
                sortiefichier = New System.IO.FileStream(nom, IO.FileMode.Create)
            End If
            _fichierLog = New System.IO.StreamWriter(sortiefichier)
            _nomEnCours = nom
            _initLog = True
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Ajoute une ligne dans le log, la date/heure (et le niveau) est automatiquement ajoutée
    ''' </summary>
    ''' <param name="ligne">Contenu chaine a écrire dans le log</param>
    ''' <param name="niveau">Niveau de ce message</param>
    ''' <remarks></remarks>
    Public Sub LogEcrire(ByVal ligne As String, Optional ByVal niveau As LOG_LEVEL = LOG_LEVEL.INFO)
        If (_initLog) Then
            If (aLogger(niveau)) Then
                _fichierLog.WriteLine(Now().ToString & " | " & niveau.ToString & " : " & ligne)
                _fichierLog.Flush()
            End If
        End If
    End Sub

    Private Function aLogger(ByVal niveau As LOG_LEVEL) As Boolean
        If ((_niveauEnCours & ",").LastIndexOf("," & niveau & ",") > -1) Then Return True
        Return False
    End Function

    ''' <summary>
    ''' Donne la liste des niveaux actuellement loggé par le système
    ''' </summary>
    ''' <value></value>
    ''' <returns>Liste des niveaux, séparés par des virgules</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ListeNiveauDeLog() As String
        Get
            Return _niveauEnCours
        End Get
    End Property

    ''' <summary>
    ''' Ajoute un niveau a logger a partir de maintenant
    ''' </summary>
    ''' <param name="niveau">Numéro du niveau a logger</param>
    ''' <remarks></remarks>
    Public Sub ajouteUnNiveauALogger(ByVal niveau As LOG_LEVEL)
        _niveauEnCours &= "," & niveau.ToString
    End Sub

End Class
