Finnish personal ID generator
=============================

This tool creates masses of artificial but valid Finnish personal IDs from 
given age range in seconds. This is a F# port of an old personal tool 
I've had to generate test data for system's I've been architecting or developing.
Porting to F# was done mainly for learning purposes, as I thought this kind 
of problem would be very F#-friendly.

To create ID's clone this repo, build the F# project, and launch the tool from command line:

```Batchfile
  -c, --count        Required. Count of personal IDs created.                  
                                                                               
  -s, --start        (Default: 1988) Starting year for generated IDs.          
                                                                               
  -e, --end          (Default: 2010) Ending year (inclusive) for generated IDs.
                                                                               
  --usehighsuffix    (Default: True) Use high suffix range to decrease chance  
                     of creating a real personal id.                           
                                                                               
  --help             Display this help screen.                                 
                                                                               
  --version          Display version information.                              
  ```