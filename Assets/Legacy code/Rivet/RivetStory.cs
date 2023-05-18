using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivetStory : MonoBehaviour {

    bool storyHasTriggered = false;

    void Start() {

    }

    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        //print("Rivet story collided with: " + other.name);
        if(other.name == "[VRTK][AUTOGEN][BodyColliderContainer]" && !storyHasTriggered) {
            StartStory();
        }
    }

    void StartStory() {
        storyHasTriggered = true;

        var audio = GetComponent<AudioSource>();
        audio.Play();
    }

}