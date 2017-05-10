using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.GetComponent("Siege")) {
			((Siege)col.gameObject.GetComponent("Siege")).health -= damage;

			if (((Siege)col.gameObject.GetComponent("Siege")).health < 0) {
				Destroy(col.gameObject);
			}
		}
	}
}
