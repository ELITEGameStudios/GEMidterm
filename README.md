Noah Simmons - Midterm

Singleton implementations: GameManager and ObjectPooler scripts.

GameManager: Intended to control and track the game state. the game state would be held by the isAlive bool,  and would be called by keyboard input or the Player script to start or end the game at appropriate times and events.

ObjectPooler: Capable of getting a bubble Prefab, creating a list of bubbles on startup, and outputting unused bubble objects from the list. The IBubbleSpawner would call this singleton's GetBubble() in place of what would otherwise be using Instantiate(). An object pooler system as not been used in class yet, and is vital for optimizing for memory usage and performance in many games.

Factory Implementation: IBubbleSpawner

IBubbleSpawner interface is inherited by GreenBubbleSpawner, BlueBubbleSpawner, and RedBubbleSpawner with the purpose of spawning and initializing specific bubble types which behave different ways. The Setup() Function in Bubble is called with different parameters passed by the inheritors of IBubbleSpawner to give slight variance to the bubble's behaviour. The idea of demonstrating the factory pattern to spawn bubbles is that it would differ from the courses repeated implementation of it for enemy logic. Bubbles are different because it is a player ability and a projectile instead of an enemy system.

Object Oriented Programming:
I apply the concept of abstraction and inheritance through the use of the IBubbleSpawner base class, and the three aforementioned scripts, which inherit and implements the SpawnBubble() Function. This is done so that each bubble spawner uses the same function to setup a bubble in their given ways, and set these spawner classes up for polymorphism. I apply polymorphism through the players' recognization of the three classes inheriting from the interface, Simply as the interface itself. This way, the player does not need to know what bubble it is spawning or how it should spawn it. It only knows to spawn a bubble.

Note: I recognize that the bubbles themselves could have benefitted from a base class and inheritance system. The reason I opted to go for one class and a behaviour enum is so that I could both use the factory pattern in a valid use case in that each spawner varies the Prefab itself in some way with its own custom spawning logic to any degree that isn't just holding a Prefab (in which case factory would otherwise be redundant as opposed to a single spawner class for the scope of this system). Moreover, having a single Bubble class allows easier development and implementation of the ObjectPooler system given the scope and time constraints. Implementing bubble in this way cuts more development time and complexity to an ObjectPooler that doesn't need to be complex in this solution.

Notable extra Bubble context: the differences between bubbles are their move patterns, expressed through a constant addition to position, a mathematical function floating up in the shape of a parabola, and a stationary blue bubble (for enemies to walk in to)
Bubbles would be spawned by a random spawner chosen on the spawn event, evident in the Players calling of SpawnBubble()

The Build: 
Features a somewhat working left to right player controller. Most of the systems are made, but none of them get the chance to work and demonstrate their functions due to the lack of enemies softlocking the loss condition, a null reference to the IBubbleSpawner objects due to not being reference-able through the Unity editor. Should that single mistake be fixed, the build would at least have its core mechanic functionality working as intended. It was intended to have a single enemy type which just dies on a collision to a bubble, but Enemies would never be implemented. This should explain code surrounding the EndGame()Function in the GameManager and the collision detection of the player, since enemies was intended within the design of the game.
