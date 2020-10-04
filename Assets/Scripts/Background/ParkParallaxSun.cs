using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkParallaxSun : MonoBehaviour
{

	private float length, start_pos_x, start_pos_y, timescale;
	public float diff;
	public GameObject camera;
	public float parallaxScale;
    // Start is called before the first frame update
    void Start()
    {
        start_pos_x = transform.position.x;
        start_pos_y = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
		Debug.Log("Start Position: " + start_pos_x);
		Debug.Log("Length: " + length);

		timescale = 1800;

    }

    // Update is called once per frame
    void Update()
    {
        float temp = (camera.transform.position.x * (1 - parallaxScale));
        float dist = (camera.transform.position.x * parallaxScale);

        float y_delta = 1/timescale;

        transform.position = new Vector3(start_pos_x + dist, transform.position.y - y_delta, transform.position.z);

        if (temp > start_pos_x + length) {
			start_pos_x += diff * 2; 
			Debug.Log("X Value: " + start_pos_x);
		}
    }
}
