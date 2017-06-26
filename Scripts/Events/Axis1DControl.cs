using Pear.InteractionEngine.Controllers;
using Pear.InteractionEngine.Properties;
using UnityEngine;

namespace Pear.InteractionEngine.Events
{
	public class Axis1DControl : ControllerBehavior<OculusTouchController>, IEvent<float>
	{
		[Tooltip("The control who's changes we're listening for")]
		public OVRInput.Axis1D Control;

		public Property<float> Event { get; set; }

		void Update()
		{
			Event.Value = OVRInput.Get(Control, Controller.OVRController);
		}
	}
}