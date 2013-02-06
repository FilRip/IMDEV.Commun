Imports System.IO
Imports System.Net
Imports System.Text

Public Class clientFTP

    Public Const SEPARATEUR As String = "/"
    Public Const REP_PARENT As String = ".."
    Public Const SEPARATEUR_LOCAL As String = "\"
    Private Const TXT_ENTETE_FTP As String = "ftp://"
    Private _passif As Boolean
    Private _login As String = ""
    Private _mdp As String = ""
    Private _serveurFTP As String
    Private _portFTP As Integer

    Public Property serveurFTP() As String
        Get
            Return _serveurFTP
        End Get
        Set(ByVal value As String)
            _serveurFTP = value
        End Set
    End Property

    Public Property portFTP() As Integer
        Get
            Return _portFTP
        End Get
        Set(ByVal value As Integer)
            _portFTP = value
        End Set
    End Property

    Public Property loginFTP() As String
        Get
            Return _login
        End Get
        Set(ByVal value As String)
            _login = value
        End Set
    End Property

    Public Property motDePasseFTP() As String
        Get
            Return _mdp
        End Get
        Set(ByVal value As String)
            _mdp = value
        End Set
    End Property

    Public Property modePassif() As Boolean
        Get
            Return _passif
        End Get
        Set(ByVal value As Boolean)
            _passif = value
        End Set
    End Property

    Private Function downloadFichier(ByVal strUrlFichier As String, ByVal strCheminDestinationFichier As String, Optional ByVal pb As Infragistics.Win.UltraWinProgressBar.UltraProgressBar = Nothing) As Boolean
        Dim monUriFichier As New Uri(strUrlFichier)
        Dim monUriDestinationFichier As New Uri(strCheminDestinationFichier)
        If Not (monUriFichier.Scheme = Uri.UriSchemeFtp) Then
            Return False
        End If
        If Not (monUriDestinationFichier.Scheme = Uri.UriSchemeFile) Then
            Return False
        End If
        If (File.Exists(strCheminDestinationFichier)) Then
            Return False
        End If
        Dim monResponseStream As Stream = Nothing
        Dim monFileStream As FileStream = Nothing
        Dim monReader As StreamReader = Nothing
        Try
            Dim downloadRequest As FtpWebRequest = CType(WebRequest.Create(monUriFichier), FtpWebRequest)
            downloadRequest.UsePassive = _passif
            If (_login <> "") Then
                Dim monCompteFtp As New NetworkCredential(_login, _mdp)
                downloadRequest.Credentials = monCompteFtp
            End If
            Dim downloadResponse As FtpWebResponse = CType(downloadRequest.GetResponse(), FtpWebResponse)
            monResponseStream = downloadResponse.GetResponseStream()
            If (pb IsNot Nothing) Then pb.Value = 0
            Dim nomFichier As String = monUriDestinationFichier.LocalPath.ToString
            monFileStream = File.Create(nomFichier)
            Dim monBuffer(1024) As Byte
            Dim octetsLus As Integer
            While True
                octetsLus = monResponseStream.Read(monBuffer, 0, monBuffer.Length)
                If octetsLus = 0 Then
                    Exit While
                End If
                monFileStream.Write(monBuffer, 0, octetsLus)
                If (pb IsNot Nothing) Then
                    Try
                        pb.Value += 1
                    Catch ex As Exception
                        pb.Value = pb.Maximum
                    End Try
                    pb.Parent.Refresh()
                    pb.Refresh()
                End If
            End While
            If (pb IsNot Nothing) Then pb.Value = 0
            ' redefinir la date du fichier
            downloadRequest = CType(WebRequest.Create(monUriFichier), FtpWebRequest)
            downloadRequest.UsePassive = _passif
            If (_login <> "") Then
                Dim monCompteFtp As New NetworkCredential(_login, _mdp)
                downloadRequest.Credentials = monCompteFtp
            End If
            downloadRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp
            downloadResponse = CType(downloadRequest.GetResponse(), FtpWebResponse)
            monFileStream.Close()
            File.SetCreationTimeUtc(strCheminDestinationFichier, CDate(downloadResponse.LastModified))
            File.SetLastWriteTimeUtc(strCheminDestinationFichier, CDate(downloadResponse.LastModified))
        Catch ex As Exception
#If DEBUG Then
            MsgBox(strUrlFichier & vbCrLf & ex.Message)
