using UnityEngine;

public class Prop : MonoBehaviour
{
	[HideInInspector] public bool hasChanged;
	public bool isLocked = false;
	public Sprite altState;

	public string[] textDisplay;

	private SpriteRenderer spriteRenderer;

	private void Awake() {
		hasChanged = false;
		if (altState == null) {
			Debug.LogError(gameObject.name + " has no alternated state sprite");
		}

		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void UpdateSprite(Sprite s) {
		spriteRenderer.sprite = s;
	}
	private void OnMouseDown() {
		Alternate();
	}

	public void Alternate() {
		Debug.Log(gameObject.name + ", " + hasChanged + isLocked);
		if (!hasChanged && !isLocked) {
			hasChanged = true;

			print("sprite change");
			spriteRenderer.sprite = altState;
		}
	}
}
