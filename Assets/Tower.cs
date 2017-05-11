using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public double damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.GetComponent("Siege")) {
			Siege enemy = (Siege)col.gameObject.GetComponent ("Siege");
			enemy.health -= Globals.multiplier;

			if (enemy.health < 0) {
				Destroy(col.gameObject);
			}
		}
	}
}
