using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehavior : MonoBehaviour {

	private SpriteRenderer customerSpriteRenderer;
	public SpriteRenderer iconSpriteRenderer;
	public Sprite defaultSprite;
	public Sprite askSprite;
	public Sprite happySprite;

	public Sprite stopIconSprite;
	public Sprite paletaIconSprite;
	public Sprite happyIconSprite;
	public Sprite sadIconSprite;

	public AudioSource audioSource;
	public AudioClip stopClip;
	public AudioClip paletaClip;
	public AudioClip happyClip;
	public AudioClip sadClip;
	public AudioClip cartSearchClip;


	private GameObject vendor;
	private GameObject bubble;
	private GameObject icon;

	public float x_diff;
	public float x_stop_threshold;
	public float x_paleta_threshold;
	public float wait_count;

	public bool askStop;
	public bool askPaleta;
	public bool hasPaleta;

    void Start() {
    	customerSpriteRenderer = GetComponent<SpriteRenderer>();
    	vendor = GameObject.Find("Player/Vendor");
    	bubble = GameObject.Find("Bubble");
    	icon = GameObject.Find("Icon");

    	bubble.GetComponent<SpriteRenderer>().enabled = false;
    	iconSpriteRenderer.enabled = false; 

    	askStop = false;
    	askPaleta = false;
    	hasPaleta = false;
    }

    void Update() {

    	// if within range of vendor, ask vendor to stop
    	x_diff = Mathf.Abs(transform.position.x - vendor.transform.position.x);
    	if (x_diff < x_stop_threshold && !askStop) {
    		askStop = true;
	    	bubble.GetComponent<SpriteRenderer>().enabled = true;
    		icon.GetComponent<SpriteRenderer>().enabled = true; 
    		iconSpriteRenderer.sprite = paletaIconSprite;

    		audioSource.PlayOneShot(stopClip, .35f);
    	}

    	// if vendor stops in range, ask vendor for paleta
    	if (x_diff < x_paleta_threshold && !askPaleta) {
    		askPaleta = true;

    		customerSpriteRenderer.sprite = askSprite;
    		iconSpriteRenderer.sprite = stopIconSprite;
    	
    		audioSource.PlayOneShot(paletaClip, .35f);

    	}

    	// if vendor stops for certain amount of time, change sprite and expression
    	if (x_diff < x_paleta_threshold && !hasPaleta) {
    		wait_count--;
    		// play rummage sound
    		if (!audioSource.isPlaying) {
				audioSource.PlayOneShot(cartSearchClip, .35f);
			}

    		if (wait_count < 0 && !hasPaleta) {
    			hasPaleta = true;
    			customerSpriteRenderer.sprite = happySprite;
	    		iconSpriteRenderer.sprite = happyIconSprite;
    			audioSource.PlayOneShot(happyClip, .35f);
    		}
    	}

    	// if vendor does not stop and is out of range, sad expression
    	if (x_diff > x_paleta_threshold && askStop && askPaleta && !hasPaleta) {
			customerSpriteRenderer.sprite = defaultSprite;
    		iconSpriteRenderer.sprite = sadIconSprite;
			audioSource.PlayOneShot(sadClip, .05f);
    	}

    	if (x_diff > x_stop_threshold && askStop) {
			Reset();
		}
        
    }

	// reset all variables and move to new position
    private void Reset() {
    	bubble.GetComponent<SpriteRenderer>().enabled = false;
    	iconSpriteRenderer.enabled = false;
    	customerSpriteRenderer.sprite = defaultSprite;

    	askStop = false;
    	askPaleta = false;
    	hasPaleta = false;
    	wait_count = Random.Range(500, 750);

    	// move to new position
    	transform.position = new Vector3(vendor.transform.position.x + Random.Range(100, 400), transform.position.y, transform.position.z); 
    }
}
