namespace Pear.InteractionEngine.Controllers
{
	/// <summary>
	/// Base class for Oculus controllers
	/// </summary>
	public abstract class OculusController : Controller
	{
		/// <summary>
		/// Specifies whether this is the left of right OVR controller
		/// </summary>
		public abstract OVRInput.Controller OVRController
		{
			get;
		}
	}
}