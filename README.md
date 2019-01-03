Linux Commands

Command
Switch
Action
ps

Information about current running process.
date

Complete date and time
date
%R
Displays time
date 
%x    %A
Only date,
Only day
passwd

Change password
file

Display file type
head
-n
First n lines
tail 
-n
Last n lines
wc
-l, w, c
Counts lines, words and char
useradd

Root can add users to the system
history 

Previously executed commands
Pwd

Full path of current working directory
ls

List contents
ls 
-l
Long listing format
ls
-a
Including the hidden files
ls
-R
Recursive, includes subdirectories also
cd

Change directories
touch


mkdir

Make directory
mkdir
-p
Create missing parent directory
cp

Copy files
cp
-r
Copy a non-empty directory
mv

Rename files in the same directory (or) move files to other directories
rm

Removes only files
rm
-r
Delete non-empty directories
rm
-i
Ask before deleting very file in the directory
rm
-f
Force delete
rmdir

Delete empty directory
echo

Prints text
man

Manual for each command
pinfo


locate

Fast utility to search file from the database.
mkfifo

Create named pipe as filesystem object.

Regular Expressions:
Pattern
Matches
*
Any string of zero or more characters
?
Any single character
~
User’s current working directory
[^abc]
Doesn’t include abc
. 
A single character
+
Preceding character matches one or more times.
{n}
Matches exactly n times.
{n,m}
Matches at least n times but not more than m times.
[abc]
One of those.
[c-f]
Matches between this range.
|
Logical OR (pipe)
^
Matches the beginning 
$
Matches the end


Local users and group users  (124 Chap-5 & pre -3)
Command
Switch
Action
id, whoami

Info about the currently logged in user.
w, who

List of other currently logged in users.
lastlog

Last login time of each user.
last

Print most recent logins in the system.
ps
-u
Lists the running process and the users.
userdel

Remove user
userdel
-r
Removes the user home directory from the filesystem
groupadd
-g
Create a new group. Switch gives the specific GID.
groupmod
-n
Modify the existing group. This switch is used to change the name of the group 
groupdel

Delete the group
chage
-d 0 username
Force password change on next login.
chage
-l username
List users current settings.
chage
-E yyyy-mm-dd 
The account will expire on a specific date.
chage
-M
Set max no. of days between password change.

•	The public part of the user account data is stored in the /etc/passwd file.


•	The confidential part of the user account data is stored in the /etc/shadow (ex. Password hashes) file.











•	Group memberships is public info, it is stored in /etc/group file.


•	Groups can also have confidential info like passwords that are stored in the /etc/gshadow file. 





•	UID = 0 always root
•	UID = 65534 most unprivileged user nobody. This is need to map the privileges of the network users to remote filesystem.
Ex. Sudo has been configured to allow the student user to run usermod command as root, the student can run the following command to lock a user account.


•	useradd [switches] username – create new user
-c to set comment (Gecos) feld (empty)
 -s to specify shell (/bin/sh)
 -d to specify home directory (/home/[username])
 -g to specify primary group (UPG)
 -G to specify list of supplementary groups (none)
 -u to specify UID (add one to the last used UID)


•	usermod – modify the existing user (syntx : similar to useradd)
-L lock the password 
-U unlock the password
•	The root user can find the “unowned ” files and directories using find / -nouser -o -nogroup 2> /dev/null.
•	The password hashes algorithm can be changed by the root using authconfig –passlog (give the arguments like md5, sha256, sha512).

File access permissions (124 Chap-6 & pre -3)
Command
Switch
Action
chmod

Change the permissions of the file/directory.
chown
User file 
Grants ownership to the user for the specified file.
chown
-R
Recursively change the ownership of entire directory.
chown
:group file
Change group ownership of the file.
chown
User:group file
Change both user and the group at the same time.

SELinux (144 Chap-7 & pre -4)
•	Lesson 5 changing selinux context

Filesystem (124 Chap- & pre -5)
Command
Switch
Action
mount
-t type filesystem
Mount a specific type of file system.
umount
filesystem
Unmount the file system.
mkfs

Create filesystem.
blkid

