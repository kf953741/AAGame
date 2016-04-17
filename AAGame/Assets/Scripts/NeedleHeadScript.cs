using UnityEngine;
using System.Collections;

public class NeedleHeadScript : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D target)
	{

		if (target.CompareTag("Needle Head")) {
			//Time.timeScale = 0;
			if (GameManager.failGame!=null) {
				GameManager.failGame();
			}
		}
	}
}
