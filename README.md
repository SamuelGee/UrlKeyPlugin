# UrlKeyPlugin
Keepass plugin for providing master key from URL

![urlkeyplugin-noloop](https://github.com/user-attachments/assets/bf3012c1-3c01-41e6-82bf-c745a1be0337)

1. Provides strong password-key: 48 bytes, 260+ bits entropy
2. You don't have to type long password/passphrase like a slave
3. You don't have to remember non-sensical passphrases
4. You get remote control of your keys via internet, independent of device
5. Execute different security policies for yourself, based on environment and situations you happened to be
6. In case of danger, you can destroy all your keys in 3 seconds
7. Telegram notifications about accessing your keys

(more elaboration below)

# Demo:
https://iowa.root.sx/plugin/manage/DEMOxyzWbVDit67uwA2DZbePRqmFoNOfVWkWyDALDhy20ZYc

passwords is demo

# New Account:
https://iowa.root.sx/plugin

or press "New Account" in demo page bottom.

# Installation of plugin:
1. Download UrlKeyPlugin.plgx from this repo.
2. In KeePass, click 'Tools' → 'Plugins' → button 'Open Folder'; KeePass now opens a folder called 'Plugins'. Move UrlKeyPlugin.plgx into the 'Plugins' folder.
3. Download UrlKeyProvider.cfg from this repo. Put it to your Documents (My Documents) folder. In case you have portable version of KeePass, put cfg file in the same dir.
4. Restart KeePass to load the new plugin.

You should see 3 keys available (from demo account):

![image](https://github.com/user-attachments/assets/b5ab881d-34d2-47b2-a254-9506756a1274)

Nice thing is that Keepass remembers your last-used Key Provider for each file.

Now, when you've successfully installed the plugin and it works, you can set it up for yourself:
1. Create New Account in Iowa server: https://iowa.root.sx/plugin
2. Create your new key(s)
3. Edit UrlKeyProvider.cfg with Notepad in your "Documents" folder.

Delete/replace last 3 lines with your data.

name_of_yourKey:account_id/key_name

4. Run KeePass to see if everything works - now you should see your KeyNames in MasterKey selectbox.
5. Backup your keepass kdbx files to some temporary directory.
6. Open your keepass kdbx as you usually do.
7. Go to your Iowa account in browser and Turn on your keys with no time-out.
8. Keepass Menu > File > Change Master Key: let password empty, go Expert options: Key File Provider -- and choose the key you've just made. Then Save.
9. Close KeePass and open it again. Now choose Key File provider and press Enter. You should be in.

This way you can set up all your KeePass databases. If everythings works, delete your backups from temporary dir. Now you can happily wipe all your passwords to keepass from your head.

10. Open link to your Iowa account in browser of your mobile phone. You can save it to your home screen (and/or to your bookmarks), so then you can run it as an app.
11. You don't have to log out. (no session cookies). You are logged out as soon as your phone unload the page from memory, or as soon as you close the tab in browser.
12. In your pc browser, copy and Backup your account_id and password, also backup all your keys somewhere. To show your key, click on it's name, it opens in new window. (This is how KeePass see it.)

# Examples of how to set up different policies for different situations and environments:
If you are in a safe environment, e.g. at home, and you use some of your kdbx frequently, you can turn on your key with no time-out (always-on). For convenience. You can also combine Key from Iowa with some short password or numeric pin (step 8 - password field) - this way you still have "48 bytes + pin = strong password" + you have convenience + you're protected against someone just runnig in your opened laptop and getting into your Keepass with just Enter.

For less frequent usage, keep your Iowa keys turned off, and turn them on for 15s when you are going to open your kdbx file. This behavior is also meant to be followed in the unsafe environments, e.g. in office, or while travelling.

If your laptop gets stolen or lost, you should destroy your current Iowa account. You can do it e.g. from your phone, just login 3 times with empty password. URL always looks like this - just account_id changes, e.g. https://iowa.root.sx/plugin/manage/DEMOxyzWbVDit67uwA2DZbePRqmFoNOfVWkWyDALDhy20ZYc. Account self-destroys after 3 wrong attempts (except demo account). Keys associated with that account are destroyed too. This way, even if the thief somehow gets in your laptop, even if he finds your kdbx files and even if he knows about this plugin and he looks at your UrlKeyProvider.cfg file to find your account_id and thus URL to manage your account, he won't be successfull. If he tries to brute force your kdbx file, he won't be successfull either. Password/MasterKey is too long and none-dictionary. No dictionary and GPU mega-cluster would help. Account self-destroyed & too much of entropy!

If you loose your laptop and your phone too, you should turn to your emergency backups. So definitely you should have backup of your Iowa keys somewhere away of your laptop - to be protected against stolen laptop to be decrypted. 

If you have new laptop with TPM 2.0 and Bitlocker you should be safe when you loose it, even without this plugin. Yet this plugin gives you more safety even for another situations. Also, TPM 1 turned out to not be very safe (bus listening) and TPM 2 ... well, recently has been discovered that manufacturers sold thousands of TPM2 laptops encrypted with demo certificates which are publicly available in github. Better safe than sorry.

It's also nice, that if you forget to lock your laptop and move away from home/office, you can lock access to keepass via your phone, when you realize it. Just turn the keys off.

# How to set up MiniKeepass or Keepassium, phone apps for keepass sync databases:
Login to your Iowa account and click on your key name, your 48-byte key will open in a new tab. This is your password, just copy and paste it to app. Or you can save it as a text file to your phone storage and use it as master key (probably less safe).

# Telegram notifications:
You can set up Telegram notifications, so you'll be notified when your keys are used, or even requested and not provided, because they were turned off. This way you'll get info, for example if your laptop was stolen or misused, either successfully or not, depending on your keys to be turned on or off. In worst case scenario, you had your keys ON, your laptop gets stolen, windows account breached or data cloned away, you didn't know about it, you didn't destroy your Iowa account, yet you'll be notidied that your keepass was opened, so you can start blocking accounts, changing passwords etc. This can never happen, if you use that 15-seconds time-out.

# Web service reliability and longevity
This web service for keys is free, so to make it independent of my credit card, I deployed Ubuntu 22 on free-tier e2-micro on Google Cloud in Iowa, USA. Thanks, Google. Domain is also on free service via freedns.afraid.org, it has a good 20 years track record of reliability. HTTPS is free Let's encrypt certificate. Traffic is encrypted from keepass.exe to server and back. If you want to use your own URL, just replace it in source code and create your own plgx.

Server is backed up daily to my private AWS S3 bucket. Justin Case. 

# Why this solution is better than online password manager (in my opinion):
I am a big fan of 1password or ProtonPass. The problem is master password to these services. While it's true that they are online services, so they can block password guessing to your account after few attempts, still you have local copy of your database on your machine. They work offline too. Even when you have free version of ProtonPass, Chrome extension only, local copy of database is still on your machine. And it's encrypted by your master password. Yeah yeah. That's why 1password has "traveler mode", so you can unload some vaults when travelling to Mexico. Vault is just encrypted database file. So here we go again, same problem as KeePass and stolen laptop and brute force dictionary guessing with unlimited time and resources. That is why 1password suggests you should use 4-5 words passphrase. Same rules apply for ProtonPass and KeePass. Yet KeePass offers an advantage: you can choose crypto algorithm and you can setup params for Argon or setup number of rounds for AES-KDF chain. 1password uses 100K iterations to keep the program fast even on slower computers and phones. Yet my 10-years old laptop is happy with 21M iterations (Keepass 1-sec delay benchmark). That is 210 times better. Not talking of Argon2d... So why choose 1pass with less security? 

But the more annoying part is that 4-5 words passphrase. This is pure slavery, to type it, and also to remember it! It's unnatural to remember 5 words with no sense. Perhaps it can even cause brain damage. No joke, ask CIA interrogation techniques. Brain-bloatware. You may think that you can choose passphrase with at least grammatical sense. "The sonic strap was grinding passably a sunlamp before his lawless runt". Or "a sedative is trashing an evergreen". Funny, but no. It weakens your passphrase very much, much less combinations to guess, compared to Diceware dictionary or so. Correct horse battery staple. Too short.

DRAFT, not finished

stackexchange
dns check - secret file from augusta, shut down apache reverse check to augusta
separate google account.
note: you can safely close browser window when time-out counts down - it's just interface. Countdown "counts down" on server-side.
its anonymous, telegram is also anon, see youd ID, not phone num.


