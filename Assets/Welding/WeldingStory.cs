using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeldingStory : MonoBehaviour
{

    bool storyHasTriggered = false;

    public AudioClip goodSound;
    public AudioClip badSound;

    Vizor[] vizors;

    void Start()
    {

    }

    void Update()
    {

    }

    GameObject player;

    void OnTriggerEnter(Collider other)
    {
        //print("Welding story collided with: " + other.name);
        if (other.name == "[VRTK][AUTOGEN][BodyColliderContainer]" && !storyHasTriggered)
        {
            player = other.gameObject;
            StartStory();
        }
    }

    void StartStory()
    {
        storyHasTriggered = true;

        var audio = GetComponent<AudioSource>();
        audio.Play();

        vizors = GameObject.FindObjectsOfType<Vizor>();
        Debug.Log(vizors.Length + " vizors found");

        foreach (var v in vizors)
        {
            v.mode = Vizor.VizorMode.GoDown;
        }

        StartCoroutine(Judge());
    }

    IEnumerator Judge()
    {
        var audio = GetComponent<AudioSource>();
        var joints = GameObject.FindObjectsOfType<WeldingJoint>();

        while (true)
        {

            // Count joints
            int goodJointsDone = 0;
            int badJointsDone = 0;
            foreach (var joint in joints)
            {
                if (joint.isShowing)
                {
                    if (joint.good)
                    {
                        goodJointsDone++;
                    }
                    else
                    {
                        badJointsDone++;
                    }
                }
            }

            // Judge the result
            if (goodJointsDone > 6)
            {
                print("Good welding result!");
                audio.clip = goodSound;
                audio.Play();
                break;
            }
            else if (badJointsDone > 2)
            {
                print("Bad welding result!");
                audio.clip = badSound;
                audio.Play();
                break;
            }

            if (Vector3.Distance(player.transform.position, this.transform.position) > 10.0f)
            {
                foreach (var v in vizors)
                {
                    v.mode = Vizor.VizorMode.GoUp;
                }
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

}