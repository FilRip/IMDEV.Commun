Public Class Logger

    Private _nomEnCours As String
    Private _niveauEnCours As String
    Private Shared _instance As New Logger

    Public Shared Function getInstance() As Logger
        If (_instance Is Nothing) Then _instance = New Logger()
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
        Return _nomEnCours
    End Function

    ''' <summary>
    ''' Ajoute une ligne dans le log, la date/heure (et le niveau) est automatiquement ajoutée
    ''' </summary>
    ''' <param name="ligne">Contenu chaine a écrire dans le log</param>
    ''' <param name="niveau">Niveau de ce message</param>
    ''' <remarks></remarks>
    Public Sub LogEcrire(ByVal ligne As String, Optional ByVal niveau As LOG_LEVEL = LOG_LEVEL.INFO)
        If (_nomEnCours <> "") Then
            If (aLogger(niveau)) Then
                System.IO.File.AppendAllText(_nomEnCours, Now().ToString & " | " & niveau.ToString & " : " & ligne)
            End If
        End If
    End Sub

    Private Function aLogger(ByVal niveau As LOG_LEVEL) As Boolean
        If ((_niveauEnCours & ",").LastIndexOf("," & niveau & ",") >= 0) Then Return True
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

    Public Sub generateLogName(Optional ByVal withTime As Boolean = False)
        Dim dir As String

        dir = System.Environment.CurrentDirectory + "\logs"
        If (Not (System.IO.Directory.Exists(dir))) Then System.IO.Directory.CreateDirectory(dir)
        _nomEnCours = dir & "\" & My.Application.Info.AssemblyName & "_" & System.DateTime.Now.Day.ToString("00") & "-" + System.DateTime.Now.Month.ToString("00") & "-" + System.DateTime.Now.Year.ToString("0000")
        If (withTime) Then
            _nomEnCours &= "_" & System.DateTime.Now.Hour.ToString("00") & "-" + System.DateTime.Now.Minute.ToString("00")
        End If
        _nomEnCours &= ".log"
    End Sub

End Class