#End If
            Return False
        Finally
            Try
                monReader.Close()
            Catch ex As Exception
            End Try
            Try
                monResponseStream.Close()
            Catch ex As Exception
            End Try
            Try
                monFileStream.Close()
            Catch ex As Exception
            End Try
        End Try
        Return True
    End Function

    Private Function FTPlisteFichiers(ByVal serveurCible As String) As Array
        Dim monResponseStream As Stream = Nothing
        Dim monStreamReader As StreamReader = Nothing
        Dim monResultat As Array = Nothing
        Dim monUriServeur As New Uri(serveurCible)
        If Not (monUriServeur.Scheme = Uri.UriSchemeFtp) Then
            Return monResultat
        End If
        Try
            Dim maRequeteListe As FtpWebRequest = CType(WebRequest.Create(monUriServeur), FtpWebRequest)
            maRequeteListe.UsePassive = _passif
            maRequeteListe.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            If (_login <> "") Then
                Dim monCompteFtp As New NetworkCredential(_login, _mdp)
                maRequeteListe.Credentials = monCompteFtp
            End If
            Dim maResponseListe As FtpWebResponse = CType(maRequeteListe.GetResponse, FtpWebResponse)
            monStreamReader = New StreamReader(maResponseListe.GetResponseStream, Encoding.UTF8)
            Dim listeBrute As String = monStreamReader.ReadToEnd
            Dim separateur() As String = {Environment.NewLine}
            Dim tableauListe() As String = listeBrute.Split(separateur, StringSplitOptions.RemoveEmptyEntries)
            Dim listeFinale As New List(Of String)
            Dim i As Integer = 0
            While i < tableauListe.Length
                listeFinale.Add(tableauListe(i))
                i += 1
            End While
            monResultat = listeFinale.ToArray
        Catch ex As Exception
#If DEBUG Then
            MsgBox(ex.Message & VbCrLf & ex.StackTrace)
#End If
            Return Nothing
        Finally
            Try
                monResponseStream.Close()
            Catch ex As Exception
            End Try
            Try
                monStreamReader.Close()
            Catch ex As Exception
            End Try
        End Try
        Return monResultat
    End Function

    Private Function uploadFichier(ByVal cheminSource As String, ByVal urlDestination As String, Optional ByVal pb As Infragistics.Win.UltraWinProgressBar.UltraProgressBar = Nothing) As Boolean
        Dim monRequestStream As Stream = Nothing
        Dim fileStream As FileStream = Nothing
        Dim uploadResponse As FtpWebResponse = Nothing
        Try
            ' TODO : Test existance du fichier sur le serveur avant
            ' et demander écrasement si présent

            Dim monUriFichierLocal As New Uri(cheminSource)
            Dim monUriFichierDistant As New Uri(urlDestination)

            If (Not (monUriFichierLocal.Scheme = Uri.UriSchemeFile)) Then Return False
            If (Not (monUriFichierDistant.Scheme = Uri.UriSchemeFtp)) Then Return False

            Dim uploadRequest As FtpWebRequest = CType(WebRequest.Create(urlDestination), FtpWebRequest)
            uploadRequest.UsePassive = _passif
            If (_login <> "") Then
                Dim monCompte As New NetworkCredential(_login, _mdp)
                uploadRequest.Credentials = monCompte
            End If
            uploadRequest.Method = WebRequestMethods.Ftp.UploadFile
            uploadRequest.Proxy = Nothing
            monRequestStream = uploadRequest.GetRequestStream()
            fileStream = File.Open(cheminSource, FileMode.Open)
            If (pb IsNot Nothing) Then
                Try
                    pb.Maximum = CInt(fileStream.Length / 1024)
                Catch ex As Exception
                End Try
            End If
            Dim buffer(1024) As Byte
            Dim bytesRead As Integer
            While True
                bytesRead = fileStream.Read(buffer, 0, buffer.Length)
                If bytesRead = 0 Then
                    Exit While
                End If
                monRequestStream.Write(buffer, 0, bytesRead)
                If (pb IsNot Nothing) Then
                    Try
                        pb.Value += 1
                    Catch ex As Exception
                        pb.Value = pb.Maximum
                    End Try
                    pb.Refresh()
                    pb.Parent.Refresh()
                End If
            End While
            monRequestStream.Close()
            uploadResponse = CType(uploadRequest.GetResponse(), FtpWebResponse)

            ' redefinir la date du fichier
            'Dim fi As New FileInfo(cheminSource)
            'changeDateFichierServeur(urlDestination.Replace("ftp://" & Constantes.getInstance().IP_SERVEUR_FTP & ":" & Constantes.getInstance().PORT_SERVEUR_FTP.ToString, ""), fi.LastWriteTimeUtc)

        Catch ex As Exception
