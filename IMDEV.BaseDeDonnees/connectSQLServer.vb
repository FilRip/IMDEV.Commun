﻿Imports System.Data.SqlClient

Public Class connectSQLServer

    Private Shared _instance As connectSQLServer
    Private _lastServer As String = ""
    Private _conn As SqlConnection
    Private _proc As SqlCommand
    Private _lastError As String = ""

    Public Shared Function getInstance() As connectSQLServer
        If (_instance Is Nothing) Then _instance = New connectSQLServer
        Return _instance
    End Function

    Public Function connexion(ByVal serveur As String, ByVal nomBase As String, ByVal login As String, ByVal motDePasse As String) As Boolean
        Dim chaineConnexion As String = "Persist Security Info=False;Integrated Security=False;workstation id=PA:" & My.Computer.Name & ";packet size=4096;initial catalog=" & nomBase & ";data source='" & serveur & "';user id=" & login & ";password='" & motDePasse & "'"

        Try
            _lastServer = chaineConnexion
            _conn = New SqlConnection(chaineConnexion)
            _conn.Open()
            Return True
        Catch ex As Exception
            _lastError = ex.Message
        End Try
        Return False
    End Function

    Private Function copieDonnees(ByRef source As SqlDataReader) As unRetourRequete
        Dim retour As New unRetourRequete

        Try
            retour.Tables.Add("Resultat1")
            For i As Integer = 0 To source.FieldCount - 1
                retour.Tables(0).Columns.Add(source.GetName(i), source.GetFieldType(i))
            Next
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

    Public Function retourneDonnees(ByVal requete As String) As unRetourRequete
        Dim sa As New SqlCommand
        Dim src As SqlDataReader = Nothing

        verifConnexion()
        Try
            sa.Connection = _conn
            sa.CommandType = CommandType.Text
            sa.CommandText = requete
            src = sa.ExecuteReader
            If ((src IsNot Nothing) AndAlso (src.HasRows)) Then Return copieDonnees(src)
        Catch ex As Exception
            _lastError = ex.Message
        Finally
            sa = Nothing
            Try
                src.Close()
            Catch ex As Exception
            End Try
            src = Nothing
        End Try
        Return Nothing
    End Function

    Public Function executeRequete(ByVal requete As String) As Boolean
        Dim sa As New SqlCommand

        verifConnexion()
        Try
            sa.Connection = _conn
            sa.CommandText = requete
            sa.CommandType = CommandType.Text
            sa.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            _lastError = ex.Message
        Finally
            sa = Nothing
        End Try
        Return False
    End Function

    Public Function prepareProcedureStockee(ByVal nom As String) As Boolean
        Try
            _proc = New SqlCommand
            _proc.CommandType = CommandType.StoredProcedure
            _proc.CommandText = nom
            Return True
        Catch ex As Exception
            _lastError = ex.Message
        End Try
        Return False
    End Function

    Public Function ajouteParametrePS(ByVal nom As String, ByVal valeur As Object) As Boolean
        Try
            _proc.Parameters.AddWithValue(nom, valeur)
            Return True
        Catch ex As Exception
            _lastError = ex.Message
        End Try
        Return False
    End Function

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

    Public Function retourneDonnees() As unRetourRequete
        verifConnexion()
        Dim reader As SqlDataReader = Nothing
        Try
            _proc.Connection = _conn
            reader = _proc.ExecuteReader()
            If ((reader IsNot Nothing) AndAlso (reader.HasRows)) Then Return copieDonnees(reader)
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
            If (_lastServer <> "") Then
                Try
                    _conn = New SqlConnection(_lastServer)
                    _conn.Open()
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Public ReadOnly Property etatConnexion() As System.Data.ConnectionState
        Get
            Return _conn.State
        End Get
    End Property

End Class
