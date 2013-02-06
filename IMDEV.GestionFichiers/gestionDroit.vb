Imports System.Security

Public Class gestionDroit

    Public Shared Function lireDroit(ByVal fichier As String, Optional ByVal avecExplicite As Boolean = True, Optional ByVal avecHeritage As Boolean = True) As models.droitGlobalNTFS
        Dim retour As models.droitGlobalNTFS = Nothing
        Dim f As models.droitNTFS

        If (IO.Directory.Exists(fichier)) Then
            Dim a As AccessControl.DirectorySecurity
            a = IO.Directory.GetAccessControl(fichier)
            For Each ar As AccessControl.FileSystemAccessRule In a.GetAccessRules(avecExplicite, avecHeritage, GetType(Security.Principal.NTAccount))
                f = New models.droitNTFS
                f.nom = ar.IdentityReference.Value
                f.emplacement = fichier
                f.typeEmplacement = models.droitNTFS.TYPE_FICHIER.REPERTOIRE
                ' TODO Lire droit repertoire
                f.acces = ar.FileSystemRights
                f.typeAcces = ar.AccessControlType
                'ar.InheritanceFlags
                f.estDroitHerite = ar.IsInherited
                retour.listeDroit.Add(f)
            Next
        ElseIf (IO.File.Exists(fichier)) Then
            Dim a As AccessControl.FileSecurity
            a = IO.File.GetAccessControl(fichier)
            For Each ar As AccessControl.FileSystemAccessRule In a.GetAccessRules(avecExplicite, avecHeritage, GetType(Security.Principal.NTAccount))
                f = New models.droitNTFS
                f.nom = ar.IdentityReference.Value
                f.emplacement = fichier
                f.typeEmplacement = models.droitNTFS.TYPE_FICHIER.FICHIER
                f.acces = ar.FileSystemRights
                f.typeAcces = ar.AccessControlType
                f.estDroitHerite = ar.IsInherited
                ' TODO Lire droit fichier
                retour.listeDroit.Add(f)
            Next
        End If

        Return retour
    End Function

    Public Overloads Shared Function ajouteDroit(ByVal fichier As String, ByVal droit As models.droitNTFS) As Boolean
        droit.emplacement = fichier
        Return droit.sauve()
    End Function

    Public Overloads Shared Function ajouteDroit(ByVal emplacement As String, ByVal listeDroit As models.droitGlobalNTFS) As Boolean
        For Each droit As models.droitNTFS In listeDroit.listeDroit
            If (Not (ajouteDroit(emplacement, droit))) Then Return False
        Next
        Return True
    End Function

    Public Overloads Shared Function ajouteDroit(ByVal fichier As String, ByVal nom As String, ByVal acces As AccessControl.FileSystemRights, ByVal typeAcces As AccessControl.AccessControlType) As Boolean
        Dim droit As New models.droitNTFS
        droit.nom = nom
        droit.typeAcces = typeAcces
        droit.acces = acces
        Return ajouteDroit(fichier, droit)
    End Function

End Class
