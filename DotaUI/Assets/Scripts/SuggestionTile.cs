using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuggestionTile : MonoBehaviour {

	// Rating
	int rating;

	// Internal Objects
	public GameObject who;
	public GameObject what;
	public GameObject why;
	public GameObject voteText;

	// Components
	SpriteRenderer whoRenderer;
	SpriteRenderer whatRenderer;
	SpriteRenderer whyRenderer;

	void Start(){
		rating = 0;
		this.updateVotes();
	}

	/////////////////////////////////
	//
	public void SetWho(Sprite newWho, int property){
		this.whoRenderer = this.who.GetComponent<SpriteRenderer>();
		whoRenderer.sprite = newWho;
		// Fixes hero portrait size
		if (property == 0) {
			this.who.transform.localScale = new Vector3(1.13f,0.6f,0);
		} else {
			this.who.transform.localScale = new Vector3(0.45f, 0.6f, 0);
		}
	}

	public void SetWhat(Sprite newWhat, int property){
		this.whatRenderer = this.what.GetComponent<SpriteRenderer>();
		whatRenderer.sprite = newWhat;
		// Fixes item sizes
		if (property == 0) {
			this.what.transform.localScale = new Vector3(1.13f,0.6f,0);
		} else {
			this.what.transform.localScale = new Vector3(2f,2f,0);
		}
	}

	public void SetWhy(Sprite newWhy, int property){
		this.whyRenderer = this.why.GetComponent<SpriteRenderer>();
		whyRenderer.sprite = newWhy;
		// Fixes hero portrait size
		if (property == 0) {
			this.why.transform.localScale = new Vector3(1.13f,0.6f,0);
		} else {
			this.why.transform.localScale = new Vector3(0.45f, 0.6f, 0);
		}
	}

	public void Upvote() {
		if (this.rating < 5){
			this.rating += 1;
			this.updateVotes();
		}
	}

	public void Downvote() {
		if (this.rating > -5){
			this.rating -= 1;
			this.updateVotes();	
		}
	}

	public void updateVotes(){
		this.voteText.GetComponent<TextMeshPro>().SetText("{0}", this.rating);
	}
}
