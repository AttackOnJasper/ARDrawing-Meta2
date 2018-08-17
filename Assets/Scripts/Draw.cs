using UnityEngine;

public class Draw : MonoBehaviour {
    private bool shouldUpdate = true;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (shouldUpdate && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
        {
            double relativeX = (Input.mousePosition.x / Screen.width - 0.5) * -10;
            double relativeZ = (Input.mousePosition.y / Screen.height - 0.5) * -10;
            Debug.Log("x: " + relativeX + ", z: " + relativeZ);

            this.transform.localPosition = new Vector3((float)relativeX, 0, (float)relativeZ);
            this.transform.localRotation = Quaternion.identity;
        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0))
        {
            shouldUpdate = false;
        }
        
    }
}