#If DEBUG Then
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
#End If
            Return False
        Finally
            Try
                uploadResponse.Close()
            Catch ex As Exception
            End Try
            Try
                fileStream.Close()
            Catch ex As Exception
            End Try
            Try
                monRequestStream.Close()
            Catch ex As Exception
            End Try
        End Try
        Return True
    End Function

    Private Function effaceFichier(ByVal uriFichier As String) As Boolean
        Dim monUriFichier As New Uri(uriFichier)
        If Not (monUriFichier.Scheme = Uri.UriSchemeFtp) Then Return False
        Try
            Dim maRequeteEffacement As FtpWebRequest = CType(WebRequest.Create(uriFichier), FtpWebRequest)
            maRequeteEffacement.UsePassive = _passif
            maRequeteEffacement.Method = WebRequestMethods.Ftp.DeleteFile
            If (_login <> "") Then
                Dim monCompteFtp As New NetworkCredential(_login, _mdp)
                maRequeteEffacement.Credentials = monCompteFtp
            End If
            Dim maResponseFtp As FtpWebResponse = CType(maRequeteEffacement.GetResponse, FtpWebResponse)
        Catch ex As Exception
#If DEBUG Then
            MsgBox(ex.Message & VbCrLf & ex.StackTrace)
#End If
            Return False
        End Try
        Return True
    End Function

    Private Function effaceDossier(ByVal uriDossier As String) As Boolean
        Dim monUriDossier As New Uri(uriDossier)
        If Not (monUriDossier.Scheme = Uri.UriSchemeFtp) Then Return False
        Try
            Dim maRequeteEffacement As FtpWebRequest = CType(WebRequest.Create(uriDossier), FtpWebRequest)
            maRequeteEffacement.UsePassive = _passif
            maRequeteEffacement.Method = WebRequestMethods.Ftp.RemoveDirectory
            If (_login <> "") Then
                Dim monCompteFtp As New NetworkCredential(_login, _mdp)
                maRequeteEffacement.Credentials = monCompteFtp
            End If
            Dim maResponseFtp As FtpWebResponse = CType(maRequeteEffacement.GetResponse, FtpWebResponse)
        Catch ex As Exception
#If DEBUG Then
            MsgBox(ex.Message & VbCrLf & ex.StackTrace)
