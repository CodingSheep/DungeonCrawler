# DungeonCrawler #
Our attempt at a dungeon crawler game.

# Who #
1.  Joe Alsko, JAlsko
2.  Sky Johnson, nullmage
3.  Jacob Toomey, jcbtmy
4.  Jarrod Raine, codingsheep
5.  Stevan Maksimovic, stevmak

# Title #

That One Dungeon Crawler

# Description #

A game that uses a rhythm game like interaction as a pivotal part of the base game mechanic. This game will be a dungeon crawler-esk 2.5d isometric rouge-like hack and slash. Made in Unity.

# Vision Statement #

"To deliver smooth interactive gameplay mechanics, and a game I could show off playing."   
Motivation:  
We all want to make a game that we would want to play.

# Automated Tests #

For automated testing, we used Unity Test Tools which is an asset package provided by Unity in order to test certain game mechanics.  
![alt tag](http://i.imgur.com/YeFUt28.png)  
This package is essentially a collection of scripts that we can add to any game object to test changes during the game. As you can see, we added an AssertionComponent to the player object.  
![alt tag](http://i.imgur.com/M2iXgQC.png)  
In the AssertionComponent, we can set what type of variable is being tested, when the test should arise, and what to test for, and all of this happens automatically during playtests. In the case above, we test whether player speed increases when he/she gets a speed pick-up. If the test were to fail, an error message would appear in the console, and the game would pause.  
![alt tag](http://i.imgur.com/ZlSNvZO.png)  
In the image above, we set up the test to fail to show what happens if it ever does fail. The console message shows what assertion failed and how it failed. Above that, there is a button labeled "Error Pause," and what this means is that the game will pause whenever an error occurs during testing, so that we can see under what circumstances within the game caused this error.  

# User Acceptance Tests #

UAT 1  
&nbsp;&nbsp;Use case name   
&nbsp;&nbsp;&nbsp;&nbsp;Player speed pick-up  
&nbsp;&nbsp;Description  
&nbsp;&nbsp;&nbsp;&nbsp;Player speed increases when picking up the yellow speed pick-up
&nbsp;&nbsp;Preconditions 
&nbsp;&nbsp;&nbsp;&nbsp;None  
&nbsp;&nbsp;Test steps  
&nbsp;&nbsp;&nbsp;&nbsp;Move player object with arrow keys into yellow circle   
&nbsp;&nbsp;Expected result  
&nbsp;&nbsp;&nbsp;&nbsp;Player speed increases slightly and pick-up disappears  
&nbsp;&nbsp;Actual result   
&nbsp;&nbsp;&nbsp;&nbsp;Player speed increases from 10 to 13 and pick-up disappears  
&nbsp;&nbsp;Status  
&nbsp;&nbsp;&nbsp;&nbsp;Pass    
    
UAT 2   
&nbsp;&nbsp;Use case name   
&nbsp;&nbsp;&nbsp;&nbsp;Arrow speed pick-up  
&nbsp;&nbsp;Description  
&nbsp;&nbsp;&nbsp;&nbsp;Arrow speed increases when picking up the orange arrow speed pick-up    
&nbsp;&nbsp;Preconditions  
&nbsp;&nbsp;&nbsp;&nbsp;None  
&nbsp;&nbsp;Test steps  
&nbsp;&nbsp;&nbsp;&nbsp;Move player object with arrow keys into orange circle   
&nbsp;&nbsp;Expected result  
&nbsp;&nbsp;&nbsp;&nbsp;Arrow speed increases slightly and pick-up disappears   
&nbsp;&nbsp;Actual result   
&nbsp;&nbsp;&nbsp;&nbsp;Player speed increases from 1 to 2 and pick-up disappears   
&nbsp;&nbsp;Status  
&nbsp;&nbsp;&nbsp;&nbsp;Pass  
    
UAT 3   
&nbsp;&nbsp;Use case name   
&nbsp;&nbsp;&nbsp;&nbsp;Osu circle appears  
&nbsp;&nbsp;Description  
&nbsp;&nbsp;&nbsp;&nbsp;A circle appears near the player when right-click is held down, and the player can left-click on the circle.    
&nbsp;&nbsp;Preconditions  
&nbsp;&nbsp;&nbsp;&nbsp;None  
&nbsp;&nbsp;Test steps  
&nbsp;&nbsp;&nbsp;&nbsp;Click and hold right-click, and left-click on the circle that appears   
&nbsp;&nbsp;Expected result  
&nbsp;&nbsp;&nbsp;&nbsp;Circle appears near the player and disappears once the player left-clicks on it  
&nbsp;&nbsp;Actual result   
&nbsp;&nbsp;&nbsp;&nbsp;Circle appears next to the player and disappears once the player left-clicks on it  
&nbsp;&nbsp;Status  
&nbsp;&nbsp;&nbsp;&nbsp;Pass    
