using System;

public class CooldownsManager 
{
    // A class for handling and managing multiple cooldowns efficiently
    //
    // Wiki page: https://github.com/JosepeDev/UnityCooldownsHandler/wiki/CooldownsManager
    // Examples and tutorial: https://github.com/JosepeDev/UnityCooldownsHandler/wiki/Examples-&-Tutorial
    //
    // INFO AND TOOLS:
    // 
    // DecreaseCooldowns() - Call this method inside Update() to decrease all the cooldowns
    // NewCooldown() - Creates and returns a new cooldown, just input the cooldown's duration.

    #region Variables

    // when called it'll decrease every cooldown you created with this object
    private Action decreaseCooldowns;

    #endregion

    #region Methods

    public Cooldown NewCooldown(float duration)
    {
        // create a new cooldown
        Cooldown returnThisCooldown = new Cooldown(duration);

        // add to Action delegate
        AssignCooldownToDelegate(returnThisCooldown);

        // return the new cooldown
        return returnThisCooldown;
    }

    // calls the delegate from outside the class
    public void DecreaseCooldowns()
    {
        decreaseCooldowns();
    }

    private void AssignCooldownToDelegate(Cooldown cooldown)
    {
        // delegate has no subscribers
        if (decreaseCooldowns == null)
        {
            // assign the first subscriber
            decreaseCooldowns = cooldown.DecreaseCooldown;
        }
        else
        {
            // add an additional subscriber
            decreaseCooldowns += cooldown.DecreaseCooldown;
        }
    }

    #endregion
}