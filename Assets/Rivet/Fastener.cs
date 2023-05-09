using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fastener : MonoBehaviour {

    public Transform leftHand;
    public Transform rightHand;

    AudioSource fasteningAudioSource;
    FastenerHead head;

    void Start() {
        Debug.Assert(leftHand != null, "Must set left hand for Rivet Fastener.");
        Debug.Assert(rightHand != null, "Must set right hand for Rivet Fastener.");
        head = GetComponentInChildren<FastenerHead>();
        Debug.Assert(head != null, "Can't find 'FastenerHead' component in Rivet Fastener.");
        fasteningAudioSource = GetComponent<AudioSource>();
    }

    void Update() {
        var diff = leftHand.position - rightHand.position;
        var mid = rightHand.position + (diff * 0.5f);
        transform.position = mid;
        transform.LookAt(rightHand);

        if(head.rivet != null) {
            if(!fasteningAudioSource.isPlaying) {
                fasteningAudioSource.Play();
                head.rivet.Fasten();

				{
					var leftControllerRef = VRTK.VRTK_ControllerReference.GetControllerReference (VRTK.SDK_BaseController.ControllerHand.Left);
					Debug.Assert (leftControllerRef != null, "leftControllerRef is null");
					VRTK.VRTK_ControllerHaptics.TriggerHapticPulse (leftControllerRef, 1.0f);
				}

				{
					var rightControllerRef = VRTK.VRTK_ControllerReference.GetControllerReference (VRTK.SDK_BaseController.ControllerHand.Right);
					Debug.Assert (rightControllerRef != null, "rightControllerRef is null");
					VRTK.VRTK_ControllerHaptics.TriggerHapticPulse (rightControllerRef, 1.0f);
				}
            }
        } else {
            if(fasteningAudioSource.isPlaying) {
                fasteningAudioSource.Stop();
            }
        }
    }
}
