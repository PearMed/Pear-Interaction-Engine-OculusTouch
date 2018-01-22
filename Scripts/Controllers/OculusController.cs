using Pear.InteractionEngine.Interactions;

namespace Pear.InteractionEngine.Controllers
{
	/// <summary>
	/// Base class for Oculus controllers
	/// </summary>
	public abstract class OculusController : Controller
	{
		// This controller's UI pointer
		private UIPointer _pointer;

		/// <summary>
		/// Specifies whether this is the left of right OVR controller
		/// </summary>
		public abstract OVRInput.Controller OVRController
		{
			get;
		}

		protected override void Awake()
		{
			base.Awake();

			_pointer = GetComponent<UIPointer>();
		}

		protected override void Start ()
		{
			base.Start();

			// When the in use state of this controller changes update the pointer
			InUseChangedEvent += inUse => SetPointerState(inUse);
		}

		protected void SetPointerState(bool enabled)
		{
			_pointer.enabled = enabled;
		}

		private void Update()
		{
			InUse = OVRInput.IsControllerConnected(OVRController);
		}
	}
}