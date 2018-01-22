namespace Pear.InteractionEngine.Controllers
{
	/// <summary>
	/// Default class for Gear VR controllers
	/// </summary>
	public class OculusGearVRController : OculusController
	{
		public override OVRInput.Controller OVRController
		{
			get
			{
				return Location == ControllerLocation.LeftHand ? OVRInput.Controller.LTrackedRemote : OVRInput.Controller.RTrackedRemote;
			}
		}
	}
}

