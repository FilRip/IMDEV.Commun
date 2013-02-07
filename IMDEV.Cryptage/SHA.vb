Imports System.Security.Cryptography

Public Class SHA

    Public Function crypteDonnees(ByVal datas As Byte()) As Byte()
        Dim mySha As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Return mySha.ComputeHash(datas)
    End Function

    Public Function crypteChaine(ByVal chaine As String) As String
        Return Base64.encodeBase64(crypteDonnees(System.Text.Encoding.ASCII.GetBytes(chaine)))
    End Function

End Class
