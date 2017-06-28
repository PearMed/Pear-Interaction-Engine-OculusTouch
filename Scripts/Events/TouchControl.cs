using Pear.InteractionEngine.Properties;
using System.Collections.Generic;
using UnityEngine;
using Pear.InteractionEngine.Controllers;
using System.Linq;

namespace Pear.InteractionEngine.Events
{
	/// <summary>
	/// Fires events for touch controls
	/// </summary>
	public class TouchControl : ControllerBehavior<OculusTouchController>, IEvent<bool>
	{
		[Tooltip("The touch control who's change we're listening for")]
		public OVRInput.Touch Touch;

		// Stores the event value that's handled by IEventListener classes
		public Property<bool> Event { get; set; }

		void Update()
		{
			Event.Value = OVRInput.Get(Touch, Controller.OVRController);
		}
	}
}