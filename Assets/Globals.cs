using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globals : MonoBehaviour {

	public static double multiplier = 1.0f;
	public Text mu;

	void Start () {}
	
	// Update is called once per frame
	void Update () {
		mu.text = multiplier + "";
	}
}