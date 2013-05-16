Imports System.Net.Mail

Public Class gestionEnvoiMail
    Inherits SmtpClient

    Private Const TAILLE_SMS As Integer = 160

    Private _formatHTML As Boolean
    Private _mail As New MailMessage
    Private _sms As Boolean
    Private _lastError As String = ""
    Private _auth As Net.NetworkCredential

    ''' <summary>
    ''' Ajouter un(des) destinataire(s) à ce mail
    ''' </summary>
    ''' <param name="liste">adresse email des destinataires à ajouter, séparer par des virgules</param>
    ''' <remarks></remarks>
    Public Sub destinataire(ByVal liste As String)
        _mail.To.Add(liste)
    End Sub

    ''' <summary>
    ''' Définir l'adresse email de l'emetteur de ce mail
    ''' </summary>
    ''' <param name="mail">adresse email de l'emetteur</param>
    ''' <remarks></remarks>
    Public Sub emetteur(ByVal mail As String)
        _mail.From = New MailAddress(mail)
    End Sub

    ''' <summary>
    ''' Définir le contenu du mail
    ''' </summary>
    ''' <param name="corps">Texte du mail</param>
    ''' <remarks></remarks>
    Public Sub message(ByVal corps As String)
        _mail.Body = corps
    End Sub

    ''' <summary>
    ''' Définir le titre du mail
    ''' </summary>
    ''' <param name="titre">Texte du titre du mail</param>
    ''' <remarks></remarks>
    Public Sub titre(ByVal titre As String)
        _mail.Subject = titre
    End Sub

    ''' <summary>
    ''' Défini si ce mail est au format HTML ou non
    ''' </summary>
    ''' <value>True = format HTML, sinon False</value>
    ''' <returns>True = format HTML, sinon False</returns>
    ''' <remarks></remarks>
    Public Property formatHTML() As Boolean
        Get
            Return _formatHTML
        End Get
        Set(ByVal value As Boolean)
            _formatHTML = value
        End Set
    End Property

    ''' <summary>
    ''' Adresse du serveur SMTP qui servira a envoyer ce mail
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property serveurSMTP()
        Get
            Return Host
        End Get
        Set(ByVal value)
            Host = value
        End Set
    End Property

    ''' <summary>
    ''' Port du serveur SMTP qui servira a envoyer ce mail
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property portSMTP()
        Get
            Return Port
        End Get
        Set(ByVal value)
            Port = value
        End Set
    End Property

    ''' <summary>
    ''' Définir le login et mot de passe a utiliser pour se connecter au serveur SMTP si celui ci requiere une authentification
    ''' </summary>
    ''' <param name="login">Login du serveur SMTP</param>
    ''' <param name="mdp">mot de passe du serveur SMTP</param>
    ''' <remarks></remarks>
    Public Sub authentificationSMTP(ByVal login As String, ByVal mdp As String)
        _auth = New Net.NetworkCredential(login, mdp)
    End Sub

    Public Sub envoiMailAsync(ByVal callBack As System.ComponentModel.RunWorkerCompletedEventHandler)
        Dim bg As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        AddHandler bg.DoWork, AddressOf bg_DoWork
        AddHandler bg.RunWorkerCompleted, callBack
        bg.RunWorkerAsync()
    End Sub
    Private Sub bg_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        e.Result = envoiMail()
    End Sub
    ''' <summary>
    ''' Fonction principale, envoi le mail une fois que tout a été défini
    ''' </summary>
    ''' <returns>True si le mail est parti, sinon False</returns>
    ''' <remarks></remarks>
    Public Function envoiMail() As Boolean
        Try
            _lastError = ""
            If (_mail.From Is Nothing) Then Return False
            If (_mail.To.Count = 0) Then Return False
            If (_auth IsNot Nothing) Then
                Credentials = _auth
            End If
            _mail.IsBodyHtml = _formatHTML
            If (_sms) Then
                If (_mail.Body.Length > TAILLE_SMS) Then
                    _mail.Body = _mail.Body.Substring(0, TAILLE_SMS - 1)
                End If
            End If
            Send(_mail)
            Return True
        Catch ex As Exception
            _lastError = ex.Message
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Défini si ce mail est en fait un SMS, donc automatiquement limité à 160 caractères
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SMS() As Boolean
        Get
            Return _sms
        End Get
        Set(ByVal value As Boolean)
            _sms = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne la dernière erreur générée lors de la dernière tentative d'envoi d'un mail/sms
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property derniereErreur() As String
        Get
            Return _lastError
        End Get
    End Property

End Class
