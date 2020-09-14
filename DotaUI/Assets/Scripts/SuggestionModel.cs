using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuggestionModel : MonoBehaviour {

	public GameObject suggestionPrefab;
	List<GameObject> suggestionTiles;

	public GameObject createBar;

	void Start () {
		if (suggestionTiles == null){
			suggestionTiles = new List<GameObject>();
		}
	}

	/////////////////////////////////
	// Creates a SuggestionTile 
	public void CreateSuggestion(Sprite who, int whoProperty, Sprite what, int whatProperty, Sprite why, int whyProperty){
		// Fixes load order error
		if (suggestionTiles == null){
			suggestionTiles = new List<GameObject>();
		}
		// Setup new suggestion tile
		SuggestionTile tileScript = this.suggestionPrefab.GetComponent<SuggestionTile>();
		tileScript.SetWho(who, whoProperty);
		tileScript.SetWhat(what, whatProperty);
		tileScript.SetWhy(why, whyProperty);
		// Create new suggestion tile
		GameObject newTile = Instantiate(this.suggestionPrefab, new Vector3(6.68f,-0.65f,0), Quaternion.identity);
		this.TilePlacement();
		suggestionTiles.Add(newTile);
		this.createBar.GetComponent<SuggestionCreate>().ResetTile();
	}

	// Deletes a SuggestionTile
	public void DeleteSuggestion(GameObject toDelete){
		suggestionTiles.Remove(toDelete);
		Destroy(toDelete);
	}

	// Organizes the suggestion tiles
	void TilePlacement(){
		Vector3[] slot = new Vector3[5];
		slot[0] = new Vector3(6.68f,0.1f,0);
		slot[1] = new Vector3(6.68f,0.85f,0);
		slot[2] = new Vector3(6.68f,1.60f,0);
		slot[3] = new Vector3(6.68f,2.35f,0);
		slot[4] = new Vector3(6.68f,3.10f,0);

		for (int i = 0; i < suggestionTiles.Count; i += 1){
			if (i < 5){
				this.suggestionTiles[suggestionTiles.Count-1-i].transform.position = slot[i];
			} else {
				this.DeleteSuggestion(suggestionTiles[suggestionTiles.Count-1-i]);
			}
		}
	}

	// Get'ers and Set'ers
	// Sets the who sprite in the creation bar
	public void SetCreateWho(Sprite newWho, int property){
		this.createBar.GetComponent<SuggestionCreate>().SetWho(newWho, property);
	}

	// Sets the who sprite in the creation bar
	// property: 0 - Hero; 1 - Item
	public void SetCreateWhat(Sprite newWhat, int property){
		this.createBar.GetComponent<SuggestionCreate>().SetWhat(newWhat, property);
	}

	// Sets the who sprite in the creation bar
	public void SetCreateWhy(Sprite newWhy, int property){
		this.createBar.GetComponent<SuggestionCreate>().SetWhy(newWhy, property);
	}

	public Sprite GetCreateWho(){
		return this.createBar.GetComponent<SuggestionCreate>().GetWho();
	}

	public Sprite GetCreateWhat(){
		return this.createBar.GetComponent<SuggestionCreate>().GetWhat();
	}

	public Sprite GetCreateWhy(){
		return this.createBar.GetComponent<SuggestionCreate>().GetWhy();
	}

	public int GetCreateWhoProperty() {
		return this.createBar.GetComponent<SuggestionCreate>().GetWhoProperty();
	}

	public int GetCreateWhatProperty(){
		return this.createBar.GetComponent<SuggestionCreate>().GetWhatProperty();
	}

	public int GetCreateWhyProperty() {
		return this.createBar.GetComponent<SuggestionCreate>().GetWhyProperty();
	}

}
