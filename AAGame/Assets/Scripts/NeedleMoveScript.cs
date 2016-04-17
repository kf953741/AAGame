using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NeedleMoveScript : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private GameObject needleBody;
	public Text needleNum;
	private Rigidbody2D mBody;
	private float forceY = 20f;
	private bool touchedTheCircle = false;
	private bool canFireNeedle= false;

	void Awake () {
		needleBody.SetActive(false);
		mBody = GetComponent<Rigidbody2D>();
		//FireTheNeedle();
	}
	
	// Update is called once per frame
	void Update () {
		if (canFireNeedle) {
			mBody.velocity = new Vector2(0,forceY);
		}
	}

	public void FireTheNeedle()
	{
		needleBody.SetActive(true);
		mBody.isKinematic = false;
		canFireNeedle = true;
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (touchedTheCircle) {
			return;
		}
		if (target.CompareTag("Circle")) {
			canFireNeedle = false;
			touchedTheCircle = true;
			mBody.isKinematic = true;
			gameObject.transform.SetParent(target.transform);
		}
		if (GameManager.needShoot<=0) {
			if (GameManager.winGame!=null) {
				GameManager.winGame();
			}
		}

	}
}
