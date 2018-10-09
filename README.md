# msgbox
Console application for displaying the Windows MessageBox form.

### Command-line Usage

```
Displays a message box to current user.

Usage: msgbox [options]

Options:
  --version         Show version information
  -t|--text         The text to display in the message box.
  -c|--caption      The text to display in the title bar of the message box.
  -b|--buttons      The buttons to display in the message box.
  -i|--icon         The icon to display in the message box.
  -d|--default-btn  Specifies the default button for the message box.
  -a|--help-btn     Shows the help button in the message box.
  -?|-h|--help      Show help information
```

The DiaglogResult return value of MessageBox.Show is returned to the caller as the process exit code. You can view the list of possible return codes by running `msgbox --error-codes`.
```
C:\msgbox --error-codes
The following error codes are supported.

    None     = 0
    OK       = 1
    Cancel   = 2
    Abort    = 3
    Retry    = 4
    Ignore   = 5
    Yes      = 6
    No       = 7
```
