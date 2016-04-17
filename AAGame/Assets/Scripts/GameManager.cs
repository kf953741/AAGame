using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour{


	private static GameManager instance;

	public  delegate void FailGame();
	public static FailGame failGame;
	public delegate void WinGame();
	public static WinGame winGame;

	public GameObject failGameGo;
	public GameObject WinGameGo;
	public Text ScoreText;
	public Text NeedShootNum;
	public Text WinLevelText;
	public Text FailLevelText;

	private Button shootBtn;
	[SerializeField]
	private GameObject needle;
	[SerializeField]
	private GameObject needleForCircle;
	[SerializeField]
	private Transform Circle;
	[SerializeField]
	private Transform Pos;
	public static int level =1;
	public static int needShoot=1;
	private List<GameObject> allNeedldPrefab = new List<GameObject>();
	private List<GameObject> allNeedldForCirclePrefab = new List<GameObject>();

	// Use this for initialization

	void Awake () {
		if (instance==null) {
			instance = this;
		}

		shootBtn = GameObject.Find("ShootButton").GetComponent<Button>();
		DownListener.Get(shootBtn.gameObject).onDown = ShootTheNeedle;
		InitNeedleForCircle(level);
		failGame+=FailedGame;
		winGame+=WinedGame;
		PlayerPrefs.DeleteKey("level");
		level = PlayerPrefs.GetInt("level",1);
		needShoot = 6+level/2;
		ScoreText.text = level.ToString();
		NeedShootNum.text = needShoot.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void ShootTheNeedle()
	{
		
		GameObject go=Instantiate (needle, Pos.position, Quaternion.identity) as GameObject;
		allNeedldPrefab.Add(go);
		go.transform.SetParent(Pos);
		go.transform.localScale =Vector2.one;
		go.GetComponent<NeedleMoveScript>().FireTheNeedle();
		go.GetComponent<NeedleMoveScript>().needleNum.text = needShoot.ToString();
		needShoot--;
		NeedShootNum.text = needShoot.ToString();

	}

	private void InitNeedleForCircle(int level)
	{
		// levelNum
		int Num =level/5+3;
		if (Num>6) {
			Num=6;
		}
		float rate =0.0f;
		if (allNeedldForCirclePrefab.Count!=0) {
			foreach (var item in allNeedldForCirclePrefab) {
				Destroy(item);
			}
		}
		for (int i = 0; i < Num; i++) {
			rate = (float)i/Num;
			Vector3 rotation =new Vector3(0,0, rate*360);
			GameObject go = Instantiate(needleForCircle,Circle.position,Quaternion.Euler(rotation))as GameObject;
			allNeedldForCirclePrefab.Add(go);
			go.transform.SetParent(Circle);
			go.transform.localScale = Vector3.one;
		}
	}
	private void FailedGame()
	{
		needShoot = 6+level/2;
		if (needShoot>15) {
			needShoot = 15;
		}
		ScoreText.text = level.ToString();
		NeedShootNum.text = needShoot.ToString();
		failGameGo.SetActive(true);
		FailLevelText.text ="Level"+ level.ToString();
		foreach (var item in allNeedldPrefab) {
			Destroy(item);
		}
		allNeedldPrefab.Clear();
	}

	private void WinedGame()
	{
		level++;
		PlayerPrefs.SetInt("Level ",level);
		needShoot = 6+level/2;
		if (needShoot>15) {
			needShoot = 15;
		}
		ScoreText.text = level.ToString();
		NeedShootNum.text = needShoot.ToString();
		foreach (var item in allNeedldPrefab) {
			Destroy(item);
		}
		allNeedldPrefab.Clear();
		InitNeedleForCircle(level);
		WinGameGo.SetActive(true);
		WinLevelText.text = "Level "+level.ToString();
	}

	public void ClickWinGameBtn()
	{
		WinGameGo.SetActive(false);

	}
	public void ClickFailGameBtn()
	{
		failGameGo.SetActive(false);

	}

}
