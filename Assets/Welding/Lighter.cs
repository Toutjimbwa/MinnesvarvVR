using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Lighter : VRTK_InteractableObject {

	public Welder welder;
	public float activationDistance = 0.2f;

	protected void Start() {
		Debug.Assert (welder != null, "Welder not set.");
	}

	override protected void Update() {
		base.Update();
	}

	void TryToLight() {

	}

	public override void StartUsing(VRTK_InteractUse usingObject)
	{
		base.StartUsing(usingObject);
		print ("Started using " + name);

		if (Vector3.Distance (this.transform.position, welder.transform.position) < activationDistance) {
			welder.TurnOn ();
		} else {
			print ("Welder too far away, can't light it.");
		}
	}

	/*public override void StopUsing(VRTK_InteractUse usingObject)
	{
		base.StopUsing(usingObject);
		print ("Stopped using " + name);
	}*/
}
