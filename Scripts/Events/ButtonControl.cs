using Pear.InteractionEngine.Properties;
using System.Collections.Generic;
using UnityEngine;
using Pear.InteractionEngine.Controllers;
using System.Linq;

namespace Pear.InteractionEngine.Events
{
	/// <summary>
	/// Fires events for button controls
	/// </summary>
	public class ButtonControl : ControllerBehavior<OculusTouchController>, IEvent<bool>
	{
		[Tooltip("The button who's change we're listening for")]
		public OVRInput.Button Button;

		// Stores the event value that's handled by IEventListener classes
		public Property<bool> Event { get; set; }

		void Update()
		{
			Event.Value = OVRInput.Get(Button, Controller.OVRController);
		}
	}
}