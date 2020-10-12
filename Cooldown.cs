using UnityEngine;

public class Cooldown
    {
        // A class for handeling cooldowns in Unity using a timer
        // Create a CooldownManager inside a class you want to use cooldowns in.
        //
        // ---- INFO AND TOOLS:
        //
        // isActive - Call this bool for checking if the cooldown is active (timer higher than 0 = active)
        // Duration - Returns the value of the current deafult duration
        //
        // DecreaseCooldown() - Call this method on Update() for each cooldown you have (don't worry about it if you use the manager)
        // ActivateCooldown() - Call this for activating the cooldown. If you don't input a duration, the deafult one will be used
        // ResetCooldown() - If you want to deactivate the cooldown
        // ChangeDeafultDurationValue() - Call this if you want to change the deafult Duration value after the declaration
        //
        // ----

        #region Variables and Properties

        // variables
        private float cooldownTimer; // The current value of the cooldown (higher than 0 = active)
        private float _duration; // Set this value on the declaration of the object (it is the deafult duration value)

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

        // without a duration parameter, uses the deafult duration
        public void ActivateCooldown()
        {
            this.ActivateCooldown(_duration);
        }

        // if you want to add a special duration for the cooldown while keeping the deafult one
        public void ActivateCooldown(float customDuration)
        {
            cooldownTimer = customDuration;
        }

        // reset the timer's value to 0
        public void DeactivateCooldown()
        {
            cooldownTimer = 0;
        }

        public void ChangeDeafultDurationValue(float newDurationValue)
        {
            _duration = newDurationValue;
        }

        #endregion
    }
