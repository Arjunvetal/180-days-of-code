# Day 1: 14-03-2022
======================
Topics:
	-Introduction to Opearating System
	
	-Introduction to Linux

<hr>

**Operating Systems** :
- Direct operational resources [CPU, memory, devices]
- Enforces working policies [Resource usage, access]
- Mitigates difficulty of complex tasks [abstract hardware details (using system calls)]

## What is an Operating System?

* Intermediate between Hardware and Software applications
* Hides hardware complexity (Read/write file storage, send/receive socket network)
* Handles resource management (CPU scheduling, Memory management)
* Provide isolation and protection (allocate different parts of memory to different applications so that applications don't overwrite other memory locations)

## Operating System definition:

An **Operating System** is a layer of systems software that:
* directly has privileged access to the underlying hardware;
* hides the hardware complexity;
* manages hardware on behalf of one or more application according to some predifined policies.
* In addition, it ensures that applications are isolated and protected from one another.

## Operating System examples:

Desktop|Embedded devices
-----------|------------
Microsoft Windows | Android OS 
MAC OS X (BSD) | iOS
LINUX | Symbian
...|...

## OS Elements

- **Abstractions** (corresponds to applications that OS executes)
	- process, thread, file, socket,  memory page
- **Mechanisms**  (on top of Abstractions)
	- create, schedule, open, write, allocate
- **Policies** (how mechanisms are used to manage underlying hardware)    
	- Least Recently Used (LRU) , Earliest Deadline First (EDF), etc.
    
#### Example :

_Memory Management:_

- **Abstractions**: Memory page
- **Mechanisms**: Allocate, map to a process
- **Policies**: LRU

## OS Design Principles

- Seperation of mechanism and policy
	- implement flexible mechanisms to support many policies 
    - e.g. LRU, LFU, random
- Optimize for common case 
	- Where will the OS be used?
    - What will the user want to execute on that machine?
    - What are the workload requirements?
    
 ## OS Applications: 
----------------
	-Embedded OS
		eg:Contiki OS
	-Mobile OS
		eg:Android, iOS, Windows,...
	-RTOS
		eg: VxWorks, RTLinux,..
	-Secure Environment
		eg: SeLinux
	-For Servers
		eg:Redhat,Ubuntu, Windows Server,
	-Desktops
		eg: Windows, Linux, Mac OS
		
## User/ Kernel Protection Boundary

* user-level => applications [underprivileged mode]
* kernel-level => OS Kernel [privileged access, hardware access]

![image](https://user-images.githubusercontent.com/72081819/158135301-82e2b79c-1c8f-4507-959f-3b57ca49a315.png)

- User-Kernel switch is supported by hardware.
	- using trap instructions
    - system calls like:
    	- open (file)
        - send (socket)
        - malloc (memory)
	- signals
    
## System call Flowcart

![systemcallflowchart](images/systemcallflowchart.png)
    
- To make a system call, an application must:
	- write arguments
    - save relevant data ast well defined location
    - make system calls using system call number
- In synchronous mode : wait until system call completes.

## Basic OS services

* process management
* file management
* device management
* memory management
* storage management
* security

## Linux System Calls

Task|Commands
------------ | ------------
Process Control | fork (); exit(); wait(); 
File Manipulation | open(); read(); write();
Device Manipulation | ioctl(); read(); write();
Information Maintenance | getpid(); alarm(); sleep();
Communication | pipe(); shmget(); mmap();
Protection | chmod(); umask(); chown();

## Introduction to Linux:
----------------------
-Linus Torvalds : In 1991
-open source
-Variant of UNIX
-fully-networked 32/64 bit( Unix OS)
	-Unix Tools:  sed, awk , grep....
	-Compiler: C, C++, Fortran, Cobol, Smalltalk,...
	-Network Tools : telnet, ftp,ping,....
-Multi-user, Multitasking,Multiprocessor
-Has GUI like Windows system
-Run files on multiple platforms
-Linux is free - (edit ad view : source code of OS)
-customizable
-Stability
-Security is structure
-Highly portable

## Distributions of Linux:
-----------------------

-UBuntu
-Linux mint
-Fedora : REd hat latest version
-Red hat enterprise : commercial
CentOS, Debian...

## Linux Architecture 

![image](https://user-images.githubusercontent.com/72081819/158135379-e995ae12-142d-4ede-9dd4-a18989a8e797.png)


<hr>
$10-worth New Year Gift for You
Make your 2022 productive
with LINER Premium

Dismiss
Open the gift
