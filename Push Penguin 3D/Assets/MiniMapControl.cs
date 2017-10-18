using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapControl : MonoBehaviour,IMiniMap {

    public GameObject player;
    private Vector3 offset;
    Camera ourCamera;

    float heightOfCamera = 5.0f;
  

    public void Over(Vector3 focusOfCamera)
    {
        transform.position = focusOfCamera + heightOfCamera * Vector3.up;
      
    }

    // Use this for initialization
    void Start () {
        ourCamera = GetComponent<Camera>();

        if (ourCamera) print("Yippeeee");
        else print("ouch");
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
        
	}
}
