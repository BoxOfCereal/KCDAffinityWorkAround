# KCDAffinityWorkAround
console application to reset core affinities for KingdomCome:Deliverance PC

This does the exact same thing as opening up Task manager and selecting the affinities manually. The advantage here is that you
only need to double click the exe


This is a very hacky work around for the cpu affinity issue in KingdomCome: Deliverance for the PC as of 3/4/2018. 
It's not clean and has loads of uncommented code.

There are one(two?) problems currently:

-This **should** work on any amount of multi core cpu but have only tested it on 4.
-The script does not dynamically check which core is at 100%





# To use: 
Download the repository, navigate to /KCDWorkAround/KCDWorkAround/bin/Debug/ and put KCDWorkAround.exe somewhere handy.

**At the title screen** run the KCDWorkAround.exe as admin. It needs the administrative rights because the script accsess proceses on the machine.
