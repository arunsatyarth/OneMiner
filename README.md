# OneMiner
As the name suggests, this is a 1 click miner for all GPU coins viz Ethereum, Zcash, Ubiq etc. It uses the tried and tested Mining softwares like Claymore, EWBF internally and keeps all the complications of using them hidden from the end user. It is especially built to handle situations when you have both AMD and Nvidia cards and have to use different softwares to mine on both cards.

The name might hold a subtle  reference to the 'One Ring" from 'Lord of the Rings' but it holds no delusions of grandeur about its supremacy :).

Download from Github
https://github.com/arunsatyarth/OneMiner/releases

# Screenshot
Screenshot of a 6 GPU Rig mining ZCash with 3 AMD and # NVidia cards 

![Running View](https://github.com/arunsatyarth/OneMiner/blob/master/Screenshots/1.PNG)

# Reasons to Use
The main reason to use this tool is that  setting up a miner is difficult. Especially if you have different GPU cards or if you want to switch between mining different coins or to different wallet adddresses. It becomes a lot script heavy to handle such situations. This tool was built to have all such functionality in 1 place. It is open source hence anyone can download the code/tool and use it as is or make modifications to suit his needs.

For instance, my prime motive behind the creation of this tool  was that I have a miner with both Nvidia and AMD cards. I was using Claymore miner for AMD and EWBF for Nvidia while mining Zcash. But sometimes when the newtwork is down the EWBF miner would die and never come back up. I had to manually launch it later. Writing scripts for everything was getting tedious. So I thought of creating this tool which would benefit everyone.

I tried out things like Awesome Miner and Minergate but both being closed source they wwere neither trustworthy nor extensible. With this project I intend to create a one stop tool which can mine almost anything and in as little steps as possible and which coule be extended by anyone to meet his needs.

I would like to hear your feedback and thoughts if any. Please use the github issue tracker  to notify me of any issues or enhanement requests or send a mail to arun.satyarth@gmail.com.

# Features
Below are some of the features for first release

1. Mine any GPU based coins(Ethereum, Zcash,Bitcoin Gold, Zencash, Ethereum Classic, Ubiq, Expanse, ZClassic )
2. Support mixed GPUs. Nvidia and AMD
3. Easy switch between different configured miners. Mine different coins with ease.
4. Mine on Startup
5. Automatically restart miner in case of crash or accidental close. eg: Zcash EWBF miner would always close on network unavailablity.
6. Open source. so no fear of hashrate stealing like in Minergate.
7. 1 click Jump to pool account



# Future Planned Features
1. Automatically mine the most profitable coin
4. Automatic Dual mining off on temperature increase
5. Benchmark against different algos with profitability
6. Identify new coins in market for mining
7. Automatic wallet generation for coins so that you dont have to enter wallet address.
8. Automatic connection to Wifi. Sometimes when network goes and comes back up, wifi dosen't connect and miner would be stuck. With this, it would connect automatically
9. Launching scripts, commands at specifc times,eg: To restart machine at a set time.

# How to use
1. The first time you open the app, you will have a "Default Ethereum Miner" configured. Right click and edit it to change the wallet address to your address.
2. You could create more miners with the Add Miner button.
3. The first time it would take a bit of time to start mining as it needs to download the miners.
4. You can configure settings from the settings window to mine on launch etc.
5. Right click on the miner to Activate a miner, edit it or delete it.
6. Activated miner: Any miner can be started by the start button but the Activated miner would be the miner which starts when system restarts and "Mine on Launch" is configured to Yes


# Donations
If you would like to supprt this project, your donations would be greatly appreciated

### Bitcoin
1MtjqqLDtbLvMY8s3vw2SCynGqSvszJf4V

### Ethereum
0x033ff6918d434cef3887d8e529c14d1bcb91ca8b

### Litecoin
LgPDDxVbtB4khAd4b6MmP6GGV3JSdyShpR


# Screenshots of different screens
1. Miner options menu on Right click on Miner list
![Miner options](https://github.com/arunsatyarth/OneMiner/blob/master/Screenshots/2.PNG)

2. Adding a Miner
![Adding a Miner](https://github.com/arunsatyarth/OneMiner/blob/master/Screenshots/3.PNG)

3. Minner Settings
You can select any pool. Even the ones which are not present in the list. Be sure to give correpsonding Pool Account link so you can quickly access it when needed.
![Adding a Miner](https://github.com/arunsatyarth/OneMiner/blob/master/Screenshots/4.PNG)

4. Script Tab
You can edit everything about the miner from the script tab. It will have subtabe for individual miner programs. No matter what is shown in UI or configured outside, this script is what would run finally. So editing this would give you maximum control.
Also you can switch on/off AMD/NVidia miners individually using the chackboxes.
![Adding a Miner](https://github.com/arunsatyarth/OneMiner/blob/master/Screenshots/5.PNG)







	
