Imports System.Data.OracleClient

Public Class connectOracle

    Private Shared _instance As connectOracle
    Private _lastError As String
    Private _conn As OracleClient.OracleConnection
    Private _reader As OracleClient.OracleDataReader
    Private _proc As OracleCommand
    Private _lastServer As String = ""

    ''' <summary>
    ''' Accède à l'objet
    ''' </summary>
    ''' <returns>L'objet</returns>
    ''' <remarks></remarks>
    Public Shared Function getInstance() As connectOracle
        If (_instance Is Nothing) Then _instance = New connectOracle
        Return _instance
    End Function

    ''' <summary>
    ''' Permet de se connecter à un serveur, toutes les futurs commandes seront disponible et s'exécuteront sur ce serveur
    ''' </summary>
    ''' <param name="serveur">Nom/Adresse du serveur</param>
    ''' <param name="nomBase">Nom de la base (TNS)</param>
    ''' <param name="login">Nom de compte</param>
    ''' <param name="motDePasse">Mot de passe du compte</param>
    ''' <param name="port">Port TCP à utilisé, si différent du port par défaut de Oracle</param>
    ''' <returns>True si la connexion a pu s'effectuer, sinon False</returns>
    ''' <remarks></remarks>
    Public Function connexion(ByVal serveur As String, ByVal nomBase As String, ByVal login As String, ByVal motDePasse As String, Optional ByVal port As Integer = 1521) As Boolean
        Dim chaineConnexion As String = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=EUROPROD)(PORT=" & port.ToString & ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & nomBase & ")));User Id=" & login & ";Password=" & motDePasse & ";"
        Try
            _lastServer = chaineConnexion
            _conn = New OracleConnection(chaineConnexion)
            _conn.Open()
            Return True
        Catch ex As Exception
            _lastError = ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Converti les données d'un OracleReader à un unRetourRequete
    ''' </summary>
    ''' <param name="source">Un OracleReader</param>
    ''' <returns>un unRetourRequete si tout s'est bien passé, sinon Nothing</returns>
    ''' <remarks></remarks>
    Private Function copieDonnees(ByRef source As OracleDataReader) As unRetourRequete
        Dim retour As New unRetourRequete

        Try
            ' On ajoute une liste, une table qui contiendra le résultat
            retour.Tables.Add("Resultat1")
            ' On ajoute les champs, un par un, avec leur type d'origine
            For i As Integer = 0 To source.FieldCount - 1
                retour.Tables(0).Columns.Add(source.GetName(i), source.GetFieldType(i))
            Next
            ' Maintenant, on rempli avec les données sortie
            While (source.Read())
                retour.Tables(0).Rows.Add()
                For numColonne As Integer = 0 To source.FieldCount - 1
                    retour.Tables(0).Rows(retour.Tables(0).Rows.Count - 1).Item(numColonne) = source(numColonne)
                Next
            End While
            Return retour
        Catch ex As Exception
            _lastError = ex.Message
        Finally
            Try
                source.Close()
            Catch ex As Exception
            End Try
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' Exécute une requête et retourne le résultat (select)
    ''' </summary>
    ''' <param name="requete">Instructions SQL</param>
    ''' <returns>un objet unRetourRequete (dataset) contenant toutes les données si tout s'est bien passé, sinon False</returns>
    ''' <remarks></remarks>
    Public Function retourneDonnees(ByVal requete As String) As unRetourRequete
        Dim oc As New OracleCommand(requete)
        Dim reader As OracleDataReader = Nothing

        verifConnexion()
        Try
            oc.Connection = _conn
            reader = oc.ExecuteReader
            If ((reader IsNot Nothing) AndAlso (reader.HasRows)) Then
                Return copieDonnees(reader)
            End If
        Catch ex As Exception
            _lastError = ex.Message
        Finally
            oc = Nothing
            Try
                reader.Close()
            Catch ex As Exception
            End Try
            reader = Nothing
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' Exécute une requête sur le serveur oracle actuellement connecté
    ''' </summary>
    ''' <param name="requete">Instructions SQL à exécuter</param>
    ''' <returns>True si tout s'est bien passé, sinon False</returns>
    ''' <remarks></remarks>
    Public Function executeRequete(ByVal requete As String) As Boolean
        Dim oc As New OracleCommand

        verifConnexion()
        Try
            oc.Connection = _conn
            oc.CommandText = requete
            oc.CommandType = CommandType.Text
            oc.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            _lastError = ex.Message
        Finally
            oc = Nothing
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Prepare/Initialise une procédure stockée pour être exécuter plus tard après avoir entré les paramètres si necessaire
    ''' </summary>
    ''' <param name="nom">Nom de la procédure stockée</param>
    ''' <returns>True si tout s'est bien passé, sinon False</returns>
    ''' <remarks></remarks>
    Public Function prepareProcedureStockee(ByVal nom As String) As Boolean
        Try
            _proc = New OracleCommand
            _proc.CommandText = nom
            _proc.CommandType = CommandType.StoredProcedure
            Return True
        Catch ex As Exception
            _lastError = ex.Message
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Entre un parametre pour la procedure stockée en cours
    ''' </summary>
    ''' <param name="nom">Nom du paramètre à entrer</param>
    ''' <param name="valeur">Valeur du paramètre à entrer dans son type d'origine</param>
    ''' <returns>True si tout s'est bien passé, sinon False</returns>
    ''' <remarks></remarks>
    Public Function ajoutParametrePS(ByVal nom As String, ByVal valeur As Object) As Boolean
        Try
            Dim param As New OracleParameter(nom, valeur)
            _proc.Parameters.Add(param)
            Return True
        Catch ex As Exception
            _lastError = ex.Message
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Execute une procedure stockée ne retournant pas de résultat
    ''' </summary>
    ''' <returns>True si tout s'est bien passé, sinon False</returns>
    ''' <remarks></remarks>
    Public Function executeProcedureStockee() As Boolean
        verifConnexion()
        Try
            _proc.Connection = _conn
            _proc.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            _lastError = ex.Message
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Execute une procedure stockée retournant des données
    ''' </summary>
    ''' <returns>un objet unRetourRequete (dataset), sinon Nothing</returns>
    ''' <remarks></remarks>
    Public Function retourneDonnees() As unRetourRequete
        Dim reader As OracleDataReader = Nothing

        verifConnexion()
        Try
            _proc.Connection = _conn
            reader = _proc.ExecuteReader
            If ((reader IsNot Nothing) AndAlso (reader.HasRows)) Then
                Return copieDonnees(reader)
            End If
        Catch ex As Exception
            _lastError = ex.Message
        Finally
            Try
                reader.Close()
            Catch ex As Exception
            End Try
            reader = Nothing
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' Lire le message d'erreur de la dernière erreur qui a pu se produire
    ''' </summary>
    ''' <returns>Le message d'erreur</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property derniereErreur() As String
        Get
            Return _lastError
        End Get
    End Property

    Public Sub fermer()
        Try
            _proc = Nothing
            _conn.Close()
        Catch ex As Exception
        Finally
            _conn = Nothing
        End Try
    End Sub

    Private Sub verifConnexion()
        If ((_conn Is Nothing) OrElse (_conn.State <> ConnectionState.Open)) Then
            Try
                _conn = New OracleConnection(_lastServer)
                _conn.Open()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public ReadOnly Property etatConnexion() As System.Data.ConnectionState
        Get
            Return _conn.State
        End Get
    End Property

End Class
