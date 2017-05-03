using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTower : MonoBehaviour {

	public GameObject prefab_tower;
	public Button yourButton;
	private GameObject current_tower;

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		if (current_tower != null) {
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = 26;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			current_tower.transform.position = mousePosition;
		}
	}

	void TaskOnClick() {
		current_tower = GameObject.Instantiate<GameObject>(prefab_tower);
	}
}
