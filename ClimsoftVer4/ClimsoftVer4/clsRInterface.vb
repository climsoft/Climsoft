Imports System.IO

Imports RDotNet
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks


Public Class clsRInterface
    ' R interface class
    Dim R_HOME As String = "C:\Program Files\R\R-3.2.0"  ' Default location of R home directory
    Dim systemPath As String = System.Environment.GetEnvironmentVariable("PATH")
    Dim rPath As String

    Sub setUp()
        ' TODO: move this environment setUp out of this class and into CLIMSOFT initialisation
        ' CLIMSOFT should know whether R is available and provide options accordingly
        If String.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("R_HOME")) Then
            ' The R_HOME system environment variable is not set, therefore set it here
            System.Environment.SetEnvironmentVariable("R_HOME", R_HOME)
        Else
            ' R_HOME is already set, therefore update our default
            R_HOME = System.Environment.GetEnvironmentVariable("R_HOME")
        End If
        ' Add the correct version of R to the system path
        Dim rPath = If(System.Environment.Is64BitProcess, Path.Combine(R_HOME, "bin\x64"), Path.Combine(R_HOME, "bin\i386\"))
        If Directory.Exists(rPath) = False Then
            Throw New DirectoryNotFoundException(String.Format("Could not find the specified path to the directory containing your R installation (R.dll): {0}", rPath))
        End If
        ' Update system path
        systemPath = String.Format("{0}{1}{2}", rPath, System.IO.Path.PathSeparator, systemPath)
        System.Environment.SetEnvironmentVariable("PATH", systemPath)
    End Sub

    Sub example(engine As REngine, myChoice As String)

        Select Case myChoice
            Case "Hello"
                Dim charVec As CharacterVector = engine.CreateCharacterVector({"Hello, R world!, .NET speaking"})
                engine.SetSymbol("greetings", charVec)
                engine.Evaluate("str(greetings)")
                Dim a As String() = engine.Evaluate("'Hi there .NET, from the R engine'").AsCharacter().ToArray()
                MsgBox(String.Format("R answered: '{0}'", a(0)))

            Case "T-test"
                Dim group1 As NumericVector = engine.CreateNumericVector(New Double() {30.02, 29.99, 30.11, 29.97, 30.01, 29.99})
                engine.SetSymbol("group1", group1)
                ' Direct parsing from R script.
                Dim group2 As NumericVector = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric

                Dim testResult As GenericVector = engine.Evaluate("t.test(group1, group2)").AsList
                Dim p As Double = testResult("p.value").AsNumeric.First
                Console.WriteLine("Group1: [{0}]", String.Join(", ", group1))
                Console.WriteLine("Group2: [{0}]", String.Join(", ", group2))
                Console.WriteLine("P-value = {0:0.000}", p)
                MsgBox("P-value =" & p)

            Case "DataFrame-Plot"
                Dim group1 As NumericVector = engine.CreateNumericVector(New Double() {30.02, 29.99, 30.11, 29.97, 30.01, 29.99})
                engine.SetSymbol("group1", group1)
                'Direct parsing from R script.
                Dim group2 As NumericVector = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric
                Console.WriteLine("Group1: [{0}]", String.Join(", ", group1))
                ' TODO: If the file does not exist in the location provided then no error is given
                engine.Evaluate("source('rVbClimsoft.R')")
                Dim resultNew As DataFrame = engine.Evaluate("R.dataframe(group1,group2)").AsDataFrame
                'to push a dataframe to R you need to use SetSymbol
                engine.SetSymbol("resultNew", resultNew)
                engine.Evaluate("plot.df(resultNew)")

            Case "DataFrame"
                Dim testData As DataFrame = engine.Evaluate("testData<-data.frame( 'test' = 1, 'test2'=2, 'test3' =3)").AsDataFrame
                engine.SetSymbol("testData", testData)
                ' Dim xy As String = engine.Evaluate("xy<-testData[,1]").AsCharacter().ToArray()
                'MsgBox(xy)
                'engine.Evaluate("write.table('D:/test.txt',testData)")

            Case Else
                MsgBox(String.Format("Unrecognised option {}", myChoice))
        End Select
    End Sub


    Sub New()
        ' TODO: move environment setUp to CLIMSOFT initialisation
        setUp()
        ' When a new clsRInterface is created, and R engine is started
        Using engine As REngine = REngine.GetInstance()
            engine.Initialize()

            ' call one of the available examples:
            example(engine, "Hello")
            ' example(engine, "T-test")
            ' example(engine, "DataFrame-Plot")
            ' example(engine, "DataFrame")

        End Using
    End Sub

    ' TODO: Add destructor to dispose of engine, see https://msdn.microsoft.com/en-us/library/2z08e49e%28v=vs.90%29.aspx
    ' You should always dispose of the REngine properly.
    ' After disposing of the engine, you cannot reinitialize nor reuse it
    ' engine.Dispose()
End Class
