using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongs : MonoBehaviour {

    public Transform tongs2;

    public Transform leftHand;
    public Transform rightHand;

    void Start() {
        Debug.Assert(leftHand != null, "Must set left hand.");
        Debug.Assert(rightHand != null, "Must set right hand.");
    }

    void Update() {
        if(Input.GetKey(KeyCode.A)) {
            tongs2.Rotate(new Vector3(0f, 1f, 0f), Space.Self);
        }	
        if(Input.GetKey(KeyCode.S)) {
            tongs2.Rotate(new Vector3(0f, -1f, 0f), Space.Self);
        }   

        var diff = leftHand.position - rightHand.position;
        var mid = rightHand.position + (diff * 0.5f);
        transform.position = mid;

        var arrow = diff.normalized; // points from right to left hand
        Vector3 forward = Quaternion.Euler(0, -90, 0) * arrow; // This makes the left tong look straight ahead between both hands

        transform.LookAt(mid + forward * 15.0f);

        //transform.Translate(forward * 5, Space.Self);

        tongs2.localRotation = Quaternion.identity;
        tongs2.RotateAround(Vector3.up, angle);

        transform.RotateAround(transform.up, -angle * 0.5f);
        transform.Translate(forward * 6f, Space.World);
    }

    float angle {
        get {
            float distance = Vector3.Distance(leftHand.position, rightHand.position);
            return distance * 0.1f;
        }
    }
}
