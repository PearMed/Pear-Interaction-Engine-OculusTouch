using Pear.InteractionEngine.Controllers;
using Pear.InteractionEngine.Properties;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pear.InteractionEngine.Events
{
	public class Axis2DControl : ControllerBehavior<OculusTouchController>, IEvent<Vector2>
	{
		[Tooltip("The control who's changes we're listening for")]
		public OVRInput.Axis2D Control;

		public Property<Vector2> Event { get; set; }

		void Update()
		{
			Event.Value = OVRInput.Get(Control, Controller.OVRController);
		}
	}
}
