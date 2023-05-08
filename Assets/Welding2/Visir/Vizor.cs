using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vizor : MonoBehaviour
{

    public enum VizorMode { Up, GoDown, Down, GoUp };

    public VizorMode mode = VizorMode.Up;

    public Transform childToRotateAroundZ;

    // Use this for initialization
    void Start()
    {

    }

    float fractionUp = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            mode = VizorMode.GoDown;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            mode = VizorMode.GoUp;
        }

        if (mode == VizorMode.GoUp)
        {
            fractionUp += Time.deltaTime;
            if (fractionUp > 1.0f)
            {
                fractionUp = 1.0f;
                mode = VizorMode.Up;
            }
        }

        if (mode == VizorMode.GoDown)
        {
            fractionUp -= Time.deltaTime;
            if (fractionUp < 0.0f)
            {
                fractionUp = 0.0f;
                mode = VizorMode.Down;
            }
        }

        childToRotateAroundZ.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 180f * (1.0f - fractionUp)));
    }
}