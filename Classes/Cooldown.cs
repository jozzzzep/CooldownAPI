using UnityEngine;

public class Cooldown
{
    /// A class for handling a single cooldown in Unity using a timer
    /// It is recommended to create a CooldownManager inside a class you want to use cooldowns in.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/CooldownAPI
    ///
    /// Properies:
    /// - IsActive - Determines if the cooldown is currently active (timer higher than zero)
    /// - Duration - Returns the value of the default duration of the Cooldown object.
    /// 
    /// Methods:
    /// - Activate()               - Activates the cooldown with the default duration saved in the object.
    /// - Activate(float duration) - Activates the cooldown with a custom duration.
    /// - Deactivate()             - Resets the timer (deactivates the cooldown).
    /// - ChangeDuration()         - Changes the deafult cooldown duration saved in the object.

    #region Variables and Properties

    /// <summary>
    /// Determines if the cooldown is currently active (timer higher than zero)
    /// <para> To activate >> <see cref="Activate()"/> or <see cref="Activate(float)"/></para>
    /// </summary>
    public bool IsActive
    {
        get => _cooldownTimer > 0;
    }

    /// <summary>
    /// Returns the value of the default duration of the <see cref="Cooldown"/> object.
    /// <para> You can change its value at anytime with <see cref="ChangeDuration(float)"/></para>
    /// </summary>
    public float Duration
    {
        get => _duration;
    }

    // variables
    private float _cooldownTimer; // The current value of the cooldown (higher than 0 = active)
    private float _duration; // Set this value on the declaration of the object (it is the default duration value)

    #endregion

    #region Constructors

    /// <summary>
    /// NOT RECOMMENDED - Use the <see cref="CooldownsManager"/> class for creating a cooldown. <see cref="CooldownsManager.NewCooldown(float)"/>
    /// </summary>
    /// <param name="_duration">The default duration of the cooldown</param>
    public Cooldown(float _duration)
    {
        _cooldownTimer = 0;
        this._duration = _duration;
    }

    #endregion

    #region Methods

    /// <summary>
    /// <para> DON'T YOU THIS METHOD IF YOU USE THE <see cref="CooldownsManager"/>. (and you should use the <see cref="CooldownsManager"/>) </para>
    /// The most important method. Call it on Update() inside a MonoBehaviour.
    /// </summary>
    public void Update()
    {
        // only if the cooldown is active (timer higher than zero)
        if (IsActive)
        {
            // decreases the cooldown by the time
            Mathf.Clamp(_cooldownTimer -= Time.deltaTime, 0, _duration);
        }
    }

    /// <summary>
    /// <para> Activates the cooldown with the default duration saved in the object. </para>
    /// <para> Call this method with parameters to activate the cooldown with a custom duration. <see cref="Activate(float)"/></para>
    /// </summary>
    public void Activate() => Activate(_duration);

    /// <summary>
    /// <para> Activates the cooldown with a custom duration. </para>
    /// <para> Call this method without parameters to activate the cooldown with the default duration. <see cref="Activate()"/></para>
    /// </summary>
    /// <param name="customDuration">A float represents the duration in seconds you want the cooldown to be active</param>
    public void Activate(float customDuration)
    {
        _cooldownTimer = customDuration;
    }

    /// <summary>
    /// Resets the timer (deactivates the cooldown).
    /// </summary>
    public void Deactivate()
    {
        _cooldownTimer = 0;
    }

    /// <summary>
    /// <para> Changes the deafult cooldown duration saved in the object. </para>
    /// <para> The deafult duration is set upon initialization and can be changed at anytime. </para>
    /// <para> You can get the value of the deafult duration from the propertie <see cref="Duration"/></para>
    /// </summary>
    /// <param name="newDurationValue"></param>
    public void ChangeDuration(float newDurationValue)
    {
        _duration = newDurationValue;
    }

    #endregion
}