![img](https://i.imgur.com/6VJLFue.png)  

### Content
- [**Setup & Examples**](#setup-and-examples)
- [**Documentations**](#documentations)
  - [CooldownsManager](#cooldownsmanager)
  - [Cooldown](#cooldown)

# Setup And Examples
Let's say you want to add a cooldown to some behaviour in your game.  
First, create and initialize a **CooldownsManager** object. (Do this inside a **MonoBehaviour** class)
```csharp
CooldownsManager cooldownsManager = new CooldownsManager();
```
Very simple.  
Now the last step, call the method **Update() of your CooldownsManager** inside the **Update()** method  
```csharp
void Update()
{
  cooldownsManager.Update();
}
```
You're all set and can add cooldowns.  
Let's start with creating a cooldown.  
Let's say we have an **attack method** in our game for the **player**.  
When the player **presses** a key, we want to **attack**.  
But we also want to **apply a cooldown** when the player **attacks**.  
And also to **prevent** the player from attacking **if** the cooldown **is active**.  
First let's **create** a **Cooldown** for the attack and call it "**attackCooldown**"   
Also, let's create a **float** variable for the **amount of seconds** between attacks. 
Let's say we want 3.25 seconds cooldown duration.
```csharp
float attackCoodldownDuration = 3.25f;
Cooldown attackCooldown;
```
Now to **initialize** it. All you got to to is to **set** its value to the method **NewCooldown()**  
When you **initialize** a Cooldown object, you set its **default duration** value.  
And it's the float variable we initialized before.
Initialize all your cooldowns inside **Start()** or **Awake()**  
```csharp
void Awake()
{
  attackCooldown = cooldownsManager.NewCooldown(attackCooldownDuration);
}
```
Done. The cooldown is ready.  
Let's activate it when we attack. We just need to use the method **Activate()**  
```csharp
void Attack()
{
  // some attack behaviour
  ...
  // cooldown activation
  attackCooldown.Activate();
}
```
Now, let's **prevent** the player from attacking **if** the cooldown **is active**.  
We can do this by checking the value **IsActive**.  
```csharp
if (player is pressing the attack button)
{
  if (attackCooldown.IsActive == false)
  {
    Attack();
  }
}
```
A **Cooldown** object contains **two** properties. A **timer** and a default **duration**.  
The Cooldown is considered "**active**" when its **timer** is equal to **zero**.  
The timer is **decreasing** when the **Update()** method of the **CooldownsManager** is called.  
Let's say we want to add a special, shorter attack, and apply a **short cooldown** for it with a **different duration**.  
We can do it with the **Activate()** method by **inputting** a **custom duration** to it.  
```csharp
void SpecialAttack()
{
  // some attack behaviour
  ...
  // cooldown activation
  attackCooldown.Activate(1.7f); // cooldown applied with a custom duration.
}
```
You can also **change** the **default duration** at any time with the method **ChangeDuration()**
```csharp
attackCooldown.ChangeDuration(8f);
```
You can also **manually** disable the cooldown and reset its timer to zero.  
Use the method **Deactivate()**  
```
attackCooldown.Deactivate();
```
# Documentations
### CooldownsManager
A class for handling and managing multiple cooldowns efficiently.  
![img](https://i.imgur.com/s6orwHe.jpg)  

- Methods
  - **Update()**  
  Call this method inside Update() in a MonoBehaviour inherited class.  
  Updates the value of all the cooldowns that are subscribed to the specified manager.  
  Decreases all the cooldown timers by the time, at once.  
  A cooldown is subscribed automatically to the CooldownsManager it has been created with.
  
  - **NewCooldown(float duration)**  
  Returns a new Cooldown object. Better than creating a Cooldown with a constructor.  
  Subscribes the cooldown created to the Update() method of the CooldownsManager it has been created with.   
  
### Cooldown
A class for handling a single cooldown in Unity using a timer.  
It is recommended to create a CooldownManager inside a class you want to use cooldowns in.  
![img](https://i.imgur.com/kHITH1f.jpg)  

- Properties
  - **IsActive**  
  Determines if the cooldown is currently active.  
  Returns true if the timer is higher than zero.  
  
  - **Duration**  
  Returns the default duration value of the Cooldown object.  
  The default duration is set upon initialization.  
  It used when you call the Activate() method without inputting parameters.  
  
- Methods
  - **Activate()**  
  Activates the cooldown with the default duration.  
  You can get the default duration's value form the Duration propertie.  
  
  - **Activate(float customDuration)**  
  Activates the cooldown with a custom duration.  
  
  - **Deactivate()**  
  Deactivates the cooldown manually.  
  Resets the timer's value to zero.  
  
  - **ChangeDuration(float duration)**  
  For changing the default duration's value.  
