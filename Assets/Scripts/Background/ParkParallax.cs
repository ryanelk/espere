using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkParallax : MonoBehaviour
{

	private float length, start_pos;
	public float diff;
	public GameObject camera;
	public float parallaxScale;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
		Debug.Log("Start Position: " + start_pos);
		Debug.Log("Length: " + length);

    }

    // Update is called once per frame
    void Update()
    {
        float temp = (camera.transform.position.x * (1 - parallaxScale));
        float dist = (camera.transform.position.x * parallaxScale);

        transform.position = new Vector3(start_pos + dist, transform.position.y, transform.position.z);

        if (temp > start_pos + length) {
			start_pos += diff * 2; 
			Debug.Log("X Value: " + start_pos);
		}
    }
}
