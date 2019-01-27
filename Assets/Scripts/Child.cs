using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
	public string childName;

	private SpriteRenderer sr;
	public Prop parentProp;

	private bool hasCompleted = false;

	private void Start() {
		sr = GetComponent<SpriteRenderer>();
		sr.enabled = false;
	}

	private void Update() {
		if (parentProp.hasChanged &&!hasCompleted) {
			sr.enabled = true;
			HUDMaster.message = "you found " + childName + "!";

			hasCompleted = true;
		}
	}
}
