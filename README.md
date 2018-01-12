# OneMiner
As the name suggests, this is a 1 click miner for all GPU coins viz Ethereum, Zcash, Bitcoin Gold, Ubiq etc. It uses the tried and tested Mining softwares like Claymore, EWBF internally and keeps all the complications of using them hidden from the end user. It is especially built to handle situations when you have both AMD and Nvidia cards and have to use different softwares to mine on both cards. The primary goal of this software is user experience and making mining as easy as possible.

The name might hold a subtle  reference to the 'One Ring" from 'Lord of the Rings' but it holds no delusions of grandeur about its supremacy :).

Download from Github
https://github.com/arunsatyarth/OneMiner/releases

# Screenshot
Screenshot of a 6 GPU Rig mining ZCash with 3 AMD and 3 NVidia cards 

![Running View](https://github.com/arunsatyarth/OneMiner/blob/master/Screenshots/1.PNG)

# Reasons to Use
The main reason to use this tool is that  setting up a miner is difficult. Especially if you have different GPU cards or if you want to switch between mining different coins or to different wallet adddresses. It becomes a lot script heavy to handle such situations. This tool was built to have all such functionality in 1 place. It is open source hence anyone can download the code/tool and use it as is or make modifications to suit his needs.

For instance, my prime motive behind the creation of this tool  was that I have a miner with both Nvidia and AMD cards. I was using Claymore miner for AMD and EWBF for Nvidia while mining Zcash. But sometimes when the newtwork is down the EWBF miner would die and never come back up. I had to manually launch it later. Writing scripts for everything was getting tedious. So I thought of creating this tool which would benefit everyone.

I tried out things like Awesome Miner and Minergate but both being closed source they where neither trustworthy nor extensible. With this project I intend to create a one stop tool which can mine almost anything and in as little steps as possible and which could be extended by anyone to meet his needs.

I would like to hear your feedback and thoughts if any. Please use the github issue tracker  to notify me of any issues or enhanement requests or send a mail to arun.satyarth@gmail.com.

# Features
Below are some of the features for first release

1. Mine any GPU based coins(Ethereum, Zcash, Monero, Bitcoin Gold, Electroneum,  Zencash, Ethereum Classic, Ubiq, Expanse, ZClassic )
2. CPU mining with Monero and Electroneum
3. Support mixed GPUs. Nvidia and AMD
4. Easy switch between different configured miners. Mine different coins with ease.
5. Mine on Startup
6. Automatically restart miner in case of crash or accidental close. eg: Zcash EWBF miner would always close on network unavailablity.
7. Open source. so no fear of hashrate stealing like in Minergate.
8. 1 click Jump to pool account
9. **CrytoNight based coins viz. Monero, Electroneum has been added in v1.8 onwards on AMD Radeon GPUs and CPU.**

# Donations
If you would like to support this project, your donations would be greatly appreciated

### Bitcoin
1MtjqqLDtbLvMY8s3vw2SCynGqSvszJf4V

### Ethereum
0x033ff6918d434cef3887d8e529c14d1bcb91ca8b

### Litecoin
LgPDDxVbtB4khAd4b6MmP6GGV3JSdyShpR


# How to use
- The first time you open the app, you will have a "Default Ethereum Miner" configured. It exists to give a quick way to test out the app. 
- It can be edited and used, in which case it turns into a  normal miner. Right click and select "Edit Miner" to change the wallet address to your address.
- Alternatively, you can click **"Add Miner"** and create a new miner.
- Adding a miner will remove the unedited default miners in the next restart of the application.
- There is a **right click menu** on the miner list. It can be used to Edit/Delete or activate a miner.
- Activated miner: Any miner can be started by the start button but the Activated miner would be the miner which starts when system restarts and "Mine on Launch" is configured to Yes.
- The first time it would take a bit of time to start mining as it needs to download the miners.
- Settings screen: If you intend to mine, it is important to edit the settings and **enable "Launch on Start" and "Mine on Launch".**
- **Script tab** shows the script which will run. You can edit this by clicking on Edit at the right side and then saving the changes with Save.
- Closing OneMiner does not kill it. It minimizes it to tray. You will have to manually open **system tray** and right click and select Exit.
- Closing OneMiner while it is mining does not stop the running miners. This can be used if you do not need the GUI after configuration.
- The downloaded miners and files are stored in %Appdata%\OneMiner. It creates a <your_miner>.bat file inside the software used for mining. It is only advised to fiddle with it if you know what you are doing.
- oneminer.json file contains all your configuration information. Deleting this will make you have to configure it again. It wont make you loose your payouts.
- **Transferring this software to a new machine** just involves copying the oneminer.json file over to the other machine into the same %Appdata%\OneMiner folder.
- If **miner windows keep closing**, it means some issue with the underlying hardware. Mostly if the hardware is not suited for mining.
- Show consoles can be disabled in settings screen to not show the miner UIs. This is however not recommended.


# System requirements
1. Currently supports only Windows 7 and upwards
2. .Net Framework 4.5


# Future Planned Features
- Automatically mine the most profitable coin
- Benchmarking and profitability calculator
- Mine 2 different coins together on different GPUs.
- Identify new coins in market for mining
- Automatic wallet generation for coins so that you dont have to enter wallet address.
- Automatic connection to Wifi. Sometimes when network goes and comes back up, wifi dosen't connect and miner would be stuck. With this, it would connect automatically
- Launching scripts, commands at specifc times,eg: To restart machine at a set time.
- Automatic Dual mining off on temperature increase

## Nvidia known issue with Monero/Cryptonight
Nvidia(ccminer)  has been found to be a bit unstable on cryptonight. Some antivirus wrongly classifies ccminer as a virus. This in turn makes it to classify OneMiner as a virus. In the current release, Nvidia is supported but not selected by default while creating a new miner. But it can be manually selected from checkbox in the scripts tab. Use it only if you need it.
In future if AV becomes a problem, Nvidia for Cryptonight will not be supported in the main OneMiner release. It might however be provided as a seperate release candidate. 
Also monitoring of hashrate and shares are not currently supported for Nvidia for cryptonight coins. 
1. Either an exception will have to be added to Antivirus or Antivirus will have to be disabled for it.
2. Monero mining on Nvidia requires Visual studio redistributables to be installed.https://www.microsoft.com/en-in/download/details.aspx?id=5555


# Screenshots of different screens
1. Miner options menu on Right click on Miner list

![Miner options](https://github.com/arunsatyarth/OneMiner/blob/master/Screenshots/2.png)

2. Adding a Miner

![Adding a Miner](https://github.com/arunsatyarth/OneMiner/blob/master/Screenshots/3.PNG)

3. Minner Settings

You can select any pool. Even the ones which are not present in the list. Be sure to give correpsonding Pool Account link so you can quickly access it when needed.
![Adding a Miner](https://github.com/arunsatyarth/OneMiner/blob/master/Screenshots/4.PNG)

4. Script Tab

You can edit everything about the miner from the script tab. It will have subtabe for individual miner programs. No matter what is shown in UI or configured outside, this script is what would run finally. So editing this would give you maximum control.
Also you can switch on/off AMD/NVidia miners individually using the chackboxes.
![Adding a Miner](https://github.com/arunsatyarth/OneMiner/blob/master/Screenshots/5.png)


## Contributing
1. Fork this repo to your github account
2. Clone the repo to your machine `git clone https://github.com/<yourusername>/OneMiner`
3. Make sure you are in the project directory, then run `git remote add upstream https://github.com/OneMiner/OneMiner`
4. Make sure you are on the master branch, run `git pull --rebase upstream master`. This will insure you are up-to-date with main repo. 
5. Finally, create a branch and fix/improve something.  