#End If
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Retourne la liste des fichiers d'un répertoire spécifié du serveur FTP
    ''' </summary>
    ''' <param name="repertoire">Répertoire (ou vide pour la liste à la racine)</param>
    ''' <returns>Liste de unFichier</returns>
    ''' <remarks></remarks>
    Public Function ListeFichiers(ByVal repertoire As String) As List(Of unFichier)
        Dim i, j As Integer
        Dim f As unFichier
        Dim temp As String()
        Dim chaine As String
        Dim retour As New List(Of unFichier)
        Dim contenu As Array = FTPlisteFichiers(TXT_ENTETE_FTP & _serveurFTP & ":" & _portFTP.ToString & repertoire)

        f = New unFichier
        f.nomComplet = ".."
        f.type = unFichier.TYPE_FICHIER.TYPE_DOSSIER
        retour.Add(f)
        If (contenu.Length > 0) Then
            For i = 0 To contenu.Length - 1
                chaine = contenu(i).ToString
                While (chaine.IndexOf("  ") > 0)
                    chaine = chaine.Replace("  ", " ")
                End While
                temp = chaine.Split(" ")
                f = New unFichier
                If (temp(0)(0) = "d") Then
                    f.type = unFichier.TYPE_FICHIER.TYPE_DOSSIER
                Else
                    f.type = unFichier.TYPE_FICHIER.TYPE_FICHIER
                    Try
                        f.taille = CInt(temp(4))
                    Catch ex As Exception
                        f.taille = 0
                    End Try
                    Try
                        f.dateModif = DateTime.Parse(temp(6) & "/" & temp(5) & "/" & temp(7))
                    Catch ex As Exception
                    End Try
                End If
                f.nomComplet = temp(8)
                If (temp.Length > 9) Then
                    For j = 9 To temp.Length - 1
                        f.nomComplet &= " " & temp(j)
                    Next
                End If
                retour.Add(f)
            Next
        End If
        Return retour
    End Function

    ''' <summary>
    ''' Effacer un fichier stocké sur le FTP
    ''' </summary>
    ''' <param name="nom">Nom (avec emplacement au besoin) du fichier a effacer</param>
    ''' <returns>True si effacé avec succès, sinon False</returns>
    ''' <remarks></remarks>
    Public Function FTPEffaceFichier(ByVal nom As String) As Boolean
        Try
            Return effaceFichier(TXT_ENTETE_FTP & _serveurFTP & ":" & _portFTP.ToString & nom)
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Efface un répertoire stocké sur le FTP
    ''' </summary>
    ''' <param name="nom">Nom (et emplacement au besoin) du dossier à supprimer</param>
    ''' <returns>True si effacé avec succès, sinon False</returns>
    ''' <remarks></remarks>
    Public Function FTPEffaceDossier(ByVal nom As String) As Boolean
        Try
            Return effaceDossier(TXT_ENTETE_FTP & _serveurFTP & ":" & _portFTP.ToString & nom)
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Envoyer(upload) un fichier(ou un répertoire entier) local vers le serveur FTP
    ''' </summary>
    ''' <param name="local">Nom et emplacement du fichier à envoyer (ou nom (avec emplacement) du dossier à envoyer)</param>
    ''' <param name="repdist">Répertoire destination du serveur FTP ou mettre ce fichier (ou ce dossier)</param>
    ''' <param name="pb">Barre de progression</param>
    ''' <param name="mylabel">Affichage de l'état (si c'est un dossier qu'il faut envoyer, il précisera dans ce label, les fichiers un par un qu'il envoi)</param>
    ''' <returns>True si upload réussi, sinon False</returns>
    ''' <remarks></remarks>
    Public Function FTPEnvoyerFichier(ByVal local As String, ByVal repdist As String, Optional ByVal pb As Infragistics.Win.UltraWinProgressBar.UltraProgressBar = Nothing, Optional ByVal mylabel As System.Windows.Forms.Label = Nothing) As Boolean
        If ((File.GetAttributes(local) And FileAttributes.Directory) = FileAttributes.Directory) Then
            FTPCreerDossier(repdist & IO.Path.GetFileName(local))
            Dim listerecursif As String()
            Dim lastretour As Boolean = True
            Dim f As String
            listerecursif = Directory.GetFileSystemEntries(local)
            For Each f In listerecursif
                If (Not (FTPEnvoyerFichier(f, repdist & Path.GetFileName(f), pb, mylabel))) Then lastretour = False
            Next
            Return lastretour
        Else
            If (mylabel IsNot Nothing) Then
                mylabel.Text = "Envoi du fichier : " & local & " en cours..."
                mylabel.Refresh()
            End If
            Return uploadFichier(local, TXT_ENTETE_FTP & _serveurFTP & ":" & _portFTP.ToString & repdist, pb)
        End If
    End Function

    ''' <summary>
    ''' Réception(download) d'un fichier ou d'un dossier, depuis le serveur FTP, en local
    ''' </summary>
    ''' <param name="nom">Nom du fichier ou du dossier à télécharger qui se trouve sur le FTP</param>
    ''' <param name="dest">Répertoire local de destination ou stocker ce fichier (ou dossier)</param>
    ''' <param name="type">Précise si c'est un dossier ou un fichier</param>
    ''' <param name="pb">Barre de progression</param>
    ''' <param name="mylabel">Affichage de l'état (si c'est un dossier qu'il faut récupérer, il précisera dans ce label, les fichiers un par un qu'il récupère)</param>
    ''' <returns>True si le téléchargement à réussi, sinon False</returns>
    ''' <remarks></remarks>
    Public Function FTPReceptionFichier(ByVal nom As String, ByVal dest As String, ByVal type As unFichier.TYPE_FICHIER, Optional ByVal pb As Infragistics.Win.UltraWinProgressBar.UltraProgressBar = Nothing, Optional ByVal mylabel As System.Windows.Forms.Label = Nothing) As Boolean
        If (Type = unFichier.TYPE_FICHIER.TYPE_DOSSIER) Then
            If (Not (Directory.Exists(dest))) Then
                Try
                    Directory.CreateDirectory(dest)
                Catch ex As Exception
                    Return False
                End Try
            End If
            Dim maListeDistant As New List(Of unFichier)
            Dim lastretour As Boolean = True
            maListeDistant = ListeFichiers(nom)
            Dim fich As unFichier
            For Each fich In maListeDistant
                If (fich.nomFichier <> "..") Then
                    If (pb IsNot Nothing) Then pb.Maximum = CInt(fich.taille / 1024)
                    If (Not (FTPReceptionFichier(nom & "/" & fich.nomFichier, dest & "\" & fich.nomFichier, fich.type, pb, mylabel))) Then lastretour = False
                End If
            Next
            Return lastretour
        Else
            If (mylabel IsNot Nothing) Then
                mylabel.Text = "Réception du fichier : " & nom
                mylabel.Refresh()
            End If
            Return downloadFichier(TXT_ENTETE_FTP & _serveurFTP & ":" & _portFTP.ToString & nom, dest, pb)
        End If
    End Function

    ''' <summary>
    ''' Renommer un fichier, ou un dossier, du serveur FTP
    ''' </summary>
    ''' <param name="nom">Nom actuel sur le serveur FTP (avec emplacement au besoin)</param>
    ''' <param name="newnom">Nouveau nom à lui attribuer</param>
    ''' <returns>True si le renommage à réussi, sinon False</returns>
    ''' <remarks></remarks>
    Public Function FTPRenommerFichier(ByVal nom As String, ByVal newnom As String) As Boolean
        Try
            Return renommeFichier(TXT_ENTETE_FTP & _serveurFTP & ":" & _portFTP.ToString & nom, newnom)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function renommeFichier(ByVal uriFichier As String, ByVal futurNom As String) As Boolean
        Dim monUriFichier As New Uri(uriFichier)
        If Not (monUriFichier.Scheme = Uri.UriSchemeFtp) Then Return False
        Try
            Dim maRequeteRename As FtpWebRequest = CType(WebRequest.Create(uriFichier), FtpWebRequest)
            maRequeteRename.UsePassive = _passif
            maRequeteRename.Method = WebRequestMethods.Ftp.Rename
            maRequeteRename.RenameTo = futurNom
            If (_login <> "") Then
                Dim monCompteFtp As New NetworkCredential(_login, _mdp)
                maRequeteRename.Credentials = monCompteFtp
            End If
            Dim maResponseFtp As FtpWebResponse = CType(maRequeteRename.GetResponse, FtpWebResponse)
        Catch ex As Exception
