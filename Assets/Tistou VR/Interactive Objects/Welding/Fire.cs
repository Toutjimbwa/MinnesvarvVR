using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouVR
{
	public class Fire : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			SvetsFog fog = other.GetComponent<SvetsFog>();
			if(fog == null) return;
			fog.TryWeld();
		}
	}
}