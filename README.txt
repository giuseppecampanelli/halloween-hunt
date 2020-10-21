=========Halloween Hunt=========
Duck Hunt with a Halloween spin.

COMP 376 Assignment 2
Giuseppe Campanelli 40043909

How To Run Project in Unity
---------------------------
1. Open Project in Unity
2. Open Menu Scene
3. Go to Game tab
4. Make sure Aspect Ratio is set to 'Standalone (1024x576)'
5. Click Play button

How To Build and Run Project (.exe)
-----------------------------------
1. Open Project in Unity
2. File > Build and Run
3. Specify Folder to save the Build
NOTE: Build (.exe) provided in assignment submission

How To Read Code
----------------
Menu Scene - contains main menu
Menu.cs - menu button actions
Game Scene - contains game functionality
Ghost.cs, Witch.cs, Pumpkin.cs - scripts for corresponding game enemies
GhostSpawner.cs, WitchSpawner.cs - handle enemy spawning
Crosshair.cs - handles user clicks and input
Game.cs - handles level logic and overall gameplay

How To Play - Normal Mode
-------------------------
- Shoot 5 Ghosts (3 points each) by aiming and clicking left-mouse button to advance to the next Level (60 seconds per level)
- Ghosts will move faster each level (5% faster)
- Hit a Witch 3 times to kill it (> 2 appear per level) and earn big amount of points (10)
- Earn bonus points (5) for shooting 2 enemies at once
- When you miss a target, a laughing Pumpkin will appear
- The game ends when you cannot hit 5 targets in 60 seconds

How To Play - Special Mode
--------------------------
- Same as Normal Mode except:
- Missing a target will result in points lost (2)
- Press LEFT SHIFT to enable continuous firing mode for 3 seconds (just hold down left-click mouse button)
- More Ghosts spawn per level in Special Mode
- Ghosts are only worth 1 point each

References
----------
Maneater BB Font (Game Font) - https://www.1001fonts.com/maneater-bb-font.html
Horror Pumpkins Halloween (Menu and Game Background) - https://hdqwalls.com/wallpaper/2560x1700/horror-pumpkins-halloween-4k
Crosshair - https://en.m.wikipedia.org/wiki/File:Crosshairs_Red.svg
Ghost Sprite - https://rpgtileset.com/sprite/ghosts-sprite-for-rpg-maker-mv/
Darkness and Horror Soundtrack (Main Menu Background Music) - https://assetstore.unity.com/packages/audio/ambient/darkness-and-horror-soundtrack-56718
Ambient Eerie (Game Background Music) - https://assetstore.unity.com/packages/audio/ambient/ambient-scary-volume-1-167786
Laser 01 (CrossHair Click Audio) - https://assetstore.unity.com/packages/audio/sound-fx/shooting-sound-177096
Coin 01 (Time Warning Audio) - https://assetstore.unity.com/packages/audio/sound-fx/sound-fx-retro-pack-121743
Power Up 11 (Level Up Audio) - https://assetstore.unity.com/packages/audio/sound-fx/sound-fx-retro-pack-121743
Game Over 28 (Game Over Audio) - https://assetstore.unity.com/packages/audio/sound-fx/sound-fx-retro-pack-121743
Pumpkin Sprite - https://www.pngitem.com/middle/TRbiiRm_pumpkin-clipart-spinning-png-clipart-freeuse-download-pumpkin/
Witch Sprite - https://www.animatedimages.org/img-animated-witch-image-0106-55484.htm