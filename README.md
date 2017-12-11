# .NET Core clipboard utility programs:

* CopyFileName: Send file to clipboard as name
* CopyFileContents: Send file to clipboard as contents
* TextClean: Remove formatting from clipboard text

## Publishing .exe files

From a command line pointed to the project folder:

```
dotnet publish -c Release -r win10-x64
```

## Adding to Windows "Send to" context menu

Press Win-R, then type

```
shell:sendto
```

...to display your send-to shortcuts folder. Add shortcuts to  
.._ClipboardUtilitiesCopyFileName.exe_ and  
..._ClipboardUtilities.CopyFileContents.exe_.
