using UnityEngine;

public class LockedDoor : MonoBehaviour
{
	private Prop prop;
	public bool unlock = false;
	private bool isDone = false;

	public Sprite unlockedState;

	private void Start() {
		prop = GetComponent<Prop>();

		prop.isLocked = true;
	}

	private void Update() {
		// unlock = LevelManager.childFound == 2
		if (unlock && !isDone) {
			prop.isLocked = false;
			prop.UpdateSprite(unlockedState);

			isDone = true;
		}
	}

}