Print the UUID of the FS.
df
-h
View the free space in all the mounted FS in human readable units.
fuser

List processes using specific file.
du
-h
Show disk usage of a single file in human readable units.
du
-s
Show space usage of the directories.

•	fsck.[fstype] or e2fsk for ext2/3/4 filesystem to run a check. Most FS can be repaired or scanned when offline (not mounted).
•	resize2fs adjusts the size of an ext2/3/4 FS to a specific size. Usually growing is possible online but shrinking is possible only offline. 
•	To mount tmpfs file use mount -t tmpfs.
Swap (134 Chap-9 & pre -5)
Create and format swap partition 9.3 
LVM (134 Chap-10 & pre -5)
Package management ( pre -6)
Repositories – chap-124 less- 13.6


YUM 
Command
Switch
Action
yum list

Lists the installed packages.
yum provides  
*filename
To search for a specific file.
yum update
Package 
Update the package to the latest version available.
yum install
Package 
Install a new package.
yum remove
Package
Removes one or more packages.
yum history

Lists all the recent transactions.
yum history undo
[nr]
You can undo a specific transaction.
yum group install
Groupname
Does group installation.

Boot Loader (pres-6)
Grub -  cat /boot/grub2/grub.cnf
System manager (pres-6)
The most common system manger is System V
•	Services are managed by using /etc/init.d/servicename start or (restart or stop)
Systemd
	Refer presentation 6 and chap 124 lesson 8.
•	Systemctl start/stop/restart unit.name – to start / stop/ restart a unit.
•	Systemctl enable/disable unit.name – to AutoStart a unit.
•	Systemctl status – query the status of the services. 
Troubleshooting Boot Loader (pres-6)
chap 134 lesson 13.
Network Manager & Firewall, TCP (pres-7)
Chap – 124 less-11
Chap 134 less -14
Logging (pres-9)
Chap – 124 less-10
SSH (pres-10)
chap 124 lesson 9.
Examples :
I.	Configuring network interface (can also refer chap 124 less-11.5)
Add new connection.
# nmcli con show
#nmcli dev
# nmcli con add con-name "Exam" ifname eth0 type ethernet ip4 172.25.201.X/24 gw4 172.25.201.254 
# nmcli con mod "Exam" ipv4.dns 172.25.201.254 
#nmcli con mod Exam ipv4.method manual
# nmcli con mod "Exam" connection.autoconnect yes 
# nmcli con mod "Exam" +ipv4.dns 8.8.8.8

Activate new NetworkManager connection: 
# nmcli con up "Exam"
# nmcli dev status
#nmcli con show --active

Verify NetorkManager connection and /etc/resolv.conf file: 
# cat /etc/resolv.conf

II.	Creating a swap file. Size 1GB.
1.	At a shell prompt as root, type the following command with count being equal to the desired block size:
dd if=/dev/zero of=/swap.file bs=1M count=1024
2.	Setup the swap file with the command:
mkswap /swap.file
3.	To enable the swap file immediately but not automatically at boot time:
swapon /swap.file
4.	To enable it at boot time, edit /etc/fstab to include the following entry:
/swap.file swap swap defaults 0 0
The next time the system boots, it enables the new swap file. Now test using free command.

III.	Generate SSH key-pair for instructor
1.	Login to instructor desktop machine
2.	Generate ssh-keygen
Ssh-keygen
3.	Ssh-copy-id serverX
4.	From desktop machine log into server machine as root 
Ssh root@serverX
5.	Edit the etc/ssh/sshd_config using vi editor
6.	Set 
password authentication no
permit root login yes
7.	Restart the sshd service 
Systemctl restart sshd 	
8.	Verify if the instructor can log in using the private key
Open another terminal login as instructor on the desktop machine
Ssh root@serverX
To allow instructor to login to Alfred account copy public key from instructor to Alfred server.
1.	Ssh-copy-id alfred@serverX  (check if you need to generate a new public key)
2.	From desktop machine log into server machine as alfred 
Ssh alfred@serverX
9.	Edit the etc/ssh/sshd_config using vi editor
10.	Set 
password authentication no



