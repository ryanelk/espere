using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Vector2 targetPosition;
	public float velocity_threshold;
	public float x_velocity;
	public float x_prev_pos;

	private Transform vendor;
	private Transform cart;
	private Transform bag;
	private Transform bells;

	private Animator[] animators;
	private Animator vendorAnim;

	void Start() {
		vendor = transform.Find("Vendor");
		cart = transform.Find("Cart");
		bag = cart.transform.Find("Bag");
		bells = cart.transform.Find("Bells");

		animators = transform.GetComponentsInChildren<Animator>();

		vendorAnim = vendor.GetComponent<Animator>();


		velocity_threshold = .50f;
	}

	void Update() {

		// player controls vendor movement -- vendor will be pushing if input is down
		vendorAnim.SetBool("pushing", Input.GetMouseButton(0));


		if (Input.GetMouseButton(0)) {
			targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			// use coroutine to determine max speed - the max speed will change dynamically based on startup animation
			x_prev_pos = transform.position.x;
			float target_x = Mathf.Max(x_prev_pos, Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 20).x);


			// check if pushing animation is complete before setting new position
			if (vendorAnim.GetCurrentAnimatorStateInfo(0).IsName("vendor_walk")) {
				// set new position 
				transform.position = new Vector2(target_x, transform.position.y);

				// get velocity
				x_velocity = (transform.position.x - x_prev_pos) / (Time.deltaTime * 20);
			}

		} else {
		// apply friction tbd
			x_velocity = 0;
		}

		// play animations if velocity is over a certain value
		foreach (Animator anim in animators) {
			anim.SetBool("moving", x_velocity > velocity_threshold);
		}
		


	}
}