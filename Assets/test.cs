using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public Texture tex;
    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.mainTexture = tex;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
