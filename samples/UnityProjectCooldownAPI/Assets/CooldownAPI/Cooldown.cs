using UnityEngine;

namespace CooldownAPI
{
    /// Tutorial and Examples: https://github.com/jozzzzep/CooldownAPI
    /// <summary>
    /// A class for handling a cooldown in Unity using a timer
    /// </summary>
    public class Cooldown
    {
        /// Properties ---------------------------------------------------------------------------------
        /// - IsActive         - Determines if the cooldown is currently active (timer higher than zero)
        /// - Duration         - Returns the value of the default duration of the Cooldown object.
        /// - Timer            - Returns the current value from the cooldown's timer
        /// --------------------------------------------------------------------------------------------
        /// 
        /// Events -------------------------------------------------------------------------------------
        /// - BecameInactive   - An event that is raised when the cooldown becomes inactive
        /// --------------------------------------------------------------------------------------------
        /// 
        /// Methods ------------------------------------------------------------------------------------
        /// - Activate()       - Activates the cooldown with the default duration saved in the object.
        /// - Activate(float)  - Activates the cooldown with a custom duration.
        /// - Deactivate()     - Resets the timer (deactivates the cooldown).
        /// - ChangeDuration() - Changes the deafult cooldown duration saved in the object.
        /// --------------------------------------------------------------------------------------------

        private static CooldownsManager cooldownsManager;
        private static CooldownsManager CooldownsManager
        {
            get
            {
                if (cooldownsManager == null)
                    cooldownsManager = InitializeManager();
                return cooldownsManager;
            }
        }

        private bool isActive;
        private float duration;
        private float cooldownTimer;

        /// <summary>
        /// Used for creating a new cooldown
        /// </summary>
        /// <param name="duration">The default duration of the cooldown</param>
        public Cooldown(float duration)
        {
            this.duration = duration;
            Deactivate();
            CooldownsManager.AddToManager(Update);
        }

        public delegate void BecameInactiveEventHandler();

        /// <summary>
        /// Raised when the cooldown becomes inactive
        /// </summary>
        public event BecameInactiveEventHandler BecameInactive;

        /// <summary>
        /// Determines if the cooldown is currently active (timer higher than zero)
        /// <para> To activate >> <see cref="Activate()"/> or <see cref="Activate(float)"/></para>
        /// </summary>
        public bool IsActive => isActive;

        /// <summary>
        /// Returns the value of the default duration of the <see cref="Cooldown"/> object.
        /// <para> You can change its value at anytime with <see cref="ChangeDuration(float)"/></para>
        /// </summary>
        public float Duration => duration;

        /// <summary>
        /// Returns the current value from the cooldown's timer
        /// </summary>
        public float Timer => cooldownTimer;

        /// <summary>
        /// <para> Activates the cooldown with the default duration saved in the object. </para>
        /// <para> Call this method with parameters to activate the cooldown with a custom duration. <see cref="Activate(float)"/></para>
        /// </summary>
        public void Activate() => Activate(duration);

        /// <summary>
        /// <para> Activates the cooldown with a custom duration. </para>
        /// <para> Call this method without parameters to activate the cooldown with the default duration. <see cref="Activate()"/></para>
        /// </summary>
        /// <param name="customDuration">A float represents the duration in seconds you want the cooldown to be active</param>
        public void Activate(float customDuration)
        {
            isActive = true;
            cooldownTimer = customDuration;
        }

        /// <summary>
        /// Resets the timer (deactivates the cooldown).
        /// </summary>
        public void Deactivate()
        {
            isActive = false;
            cooldownTimer = 0;
            OnBecameInactive();
        }

        /// <summary>
        /// <para> Changes the deafult cooldown duration saved in the object. </para>
        /// <para> The deafult duration is set upon initialization and can be changed at anytime. </para>
        /// <para> You can get the value of the deafult duration from the property <see cref="Duration"/></para>
        /// </summary>
        /// <param name="newDurationValue"></param>
        public void ChangeDuration(float newDurationValue) =>
            duration = newDurationValue;

        private static CooldownsManager InitializeManager()
        {
            var cdm = Object.FindObjectOfType<CooldownsManager>();
            if (cdm == null)
            {
                var obj = new GameObject("CooldownsManager");
                return obj.AddComponent<CooldownsManager>();
            }
            return cdm;
        }

        private void OnBecameInactive()
        {
            var e = BecameInactive;
            if (e != null)
                e();
        }

        private void Update()
        {
            if (isActive)
            {
                if (cooldownTimer > 0f)
                    cooldownTimer = Mathf.Clamp(cooldownTimer - Time.deltaTime, 0f, duration);
                else
                    Deactivate();
            }
        }
    }
}
