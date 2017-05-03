using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider col) {
		if (col.gameObject.GetComponent("Siege")) {
			((Siege)col.gameObject.GetComponent("Siege")).health -= 1;
			Debug.Log(((Siege)col.gameObject.GetComponent("Siege")).health);

			if (((Siege)col.gameObject.GetComponent("Siege")).health < 0) {
				Destroy(col.gameObject);
			}
		}
	}
}
