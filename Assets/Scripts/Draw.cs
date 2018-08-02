using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour {
    public GameObject canvas;
    public GameObject marker;

    private Renderer trailRenderer;
    private bool shouldUpdate = true;

    // Use this for initialization
    void Start () {
        gameObject.transform.SetParent(canvas.transform);

        // Renderer Components
        trailRenderer = GetComponent<Renderer>();
        trailRenderer.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (shouldUpdate && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
        {
            double relativeX = Input.mousePosition.x / Screen.width - 0.5;
            double relativeZ = Input.mousePosition.y / Screen.height - 0.5;
            this.transform.position = new Vector3((float)relativeX, this.transform.position.y, (float)relativeZ);

            /*
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dist = canvas.transform.position.z;
            Debug.Log("Dist: " + dist);
            this.transform.position = ray.origin + (ray.direction * dist);
            */
            /*
            Plane plane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (plane.Raycast(mRay, out rayDistance))
            {
                this.transform.position = mRay.GetPoint(rayDistance);
            }
            */
        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0))
        {
            shouldUpdate = false;
        }
    }
}
