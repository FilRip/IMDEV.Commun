Public Class traitement

    ''' <summary>
    ''' Retourne le signe du nombre
    ''' </summary>
    ''' <param name="nb">Nombre pour lequel on doit retourner le signe</param>
    ''' <returns>True = positif, sinon False</returns>
    ''' <remarks></remarks>
    Public Shared Function getSigne(ByVal nb As Double) As Boolean
        If (nb < 0) Then Return False Else Return True
    End Function

    ''' <summary>
    ''' Retourne si le nb donné est un multiple de 'multiple'
    ''' </summary>
    ''' <param name="nb">Nb pour lequel on doit savoir si c'est un multiple</param>
    ''' <param name="multiple">multiple</param>
    ''' <returns>True = C'est un multiple, sinon False</returns>
    ''' <remarks></remarks>
    Public Shared Function multipleDe(ByVal nb As Double, ByVal multiple As Double) As Boolean
        Return ((nb Mod multiple) = 0)
    End Function

    ''' <summary>
    ''' Le nombre est-il un chiffre pair ?
    ''' </summary>
    ''' <param name="nb">Le nombre</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function estPair(ByVal nb As Integer) As Boolean
        Return ((nb Mod 2) = 0)
    End Function

    ''' <summary>
    ''' Le nombre est-il un chiffre impair ?
    ''' </summary>
    ''' <param name="nb"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function estImpair(ByVal nb As Integer) As Boolean
        Return (Not (estPair(nb)))
    End Function

End Class