#If DEBUG Then
            MsgBox(ex.Message & VbCrLf & ex.StackTrace)
#End If
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Créer un nouveau dossier sur le FTP
    ''' </summary>
    ''' <param name="nom">Nom du dossier (avec emplacement si besoin)</param>
    ''' <returns>True = création du dossier réussi, sinon False</returns>
    ''' <remarks></remarks>
    Public Function FTPCreerDossier(ByVal nom As String) As Boolean
        Try
            Return creerDossier(TXT_ENTETE_FTP & _serveurFTP & ":" & _portFTP.ToString & nom)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function creerDossier(ByVal uriFichier As String) As Boolean
        Dim monUriFichier As New Uri(uriFichier)
        If Not (monUriFichier.Scheme = Uri.UriSchemeFtp) Then Return False
        Try
            Dim maRequeteMakeDir As FtpWebRequest = CType(WebRequest.Create(uriFichier), FtpWebRequest)
            maRequeteMakeDir.UsePassive = _passif
            maRequeteMakeDir.Method = WebRequestMethods.Ftp.MakeDirectory
            If (_login <> "") Then
                Dim monCompteFtp As New NetworkCredential(_login, _mdp)
                maRequeteMakeDir.Credentials = monCompteFtp
            End If
            Dim maResponseFtp As FtpWebResponse = CType(maRequeteMakeDir.GetResponse, FtpWebResponse)
        Catch ex As Exception
#If DEBUG Then
            MsgBox(ex.Message & VbCrLf & ex.StackTrace)
#End If
            Return False
        End Try
        Return True
    End Function

End Class
