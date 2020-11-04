using UnityEngine;

public class Cooldown
{
    /// A class for handling cooldowns in Unity using a timer
    /// It is recommended to create a CooldownManager inside a class you want to use cooldowns in.
    ///
    /// Main wiki page: https://github.com/JosepeDev/Cooldown-System/wiki
    /// Examples and tutorial: https://github.com/JosepeDev/Cooldown-System/wiki/Examples-&-Tutorial
    ///
    /// INFO AND TOOLS:
    ///
    /// isActive - Call this bool for checking if the cooldown is active (timer higher than 0 = active)
    /// Duration - Returns the value of the current default duration
    ///
    /// DecreaseCooldown() - Call this method on Update() for each cooldown you have (don't do it if you use the cooldowns manager)
    /// ActivateCooldown() - Call this for activating the cooldown. If you don't input a duration, the default one will be used
    /// ResetCooldown() - If you want to deactivate the cooldown
    /// ChangeDefaultDurationValue() - Call this if you want to change the default Duration value after the declaration

    #region Content

    #region Variables and Properties

    // variables
    private float cooldownTimer; // The current value of the cooldown (higher than 0 = active)
    private float _duration; // Set this value on the declaration of the object (it is the default duration value)

    // properties
    public float Duration
    {
        get
        {
            return _duration;
        }
    }

    public bool isActive
    {
        get
        {
            return cooldownTimer > 0;
        }
    }

    #endregion

    #region Constructors

    public Cooldown(float _duration)
    {
        cooldownTimer = 0;
        this._duration = _duration;
    }

    #endregion

    #region Methods

    public void DecreaseCooldown()
    {
        // decrease cooldown only if its value is higher than 0
        if (isActive)
        {
            // decreases the cooldown by the time
            Mathf.Clamp(cooldownTimer -= Time.deltaTime, 0, _duration);
        }
    }

    // without a duration parameter, uses the default duration
    public void ActivateCooldown()
    {
        this.ActivateCooldown(_duration);
    }

    // if you want to add a special duration for the cooldown while keeping the default one
    public void ActivateCooldown(float customDuration)
    {
        cooldownTimer = customDuration;
    }

    // reset the timer's value to 0
    public void DeactivateCooldown()
    {
        cooldownTimer = 0;
    }

    public void ChangeDefaultDurationValue(float newDurationValue)
    {
        _duration = newDurationValue;
    }

    #endregion

    #endregion
}