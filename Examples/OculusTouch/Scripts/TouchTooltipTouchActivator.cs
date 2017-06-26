﻿using UnityEngine;

namespace Pear.InteractionEngine.Examples
{
    /// <summary>
    /// Activates/Deactivates a tooltip based on interaction with a button and/or joystick
    /// </summary>
    public class TouchTooltipTouchActivator : TouchTooltipActivator
    {
        [Tooltip("Target to listen for touch event")]
        public OVRInput.Touch TouchListener;

        [Tooltip("Pressing deactivates showing tooltip")]
        public OVRInput.Button ButtonListener;

        [Tooltip("Using deactivates showing tooltip")]
        public OVRInput.Axis2D Axis2DListener;

        /// <summary>
        /// Activate this tooltip if the user is touching the controller element (e.g. button, joystick, ect)
        /// </summary>
        /// <returns>True if user is touching the button. False otherwise.</returns>
        protected override bool ShouldStartTimer()
        {
            return OVRInput.Get(TouchListener, Controller.OVRController);
        }

        /// <summary>
        /// Deactivate the tooltip if the user presses a button or moves the joystick
        /// </summary>
        /// <returns>True if user presses a button or moves the joystick. False otherwise.</returns>
        protected override bool ShouldStopTimer()
        {
            Vector2 axis2dVal = OVRInput.Get(Axis2DListener, Controller.OVRController);
            return !OVRInput.Get(TouchListener, Controller.OVRController) ||
                OVRInput.Get(ButtonListener, Controller.OVRController) ||
                axis2dVal.x > 0 || axis2dVal.y > 0;
        }
    }
}