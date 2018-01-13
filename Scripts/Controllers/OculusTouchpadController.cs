namespace Pear.InteractionEngine.Controllers
{
	/// <summary>
	/// Default class for touchpad controllers
	/// </summary>
	public class OculusTouchpadController : OculusController
	{
		public override OVRInput.Controller OVRController
		{
			get
			{
				return OVRInput.Controller.Touchpad;
			}
		}
	}
}


