using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuggestionCreate : MonoBehaviour {

	public GameObject who;
	public GameObject what;
	public GameObject why;
	public GameObject create;

	SpriteRenderer whoRenderer;
	SpriteRenderer whatRenderer;
	SpriteRenderer whyRenderer;

	int whoProperty;
	int whatProperty;
	int whyProperty;

	void Start () {
		this.whoRenderer = this.who.GetComponent<SpriteRenderer>();
		this.whatRenderer = this.what.GetComponent<SpriteRenderer>();
		this.whyRenderer = this.why.GetComponent<SpriteRenderer>();
	}

	/////////////////////////////////
	// Get'ers & Set'ers for who, what, why
	public void SetWho(Sprite newWho, int property){
		if (whoRenderer == null){
			this.whoRenderer = this.who.GetComponent<SpriteRenderer>();
		}
		this.whoRenderer.sprite = newWho;
		this.whoProperty = property;
		// 0 - Hero; 1 - Player
		if (property == 0) {
			this.who.transform.localScale = new Vector3(1.13f, 0.6f, 0);
			this.who.GetComponent<BoxCollider>().size = new Vector3(0.391f, 0.996f, 0);
		} else {
			this.who.transform.localScale = new Vector3(0.45f, 0.6f, 0);
			this.who.GetComponent<BoxCollider>().size = new Vector3(0.391f, 0.996f, 0);
		} 
	}

	public void SetWhat(Sprite newWhat, int property){
		if (whatRenderer == null){
			this.whatRenderer = this.what.GetComponent<SpriteRenderer>();
		}
		this.whatRenderer.sprite = newWhat;
		this.whatProperty = property;
		// 0 - Hero; 1 - Item
		if (property == 0){
			this.what.transform.localScale = new Vector3(1.13f,0.6f,0);
			this.what.GetComponent<BoxCollider>().size = new Vector3(0.48f, 0.747f, 0);
			this.what.GetComponent<BoxCollider>().center = new Vector3(-0.0174f, -0.005f, 0);
		} else{
			this.what.transform.localScale = new Vector3(2f,2f,0);
			this.what.GetComponent<BoxCollider>().size = new Vector3(0.26f, 0.23f, 0);
			this.what.GetComponent<BoxCollider>().center = new Vector3(-0.003f, 0.001f, 0);
		}
	}

	public void SetWhy(Sprite newWhy, int property){
		if (whyRenderer == null){
			this.whyRenderer = this.why.GetComponent<SpriteRenderer>();
		}
		this.whyRenderer.sprite = newWhy;
		this.whyProperty = property;
		// 0 - Hero; 1 - Player
		if (property == 0) {
			this.why.transform.localScale = new Vector3(1.13f, 0.6f, 0);
			this.why.GetComponent<BoxCollider>().size = new Vector3(0.391f, 0.996f, 0);
		}
		if (property == 1) {
			this.why.transform.localScale = new Vector3(0.45f, 0.6f, 0);
			this.why.GetComponent<BoxCollider>().size = new Vector3(0.391f, 0.996f, 0);
		}
	}

	public Sprite GetWho(){
		if (whoRenderer == null){
			this.whoRenderer = this.who.GetComponent<SpriteRenderer>();
		}
		return this.whoRenderer.sprite;
	}

	public Sprite GetWhat(){
		if (whatRenderer == null){
			this.whatRenderer = this.what.GetComponent<SpriteRenderer>();
		}
		return this.whatRenderer.sprite;
	}

	public Sprite GetWhy(){
		if (whyRenderer == null){
			this.whyRenderer = this.why.GetComponent<SpriteRenderer>();
		}
		return this.whyRenderer.sprite;
	}

	public int GetWhoProperty(){
		return this.whoProperty;
	}

	public int GetWhatProperty(){
		return this.whatProperty;
	}

	public int GetWhyProperty(){
		return this.whyProperty;
	}

	public void ResetTile(){
		this.whoRenderer.sprite = null;
		this.whatRenderer.sprite = null;
		this.whyRenderer.sprite = null;
		this.whoProperty = 0;
		this.whatProperty = 0;
		this.whyProperty = 0;
	}
}
