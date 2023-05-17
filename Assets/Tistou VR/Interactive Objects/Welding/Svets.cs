using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using VRTK;

namespace TistouVR
{
	public class Svets : VRTK_InteractableObject
	{
		public GameObject _Fire;

		private void Start()
		{
			//TurnOff();
		}

		public void TurnOn()
		{
			_Fire.SetActive(true);
		}

		public void TurnOff()
		{
			_Fire.SetActive(false);
		}
	}
}