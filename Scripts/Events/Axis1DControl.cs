using Pear.InteractionEngine.Controllers;
using Pear.InteractionEngine.Properties;
using UnityEngine;

namespace Pear.InteractionEngine.Events
{
	/// <summary>
	/// Fires events for axis 1d controls
	/// </summary>
	public class Axis1DControl : ControllerBehavior<OculusController>, IEvent<float>
	{
		[Tooltip("The control who's changes we're listening for")]
		public OVRInput.Axis1D Control;

		// Stores the event value that's handled by IEventListener classes
		public Property<float> Event { get; set; }

		void Update()
		{
			Event.Value = OVRInput.Get(Control, Controller.OVRController);
		}
	}
}