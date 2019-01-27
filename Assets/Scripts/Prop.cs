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
	private Collider2D col;

	private void Awake() {
		hasChanged = false;
		if (altState == null) {
			Debug.LogError(gameObject.name + " has no alternated state sprite");
		}

		if (doRemoveCollider) {
			col = GetComponent<Collider2D>();
		}

		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void UpdateSprite(Sprite s) {
		spriteRenderer.sprite = s;
	}
	private void OnMouseDown() {
		Alternate();
	}

    public void onExamine()
    {
        Alternate();
    }

    public void Alternate() {
		if (!hasChanged && !isLocked) {
			hasChanged = true;
			
			spriteRenderer.sprite = altState;

			if (doRemoveCollider) {
				col.enabled = false;
			}
		}
		else if (isLocked) {
			if (textDisplay.Length > 1) {

				HUDMaster.message = textDisplay[1]; // add a HUD class and a canvas to display text
				print(textDisplay[1]);
			}
		}
	}
}
