using System;
using UnityEngine;

namespace CooldownAPI
{
    internal class CooldownsManager : MonoBehaviour
    {
        /// The class that manages and calls all the cooldowns
        /// No need to use or call it manually 
        /// Tutorial and Examples: https://github.com/JosepeDev/CooldownAPI

        private Action cooldownsUpdates;

        private void Update()
        {
            cooldownsUpdates();
        }

        internal void AddToManager(Action call)
        {
            // delegate has no subscribers
            if (cooldownsUpdates == null)
            {
                // assign the first subscriber
                cooldownsUpdates = call;
            }
            else
            {
                // add an additional subscriber
                cooldownsUpdates += call;
            }
        }
    }
}
