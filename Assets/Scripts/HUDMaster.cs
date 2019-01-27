using UnityEngine.UI;
using UnityEngine;

public class HUDMaster : MonoBehaviour
{

	public Text mainText;
	public static string message;

    void Start()
    {
    }

	// Update is called once per frame
	void Update() {
		mainText.text = message;
	}
}
