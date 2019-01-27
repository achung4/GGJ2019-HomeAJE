using UnityEngine;

public class Prop : MonoBehaviour
{
	[HideInInspector] public bool hasChanged;
	[HideInInspector] public bool isLocked = false;
	public bool doRemoveCollider = false;
	public Sprite altState;

	public string[] textDisplay;

	private SpriteRenderer spriteRenderer;
	private HUDMaster hud;

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
		if (!hasChanged && !isLocked) {
			hasChanged = true;

			print("sprite change");
			spriteRenderer.sprite = altState;
		}
		else if (isLocked) {
			if (textDisplay.Length > 1) {

				HUDMaster.message = textDisplay[1]; // add a HUD class and a canvas to display text
				print(textDisplay[1]);
			}
		}
	}
}
