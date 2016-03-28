***Changelog 0.0.02***   

***Additions:***   
***- Selecting options from the main menu now gives you a limited set of graphic options.***   
***- The HUD now has an animated health bar.***   
***- Added the first weapon, a metal pipe. Ordinarily it wouldn't be accessible until the next section but its enabled right away in the current build. So you can smack things if you want.***   
***- Added a flashlight pickup. After you pick up the flashlight you can toggle it on and off using the F key.***   

***Known Issues:***   
***- The pipe can currently be swung while text boxes and menus are active.***   
***- Graphics options set in the menu are not persistent beyond the menu scene.***   
***- I'm having a lot of issues with Unity's lighting currently. Hopefully the next Unity release really will have improved lighting options.***   

***Planned For Next Release:***   
***- Expanded functionality for the melee system: a "thrust" attack as well as a block ability. Preventing the pipe from swinging while in text boxes and menus.***   
***- Creating a serializable class to store and load graphic settings set in the main menu. Expanding available graphic options.***   

***Changelog 0.0.02_fixed***   

***Fixes:***   
***- The impact sound clip was not being played when the pipe hits a collider. This is now fixed.***   
***- The line renderer on the pipe has been removed.***   
***- Some Image effects added to the clipping/weapon camera so that equiped items share the effects used to render the rest of the scene.***   
***- The pipe no longer plays it's attack animation while text boxes and menus are running. The coroutine is still running though.***   

***Changes:***   
***- Added a particle system at the point of impact when striking objects with a collider.***   

