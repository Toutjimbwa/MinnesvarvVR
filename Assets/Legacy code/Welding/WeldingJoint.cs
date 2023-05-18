using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeldingJoint : MonoBehaviour {

    bool showing = false;
    public bool good = true;

    void Start() {
        HideEverything();
    }

    public void HideEverything() {
        var particles = GetComponentsInChildren<ParticleSystem>();
        foreach(var p in particles) {
            p.Stop();
        }
        var renders = GetComponentsInChildren<Renderer>();
        foreach(var r in renders) {
            r.enabled = false;
        }
        showing = false;
    }

    public void ShowEverything() {
        var particles = GetComponentsInChildren<ParticleSystem>();
        foreach(var p in particles) {
            p.Play();
        }
        StartCoroutine(DelayedShow());
        showing = true;
    }

    IEnumerator DelayedShow() {
        var renders = GetComponentsInChildren<Renderer>();
        foreach(var r in renders) {
            r.enabled = true;
        }
        float scale = 0.0f;
        for(int i = 0; i < 20; i++) {
            scale += 0.003f;
            transform.localScale = new Vector3(scale, 0.003f, scale);
            yield return new WaitForSeconds(0.1f);
        }

    }

    void Update() {
		
    }

    public bool isShowing {
        get { 
            return showing;
        }
    }
}
