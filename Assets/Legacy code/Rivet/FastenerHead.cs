using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastenerHead : MonoBehaviour {

    public Rivet rivet;

    void OnTriggerEnter(Collider other) {
        print("Rivet trigger enter: " + other.name);
        if(other.name == "Nit") {
            rivet = other.GetComponent<Rivet>();
        }
    }

    void OnTriggerExit(Collider other) {
        print("Rivet trigger exit: " + other.name);
        if(other.name == "Nit") {
            rivet = null;
        }
    }

}
