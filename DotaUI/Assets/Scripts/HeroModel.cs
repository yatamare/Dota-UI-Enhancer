using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroModel : MonoBehaviour {

	GameObject[] heroList;

	void Start () {
		heroList = GameObject.FindGameObjectsWithTag("HeroPortraits");
	}
}
