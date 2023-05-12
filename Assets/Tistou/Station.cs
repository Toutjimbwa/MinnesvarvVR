using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TistouVR
{
	public class Station : Experience
	{
		public void StationCompleted()
		{
			FindObjectOfType<GameManager>().LoadExperience(_NextExperience);
		}
	}
}