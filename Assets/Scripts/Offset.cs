using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{

    // Public variables are initialized in the inspector; private variables are initialized at Start

    // Marker Components
    public GameObject Marker;
    Transform MarkerTransform;
    DefaultTrackableEventHandler df;

    // Image Components
    Renderer ImageRenderer;

    // Fine-tune adjustments for gameobject position
    public float xFix;
    public float yFix;
    public float zFix;

    public float xAngleFix;
    public float yAngleFix;
    public float zAngleFix;

    private void Start()
    {
        // Marker Components
        MarkerTransform = Marker.transform;
        df = Marker.GetComponent<DefaultTrackableEventHandler>();

        // Image Components
        ImageRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (df.changedState)
        {
            ImageRenderer.enabled = df.found;
            df.changedState = false;
        }

        // Target is found
        if (ImageRenderer.enabled)
        {
            // Calculate new position relative to Vuforia Camera (0, 0, 0) based on current position (which is offset)
            float x = CalculateOffsetX(MarkerTransform.position.x);
            float y = CalculateOffsetY(MarkerTransform.position.y);
            float z = CalculateOffsetZ(MarkerTransform.position.z);

            float angleX = CalculateAngleX(MarkerTransform.eulerAngles.x);
            float angleY = CalculateAngleY(MarkerTransform.eulerAngles.y);
            float angleZ = CalculateAngleZ(MarkerTransform.eulerAngles.z);

            // Set new position
            Vector3 pos = new Vector3(x, y, z);
            transform.localPosition = pos;

            // Set new rotation
            Vector3 rot = new Vector3(angleX, angleY, angleZ);
            transform.localEulerAngles = rot;
        }
    }

    private float CalculateOffsetX(float MarkerPosX)
    {
        return MarkerPosX + xFix;
    }

    private float CalculateOffsetY(float MarkerPosY)
    {
        return MarkerPosY + yFix;
    }

    private float CalculateOffsetZ(float MarkerPosZ)
    {
        // replace these
        float m = 0.552f;
        float b = 0.0147f;

        return m * MarkerPosZ + b + zFix;
    }

    private float CalculateAngleX (float AngleX)
    {
        return AngleX + xAngleFix;
    }

    private float CalculateAngleY(float AngleY)
    {
        return AngleY + yAngleFix;
    }

    private float CalculateAngleZ(float AngleZ)
    {
        return AngleZ + zAngleFix;
    }
}