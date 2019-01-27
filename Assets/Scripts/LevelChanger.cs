using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D other) {
		print(other.tag);
		if (other.tag == "Player") {
			if (gameObject.tag == "LevelUp") {
				LevelManager.LoadLevel(true);
			}
			else if (gameObject.tag == "LevelDown") {
				LevelManager.LoadLevel(false);
			}
		}
	}
	
}
