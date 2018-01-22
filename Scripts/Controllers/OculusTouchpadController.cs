using UnityEngine;

namespace Pear.InteractionEngine.Controllers
{
	/// <summary>
	/// Default class for touchpad controllers
	/// </summary>
	public class OculusTouchpadController : OculusController
	{
		[Tooltip("The gear vr controllers")]
		public OculusGearVRController[] GearVRControllers;

		public override OVRInput.Controller OVRController
		{
			get
			{
				return OVRInput.Controller.Touchpad;
			}
		}

		protected override void Awake()
		{
			base.Awake();

			UpdatePointerState();

			// Listen for change in use for the tracked controllers
			foreach (OculusGearVRController controller in GearVRControllers)
			{
				controller.InUseChangedEvent += inUse => UpdatePointerState();
			}
		}

		/// <summary>
		/// If at least one of the controllers is in use hide the pointer
		/// Otherwise, show the pointer
		/// </summary>
		private void UpdatePointerState()
		{
			bool atLeastOneControllerInUse = false;
			foreach (OculusGearVRController controller in GearVRControllers)
			{
				atLeastOneControllerInUse = atLeastOneControllerInUse || controller.InUse;
			}

			// Only enable this pointer if neither of the controllers are in use
			SetPointerState(enabled: !atLeastOneControllerInUse);
		}
	}
}


