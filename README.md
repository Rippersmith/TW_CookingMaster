# TW_CookingMaster
Repository for Tentworks' Cooking Master development test

Some of the objects I was unfortunately not able to get to in time, or weren't implemented properly.
The ones that I missed are:
	+ Customer Timers: These are technically implemented, however I didn't get a chance to
	create a meter or anything for it. As it is now, it's able to run, but the player doesn't
	see how long they have left
	+ Angry Customers: Again, this is partially implemented. The time shortens, but the player(s)
	don't recieve any sort of penalty besides that at this point.
	+ Chopping Board Timers: This one hasn't been implemented at all. As of right now, when you
	take a vegetable to a cutting board, it''l be immediately turned into a salad
	+ Power-ups: I'd created scripts and prefabs for the power-ups, but I haven't added any proper
	functionality, other than destroying after about 20 seconds. Also, because I was doing some
	last-minute debugging, it may spawn regardless if you delivered the order to the customer
	before the 70% mark (though that part's also implemented - you could grab 2 with 1 delivery!)
	+ High Score List: Has not been implemented
	+ End Screen: No option is displayed, the end screen just displays itself for 5 seconds with
	the winning message, then restarts the game

Tackling the unsolved features:
	+ Customer Timers: I'd use a bar that decreases over time, most likely using a Slider object.
	I've also considered whether or not I'd use a radial timer, though I'm not positive how to implement
	that yet, possibly with a Mask
	+ Angry Customers: I already have the "decreased time" implemented, by increasing the time
	multiplier on the timer (currently, I believe that it doubles it). After that, the issue would
	be adding the points to a player's score
	+ Chopping Board Timers: most of my solutions here would be the same as the "Customer Timers"
	+ Power-ups: This one had me a little stumped. Spawning them and adding functionality would be
	the easy parts, though I'm not sure how to make sure how it would only be picked up by each player.
	Possibly, I could make a different tag like "Player1" & "Player2" for the 2 players, rather than
	just a "Player" tag. That, or I could somehow pass the appropriate PlayerScript into the power-up,
	and only allow it to be picked up by the player with that PlayerScript
	+ High Score List: This would be the best use of the GameManager. Assuming that I was still under
	a time constraint, I'd just use a simple PlayerPrefs to save the high scores, using an array of
	Dictionaries<string name, int score> to read from when displaying the high scores.
	+ I may use an Additive scene for this, and implementing the proper Buttons. I pretty much had most
	of the essential functionality already programmed

There are also some notable decisions that I made on this project:
	+ Shaders: I added a shader to the players. You can add your own color on the PlayerInfo script,
	and the player's apron and hat will change to that color when the game starts. I wanted to give
	each player it's own color to differentiate them from each other, without just painting the whole
	sprite. I didn't want to make new sprites for animation, and thought this would be more efficient.
	I also put this shader on the power-ups to indicate which player is (supposed to be) able to 
	pick it up. I also meant to apply this color to the player texts
	+ VegetableScriptObj vs SaladScriptObj: I made 2 different scriptable objects, which kind of clash
	with each other a few times. I thought it would be better to make a VegetableScriptObj that didn't
	have a lot of different variables to check against with the customers
	+ Storing in a Queue: The way the instructions described the task, it was pretty obvious that 
	I was expected to use a Queue, what with the FIFO functionality that was expected. However, I've
	mostly worked with arrays and Lists<> in Unity, and Queues haven't been a focus for me for a 
	long time
	+ Lacking GameManager: After working on the project for a bit, I realized that GameManager wasn't
	properly being used. Instead, I ended up putting a lot of the most important variables in the 
	PlayersScripts and PlayerInfo scripts. I realized that there weren't many variables that could
	be "shared" between the two players, and I wanted to try and keep the player scripts separated
	so they wouldn't get tangled up, and everything would get lost. Scripts also kept going to the 
	GameManager and were sent to another script, without anything actually being stored there. Next time,
	I'll try and combine the player scripts into GameManager in a (hopefully) cohesive manner
	+ Vegetable Piles Images: ...I'm going to be honest, I initially wanted to make custom art, but I
	ran out of time and just grabbed a few images off of Google Images. Also, I though it would be
	a little funny to try and make salad out of tomato soup

There are definitely a lot of things that I would like to go back and fix:
	+ Too many public variables & functions: right now, there are a lot of public variables and
	functions. I wanted to value functionality first, since I had a large list of things to do,
	and I wanted to make the game function and hit as many of those points as possible first. I 
	intended to go back and fix the scripts, so that more variables would be able to use code like
	GetComponent<> to assign variables, and move some functions around so it isn't as messy
	+ Timers & Power-ups: The next important things to make in the game would be the timers for the
	customers & chopping board, and fix the functionality on the power-ups. These, to me, were the 
	biggest points that I never got to, and make the game more fun. As it is now, there's no real
	strategy other than "read order, make order quick, serve order." Timers & power ups would require
	some more strategizing, and make the game just a little more hectic
	+ Proper Images/Animations: These I'd try to save for last. I'll admit, I got a little carried
	away in the beginning making my own art assets for the game, and that kind of came back to haunt
	me when I moved on to the programming part and had less time to finish them as a result. I'd save
	them for later, once I've added more of the essential functionality to the rest of the game
	
