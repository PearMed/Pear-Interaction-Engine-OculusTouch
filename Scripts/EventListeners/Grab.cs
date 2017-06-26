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
	public class Grab : MonoBehaviour, IEventListener<float>
	{
		// Start grabbing the model after this threshold is reached
		public const float GrabThreshold = 0.9f;

		private Transform originalParent = null;

		private ObjectWithAnchor objWithAnchor;

		private void Start()
		{
			objWithAnchor = transform.GetOrAddComponent<ObjectWithAnchor>();
		}

		public void ValueChanged(EventArgs<float> args)
		{
			// This assumes that the object the event script is attached to is the object we follow
			Transform objToFollow = args.Source.transform;

			// When the user starts grabbing, grab the object
			if (originalParent == null && args.NewValue > GrabThreshold)
			{
				originalParent = GrabObj(objWithAnchor, objToFollow);
			}
			// When the user stops grabbing release the object
			else if (originalParent != null && args.NewValue < GrabThreshold)
			{
				ReleaseObj(objWithAnchor, originalParent);
				originalParent = null;
			}
		}

		/// <summary>
		/// Make the object a child of the new parent
		/// </summary>
		/// <param name="objectToGrab">object to grab</param>
		/// <param name="newParent">New parent of the given object to grab</param>
		/// <returns>old parent</returns>
		private static Transform GrabObj(ObjectWithAnchor objectToGrab, Transform newParent)
		{
			Transform parent = objectToGrab.AnchorElement.transform.parent;
			objectToGrab.AnchorElement.transform.SetParent(newParent, true);
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
		}
	}
}