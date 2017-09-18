# Overview

Proof of concept of a Windows service (using TopShelf) running a pre-flight check. 

# How to run

This service can be run in two ways. 

The first way is running the pre-flight check. This will simulate the service inspecting itself, and exiting with a proper exit code to indicate success or failure.

```poc-windowsservice-preflightcheck.exe --preflight```

The other way is to run the service without arguments. This will cause the service to run normally (and indefinitely).

```poc-windowsservice-preflightcheck.exe```

# Pre-flight check

The intent behind the pre-flight check is to provide a mechanism for Windows Services to inspect themselves, e.g. to validate whether they've been configured correctly.

The pre-flight mode will cause the process to return with a 0 exit code (success), or a 1 exit code (failure).

# Sample output

### Pre-flight mode (success)

```
PS> .\poc-windowsservice-preflightcheck.exe --preflight
Configuration Result:
[Success] Name MyTopShelfService
[Success] DisplayName My TopShelf service
[Success] Description Service that has a pre-flight check. Run with --preflight argument to test.
[Success] ServiceName MyTopShelfService
Topshelf v4.0.0.0, .NET Framework v4.0.30319.42000
Running a preflight check...
Pre-flight check successful. Process is ready to run!
Returning exit code 0.
To check the exit code returned by this application, run the following command.
On Windows: cmd /c echo %errorlevel%
On OS X: echo $?
```

### Pre-flight mode (failure)

```
PS> .\poc-windowsservice-preflightcheck.exe --preflight
Configuration Result:
[Success] Name MyTopShelfService
[Success] DisplayName My TopShelf service
[Success] Description Service that has a pre-flight check. Run with --preflight argument to test.
[Success] ServiceName MyTopShelfService
Topshelf v4.0.0.0, .NET Framework v4.0.30319.42000
Running a preflight check...
Pre-flight check failed.
Returning exit code 1.
To check the exit code returned by this application, run the following command.
On Windows: cmd /c echo %errorlevel%
On OS X: echo $?
```

### Normal service start

```
PS>.\poc-windowsservice-preflightcheck.exe
Configuration Result:
[Success] Name MyTopShelfService
[Success] DisplayName My TopShelf service
[Success] Description Service that has a pre-flight check. Run with --preflight argument to test.
[Success] ServiceName MyTopShelfService
Topshelf v4.0.0.0, .NET Framework v4.0.30319.42000
Pre-flight mode wasn't specified. Running normally.
The MyTopShelfService service is now running, press Control+C to exit.
```

## Checking for exit code
The various platforms have different ways of inspecting the exit code of an application:

### Windows command prompt
`echo %errorlevel%`

### PowerShell
Either `$lastExitCode` or `$?`, see [here](https://www.safaribooksonline.com/library/view/windows-powershell-cookbook/9780596528492/ch01s11.html) for more details.

### Linux and OS/X
`echo $?`
