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

The pre-flight mode will cause the process to return with a 0 exit code, or a 1 exit code.
