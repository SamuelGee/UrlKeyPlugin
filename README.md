# UrlKeyPlugin
Keepass plugin for providing master key from URL

![urlkeyplugin-noloop](https://github.com/user-attachments/assets/bf3012c1-3c01-41e6-82bf-c745a1be0337)

1. Provides strong password-key: 48 bytes, 260+ bits entropy
2. You don't have to type long password/passphrase like a slave
3. You don't have to remember non-sensical passphrases like CIA agent lost in Tehran
4. You get remote control of your keys via internet, independent of device
5. Execute different security policies for yourself, based on environment and situations you happened to be
6. In case of danger, you can destroy all your keys on server in 3 seconds
7. Telegram notifications about accessing your keys

(more elaboration below)

# Demo:
https://iowa.root.sx/plugin/manage/DEMOxyzWbVDit67uwA2DZbePRqmFoNOfVWkWyDALDhy20ZYc

password is demo

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

4. Run KeePass to see if everything works - now you should see your KeyNames in KeyFile selectbox.
5. Backup your keepass kdbx files to some temporary directory.
6. Open your keepass kdbx as you usually do.
7. Go to your Iowa account in browser and Turn on your keys with no time-out.
8. Keepass Menu > File > Change Master Key: let password empty, go Expert options: Key File Provider -- and choose the key you've just made. Then Save.
9. Close KeePass and open it again. Now choose Key File provider and press Enter. You should be in.

This way you can set up all your KeePass databases. If everythings works, delete your backups from temporary dir. Now you can happily wipe all your passwords to keepass from your head.

10. Open link to your Iowa account in browser of your mobile phone. You can save it to your home screen (and/or to your bookmarks), so then you can run it as an app.
11. You don't have to log out. (no session cookies). You are logged out as soon as your phone unload the page from memory, or as soon as you close the tab in browser.
12. In your pc browser, copy and Backup your account_id and password, also IMPORTANT **backup all your keys** somewhere. To show your key, click on it's name, it opens in new window. (This is how KeePass see it.) DON'T FORGET TO BACKUP YOUR KEYS.

# Examples of how to set up different policies for different situations and environments:
If you are in a safe environment, e.g. at home, and you use some of your kdbx frequently, you can turn on your key with no time-out (always-on). For convenience. You can also combine Key from Iowa with some short password or numeric pin (step 8 - password field) - this way you still have "48 bytes + pin = strong password" + you have convenience + you're protected against someone just runnig in your opened laptop and getting into your Keepass with just Enter.

For less frequent usage, keep your Iowa keys turned off, and turn them on for 15s when you are going to open your kdbx file. This behavior is also meant to be followed in the unsafe environments, e.g. in office, or while travelling.

If your laptop gets stolen or lost, you should destroy your current Iowa account. You can do it e.g. from your phone, just login 3 times with empty password. URL always looks like this - just account_id changes, e.g. https://iowa.root.sx/plugin/manage/DEMOxyzWbVDit67uwA2DZbePRqmFoNOfVWkWyDALDhy20ZYc. Account self-destroys after 3 wrong attempts (except demo account). Keys associated with that account are destroyed too. This way, even if the thief somehow gets in your laptop, even if he finds your kdbx files and even if he knows about this plugin and he looks at your UrlKeyProvider.cfg file to find your account_id and thus URL to manage your account, he won't be successfull. If he tries to brute force your kdbx file, he won't be successfull either. Password/MasterKey is too long and none-dictionary. No dictionary and GPU mega-cluster would help. Account self-destroyed & too much of entropy!

If you loose your laptop and your phone too, you should turn to your emergency backups. So definitely you should have backup of your Iowa keys somewhere away of your laptop - to be protected against stolen laptop to be decrypted. 

If you have new laptop with TPM 2.0 and Bitlocker you should be safe when you loose it, even without this plugin. Yet this plugin gives you more safety even if someone gets to your kdbx file. Also, TPM 1 turned out to not be very safe (bus listening) and TPM 2 ... well, recently has been discovered that manufacturers sold thousands of TPM2 laptops encrypted with demo certificates which are publicly available in github. Better safe than sorry.

It's also nice, that if you forget to lock your laptop and move away from home/office, you can lock access to keepass via your phone, when you recall you keys are turned On. Just turn the keys off.

# How to set up MiniKeepass or Keepassium, phone apps for keepass sync databases:
Login to your Iowa account and click on your key name, your 48-byte key will open in a new tab. This is your password, just copy and paste it to app. Or you can save it as a text file to your phone storage and use it as master key (probably less safe).

# Telegram notifications:
You can set up Telegram notifications, so you'll be notified when your keys are used, or even requested and not provided, because they were turned off. This way you'll get info, for example if your laptop was stolen or misused, either successfully or not, depending on your keys to be turned on or off. In worst case scenario, you had your keys ON, your laptop gets stolen, windows account breached or data cloned away, you didn't know about it, you didn't destroy your Iowa account, yet you'll be notidied that your keepass was opened, so you can start blocking accounts, changing passwords etc. This can never happen, if you use that 15-seconds time-out.

# Web service reliability and longevity
This web service for keys is free, so to make it independent of my credit card, I deployed Ubuntu 22 on free-tier Google Cloud in Iowa, USA. Thanks, Google. DNS for domain is monitored in 1-min interval. Traffic is encrypted from keepass.exe to server and back. If you want to use your own URL, just replace it in source code and create your own plgx. (your URL will still be easy to find out even after compilation, all strings in DLL are visible via decompiler)

Server is backed up daily to my private AWS S3 bucket. Encrypted. 

Server was built with separate google account.

# Recovery from keys backup
If you loose internet or Iowa server goes down, you can open your kdbx files with Iowa keys you have backed up (step 12). Just copy&paste them to password field and choose None Keyfile.

# Notes:
## Cloud password managers
I am a big fan of 1password or ProtonPass. The problem is master password to these services. While it's true that they are online services, so they can block password guessing to your account after few attempts, still you have local copy of your database on your machine. They work offline too. Even when you have free version of ProtonPass, Chrome extension only, local copy of database is still on your machine. And it's encrypted only by your master password. That's why 1password has "traveler mode", so you can unload some vaults when travelling to Mexico. Vault is just encrypted database file. So here we go again, same problem as KeePass and stolen laptop and brute force dictionary guessing with unlimited time and resources. That is why 1password suggests you should use 4-5 words passphrase. Same rules apply for ProtonPass and KeePass. Yet KeePass offers an advantage: you can choose crypto algorithm and you can setup params for Argon or setup number of rounds for AES-KDF chain. 1password uses 100K iterations to keep the program fast even on slower computers and phones. Yet my 10-years old laptop is happy with 21M iterations (Keepass 1-sec delay benchmark). ProtonPass uses Argon2d, but still it's weakened by passphrase. 

## 4-5 words passphrase. 
It's a brain-bloatware. You may think that you can choose passphrase with at least grammatical sense. "The sonic strap was grinding passably a sunlamp before his lawless runt". Or "a sedative is trashing an evergreen". This weakens your passphrase very much, much less combinations to guess, compared to Diceware dictionary or so. Correct horse battery staple. Too short anyway.

## Clusterization of GPU and GPU pools
Big cloud providers offer to rent 1000 GPUs in hourly rate. GPUs are cheaper and more powerfull every year. Is your 5-word passphrase safe? Also, there are GPU pools known from the crypto mining world.

With passphrase you get about 70 bits entropy https://passwordbits.com/passphrase-cracking-calculator/

1Password found that it cost about $6 to go through 2^32 (4,294,967,296) combinations of passwords. https://blog.1password.com/cracking-challenge-update/

That was Nvidia GPU pool in 2018, with 210 kilohash per second, 210 KH/s. Price per day was $26 - circa 18 **billion** combinations.

Compare it with 08/2024 price here https://www.nicehash.com/pricing. Those are specialized machines which cannot be used for any algo, but just for a benchmark: They offer renting 1 EXA Hash per day for 1 Bitcoin, $60K. That would put the price of 210 KH to 0.001 USD per day, not $26 per day.

![image](https://github.com/user-attachments/assets/e57b3fac-06d7-43c9-9715-b069857d544e)

So it's likely that for offline file to be ecrypted securely, soon 5 words passphrase will be a minimum. This is not the way to solve the problem. And also because of clusterization and pools, it won't help if everytime you buy new computer with more power, you raise number of KDF rounds and you'll be fine. You won't.

Conclusion: for offline files, you need high entropy. To have high entropy, you need long non-sensical passphrase. Remembering that passphrase is a pain. Typing that passphrase all the time is also pain. And still you'll get just 70 bits entropy. But with this plugin you get 250 bit entropy. Bitcoin private key level of entropy.

## Passkeys, Yubikey, Windows Hello, Apple Keychain, Biometry ...
Passkeys are good solution for online logins. High entropy, challenge-response talk. Public key is unique, so web-services providers could offer not only password-less login, but also user-id-less login. But they don't. Why? Because people can loose passkeys, so web-services providers need to offer some fallback.

So the question arises: How to safely use, save, and backup passkeys???

For me, Yubikey is not good option. Another piece of hardware to carry. I don't want that. Low flexibility if you need to use backup - just another hardware you have to keep somewhere and get to it. If your laptop gets stolen while you're in Mexico, with your Yubikey in it, and your backup-youbikey is in Chicago...

Using passkeys with just Windows: If you don't have TPM2 chip (with correct certificate), then your Windows Hello is stored only as file. It's encrypted by 6-digits pin only. Disaster. 

If you have TPM2, your passkeys are probably as safe as with Youbikey + you don't have to carry another usb thing. Good, but has Microsoft already launched cloud-backup of passkeys? I don't know (08/2024). If it hasn't, if you loose your laptop, then your passkeys are lost for good.

Apple Keychain - YES. Keychain is synchronized to icloud, so you have good backup of your passkeys. You can also encrypt your keychain with your own keys, so not even Apple will be able to decrypt it.

https://support.apple.com/guide/security/advanced-data-protection-for-icloud-sec973254c5f/web

https://blog.elcomsoft.com/2024/05/icloud-extraction-turns-twelve/

But synchronizing Apple Keychain to your Windows laptop is probably bad idea. (Apple Password app for Windows)

## iPhone vs Laptop - vectors of attack
Your phone is locked and encrypted most of time. You can switch off biometry unlock with simple button-strokes and setup lock or data self-destruction after some number of wrong attempts.

But laptop is different animal. Laptop is usually opened and unlocked many hours of the day. It's more prone to malware and also to evil hardware via usb peripherals - e.g. keylogger built in USB cable. So even if you have Macbook with Apple T2 chip, it's much safer to have Keychain on iPhone and iCloud only, in my opinion. I use Windows on Intel Macbook, but even if I switch to Apple laptop one day, I would stay with Keepass or something similar to store secrets which I wouldn't like to store in Keychain. Another layer of security. And while I want to stay with Keepass, I want strong encryption, high entropy and not typing like a slave (while being listened by keylogger), hence this plugin...

# FAQ:
- yes you can safely close browser window when time-out counts down - it's just interface. Countdown "counts down" on server-side.
- yes its anonymous, only your IP is visible. If you are behind proxy (e.g. Apple Icloud private relay), then even your IP is hidden. Telegram is also anon, plugin sees your telegram ID, not phone number.
- plugin account - password can be short, 3x failed attempt = self-destruction. Save it to your keychain and you have biometric-keepass-access-control.

# LINKS:
https://www.rubydevices.com.au/blog/how-to-hack-keepass

https://bytesoverbombs.io/cracking-everything-with-john-the-ripper-d434f0f6dc1c

https://security.stackexchange.com/questions/117580/recommended-level-of-password-complexity-for-keepass

https://makemeapassword.ligos.net/generate/ReadablePassphrase

https://security.stackexchange.com/questions/3959/recommended-of-iterations-when-using-pbkdf2-sha256/3993#3993


https://support.apple.com/guide/security/advanced-data-protection-for-icloud-sec973254c5f/web

https://passwordbits.com/passphrase-cracking-calculator/

https://passwordbits.com/password-cracking-calculator/

https://blog.1password.com/cracking-challenge-update/

https://blog.elcomsoft.com/2024/07/password-breaking-a-to-z/

https://blog.elcomsoft.com/2021/06/breaking-veracrypt-obtaining-and-extracting-on-the-fly-encryption-keys/

Linear scalability with low bandwidth requirements and zero overhead on up to 10,000 computers

Remote deployment and console management

https://www.elcomsoft.com/edpr.html

https://blog.elcomsoft.com/2024/05/icloud-extraction-turns-twelve/

https://blog.elcomsoft.com/2022/08/windows-hello-no-tpm-no-security/

https://passwordbits.com/most-secure-password-manager/

https://proton.me/blog/safe-to-autofill-passwords - autofill exploit

https://blog.1password.com/not-in-a-million-years/

https://theworld.com/~reinhold/diceware.html


https://www.newegg.com/lexar-model-ljdf35-32gbnl/p/N82E16820191819


https://www.techlicious.com/blog/how-to-use-apple-keychain-passwords-passkeys-on-windows/


https://hashsuite.openwall.net/performance

https://hashcat.net/hashcat/

https://null-byte.wonderhowto.com/how-to/crack-ssh-private-key-passwords-with-john-ripper-0302810/


https://www.specificenergy.com/blog-posts/passkey-implementation.html

https://www.smashingmagazine.com/2015/12/passphrases-more-user-friendly-passwords/

