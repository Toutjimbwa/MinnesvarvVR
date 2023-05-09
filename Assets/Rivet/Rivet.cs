using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rivet : MonoBehaviour {

    public Material coolMaterial;

    float temperature = 1.0f;
    public float coolingSpeed = 0.001f;

    public void Fasten() {
        //        var head = transform.Find("Head");
        //        var headRenderer = head.GetComponent<Renderer>();
        //        headRenderer.enabled = true;

        var col = GetComponent<Renderer>().material.color; 
        var coolerColor = new Color(col.r - coolingSpeed, col.g - coolingSpeed, col.b - coolingSpeed);
        GetComponent<Renderer>().material.color = coolerColor;

        temperature -= coolingSpeed;
        foreach(var l in GetComponentsInChildren<Light>()) {
            //l.enabled = false;
            l.intensity = temperature;
        }

        if(temperature <= 0.5f) {
            foreach(var r in GetComponentsInChildren<Renderer>()) {
                r.enabled = true;
                r.material = coolMaterial;    
            }
        }
    }

    void Update() {
        if(Input.GetKey(KeyCode.Space)) {
            Fasten();
        }
    }
}
