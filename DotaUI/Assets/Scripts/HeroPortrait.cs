using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPortrait : MonoBehaviour {

	bool available;

	void Start () { this.available = true; }

	/////////////////////////////
	// When hero is selected
	Sprite Selected() {
		if (this.available){
			this.available = false;
			return GetComponent<SpriteRenderer>().sprite;
		} else {
			return null;
		}
	}

	// If hero is unselected
	void Unselected(){
		this.available = true;
	}

	// When hero is suggested
	Sprite Suggested() {
		return GetComponent<SpriteRenderer>().sprite;
	}
}
