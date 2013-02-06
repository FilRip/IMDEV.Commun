Public Class gestionDate

    Public Shared Function EstJourFerie(ByVal Jour As Date) As Boolean
        Dim JJ, AA, MM As Integer
        Dim NbOr, Epacte As Integer
        Dim PLune, Paques, Ascension, Pentecote As Date

        JJ = Jour.Day
        MM = Jour.Month
        AA = Jour.Year

        If (JJ = 1) And (MM = 1) Then Return True '1 Janvier
        If (JJ = 1) And (MM = 5) Then Return True '1 Mai
        If (JJ = 8) And (MM = 5) Then Return True '8 Mai
        If (JJ = 14) And (MM = 7) Then Return True '14 Juillet
        If (JJ = 15) And (MM = 8) Then Return True '15 Août
        If (JJ = 1) And (MM = 11) Then Return True '1 Novembre
        If (JJ = 11) And (MM = 11) Then Return True '11 Novembre
        If (JJ = 25) And (MM = 12) Then Return True '25 Décembre

        NbOr = (AA Mod 19) + 1
        Epacte = CType((11 * NbOr - (3 + Int((2 + Int(AA / 100)) * 3 / 7))) Mod 30, Integer)
        PLune = CDate("19/04/" & AA)
        PLune = PLune.AddDays(-((Epacte + 6) Mod 30))
        If Epacte = 24 Then PLune = PLune.AddDays(-1)
        If Epacte = 25 And (AA >= 1900 And AA < 2000) Then PLune = PLune.AddDays(-1)

        Paques = PLune.AddDays(-Weekday(PLune) + vbMonday + 7)   'Paques
        If JJ = Paques.Day And MM = Paques.Month Then Return True

        Ascension = Paques.AddDays(38)   'Ascension
        If JJ = Ascension.Day And MM = Ascension.Month Then Return True

        Pentecote = Ascension.AddDays(11)   'Pentecote
        If JJ = Pentecote.Day And MM = Pentecote.Month Then Return True

        Return False
    End Function

    ''' <summary>
    ''' Retourne le numéro de semaine d'une date/jour spécifié
    ''' </summary>
    ''' <param name="laDate">La date auquelle on veut le numéro de semaine</param>
    ''' <param name="norme">La norme ISO a utilisé. Optionel, par défaut mis sur norme Européenne</param>
    ''' <returns>Le numéro de semaine de l'année</returns>
    ''' <remarks></remarks>
    Public Shared Function numSemaine(ByVal laDate As Date, Optional ByVal norme As Microsoft.VisualBasic.FirstWeekOfYear = FirstWeekOfYear.FirstFourDays) As Integer
        Return DatePart(DateInterval.WeekOfYear, laDate, FirstDayOfWeek.Monday, norme)
    End Function

    ''' <summary>
    ''' Retourne la date exacte du premier jour (lundi) d'un numéro de semaine donné
    ''' </summary>
    ''' <param name="semaine">Numéro de la semaine</param>
    ''' <param name="annee">Pour quelle année</param>
    ''' <param name="norme">Optionelle, norme ISO a respecter, par défaut norme européenne</param>
    ''' <returns>Une date (format date)</returns>
    ''' <remarks></remarks>
    Public Shared Function premierJour(ByVal semaine As Integer, ByVal annee As Integer, Optional ByVal norme As Microsoft.VisualBasic.FirstWeekOfYear = FirstWeekOfYear.FirstFourDays) As Date
        Dim retour As Date

        retour = New DateTime(annee, 1, 1)
        While (DatePart(DateInterval.WeekOfYear, retour, FirstDayOfWeek.Monday, norme) <> semaine)
            retour = retour.AddDays(7)
        End While
        Dim numJour As Integer = DatePart(DateInterval.Weekday, retour, FirstDayOfWeek.Monday)
        If (numJour > 1) Then retour = retour.AddDays(-(numJour - 1))
        Return retour
    End Function

End Class
