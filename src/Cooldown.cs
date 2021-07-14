using UnityEngine;

namespace CooldownAPI
{
    public class Cooldown
    {
        /// A class for handling a cooldown in Unity using a timer
        /// Tutorial and Examples: https://github.com/JosepeDev/CooldownAPI
        ///
        /// Properies:
        /// - IsActive                 - Determines if the cooldown is currently active (timer higher than zero)
        /// - Duration                 - Returns the value of the default duration of the Cooldown object.
        /// - Timer                    - Returns the current value from the cooldown's timer
        /// 
        /// Methods:
        /// - Activate()               - Activates the cooldown with the default duration saved in the object.
        /// - Activate(float duration) - Activates the cooldown with a custom duration.
        /// - Deactivate()             - Resets the timer (deactivates the cooldown).
        /// - ChangeDuration()         - Changes the deafult cooldown duration saved in the object.

        /// <summary>
        /// Used for creating a new cooldown
        /// </summary>
        /// <param name="duration">The default duration of the cooldown</param>
        public Cooldown(float duration)
        {
            _cooldownTimer = 0;
            _duration = duration;
            CDM.AddToManager(Update);
        }

        /// <summary>
        /// Determines if the cooldown is currently active (timer higher than zero)
        /// <para> To activate >> <see cref="Activate()"/> or <see cref="Activate(float)"/></para>
        /// </summary>
        public bool IsActive
        {
            get => _cooldownTimer > 0f;
        }

        /// <summary>
        /// Returns the value of the default duration of the <see cref="Cooldown"/> object.
        /// <para> You can change its value at anytime with <see cref="ChangeDuration(float)"/></para>
        /// </summary>
        public float Duration
        {
            get => _duration;
        }

        /// <summary>
        /// Returns the current value from the cooldown's timer
        /// </summary>
        public float Timer
        {
            get => _cooldownTimer;
        }

        private float _cooldownTimer; 
        private float _duration; // the default duration value

        static CooldownsManager _cdm;
        static CooldownsManager CDM
        {
            get
            {
                if (_cdm == null)
                {
                    _cdm = Initialize();
                }
                return _cdm;
            }
        }

        /// <summary>
        /// Do not call manually
        /// </summary>
        private void Update()
        {
            if (IsActive)
            {
                _cooldownTimer = Mathf.Clamp(_cooldownTimer - Time.deltaTime, 0f, _duration);
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
        /// <para> You can get the value of the deafult duration from the property <see cref="Duration"/></para>
        /// </summary>
        /// <param name="newDurationValue"></param>
        public void ChangeDuration(float newDurationValue)
        {
            _duration = newDurationValue;
        }

        private static CooldownsManager Initialize()
        {
            var cdm = Object.FindObjectOfType<CooldownsManager>();
            if (cdm == null)
            {
                var obj = new GameObject("CooldownsManager");
                return obj.AddComponent<CooldownsManager>();
            }
            return cdm;
        }
    }
}
