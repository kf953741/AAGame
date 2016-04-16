using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private static GameManager instance;
	private Button shootBtn;
	[SerializeField]
	private GameObject needle;
	[SerializeField]
	private GameObject needleForCircle;
	[SerializeField]
	private Transform Circle;
	[SerializeField]
	private Transform Pos;
	// Use this for initialization
	void Awake () {
		if (instance==null) {
			instance = this;
		}

		shootBtn = GameObject.Find("ShootButton").GetComponent<Button>();
		shootBtn.onClick.AddListener(()=>ShootTheNeedle());
		InitNeedleForCircle();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void ShootTheNeedle()
	{

		GameObject go=Instantiate (needle, Pos.position, Quaternion.identity) as GameObject;
		go.transform.SetParent(Pos);
		go.transform.localScale =Vector2.one;
		go.GetComponent<NeedleMoveScript>().FireTheNeedle();
	}

	private void InitNeedleForCircle()
	{
		// levelNum
		int Num = 6; 
		float rate =0.0f;
		for (int i = 0; i < 6; i++) {
			rate = (float)i/Num;
			Vector3 rotation =new Vector3(0,0, rate*360);
			GameObject go = Instantiate(needleForCircle,Circle.position,Quaternion.Euler(rotation))as GameObject;
			go.transform.SetParent(Circle);
			go.transform.localScale = Vector3.one;
		}

	}
}
