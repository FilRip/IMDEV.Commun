' Algo original de EBArtSoft
' modifi�/adapt�/Ajout variable dynamique par Philippe TREILLE
Public Class ExprEval

    'Operateur en cours
    Private Oprd As String
    'Valeur en cours
    Private Value As Double
    'Mot temporaire
    Private Word As String
    Private _listeVariables As New List(Of uneVariableExprEval)

    ''' <summary>
    ''' Class ExprEval. Evaluation d'expression math�matique en dynamique
    ''' avec possibilit�s d'y ajouter des variables en dynamique
    ''' La variable "PI" est ajout�e automatiquement
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
        _listeVariables.Add(New uneVariableExprEval("PI", Math.PI))
    End Sub

    ''' <summary>
    ''' Retourne une �valuation de l'expression
    ''' Exception g�n�r�e si pas le compte de parenth�se ouverte/ferm�e
    ''' </summary>
    ''' <param name="formule">Chaine math�matique � �valu�e</param>
    ''' <returns>Double = �valuation de la chaine</returns>
    ''' <remarks></remarks>
    Public Function CalcEx(ByVal formule As String) As Double
        formule = formule.Replace(".", IMDEV.Conversion.optionsRegionales.retourneParametre(Conversion.optionsRegionales.INFO_LOCALE.SEPARATEUR_DECIMAL)).Replace(",", IMDEV.Conversion.optionsRegionales.retourneParametre(Conversion.optionsRegionales.INFO_LOCALE.SEPARATEUR_DECIMAL))
        If (Not (VerifParenthese(formule))) Then Return 0
        Oprd = ""
        Value = 0
        Word = ""
        '------------------------
        'Buffer de charactere
        Dim Carac As String
        '------------------------
        'Tableau d'operateurs indent�s
        Dim Opr() As String
        'Tableau de valeurs indent�es
        Dim Res() As Double
        '------------------------
        'Compteur d'indentation
        Dim j As Long
        'Variable de boucle
        Dim i As Long

        ReDim Res(0)
        ReDim Opr(0)

        formule = formule & " "
        For i = 0 To formule.Length - 1
            'Recuperation du charactere
            Carac = formule.Substring(i, 1)
            'Selection en fonction de la valeur du charactere
            Select Case Carac
                'Si c'est un chiffre ajoute dans le buffer
                Case "a" To "z"
                    Word &= Carac
                    Exit Select
                Case "A" To "Z"
                    Word &= Carac
                    Exit Select
                Case "0" To "9"
                    Word &= Carac
                    Exit Select
                    'Si c'est un point fait de meme /!\ regional settings /!\
                Case "."
                    Word &= Carac
                    Exit Select
                    'Si c'est un espace calcule l'expression
                Case " "
                    Calc()
                    Exit Select
                    'Si c'est une operation calcule et conserve l'operation en memoire
                Case "+"
                    Calc()
                    Oprd = Carac
                    Exit Select
                Case "-"
                    Calc()
                    Oprd = Carac
                    Exit Select
                Case "*"
                    Calc()
                    Oprd = Carac
                    Exit Select
                Case "/"
                    Calc()
                    Oprd = Carac
                    Exit Select
                Case "^"
                    Calc()
                    Oprd = Carac
                    Exit Select
                Case "\"
                    Calc()
                    Oprd = Carac
                    Exit Select
                    'Si c'est une debut paranthese indente la valeur
                Case "("
                    'Redimentionne le tableau
                    ReDim Preserve Res(j)
                    ReDim Preserve Opr(j)
                    'Sauve la valeur et l'operande
                    Res(j) = Value
                    Opr(j) = Oprd
                    'Increment
                    j = j + 1
                    'Initialize les variables temporaires
                    Value = 0
                    Word = ""
                    Oprd = ""
                    Exit Select
                    'Si c'est une fin de paranthere decremente la hierarchie
                Case ")"
                    'Si on n'est en indentation "positive"
                    If (j) Then
                        'Calcule l'expression
                        Calc()
                        'Decremente
                        j -= 1
                        'Si on dispose d'un operateur
                        If (Opr(j) <> "") Then
                            'Calcule
                            Select Case Opr(j)
                                Case "+"
                                    Value = Res(j) + Value
                                    Exit Select
                                Case "-"
                                    Value = Res(j) - Value
                                    Exit Select
                                Case "*"
                                    Value = Res(j) * Value
                                    Exit Select
                                Case "/"
                                    Value = Res(j) / Value
                                    Exit Select
                                Case "\"
                                    Value = Res(j) \ Value
                                    Exit Select
                                Case "^"
                                    Value = Res(j) ^ Value
                                    Exit Select
                                    '-----------------------------------
                                    'Extra fonction
                                Case "MOD"
                                    Value = Res(j) Mod Value
                                    Exit Select
                                Case "AND"
                                    Value = Res(j) And Value
                                    Exit Select
                                Case "XOR"
                                    Value = Res(j) Xor Value
                                    Exit Select
                                Case "OR"
                                    Value = Res(j) Or Value
                                    Exit Select
                                    '-----------------------------------
                            End Select
                        End If
                    End If
                    Exit Select
                    'Sinon recupere la valeur pour analyse ulterieure
                Case Else
                    Word &= Carac
                    Exit Select
            End Select
        Next
        'That it ! Renvoi le resultat ! (En double precision)
        Return Value
    End Function

    Private Sub Calc()
        ' v�rif si variable
        If ((Word <> "") And (Word <> " ")) Then
            Dim prem As String
            Dim var As uneVariableExprEval
            prem = Word.Substring(0, 1).ToLower
            If ((Asc(prem) >= Asc("a")) And (Asc(prem) <= Asc("z"))) Then
                For Each var In _listeVariables
                    If (var.nom.ToLower = Word.ToLower) Then
                        Word = var.valeur.ToString
                        Exit For
                    End If
                Next
            End If
        End If
        ' fin v�rif variable

        'Si on dispose d'un operateur
        If (Oprd = "") Then
            'Si le mot est un chiffre
            If (IsNumeric(Word)) Then
                'La valeur egale le mot
                Value = CDbl(Word)
            Else
                'L'operateur egale le mot
                If (Word.Length) Then Oprd = UCase(Word)
            End If
        Else
            'Si le mot est numerique
            If (IsNumeric(Word)) Then
                'Calcule
                Select Case Oprd
                    Case "+"
                        Value += CDbl(Word)
                    Case "-"
                        Value -= CDbl(Word)
                    Case "*"
                        Value *= CDbl(Word)
                    Case "/"
                        Value /= CDbl(Word)
                    Case "\"
                        Value \= CDbl(Word)
                    Case "^"
                        Value ^= CDbl(Word)
                        '---------------------------------------
                        'Extra fonction
                    Case "MOD"
                        Value = Value Mod CDbl(Word)
                    Case "AND"
                        Value = Value And CDbl(Word)
                    Case "XOR"
                        Value = Value Xor CDbl(Word)
                    Case "OR"
                        Value = Value Or CDbl(Word)
                        '---------------------------------------
                End Select
                'Initialise l'operateur
                Oprd = ""
            Else
                'L'operateur prend la valeur du mot
                If (Word.Length) Then Oprd = Word.ToUpper
            End If
        End If
        'Initialise le mot (buffer d'expression)
        Word = ""
    End Sub

    Private Function VerifParenthese(ByRef texte As String) As Boolean
        Dim fermee As String()
        Dim ouverte As String()

        texte = texte.Replace("[", "(")
        texte = texte.Replace("]", ")")
        fermee = texte.Split(")")
        ouverte = texte.Split("(")
        Try
            If (fermee.Length = ouverte.Length) Then Return True
            Throw New Exception("Erreur de parenth�se(s)")
        Catch ex As Exception
            MsgBox(ex.Message)
#If DEBUG Then
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
#End If
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Ajoute une variable en dynamique (objet uneVariable)
    ''' </summary>
    ''' <param name="var">L'objet contenant la variable (voir objet uneVariable)</param>
    ''' <returns>Vrai si ajout possible. Faux si le nom de la variable existe d�j� dans cet objet ExprEval</returns>
    ''' <remarks></remarks>
    Public Function ajoutVariable(ByVal var As uneVariableExprEval) As Boolean
        Dim vari As uneVariableExprEval
        For Each vari In _listeVariables
            If (vari.nom = var.nom) Then Return False
        Next
        _listeVariables.Add(var)
        Return True
    End Function

    ''' <summary>
    ''' Supprime une variable dynamique dont le nom est sp�cifi�e en param�tre.
    ''' Aucun retour. Si la variable n'existe pas, elle n'est pas supprim�e, pas d'exception g�n�r�e
    ''' </summary>
    ''' <param name="nom">Nom de la variable � supprimer</param>
    ''' <remarks></remarks>
    Public Sub supprimeVariable(ByVal nom As String)
        Dim var As uneVariableExprEval
        For Each var In _listeVariables
            If (var.nom = nom) Then
                _listeVariables.Remove(var)
                var = Nothing
                Exit For
            End If
        Next
    End Sub

End Class
