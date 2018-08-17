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
            double relativeX = (Input.mousePosition.x / Screen.width - 0.5) * 0.25;
            double relativeZ = Input.mousePosition.y / Screen.height - 0.5;
            Debug.Log("x: " + relativeX + ", y: " + this.transform.position.y + ", z: " + this.transform.position.z);

            this.transform.position = new Vector3((float)relativeX, this.transform.position.y, (float)relativeZ);
        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0))
        {
            shouldUpdate = false;
            this.transform.parent = null;
        }
        
    }
}
