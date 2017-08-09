using Pear.InteractionEngine.Properties;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pear.InteractionEngine.Interactions;
using Pear.InteractionEngine.Utils;
using Pear.InteractionEngine.Events;

namespace Pear.InteractionEngine.EventListeners
{
	/// <summary>
	/// Grabs an object based on the event's value
	/// </summary>
	public class Grab : MonoBehaviour, IEventListener<bool>
	{
		private Transform _originalParent = null;

		private ObjectWithAnchor _objWithAnchor;

		private bool _grabbing = false;

		private void Start()
		{
			_objWithAnchor = transform.GetOrAddComponent<ObjectWithAnchor>();
		}

		public void ValueChanged(EventArgs<bool> args)
		{
			// This assumes that the object the event script is attached to is the object we follow
			Transform objToFollow = args.Source.transform;

			// When the user starts grabbing, grab the object
			if (!_grabbing && args.NewValue)
			{
				_originalParent = GrabObj(_objWithAnchor, objToFollow);
			}
			// When the user stops grabbing release the object
			else if (_grabbing && args.NewValue)
			{
				ReleaseObj(_objWithAnchor, _originalParent);
				_originalParent = null;
			}
		}

		/// <summary>
		/// Make the object a child of the new parent
		/// </summary>
		/// <param name="objectToGrab">object to grab</param>
		/// <param name="newParent">New parent of the given object to grab</param>
		/// <returns>old parent</returns>
		private Transform GrabObj(ObjectWithAnchor objectToGrab, Transform newParent)
		{
			Transform parent = objectToGrab.AnchorElement.transform.parent;
			objectToGrab.AnchorElement.transform.SetParent(newParent, true);
			_grabbing = true;
			return parent;
		}

		/// <summary>
		/// Release the object by reparenting the object to its original parent
		/// </summary>
		/// <param name="objectToRelease">object to release</param>
		/// <param name="originalParent">objects original parent</param>
		private void ReleaseObj(ObjectWithAnchor objectToRelease, Transform originalParent)
		{
			objectToRelease.AnchorElement.transform.SetParent(originalParent, true);
			_grabbing = false;
		}
	}
}