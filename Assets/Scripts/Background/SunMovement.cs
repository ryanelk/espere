using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour
{
    
	public float start_y;
	public float timeScale;

    void Start() {
        timeScale = 7200; // 60 seconds * 60 frames * 2 movement slowdown
    }


    void Update() {
		transform.position = new Vector2(transform.position.x, transform.position.y - 1/timeScale);        
    }
}
