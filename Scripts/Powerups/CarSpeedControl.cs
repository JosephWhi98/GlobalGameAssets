﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpeedControl : MonoBehaviour {

    public bool speed = false;
    float speedTime = 0;

    public float speedMult = 1.5f;

    float initSpeed;

	// Use this for initialization
	void Start () {
		//initSpeed = GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().;
	}
	
	// Update is called once per frame
	void Update () {
        speedTime -= Time.deltaTime;
        if (speedTime < 0)
        {
            speed = false;
        }

        if (speed)
        {
            //initSpeed * speedMult;
        }
        else
        {
            //initSpeed;
        }
	}

    public void AddSpeedTime(int time)
    {
        if (speedTime < 0)
        {
            speedTime = time;
            speed = true;
        }
        else
        {
            speedTime += time;
        }
    }
}
