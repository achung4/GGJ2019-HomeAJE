using UnityEngine.UI;
using UnityEngine;

public class HUDMaster : MonoBehaviour
{

	public Text mainText;
	public static string message;
	private string lastMessage;
	private bool tbanimating = false;
	private float tbTimeStarted;

	public Animator textboxAnimator;

    void Start()
    {
		
		lastMessage = message;

	}

	// Update is called once per frame
	void Update() {
		if (message != lastMessage) {

			if (tbanimating) {
				textboxAnimator.SetBool("isOpen", false);
			}
			mainText.text = message;
			lastMessage = message;
			textboxAnimator.SetBool("isOpen", true);
			tbTimeStarted = Time.time;
			tbanimating = true;

		}

		else if (tbanimating) {
			if (tbTimeStarted + 5f < Time.time) {
				tbanimating = false;
				textboxAnimator.SetBool("isOpen", false);
			}
		}
	}
}
