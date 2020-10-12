using System;

public class CooldownsManager
    {
        // A class for handeling and managing cooldowns efficiently
        //
        // ---- INFO AND TOOLS:
        // 
        // DecreaseCooldowns() - Call this method inside Update() to decrease all the cooldowns
        // NewCooldown() - Creates and returns a new cooldown, just input the cooldown's duration.
        //
        // ---- TUTORIAL(For beginners):
        //
        // 1.
        // For managing cooldowns in a class create and initialize a new CooldownManager.
        // Example: CooldownManager cooldownManager = new CooldownManager();
        //
        // 2.
        // To create a new cooldown create the variable in the class.
        // Example: Cooldown nameOfYourCooldown;
        // 
        // 3.
        // Inside Start() or Awake() assign each cooldown to the method NewCooldown() and input the cooldown's duration.
        // Example: nameOfYourCooldown = CooldownManager.NewCooldown(4f);
        //
        // 4.
        // Final step, call the decreaseCooldowns Action in the Update() method.
        // Example: decreaseCooldowns();
        //
        // ----

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
            if(decreaseCooldowns == null)
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
