using System;

public class CooldownManager 
{
    /// A class for handling and managing multiple cooldowns efficiently.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/CooldownAPI
    ///
    /// Methods:
    /// - Update()      - IMPORTANT Call this method on Update() inside a MonoBehaviour to Update all the cooldowns
    /// - NewCooldown() - Creates and returns a new cooldown, just input the cooldown's duration.

    #region Variables

    // when called it'll decrease every cooldown you created with this object
    private Action cooldownsUpdateMethods;

    #endregion

    #region Methods

    /// <summary>
    /// Returns a new <see cref="Cooldown"/> object and subscribes it to the <see cref="CooldownManager"/> it has been created with.
    /// <para> When you call the <see cref="Update()"/>, it updates all the cooldowns you created with <see cref="NewCooldown(float)"/> at once </para>
    /// </summary>
    /// <param name="duration"> The default duration you want the <see cref="Cooldown"/> object to have.</param>
    /// <returns></returns>
    public Cooldown NewCooldown(float duration)
    {
        // create a new cooldown
        Cooldown returnThisCooldown = new Cooldown(duration);

        // add to Action delegate
        AssignCooldownToDelegate(returnThisCooldown);

        // return the new cooldown
        return returnThisCooldown;
    }

    /// <summary>
    /// IMPORTANT >> Call this method on Update() inside a MonoBehaviour to Update all the cooldowns
    /// </summary>
    public void Update()
    {
        cooldownsUpdateMethods();
    }

    private void AssignCooldownToDelegate(Cooldown cooldown)
    {
        // delegate has no subscribers
        if (cooldownsUpdateMethods == null)
        {
            // assign the first subscriber
            cooldownsUpdateMethods = cooldown.Update;
        }
        else
        {
            // add an additional subscriber
            cooldownsUpdateMethods += cooldown.Update;
        }
    }

    #endregion
}