using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Vector2 targetPosition;

	void Update() {

		// replace method with touch controls?
		if (Input.GetMouseButton(0)) {
			targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			// placeholder movement - need to implement slowdown and startup -- not just straight movement
			// need to lock player y position - should not be able to move up/down
			// player can only move in right direction - should not be problem if camera places player in leftside of screen

			// use coroutine to determine max speed - the max speed will change dynamically based on startup animation
			float target_x = Mathf.Max(Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5).x, transform.position.x);
			transform.position = new Vector2(target_x, transform.position.y);

			// move camera so player is followed

			// move cart along with player -- including cart rotation with movement

		}
	}
}