using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGBehaviour : MonoBehaviour {

    public float speed;
	
	void Update () {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time * speed);
    }
}
