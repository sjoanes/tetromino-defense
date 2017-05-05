using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTower : MonoBehaviour {

	public GameObject t_block;
	public GameObject L_block;
	public GameObject j_block;
	public GameObject z_block;
	public GameObject s_block;
	public GameObject straight_block;
	public GameObject o_block;

	public Button yourButton;

	private GameObject current_tower;
	private float cooldown = 0;

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		// rotate piece
		if ((Input.GetMouseButtonDown (1) || Input.GetKeyDown("z")) && current_tower != null) {
			current_tower.transform.Rotate(0, 90, 0);
		}
		// place a tower
		if (Input.GetMouseButtonDown (0) && current_tower != null) {
			current_tower = null;
			cooldown = Time.time;
			yourButton.interactable = false;
		}

		// release cooldown
		if (Time.time - cooldown > 1) {
			yourButton.interactable = true;
		}
		
		if (current_tower != null) {
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = 21.5f;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			mousePosition.x = (float)Math.Round (mousePosition.x) + 0.5f;
			mousePosition.z = (float)Math.Round (mousePosition.z) + 0.5f;
			current_tower.transform.position = mousePosition;
		}
	}

	void TaskOnClick() {
		float choose = UnityEngine.Random.value;
		if (choose < 0.2) {
			current_tower = GameObject.Instantiate<GameObject> (t_block);  // %20
		} else if (choose < 0.35) {
			current_tower = GameObject.Instantiate<GameObject> (L_block); // %15
		} else if (choose < 0.50) {
			current_tower = GameObject.Instantiate<GameObject> (j_block); // %15
		} else if (choose < 0.6) {
			current_tower = GameObject.Instantiate<GameObject> (straight_block); // %10
		}  else if (choose < 0.7) {
			current_tower = GameObject.Instantiate<GameObject> (o_block); // %10
		} else if (choose < 0.85) {
			current_tower = GameObject.Instantiate<GameObject> (s_block); // %15
		}  else {
			current_tower = GameObject.Instantiate<GameObject> (z_block); // %15
		}
	}
}
