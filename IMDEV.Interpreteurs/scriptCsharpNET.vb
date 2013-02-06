Imports System.CodeDom

Public Class scriptCsharpNET
    Inherits Microsoft.CSharp.CSharpCodeProvider

    Public Function interpreteFichier(ByVal nomFichier As String) As Compiler.CompilerResults
        Try
            Dim _parametresAssembly As Compiler.CompilerParameters
            If ((nomFichier.StartsWith(".")) Or (nomFichier.StartsWith("\"))) Then nomFichier = My.Application.Info.DirectoryPath() & nomFichier
            If (IO.File.Exists(nomFichier)) Then
                _parametresAssembly = New Compiler.CompilerParameters
                _parametresAssembly.ReferencedAssemblies.Add("system.dll")
                _parametresAssembly.ReferencedAssemblies.Add("system.xml.dll")
                _parametresAssembly.ReferencedAssemblies.Add("system.data.dll")
                _parametresAssembly.ReferencedAssemblies.Add("system.windows.forms.dll")
                _parametresAssembly.ReferencedAssemblies.Add(My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".exe")
                _parametresAssembly.CompilerOptions = "/t:library"
                _parametresAssembly.GenerateInMemory = True
                Return CompileAssemblyFromFile(_parametresAssembly, nomFichier)
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Public Function interpreteTexte(ByVal texte As String) As Boolean
        Try
            Dim script As String
            script = "using System" & vbCrLf
            script &= "using System.Xml" & vbCrLf
            script &= "using System.Data" & vbCrLf
            ' Build a little wrapper code, with our passed in code in the middle 
            script &= "Namespace dValuate" & vbCrLf
            script &= "Class EvalRunTime " & vbCrLf
            script &= "Public Function EvaluateIt() As Object " & vbCrLf
            ' Insert our dynamic code
            script &= texte & vbCrLf
            script &= "End Function " & vbCrLf
            script &= "End Class " & vbCrLf
            script &= "End Namespace" & vbCrLf
            Dim _parametresAssembly As Compiler.CompilerParameters
            _parametresAssembly = New Compiler.CompilerParameters
            _parametresAssembly.GenerateInMemory = True
            _parametresAssembly.ReferencedAssemblies.Add("system.dll")
            _parametresAssembly.ReferencedAssemblies.Add("system.xml.dll")
            _parametresAssembly.ReferencedAssemblies.Add("system.data.dll")
            _parametresAssembly.ReferencedAssemblies.Add("system.windows.forms.dll")
            _parametresAssembly.ReferencedAssemblies.Add(My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".exe")
            _parametresAssembly.CompilerOptions = "/t:library"
            Dim result As Compiler.CompilerResults
            result = CompileAssemblyFromSource(_parametresAssembly, script)
            If (result.Errors.Count = 0) Then
                Dim obj As Object
                Dim method As System.Reflection.MethodInfo
                obj = result.CompiledAssembly.CreateInstance("dValuate.EvalRunTime")
                method = obj.GetType().GetMethod("EvaluateIt")
                method.Invoke(obj, Nothing)
                Return True
            End If
        Catch ex As Exception
        End Try
        Return False
    End Function

End Class
