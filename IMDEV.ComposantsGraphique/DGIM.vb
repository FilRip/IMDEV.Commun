Public Class DGIM
    Inherits Infragistics.Win.UltraWinGrid.UltraGrid

    Private _datasource As New Infragistics.Win.UltraWinDataSource.UltraDataSource
    Private _selectOnRightClick As Boolean
    Private _activeAutoFitAll As Boolean = True
    Private _autoFitRows As Boolean = True

    ''' <summary>
    ''' Active ou non le fait que les colonnes sont toutes retaillées pendant l'écriture des lignes
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property activeAutoFitAll() As Boolean
        Get
            Return _activeAutoFitAll
        End Get
        Set(ByVal value As Boolean)
            _activeAutoFitAll = value
        End Set
    End Property

    Public Property autoFitRows() As Boolean
        Get
            Return _autoFitRows
        End Get
        Set(ByVal value As Boolean)
            _autoFitRows = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        DataSource = _datasource
    End Sub

    ''' <summary>
    ''' Définir si la grille est en lecture seule ou non
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property lectureSeule() As Boolean
        Get
            Return _datasource.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _datasource.ReadOnly = value
        End Set
    End Property

    ''' <summary>
    ''' Ajoute une colonne, manuellement, portant un nom spécifique, de type chaines
    ''' </summary>
    ''' <param name="nom">Nom de la colonne (sera en titre)</param>
    ''' <param name="lectureSeule">Spécifier si le champ est en lecture seule ou non (impossible de modifier par l'utilisateur)</param>
    ''' <remarks></remarks>
    Public Overloads Sub ajouteUneColonne(ByVal nom As String, Optional ByVal lectureSeule As Boolean = False)
        ajouteUneColonne(nom, GetType(System.String), lectureSeule)
    End Sub

    ''' <summary>
    ''' Ajoute une colonne, manuellement, portant un nom spécifique, et un type spécifique
    ''' </summary>
    ''' <param name="nom">Le nom/titre de la colonne</param>
    ''' <param name="deType">Le type de contenu de cette colonne</param>
    ''' <param name="lectureSeule">Spécifier si le champ est en lecture seule ou non (impossible de modifier par l'utilisateur)</param>
    ''' <remarks></remarks>
    Public Overloads Sub ajouteUneColonne(ByVal nom As String, ByVal deType As Type, Optional ByVal lectureSeule As Boolean = False)
        _datasource.Band.Columns.Add(nom, deType)
        _datasource.Band.Columns(_datasource.Band.Columns.Count - 1).ReadOnly = lectureSeule
    End Sub

    ''' <summary>
    ''' Supprimer une colonne, d'après son nom/titre
    ''' </summary>
    ''' <param name="nom">Le nom de la colonne à supprimer</param>
    ''' <remarks></remarks>
    Public Sub supprimeUneColonne(ByVal nom As String)
        Try
            _datasource.Band.Columns.Remove(nom)
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Supprime toutes les colonnes
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub supprimeColonnes()
        _datasource.Band.Columns.Clear()
    End Sub

    ''' <summary>
    ''' Remplir une case spécifique (ou ajouter une nouvelle ligne)
    ''' </summary>
    ''' <param name="ligne">Le numéro de la ligne de base zéro. Si -1 = création d'une nouvelle ligne à la fin</param>
    ''' <param name="colonne">Le numéro de la colonne</param>
    ''' <param name="contenu">Le contenu de la cellule, dans son type</param>
    ''' <returns>Le numéro de la ligne, si on a mis -1 en ligne et donc création d'une nouvelle ligne</returns>
    ''' <remarks>Si la colonne n'existe pas, la ligne est quand même créée dans le cas ou ligne=-1</remarks>
    Public Function remplirCase(ByVal ligne As Integer, ByVal colonne As Integer, ByVal contenu As Object) As Integer
        If (ligne < 0) Then
            _datasource.Rows.Add()
            ligne = _datasource.Rows.Count - 1
        End If
        Try
            _datasource.Rows(ligne).Item(colonne) = contenu
        Catch ex As Exception
        End Try
        Return ligne
    End Function

    ''' <summary>
    ''' Lire, manuellement, le contenu d'une case de la grille
    ''' </summary>
    ''' <param name="ligne">Numéro de la ligne</param>
    ''' <param name="colonne">Numéro de la colonne</param>
    ''' <returns>Le contenu de la case, dans son type, ou Nothing en cas d'erreur</returns>
    ''' <remarks></remarks>
    Public Function lireCase(ByVal ligne As Integer, ByVal colonne As Integer) As Object
        Try
            Return _datasource.Rows(ligne).Item(colonne)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Retourne le nombre de ligne total de la grille
    ''' </summary>
    ''' <returns>Un chiffre, le nombre de ligne</returns>
    ''' <remarks></remarks>
    Public Function nbLigne() As Integer
        Try
            Return _datasource.Rows.Count
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Retourne le numéro de la colonne d'après son nom
    ''' </summary>
    ''' <param name="nom">Le nom de la colonne a rechercher</param>
    ''' <returns>Le numéro de la colonne de base zéro, ou -1 si introuvable</returns>
    ''' <remarks></remarks>
    Public Function numColonne(ByVal nom As String) As Integer
        Try
            Return _datasource.Band.Columns(nom).Index
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Retourne le nom de la colonne d'après son numéro de base zéro
    ''' </summary>
    ''' <param name="numColonne">Le numéro de la colonne</param>
    ''' <returns>Le nom, en texte, de la colonne, ou chaine vide si le numéro de la colonne n'existe pas</returns>
    ''' <remarks></remarks>
    Public Function nomColonne(ByVal numColonne As Integer) As String
        Try
            Return _datasource.Band.Columns(numColonne).Key
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Retourne le nombre de colonne contenu dans la grille actuellement
    ''' </summary>
    ''' <returns>Le nombre de colonne</returns>
    ''' <remarks></remarks>
    Public Function nbColonne() As Integer
        Try
            Return _datasource.Band.Columns.Count
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Change la couleur de fond d'une ligne en particulier
    ''' </summary>
    ''' <param name="numLigne">Le numéro de la ligne de base zéro</param>
    ''' <param name="couleur">Le code couleur pour ce nouveau fond</param>
    ''' <remarks></remarks>
    Public Sub changeCouleur(ByVal numLigne As Integer, ByVal couleur As System.Drawing.Color)
        Try
            If (Not (ligneExiste(numLigne))) Then Exit Sub
            Rows(numLigne).Appearance.BackColor = couleur
            Rows(numLigne).Appearance.BackColor2 = couleur
        Catch ex As Exception
#If DEBUG Then
            MsgBox(ex.Message)
#End If
        End Try
    End Sub

    ''' <summary>
    ''' Change la couleur d'une seule cellule de toute la grille
    ''' </summary>
    ''' <param name="numLigne">Numéro de ligne de la cellule à changer</param>
    ''' <param name="numColonne">Numéro de colonne de la cellule à changer</param>
    ''' <param name="couleur">Code couleur, nouvelle couleur de fond de cette cellule</param>
    ''' <remarks></remarks>
    Public Sub changeCouleurCellule(ByVal numLigne As Integer, ByVal numColonne As Integer, ByVal couleur As System.Drawing.Color)
        Try
            If ((Not (ligneExiste(numLigne))) OrElse (Not (colonneExiste(numColonne)))) Then Exit Sub
            Rows(numLigne).Cells(numColonne).Appearance.BackColor = couleur
            Rows(numLigne).Cells(numColonne).Appearance.BackColor2 = couleur
        Catch ex As Exception
#If DEBUG Then
            MsgBox(ex.Message)
#End If
        End Try
    End Sub

    Private Sub DGIM_BeforeEnterEditMode(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.BeforeEnterEditMode
        Try
            If (_datasource.Band.Columns(ActiveCell.Column.Index).ReadOnly) Then e.Cancel = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGIM_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Me.InitializeLayout
        If (_activeAutoFitAll) Then e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        DisplayLayout.Override.RowSizing = IIf(_autoFitRows, Infragistics.Win.UltraWinGrid.RowSizing.AutoFree, Infragistics.Win.UltraWinGrid.RowSizing.Fixed)
    End Sub

    ''' <summary>
    ''' Vide le contenu (les lignes) de la grille
    ''' </summary>
    ''' <remarks>Les colonnes restent</remarks>
    Public Sub vide()
        If (_datasource.Rows IsNot Nothing) Then
            _datasource.Rows.Clear()
        End If
    End Sub

    ''' <summary>
    ''' Active ou non le fait qu'un clique droit sélectionne la ligne ou la souris se trouve (comme un clique gauche, mais sans interaction comme l'édition par exemple)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Attention si un controle utilise le clique droit aussi, comme le menu contextuel sur cette même grille, ce click droit pour sélection ne marche plus, il faut redéclarer le handler : 'addhandler CetteGrille.MouseClick, addressof DGIM_MouseClick'</remarks>
    Public Property selectSurClickDroit()
        Get
            Return _selectOnRightClick
        End Get
        Set(ByVal value)
            _selectOnRightClick = value
        End Set
    End Property

    Protected Sub DGIM_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If (_selectOnRightClick) Then
            If (e.Button <> Windows.Forms.MouseButtons.Left) Then
                Dim row As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
                Dim element As Infragistics.Win.UIElement = Nothing

                element = DisplayLayout.UIElement.ElementFromPoint(New System.Drawing.Point(e.X, e.Y))

                If (element IsNot Nothing) Then row = element.GetContext(GetType(Infragistics.Win.UltraWinGrid.UltraGridRow))

                If (row IsNot Nothing) AndAlso (row.IsDataRow) Then
                    ActiveRow = row
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Place une colonne en particulier en lecture seule (ou non)
    ''' </summary>
    ''' <param name="numColonne">Numéro de la colonne</param>
    ''' <param name="lectureSeule">Active ou non la lecture seule de ce champ</param>
    ''' <remarks></remarks>
    Public Overloads Sub champEnLectureSeule(ByVal numColonne As Integer, Optional ByVal lectureSeule As Boolean = True)
        If (Not (colonneExiste(numColonne))) Then Exit Sub
        _datasource.Band.Columns(numColonne).ReadOnly = lectureSeule
    End Sub

    ''' <summary>
    ''' Place une colonne en particulier en lecture seule (ou non)
    ''' </summary>
    ''' <param name="nomColonne">Nom de la colonne</param>
    ''' <param name="lectureSeule">Active ou non la lecture seule de ce champ</param>
    ''' <remarks></remarks>
    Public Overloads Sub champEnLectureSeule(ByVal nomColonne As String, Optional ByVal lectureSeule As Boolean = True)
        If (Not (colonneExiste(nomColonne))) Then Exit Sub
        champEnLectureSeule(_datasource.Band.Columns(nomColonne).Index, lectureSeule)
    End Sub

    ''' <summary>
    ''' Cache ou non la barre de tri au dessus, auto gérée par infragistics
    ''' </summary>
    ''' <param name="cache">True = cache, False = Affiche</param>
    ''' <remarks></remarks>
    Public Sub cacheBarreDeTri(ByVal cache As Boolean)
        DisplayLayout.GroupByBox.Hidden = cache
    End Sub

    ''' <summary>
    ''' Défini une colonne comme étant modifiable par une liste déroulante seulement
    ''' </summary>
    ''' <param name="numColonne">Le numéro de la colonne</param>
    ''' <param name="listeValeur">La liste des valeurs qui seront dans la liste déroulante</param>
    ''' <remarks></remarks>
    Public Overloads Sub listeDeroulanteColonne(ByVal numColonne As Integer, ByVal listeValeur As List(Of Infragistics.Win.ValueListItem))
        Dim vl As New Infragistics.Win.ValueList

        If (Not (colonneExiste(numColonne))) Then Exit Sub
        For Each va As Infragistics.Win.ValueListItem In listeValeur
            vl.ValueListItems.Add(va)
        Next
        DisplayLayout.Bands(0).Columns(numColonne).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        DisplayLayout.Bands(0).Columns(numColonne).ValueList = vl
    End Sub

    ''' <summary>
    ''' Défini une colonne comme étant modifiable par une liste déroulante seulement
    ''' </summary>
    ''' <param name="nomColonne">Le nom de la colonne</param>
    ''' <param name="listeValeur">La liste des valeurs qui seront dans la liste déroulante</param>
    ''' <remarks></remarks>
    Public Overloads Sub listeDeroulanteColonne(ByVal nomColonne As String, ByVal listeValeur As List(Of Infragistics.Win.ValueListItem))
        If (Not (colonneExiste(nomColonne))) Then Exit Sub
        listeDeroulanteColonne(_datasource.Band.Columns(nomColonne).Index, listeValeur)
    End Sub

    ''' <summary>
    ''' Change l'état GRAS de la police d'une colonne en particulier
    ''' </summary>
    ''' <param name="numColonne">Numéro de la colonne</param>
    ''' <param name="gras">Gras ou pas pour cette colonne</param>
    ''' <remarks></remarks>
    Public Sub changePoliceGrasColonne(ByVal numColonne As Integer, ByVal gras As Boolean)
        If (Not (colonneExiste(numColonne))) Then Exit Sub
        DisplayLayout.Bands(0).Columns(numColonne).CellAppearance.FontData.Bold = IIf(gras, Infragistics.Win.DefaultableBoolean.True, Infragistics.Win.DefaultableBoolean.False)
    End Sub

    ''' <summary>
    ''' Ajoute une ligne à une position spécifique
    ''' </summary>
    ''' <param name="numLigne">Numéro de la ligne (de base zéro) ou l'on doit ajouter une nouvelle</param>
    ''' <remarks></remarks>
    Public Sub ajouteLigne(ByVal numLigne As Integer)
        If (numLigne < 0) Then Exit Sub
        If (numLigne > nbLigne() - 1) Then
            _datasource.Rows.Add()
        Else
            _datasource.Rows.Insert(numLigne)
        End If
    End Sub

    Public Overloads Sub cacheColonne(ByVal numColonne As Integer, ByVal cache As Boolean)
        If (Not (colonneExiste(numColonne))) Then Exit Sub
        Me.DisplayLayout.Bands(0).Columns(numColonne).Hidden = cache
    End Sub

    Public Overloads Sub cacheColonne(ByVal nomColonne As String, ByVal cache As Boolean)
        If (Not (colonneExiste(nomColonne))) Then Exit Sub
        Me.DisplayLayout.Bands(0).Columns(nomColonne).Hidden = cache
    End Sub

    Public Overloads Sub changeTaillePolice(ByVal numLigne As Integer, ByVal taille As Integer)
        If (Not (ligneExiste(numLigne))) Then Exit Sub
        Rows(numLigne).Appearance.FontData.SizeInPoints = taille
    End Sub

    Public Overloads Sub changeTaillePolice(ByVal numLigne As Integer, ByVal numColonne As Integer, ByVal taille As Integer)
        If (Not (ligneExiste(numLigne))) Then Exit Sub
        If (Not (colonneExiste(numColonne))) Then Exit Sub
        Rows(numLigne).Cells(numColonne).Appearance.FontData.SizeInPoints = taille
    End Sub

    Private Overloads Function colonneExiste(ByVal numColonne As Integer) As Boolean
        If ((numColonne >= 0) AndAlso (numColonne <= nbColonne() - 1)) Then Return True
        Return False
    End Function

    Private Overloads Function colonneExiste(ByVal nomColonne As String) As Boolean
        If (numColonne(nomColonne) >= 0) Then Return True
        Return False
    End Function

    Private Function ligneExiste(ByVal numLigne As Integer) As Boolean
        If ((numLigne >= 0) AndAlso (numLigne <= nbLigne() - 1)) Then Return True
        Return False
    End Function

    Public Overloads Sub changeCouleurPolice(ByVal numLigne As Integer, ByVal couleur As System.Drawing.Color)
        If (Not (ligneExiste(numLigne))) Then Exit Sub
        Rows(numLigne).Appearance.ForeColor = couleur
    End Sub

    Public Overloads Sub changeCouleurPolice(ByVal numLigne As Integer, ByVal numColonne As Integer, ByVal couleur As System.Drawing.Color)
        If (Not (ligneExiste(numLigne))) Then Exit Sub
        If (Not (colonneExiste(numColonne))) Then Exit Sub
        Rows(numLigne).Cells(numColonne).Appearance.ForeColor = couleur
    End Sub

End Class
