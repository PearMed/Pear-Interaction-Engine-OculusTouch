using Pear.InteractionEngine.Interactions;

namespace Pear.InteractionEngine.Controllers
{
	/// <summary>
	/// Default class for Gear VR controllers
	/// </summary>
	public class OculusGearVRController : OculusController
	{
		// This controller's UI pointer
		private UIPointer _pointer;

		public override OVRInput.Controller OVRController
		{
			get
			{
				return Location == ControllerLocation.LeftHand ? OVRInput.Controller.LTrackedRemote : OVRInput.Controller.RTrackedRemote;
			}
		}

		protected override void Awake()
		{
			base.Awake();

			_pointer = GetComponent<UIPointer>();
		}

		private void Update()
		{
			// If this pointer is available enable/disable depending on whether the controller is connected
			if(_pointer != null)
			{
				_pointer.enabled = OVRInput.IsControllerConnected(OVRController);
			}
		}
	}
}

