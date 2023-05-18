using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Welder : VRTK_InteractableObject {

    //public GameObject[] moltenMetalPrefabs;
    ParticleSystem particles;

    public GameObject sparksPrefab;
    private bool fire = false;

    protected void Start() {
        particles = GetComponentInChildren<ParticleSystem>();
        TurnOff();

		fire = true; // HACK to turn it on always
    }

    override protected void Update() {
        base.Update();

        //print("Fire? " + fire);

        if(fire) {
            var ray = new Ray(transform.position, transform.forward);
            var hits = Physics.RaycastAll(ray);
            foreach(var hit in hits) {
                //print("Texture coord: " + hit.textureCoord + ", and " + hit.textureCoord2);
                if(hit.distance > 0.5) {
                    //print("Joint too far away.");
                    continue;
                }
                var joint = hit.transform.GetComponent<WeldingJoint>();
                if(joint != null && !joint.isShowing) {
                    joint.ShowEverything();
                    Instantiate(sparksPrefab, hit.point, Quaternion.identity);
                }
            }
        }
    }

    public override void StartUsing(VRTK_InteractUse usingObject) {
        base.StartUsing(usingObject);
        print("Started using " + name);
        TurnOn();
    }

    public override void StopUsing(VRTK_InteractUse usingObject) {
        base.StopUsing(usingObject);
        print("Stopped using " + name);
        TurnOff();
    }

    //    print("Hit: " + hit.transform.name);
    //    if(Time.frameCount % 2 == 0) {
    //        var randomPrefab = moltenMetalPrefabs[Random.Range(0, moltenMetalPrefabs.Length)];
    //        Instantiate(randomPrefab, hit.point, Quaternion.identity);
    //    }

    public void TurnOn() {
        particles.Play();
        fire = true;
    }

    public void TurnOff() {
        particles.Stop();
        fire = false;
    }

    public bool isTurnedOn {
        get {
            return particles.isPlaying;
        }
    }

}
