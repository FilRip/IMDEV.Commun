Public Class MD5

    Public Shared Function crypteChaine(ByVal chaine As String) As String
        Return Base64.encodeBase64(crypteDonnees(System.Text.Encoding.ASCII.GetBytes(chaine)))
    End Function

    Public Shared Function crypteDonnees(ByVal datas As Byte()) As Byte()
        Return System.Security.Cryptography.MD5.Create().ComputeHash(datas)
    End Function

End Class
