Public Class Base64

    ''' <summary>
    ''' Covnerti une chaine base64 pur en flux de données
    ''' </summary>
    ''' <param name="txt">La chaine base64 à convetir</param>
    ''' <returns>Un flux de données, tableau d'octet</returns>
    ''' <remarks></remarks>
    Public Shared Function decodeBase64(ByVal txt As String) As Byte()
        If (txt <> "") Then
            Return Convert.FromBase64String(txt)
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Converti un flux de données (tableau d'octets) en base64
    ''' </summary>
    ''' <param name="donnees">Le flux de données à convertir (tableau d'octet)</param>
    ''' <returns>Une chaine texte pur contenant la chaine base64 encodée</returns>
    ''' <remarks></remarks>
    Public Shared Function encodeBase64(ByVal donnees() As Byte) As String
        If (donnees IsNot Nothing) Then
            Return Convert.ToBase64String(donnees)
        End If
        Return ""
    End Function

End Class
