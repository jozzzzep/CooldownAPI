![img](https://i.imgur.com/cSOJR5d.png)  
 <p align="center">
        <img src="https://img.shields.io/codefactor/grade/github/JosepeDev/CooldownAPI/main">
        <img src="https://img.shields.io/github/languages/code-size/JosepeDev/CooldownAPI">
        <img src="https://img.shields.io/github/license/JosepeDev/CooldownAPI">
        <img src="https://img.shields.io/github/v/release/JosepeDev/CooldownAPI">
</p>
<p align="center">
        <img src="https://img.shields.io/github/followers/JosepeDev?style=social">
        <img src="https://img.shields.io/github/watchers/JosepeDev/CooldownAPI?style=social">
        <img src="https://img.shields.io/github/stars/JosepeDev/CooldownAPI?style=social">
</p>

### Content
- [**Setup & Examples**](#setup-and-examples)
- [**Documentations**](#documentations)
  - [Cooldown](#cooldown)

# Setup And Examples
Let's say we have an **attack method** in our game for the **player**.  When the player **presses** a key, we want to **attack**.  But we also want to **apply a cooldown** when the player **attacks** to **prevent** the player from attacking too quickly.  

First let's **declare** a **Cooldown** for the attack and call it "**attackCooldown**"   
Also, let's declare a **float** variable for the **amount of seconds** between attacks. 
Let's say we want the duration of the cooldown to be 3.25 seconds.
```csharp
float attackCoodldownDuration = 3.25f;
Cooldown attackCooldown;
```
Now to **initialize** it. All you got to to is to **call** its constructor.  
When you **initialize** a Cooldown object, you set its **default duration** value.  
And it's the float variable we declared before.  
Make sure you initialize your cooldowns inside **Start()** or **Awake()**  
```csharp
void Awake()
{
  attackCooldown = new Cooldown(attackCooldownDuration);
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
We can do this by checking the value **IsActive** in the cooldown.  
```csharp
if (//player is pressing the attack button)
{
  if (attackCooldown.IsActive == false)
  {
    Attack();
  }
}
```
A **Cooldown** object contains **two** properties. A **timer** and a default **duration**.  
The Cooldown is considered "**active**" when its **timer** equal to **zero**.  
The timer is always **decreasing** until it reaches zero.  
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
You can also **manually** deactivate the cooldown and reset its timer to zero.  
Use the method **Deactivate()**  
```csharp
attackCooldown.Deactivate();
```
# Documentations
### Cooldown
A class for handling a cooldown in Unity using a timer.   

- Properties
  - **IsActive**  
  Determines if the cooldown is currently active.  
  Returns true if the timer is higher than zero.  
  
  - **Duration**  
  Returns the default duration value of the Cooldown object.  
  The default duration is set upon initialization.  
  It used when you call the Activate() method without inputting parameters.  

  - **Timer**  
  Returns the current value from the cooldown's timer
  
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

- Constructors
  - **Cooldown(float duration)**  
  Used for creating a new cooldown  
  Input the default duration of the cooldown

- Events
  - **BecameInactive**  
  An event that is raised when the cooldown becomes inactive
