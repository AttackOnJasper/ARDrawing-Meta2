﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingManager : MonoBehaviour {
    public GameObject drawingPrefab;
    public GameObject canvas;
    GameObject thisTrail;
    Vector3 startPos;

    // Use this for initialization
    void Start () {
        gameObject.transform.SetParent(canvas.transform);
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Start drawing");
            float dist = canvas.transform.position.z;
            double relativeX = Input.mousePosition.x / Screen.width - 0.5;
            double relativeZ = Input.mousePosition.y / Screen.height - 0.5;
            startPos = new Vector3((float)relativeX, this.transform.position.y, (float)relativeZ);
            thisTrail = Instantiate(drawingPrefab, startPos, Quaternion.identity);
        }
    }
}