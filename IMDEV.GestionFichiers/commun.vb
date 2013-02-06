Public Class commun

    Public Shared Function nomConforme(ByVal nomFichier As String, Optional ByVal remplacement As String = "_") As String
        ' INFO : Gérer les dossiers/sous dossiers ?! autrement dit un chemin complet envoyé dans 'nomFichier' 
        nomFichier = nomFichier.Replace("/", remplacement)
        nomFichier = nomFichier.Replace("\", remplacement)
        nomFichier = nomFichier.Replace(":", remplacement)
        nomFichier = nomFichier.Replace("*", remplacement)
        nomFichier = nomFichier.Replace("?", remplacement)
        nomFichier = nomFichier.Replace("<", remplacement)
        nomFichier = nomFichier.Replace(">", remplacement)
        nomFichier = nomFichier.Replace("|", remplacement)
        nomFichier = nomFichier.Replace(Chr(34), remplacement)
        Return nomFichier
    End Function

End Class
