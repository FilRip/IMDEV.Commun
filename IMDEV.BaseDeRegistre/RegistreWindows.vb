Public Class RegistreWindows

    ''' <summary>
    ''' Retourne le contenu d'une valeur dans la base de registre Windows sur HKEY_CURRENT_USER (Utilisateur actuellement loggé dans Windows)
    ''' </summary>
    ''' <param name="DirName">Emplacement de la clé dans la base de registre (Exclu "HKEY_CURRENT_USER")</param>
    ''' <param name="name">Nom de la 'variable'</param>
    ''' <returns>Contenu de la 'variable'</returns>
    ''' <remarks></remarks>
    Public Shared Function GetKeyValueCurrentUser(ByVal DirName As String, ByVal name As String) As Object
        Return Microsoft.Win32.Registry.CurrentUser.OpenSubKey(DirName).GetValue(name)
    End Function

    ''' <summary>
    ''' Définie la valeur d'une 'variable' dans la base de registre Windows sur HKEY_CURRENT_USER (Utilisateur actuellement loggé dans Windows)
    ''' </summary>
    ''' <param name="DirName">Emplacement de la clé dans la base de registre (Exclu "HKEY_CURRENT_USER")</param>
    ''' <param name="name">Nom de la 'variable'</param>
    ''' <param name="value">Contenu de la 'variable'</param>
    ''' <param name="type">Type de la variable (chaine, entier, etc...)</param>
    ''' <remarks>Si la clé n'existe pas également, elle est automatiquement créée</remarks>
    Public Shared Sub SetKeyValueCurrentUser(ByVal DirName As String, ByVal name As String, ByVal value As Object, ByVal type As Microsoft.Win32.RegistryValueKind)
        Microsoft.Win32.Registry.CurrentUser.CreateSubKey(DirName).SetValue(name, value, type)
    End Sub

    ''' <summary>
    ''' Efface une clé de la base de registre Windows sur HKEY_CURRENT_USER (Utilisateur actuellement loggé dans Windows)
    ''' </summary>
    ''' <param name="DirName">Emplacement de la clé à effacer</param>
    ''' <remarks></remarks>
    Public Shared Function DelKeyCurrentUser(ByVal DirName As String) As Boolean
        Try
            Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree(DirName)
            Return True
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Retourne le contenu, en chaine, d'une valeur dans la base de registre Windows sur HKEY_LOCAL_MACHINE (base de registre global à tous les utilisateurs Windows)
    ''' </summary>
    ''' <param name="DirName">Emplacement de la clé dans la base de registre (Exclu : HKEY_LOCAL_MACHINE)</param>
    ''' <param name="name">Nom de la 'variable' à lire</param>
    ''' <returns>Contenu de la 'variable'</returns>
    ''' <remarks></remarks>
    Public Shared Function GetKeyValueLocalMachine(ByVal DirName As String, ByVal name As String) As Object
        Return Microsoft.Win32.Registry.LocalMachine.OpenSubKey(DirName).GetValue(name)
    End Function

    ''' <summary>
    ''' Définie la valeur d'une 'variable' dans la base de registre Windows sur HKEY_LOCAL_MACHINE (base de registre global à tous les utilisateurs Windows)
    ''' </summary>
    ''' <param name="DirName">Emplacement de la clé dans la base de registre (Exclu : HKEY_LOCAL_MACHINE)</param>
    ''' <param name="name">Nom de la 'variable'</param>
    ''' <param name="value">Contenu de la 'variable'</param>
    ''' <param name="type">Type de la variable (chaine, entier, etc...)</param>
    ''' <remarks>Si la clé n'existe pas, elle est automatiquement créée</remarks>
    Public Shared Sub SetKeyValueLocalMachine(ByVal DirName As String, ByVal name As String, ByVal value As Object, ByVal type As Microsoft.Win32.RegistryValueKind)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey(DirName).SetValue(name, value, type)
    End Sub

    ''' <summary>
    ''' Efface une clé de la base de registre Windows sur HKEY_LOCAL_MACHINE (base de registre global à tous les utilisateurs Windows)
    ''' </summary>
    ''' <param name="DirName">Emplacement de la clé dans la base de registre (Exclu : HKEY_LOCAL_MACHINE)</param>
    ''' <remarks></remarks>
    Public Shared Sub DelKeyLocalMachine(ByVal DirName As String)
        Microsoft.Win32.Registry.LocalMachine.DeleteSubKeyTree(DirName)
    End Sub

    ''' <summary>
    ''' Efface une 'variable' dans la base de registre Windows
    ''' </summary>
    ''' <param name="dirName">Emplacement de la clé ou se trouve la variable à effacer</param>
    ''' <param name="nomParam">Nom de la 'variable' à effacer</param>
    ''' <remarks></remarks>
    Public Shared Function DelValueCurrentUser(ByVal dirName As String, ByVal nomParam As String) As Boolean
        Try
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey(dirName, True).DeleteValue(nomParam)
            Return True
        Catch ex As Exception
        End Try
        Return False
    End Function

End Class
