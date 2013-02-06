Public Class convertirDatePAGE

    ''' <summary>
    ''' Converti une date au format PAGE MAASSJHHMM vers une date au format standard (jour/moi/annee heure:minute)
    ''' </summary>
    ''' <param name="datePAGE">La date au format PAGE</param>
    ''' <returns>Date au format standard</returns>
    ''' <remarks></remarks>
    Public Shared Function dateVersFR(ByVal datePAGE As String) As Date
        Dim centenaire As Integer
        Dim annee As Integer
        Dim semaine As Integer
        Dim jour As Integer
        Dim heure As Integer
        Dim minute As Integer
        Dim retour As Date

        centenaire = datePAGE.Substring(0, 1)
        annee = datePAGE.Substring(1, 2)
        semaine = datePAGE.Substring(3, 2)
        jour = datePAGE.Substring(5, 1)
        heure = datePAGE.Substring(6, 2)
        minute = datePAGE.Substring(8, 2)

        If (centenaire > 0) Then
            annee += 2000
        Else
            annee += 1900
        End If
        retour = #1/1/1900#
        retour = retour.AddYears(annee - 1900)
        ' on gere les semaines
        retour = retour.AddDays((7 * (semaine - 1)) + 2)
        ' on gere le jour de la semaine
        retour = retour.AddDays(jour - 1)

        retour = retour.AddHours(heure)
        retour = retour.AddMinutes(minute / 100 * 60)

        Return retour
    End Function

    ''' <summary>
    ''' Converti une date au format standard (jour/mois/annee heure:minute) vers une date au format PAGE MAASSJHHMM
    ''' </summary>
    ''' <param name="dateFR">Date au format standard</param>
    ''' <returns>Date au format PAGE</returns>
    ''' <remarks></remarks>
    Public Shared Function dateVersPAGE(ByVal dateFR As Date) As String
        Dim retour As String
        Dim annee As String
        Dim siecle As Integer
        Dim numSemaine As Integer
        Dim dateDebutAnnee As Date

        dateDebutAnnee = dateFR.AddDays((-dateFR.Day) + 1)
        dateDebutAnnee = dateDebutAnnee.AddMonths((-dateFR.Month) + 1)

        annee = Year(dateFR).ToString
        siecle = annee.Substring(0, 2)
        If (siecle > 19) Then retour = "1" Else retour = "0"
        retour &= annee.ToString.Substring(2, 2)
        numSemaine = Math.Abs(DateDiff(DateInterval.WeekOfYear, dateDebutAnnee, dateFR))
        retour &= Format(numSemaine, "0#")
        retour &= dateFR.DayOfWeek
        retour &= Format(dateFR.Hour, "0#")
        retour &= Format(dateFR.Minute / 60 * 100, "0#")

        Return retour
    End Function

End Class
