'bo qua loi
On Error Resume Next

' dieu kien can
Set WshShell = WScript.CreateObject("WScript.Shell")
dim fs:set fs= CreateObject("Scripting.FileSystemObject")

' cai dat thu muc
CreateFolder(GetNameFolder(WScript.ScriptFullName) & "\Reality")
CreateFolder(GetNameFolder(WScript.ScriptFullName) & "\Message")

' cai dat file
CreateFile(GetNameFolder(WScript.ScriptFullName) & "\reality.txt")
' thuc thi lenh cmd bang file
RunBatFile GetNameFolder(WScript.ScriptFullName) & "\cmd.bat","cd Reality" & vbCrLf & "dir /b > " & GetNameFolder(WScript.ScriptFullName) & "\reality.txt",strFileData

' bien
Dim strSearch, strFileData, strLink, strLinkBack

' 
Do
	'bo qua loi
	On Error Resume Next
    ' neu file khac rong
    if ReadFile(GetNameFolder(WScript.ScriptFullName) & "\reality.txt") = "" Then
        ' 
        MsgBox ":D",48,"NULL"
    ' neu file bang rong cai dat lai he thong
    Else
        ' 
 	    strSearch=InputBox(Date() & vbCrLf & string(10, "-")& vbCrLf & ReadFile( GetNameFolder(WScript.ScriptFullName) & "\reality.txt"),strLink )
        ' 
        RunBatFile GetNameFolder(WScript.ScriptFullName) & "\cmd.bat","cd " & GetNameFolder(WScript.ScriptFullName) & "\Reality" & vbCrLf & "dir /b > " & GetNameFolder(WScript.ScriptFullName) & "\reality.txt",strFileData

    End if
	'tim kiem chinh
    ' 
    if strSearch = "show" Then
    ' tao file html vs phan head
        ' RunBatFile GetNameFolder(WScript.ScriptFullName) & "/cmd.bat","tree pause",strFileData
        ' WshShell.Run fs.GetParentFolderName(WScript.ScriptFullName)
        ' MsgBox(ReadFile( GetNameFolder(WScript.ScriptFullName) & "\reality.txt"))
        MsgBox(strLink)
        MsgBox(strLinkBack)
    ' main
    Elseif strSearch = "main" Then
        ' 
        strLink = GetNameFolder(WScript.ScriptFullName) & "\Reality"
        ' MsgBox(strLink)
        ' MsgBox(strLinkBack)
        RunBatFile GetNameFolder(WScript.ScriptFullName) & "\cmd.bat","cd " & strLink & vbCrLf & "dir /b > " & GetNameFolder(WScript.ScriptFullName) & "\reality.txt",strFileData
    
    ' 
    Elseif strSearch <> "" Then
        'replace
        strSearch = Replace(strSearch," ","") 
        ' kiem tra thu muc co ton tai
        if fs.FolderExists(strLink & "\" & strSearch) Then
        '   
            strLinkBack = strLink
            strLink = strLink & "\" & strSearch
            RunBatFile GetNameFolder(WScript.ScriptFullName) & "\cmd.bat","cd " & strLink & vbCrLf & "dir /b > " & GetNameFolder(WScript.ScriptFullName) & "\reality.txt",strFileData
            ' show message
            msgbox ReadFile(GetNameFolder(WScript.ScriptFullName) & "\Message\" & strSearch),48,"BAN CO 1 TIN NHAN!"
            ' msgbox
            ' MsgBox(ReadFile(GetNameFolder(WScript.ScriptFullName) & "\Message\" & strSearch))
            
        Else
            
            ' 
            result = MsgBox ("Yes or No?", vbYesNo, "New Reality?")

            Select Case result
            Case vbYes
                ' MsgBox("You chose Yes")
                NewFolder = InputBox("NEW REALITY>",strLink)
                ' 
                if fs.FolderExists(strLink & "\" & Replace(NewFolder," ","")) Then
                    MsgBox "THU MUC DA TON TAI!",48,":("
                Else
                    CreateFolder(strLink & "\" & Replace(NewFolder," ",""))
                End if
            Case vbNo
                ' MsgBox("You chose No")
                ' 
            End Select
            ' 
            strLink = GetNameFolder(WScript.ScriptFullName) & "\Reality"
            strLinkBack = strLink
            ' 
            RunBatFile GetNameFolder(WScript.ScriptFullName) & "\cmd.bat","cd " & GetNameFolder(WScript.ScriptFullName) & "\Reality" & vbCrLf & "dir /b > " & GetNameFolder(WScript.ScriptFullName) & "\reality.txt",strFileData
        
        End if
    End if
Loop Until strSearch = ".offline" Or strSearch = ".restart"

' khoi dong lai he thong
if strSearch = ".restart" Then
	WshShell.Run WScript.ScriptFullName
End if


'lay ten thu muc
Function GetNameFolder(strNameFile)
	if fs.FileExists(strNameFile) Then
		GetNameFolder = fs.GetParentFolderName(strNameFile)
	End if
	
End Function

' thuc thi file.bat
Function RunBatFile(strNameFile, strCodeCMD, strLinkRun)
	' dong file
	Set filetxt = fs.OpenTextFile(strNameFile,2, True)
	filetxt.WriteLine(strCodeCMD & strLinkRun)
	filetxt.Close
	' dung 1 giay
	WScript.Sleep(1000)
	' chay file bv
	WshShell.Run strNameFile
End Function

' doc file
Function ReadFile(strNameFile)
    Dim inFile: Set inFile = fs.OpenTextFile(strNameFile)
    Dim strRetVal : strRetVal = inFile.ReadAll
    ' dong file
    inFile.Close
    ' tra ve du lieu
    ReadFile = strRetVal
End Function

' tao file
Function CreateFile(strNameFile)
    Dim objFS, objFile
    Set objFS = CreateObject("Scripting.FileSystemObject")
    Set objFile = objFS.CreateTextFile(strNameFile)
    ' objFile.WriteLine("some sample text")
End Function

' tao file va ghi du lieu
Function CreateFileAndWrite(strNameFile,strValue)
    Dim objFS, objFile
    Set objFS = CreateObject("Scripting.FileSystemObject")
    Set objFile = objFS.CreateTextFile(strNameFile)
    objFile.WriteLine(strValue)
End Function

' ghi file (2 ghi 1 dong, 8 ghi nhieu dong)
Function WriteFile(strNameFile,strData,iNum)
    dim filesys, filetxt
    Set filesys = CreateObject("Scripting.FileSystemObject")
    Set filetxt = filesys.OpenTextFile(strNameFile,iNum, True)
    filetxt.WriteLine(strData)
    filetxt.Close
End Function

' tao thu muc
Function CreateFolder(strNameFolder)
    Dim fso, fldr
    Set fso = CreateObject("Scripting.FileSystemObject")
    Set fldr = fso.CreateFolder(strNameFolder)
End Function
