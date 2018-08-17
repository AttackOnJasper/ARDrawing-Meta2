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
            double relativeX = Input.mousePosition.x / Screen.width - 0.5;
            double relativeZ = Input.mousePosition.y / Screen.height - 0.5;
            startPos = new Vector3((float)relativeX, 0, (float)relativeZ);

            /*
            // this creates a horizontal plane passing through this object's center
            var plane = new Plane(canvas.transform.position, Vector3.up);
            // create a ray from the mousePosition
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // plane.Raycast returns the distance from the ray start to the hit point
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                // some point of the plane was hit - get its coordinates
                startPos = ray.GetPoint(distance);
                // use the hitPoint to aim your cannon
            }
            */
            thisTrail = Instantiate(drawingPrefab, startPos, Quaternion.identity) as GameObject;
            thisTrail.transform.parent = gameObject.transform;

            var localTrailRenderer = canvas.AddComponent<TrailRenderer_Local>();
            localTrailRenderer.objToFollow = thisTrail.transform;
            localTrailRenderer.limitTrailLength = false;
            localTrailRenderer.maxPositions = 1000;
            localTrailRenderer.distIncrement = 0.1F;
        }
    }
}
