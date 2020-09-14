
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	// Models
	public GameObject suggestionModel;
	public GameObject heroModel;

    private enum State {readyState, whoState, whatState, whyState, postState};

    // States
    State currentState;

	// Layer masks
	int createMask = 1 << 8;
	int heroLayerMask = 1 << 9;
	int itemLayerMask = 1 << 10;
    int whoLayerMask = 1 << 11;
    int whatLayerMask = 1 << 12;
    int whyLayerMask = 1 << 13;
    int teamMask = 1 << 14;
    int enemyMask = 1 << 15;
    int upvoteMask = 1 << 16;
    int downvoteMask = 1 << 17;

    // Highlights
    GameObject itemHighlight;
    GameObject heroHighlight;
    GameObject whoHighlight;
    GameObject whatHighlight;
    GameObject whyHighlight;
    GameObject enemyHighlight;
    GameObject allyHighlight;
    GameObject radientHighlight;
    GameObject direHighlight;
    GameObject postHighlight;


    // random bull-shit protection
    int frameCountAtLastClick = 0;

	// Use this for initialization
	void Start () {
		currentState = State.readyState;
        intitHighlights();
    }
	
	// Update is called once per frame
	void Update () {

        homerSimpson();

        if (Input.GetMouseButton(1)) {
            currentState = State.readyState;
        }


		if (Input.GetMouseButton(0)) {
			int framesSinceLastClick = Time.frameCount - frameCountAtLastClick;
			frameCountAtLastClick = Time.frameCount;

			if (framesSinceLastClick > 1) {
				
				RaycastHit selection;
				Ray selectionRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, upvoteMask)) {
                    selection.transform.parent.GetComponent<SuggestionTile>().Upvote();
                }
                if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, downvoteMask)) {
                    selection.transform.parent.GetComponent<SuggestionTile>().Downvote();
                }
				switch (currentState) {
					case State.readyState: 
						if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, createMask)) {
							currentState = State.whoState;
						}
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whoLayerMask)){
                            currentState = State.whoState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whatLayerMask)){
                            currentState = State.whatState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whyLayerMask)){
                            currentState = State.whyState;
                        }
                        break;	
					case State.whoState:
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, heroLayerMask)) {
                            Sprite who = selection.transform.GetComponent<SpriteRenderer>().sprite;
                            suggestionModel.GetComponent<SuggestionModel>().SetCreateWho(who, 0);
                            currentState = State.whatState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, teamMask)){
                        	Sprite who = selection.transform.GetComponent<SpriteRenderer>().sprite;
                        	suggestionModel.GetComponent<SuggestionModel>().SetCreateWho(who, 1);
                        	currentState = State.whatState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whatLayerMask)){
                            currentState = State.whatState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whyLayerMask)){
                            currentState = State.whyState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, createMask)){
                            CreateSuggestion();
                            currentState = State.readyState;
                        }
                        break;				
					case State.whatState: 
						if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, heroLayerMask)){
							Sprite what = selection.transform.GetComponent<SpriteRenderer>().sprite;
							suggestionModel.GetComponent<SuggestionModel>().SetCreateWhat(what, 0);
							currentState = State.whyState;
						}
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, itemLayerMask)){
                            Sprite what = selection.transform.GetComponent<SpriteRenderer>().sprite;
                            suggestionModel.GetComponent<SuggestionModel>().SetCreateWhat(what, 1);
                            currentState = State.whyState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whoLayerMask)){
                            currentState = State.whoState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whyLayerMask)){
                            currentState = State.whyState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, createMask)){
                            CreateSuggestion();
                            currentState = State.readyState;
                        }
                        break;		
					case State.whyState:
						if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, heroLayerMask)) {
							Sprite why = selection.transform.GetComponent<SpriteRenderer>().sprite;
							suggestionModel.GetComponent<SuggestionModel>().SetCreateWhy(why, 0);
                            currentState = State.postState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, (enemyMask | teamMask))) {
                        	Sprite why = selection.transform.GetComponent<SpriteRenderer>().sprite;
                        	suggestionModel.GetComponent<SuggestionModel>().SetCreateWhy(why, 1);
                        	currentState = State.postState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whatLayerMask)){
                            currentState = State.whatState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whoLayerMask)){
                            currentState = State.whoState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, createMask)){
                            CreateSuggestion();
                            currentState = State.readyState;
                        }
                        break;
					case State.postState:
						if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, createMask)) {
							CreateSuggestion();
							currentState = State.readyState;
						}
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whatLayerMask)){
                            currentState = State.whatState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whoLayerMask)){
                            currentState = State.whoState;
                        }
                        if (Physics.Raycast(selectionRay, out selection, Mathf.Infinity, whyLayerMask)){
                            currentState = State.whyState;
                        }
                        break;	
				}
			}

		}		
	}

	private void CreateSuggestion(){
		Sprite who = suggestionModel.GetComponent<SuggestionModel>().GetCreateWho();
		Sprite what = suggestionModel.GetComponent<SuggestionModel>().GetCreateWhat();
		Sprite why = suggestionModel.GetComponent<SuggestionModel>().GetCreateWhy();
		int whoProperty = suggestionModel.GetComponent<SuggestionModel>().GetCreateWhoProperty();
		int whatProperty = suggestionModel.GetComponent<SuggestionModel>().GetCreateWhatProperty();
		int whyProperty = suggestionModel.GetComponent<SuggestionModel>().GetCreateWhyProperty();

		if ((what != null) && (why != null)){
			suggestionModel.GetComponent<SuggestionModel>().CreateSuggestion(who, whoProperty, what, whatProperty, why, whyProperty);
		}
	}

    // Sets all highlight variables and sets them to inactive
    private void intitHighlights() {
        itemHighlight = GameObject.Find("ItemHighlight");
        heroHighlight = GameObject.Find("HeroHighlight");
        whoHighlight = GameObject.Find("WhoHighlight");
        whatHighlight = GameObject.Find("WhatHighlight");
        whyHighlight = GameObject.Find("WhyHighlight");
        enemyHighlight = GameObject.Find("EnemyHighlight");
        allyHighlight = GameObject.Find("AllyHighlight");
        radientHighlight = GameObject.Find("RadientHighlight");
        direHighlight = GameObject.Find("DireHighlight");
        postHighlight = GameObject.Find("PostHighlight");
        itemHighlight.SetActive(false);
        heroHighlight.SetActive(false);
        whoHighlight.SetActive(false);
        whatHighlight.SetActive(false);
        whyHighlight.SetActive(false);
        enemyHighlight.SetActive(false);
        allyHighlight.SetActive(false);
        radientHighlight.SetActive(false);
        direHighlight.SetActive(false);
        postHighlight.SetActive(false);
    }

    // Check the current state and set all highlights to right state
    private void homerSimpson() {
        switch (currentState){
            case State.readyState:
                heroHighlight.SetActive(false);
                whoHighlight.SetActive(false);
                whatHighlight.SetActive(false);
                whyHighlight.SetActive(false);
                itemHighlight.SetActive(false);
                radientHighlight.SetActive(false);
                direHighlight.SetActive(false);
                postHighlight.SetActive(false);
                enemyHighlight.SetActive(false);
                allyHighlight.SetActive(false);
                break;
            case State.whoState:
                heroHighlight.SetActive(true);
                whoHighlight.SetActive(true);
                whatHighlight.SetActive(false);
                whyHighlight.SetActive(false);
                itemHighlight.SetActive(false);
                radientHighlight.SetActive(true);
                direHighlight.SetActive(false);
                postHighlight.SetActive(false);
                enemyHighlight.SetActive(false);
                allyHighlight.SetActive(true);
                break;
            case State.whatState:
                whatHighlight.SetActive(true);
                heroHighlight.SetActive(true);
                whoHighlight.SetActive(false);
                whyHighlight.SetActive(false);
                itemHighlight.SetActive(true);
                radientHighlight.SetActive(false);
                direHighlight.SetActive(false);
                postHighlight.SetActive(false);
                enemyHighlight.SetActive(false);
                allyHighlight.SetActive(false);
                break;
            case State.whyState:
                whatHighlight.SetActive(false);
                heroHighlight.SetActive(true);
                whoHighlight.SetActive(false);
                whyHighlight.SetActive(true);
                itemHighlight.SetActive(false);
                radientHighlight.SetActive(true);
                direHighlight.SetActive(true);
                postHighlight.SetActive(false);
                enemyHighlight.SetActive(true);
                allyHighlight.SetActive(true);
                break;
            case State.postState:
                whatHighlight.SetActive(false);
                heroHighlight.SetActive(false);
                whoHighlight.SetActive(false);
                whyHighlight.SetActive(false);
                itemHighlight.SetActive(false);
                radientHighlight.SetActive(false);
                direHighlight.SetActive(false);
                postHighlight.SetActive(true);
                enemyHighlight.SetActive(false);
                allyHighlight.SetActive(false);
                break;
        }
    }
}
	