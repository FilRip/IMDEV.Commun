Public Class Random

    ''' <summary>
    ''' Retourne aléatoirement Vrai ou Faux
    ''' </summary>
    ''' <returns>Un booléen</returns>
    ''' <remarks></remarks>
    Public Shared Function getBoolRand() As Boolean
        If (Rnd(2) < 1) Then Return True Else Return False
    End Function

End Class
