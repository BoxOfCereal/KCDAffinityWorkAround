# KCDAffinityWorkAround
console application to reset core affinities for KingdomCome:Deliverance PC

This does the exact same thing as opening up Task manager and selecting the affinities manually.
The advantage here is you can run this instead of opening up task manager.


This is a very hacky work around for the cpu affinity issue in KingdomCome: Deliverance for the PC as of 3/4/2018. 
It's not clean and has loads of uncommented code.

There are two(one) problems currently:

-This **should** work with any amount of cores but I have only tested it on two pc's that only have 4 cores.
-The script does not dynamically check which core is at 100% It sets the affinity to the first core and then back to all.




# To use: 
Download the repository, navigate to /KCDWorkAround/KCDWorkAround/bin/Debug/

run KCDWorkAround.exe as Administrator **At the title screen**.


Why does this need admin rights? The program accsess the user's Environment and cannot accsess processes otherwise. The program only 
sets affinities to two cores temporarily and then back to all cores.
