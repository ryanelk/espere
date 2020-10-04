using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChange : MonoBehaviour
{
 	public Gradient gradient;
	public Color currColor;
	private SpriteRenderer spriteRenderer;
	private float colorSample;


    void Start() {
    	spriteRenderer = GetComponent<SpriteRenderer>();
    	colorSample = 0f;
    }

    void Update() {
    	colorSample += (1/7200f);
    	// sample color from gradient
    	currColor = gradient.Evaluate(colorSample);

    	// set color
        spriteRenderer.color = currColor;
    }
}
