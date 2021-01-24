# BloonsTD6-Mod-Helper
A powerful and easy to use API for BTD6 modding. It was created with the successes and failures of previous APIs in mind so it should be significantly easier to use.

## How to use it
Like other API, download/clone it. In your mod's Visual Studio project, a reference to `BloonsTD6 Mod Helper.dll`. Then at the top of each file in your project, add `using BloonsTD6_Mod_Helper.Extensions;`. Thats it. Each file that has this line at the top will have complete access to all of the features added by the API. This API is built using extension methods, which means it's created to work along side BTD6's own code. So just make your mods like normal and you'll see the new features pop up in Visual Studio Intellisense.

## What can this API currently help with
- Many useful parts of BTD6 code are hidden, deeply nested, and in obscure places. The API moves them to `Game.instance` and `InGame.instance` whenever possible making them significantly easier to access
- Many extension methods added to make modifying towers, upgrades, weapons, projectiles, and bloons easier.
- A lot of code for towers/bloons is unconnected, meaning you have to go all over to find something. API connects them in as many ways as possible
  - Towers, TowerModels, TowerToSimulation, and TowerPurchaseButtons are all inter-linked.
  - Bloons, BloonModels, and BloonToSimulation are all inter-linked
  - Same for Abilities and projectiles


## Future plans
The API already has a lot of features added, however it's no where near done. The goal is to make this a universal mod helper for btd6. To achieve this goal many features need to be added
