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
	public GameObject o_block;
	public GameObject straight_block;

	public Button yourButton;

	private GameObject current_tower;
	private float cooldown = 0;
	private const int ROWS = 10;
	private const int COLS = 22;
	private Transform[,] blocks = new Transform[ROWS,COLS];

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		// rotate piece
		if ((Input.GetMouseButtonDown(1) || Input.GetKeyDown("z")) && current_tower != null) {
			current_tower.transform.Rotate(0, 90, 0);
		}
		// place a tower
		if (Input.GetMouseButtonDown (0) && current_tower != null) {
			bool isObstructed = false;
			foreach (Transform block in current_tower.transform) {
				if (isBlockOccupied(block)) {
					isObstructed = true;
				}
			}

			if (!isObstructed) {
				foreach (Transform block in current_tower.transform) {
					placeBlock (block);
				}
				cooldown = Time.time;
				yourButton.interactable = false;
				current_tower = null;

				clearLines ();
			}
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

	bool isBlockOccupied (Transform block) {
		int row = (int)Math.Floor(block.position.z + 5);
		int column = (int)Math.Floor(block.position.x + 11);

		return blocks[row, column] != null;
	}

	void placeBlock (Transform block) {
		int row = (int)Math.Floor(block.position.z + 5);
		int column = (int)Math.Floor(block.position.x + 11);

		blocks[row, column] = block;
	}

	void clearLines() {
		for (int i = 0; i < COLS; i++) {
			bool isLineFull = true;
			for (int k = 0; k < ROWS; k++) {
				if (blocks [k, i] == null) {
					isLineFull = false;
				}
			}

			if (isLineFull) {
				for (int k = 0; k < ROWS; k++) {
					GameObject.Destroy (blocks [k, i].gameObject);
					blocks [k, i] = null;
				}

				slideLines (i + 1, COLS);
				i--;
			}
		}
	}

	void slideLines(int fromIndex, int toIndex) {
		for (int i = fromIndex; i < toIndex; i++) {
			for (int k = 0; k < ROWS; k++) {
				blocks[k, i - 1] = blocks [k, i];
				if (blocks[k,i] != null)
					blocks[k, i].position -= Vector3.right;
			}
		}
	}

	void TaskOnClick() {
		float choose = UnityEngine.Random.value;
		if (choose < 0.15F) {
			current_tower = GameObject.Instantiate<GameObject> (t_block);  // %15
		} else if (choose < 0.30F) {
			current_tower = GameObject.Instantiate<GameObject> (L_block); // %15
		} else if (choose < 0.45F) {
			current_tower = GameObject.Instantiate<GameObject> (j_block); // %15
		} else if (choose < 0.55F) {
			current_tower = GameObject.Instantiate<GameObject> (straight_block); // %10
		} else if (choose < 0.7F) {
			current_tower = GameObject.Instantiate<GameObject> (o_block); // %15
		} else if (choose < 0.85F) {
			current_tower = GameObject.Instantiate<GameObject> (s_block); // %15
		}  else {
			current_tower = GameObject.Instantiate<GameObject> (z_block); // %15
		}
	}
}
