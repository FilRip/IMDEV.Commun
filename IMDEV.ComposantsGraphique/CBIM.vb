Imports System.Drawing

Public Class CBIM
    Inherits Infragistics.Win.UltraWinEditors.UltraComboEditor

    Private _autoSizeDropDownList As Boolean

    Public Property autoSizeDropDownList() As Boolean
        Get
            Return _autoSizeDropDownList
        End Get
        Set(ByVal value As Boolean)
            _autoSizeDropDownList = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne l'objet contenu dans cette liste déroulante d'après sa valeur data
    ''' </summary>
    ''' <param name="data">La valeur data à rechercher</param>
    ''' <returns>L'objet, ou nothing si ce data n'a pas été trouvé</returns>
    ''' <remarks></remarks>
    Public Function retourneItem(ByVal data As Object) As Infragistics.Win.ValueListItem
        Dim e As Infragistics.Win.ValueListItem
        For Each e In Items
            If (e.DataValue = data) Then Return e
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Sélectionne automatiquement la première valeur de la liste déroulante
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub selectFirst()
        If (Items.Count > 0) Then
            SelectedItem = Items(0)
        End If
    End Sub

    ''' <summary>
    ''' Retourne la valeur data de l'objet sélectionné si il y en a une de sélectionnée
    ''' </summary>
    ''' <returns>La valeur de l'objet sélectionné dans son type</returns>
    ''' <remarks></remarks>
    Public Function retourneValeur() As Object
        If (SelectedItem Is Nothing) Then Return Text
        Return SelectedItem.DataValue
    End Function

    ''' <summary>
    ''' Ajoute une nouvelle valeur dans la liste déroulante sélectionnable, sans libellé spécial (la valeur devient le libellé également)
    ''' A condition que cette valeur n'existe pas déjà
    ''' </summary>
    ''' <param name="valeur">La nouvelle valeur à ajouter dans la liste déroulante, dans son type</param>
    ''' <remarks></remarks>
    Public Overloads Sub ajouteSiNExistePas(ByVal valeur As Object)
        If (retourneItem(valeur) Is Nothing) Then
            Dim e As New Infragistics.Win.ValueListItem(valeur)
            Items.Add(e)
        End If
    End Sub

    ''' <summary>
    ''' Ajoute un nouvel objet sélectionnable dans la liste déroulante, avec un data et un libellé spécial
    ''' A condition que cette valeur n'existe pas déjà
    ''' </summary>
    ''' <param name="valeur">le data, la valeur, dans son type, de l'objet à rajouter</param>
    ''' <param name="display">Le libellé de cet objet, qui apparait visuellement dans la liste (chaine texte)</param>
    ''' <remarks></remarks>
    Public Overloads Sub ajouteSiNExistePas(ByVal valeur As String, ByVal display As String)
        If (retourneItem(valeur) Is Nothing) Then
            Dim e As New Infragistics.Win.ValueListItem(valeur, display)
            Items.Add(e)
        End If
    End Sub

    ''' <summary>
    ''' Sélectionne automatiquement l'objet dont la valeur/data est spécifié
    ''' </summary>
    ''' <param name="data">La valeur de l'objet à sélectionner dans son type</param>
    ''' <remarks></remarks>
    Public Sub autoSelect(ByVal data As Object)
        SelectedItem = retourneItem(data)
    End Sub

    ''' <summary>
    ''' Sélectionne automatiquement l'objet dont son libellé est connu (texte)
    ''' </summary>
    ''' <param name="data">Le libellé de l'objet à sélectionner</param>
    ''' <remarks></remarks>
    Public Sub autoSelectDisplay(ByVal data As String)
        Dim e As Infragistics.Win.ValueListItem
        For Each e In Items
            If (e.DisplayText = data) Then
                SelectedItem = e
                Exit For
            End If
        Next
    End Sub

    Private Sub CBIM_BeforeDropDown(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.BeforeDropDown
        If (_autoSizeDropDownList) Then
            Dim senderComboBox As CBIM = Me
            Dim width As Integer = senderComboBox.DropDownListWidth
            Dim g As Graphics = senderComboBox.CreateGraphics
            Dim font As Font = senderComboBox.Font
            Dim vertScrollBarWidth As Integer = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
            Dim newWidth As Integer
            For Each s As Object In senderComboBox.Items
                newWidth = (CType(g.MeasureString(s.ToString(), font).Width, Integer) + vertScrollBarWidth)
                If (width < newWidth) Then
                    width = newWidth
                End If
            Next
            senderComboBox.DropDownListWidth = width + 16
        End If
    End Sub

End Class
