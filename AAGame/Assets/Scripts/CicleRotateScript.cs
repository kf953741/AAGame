using UnityEngine;
using System.Collections;

public class CicleRotateScript : MonoBehaviour {

	[SerializeField]
	private float rotationSpeed = 50f;

	private bool canRotate;

	private float angle;

	private Coroutine ChangeRotationCoroutine;
	// Use this for initialization
	void Awake () {
		canRotate = true;
		ChangeRotationCoroutine = StartCoroutine(ChangeRotation(GameManager.level));
	}
	
	// Update is called once per frame
	void Update () {
		if (canRotate) {
			RotateTheCircle();
		}
	}
	IEnumerator ChangeRotation(int level)
	{
		float second = 0.3f*level;
		if (second>8) {
			second = 8;
		}
		while (true) {
			
			yield return new WaitForSeconds(Random.Range(10-second,15-second));
			if (Random.Range(0,2)>0) {
				rotationSpeed = -Random.Range(10+5*level,50+5*level);
			} else {
				rotationSpeed = Random.Range(10+5*level,50+5*level);
			}
		}
	}

    private	void RotateTheCircle()
	{
		angle = transform.rotation.eulerAngles.z;
		angle+= rotationSpeed*Time.deltaTime;
		transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
	}

	public void RefreshRotate()
	{
		if (ChangeRotationCoroutine!=null) {
			StopCoroutine(ChangeRotationCoroutine);
		}
		ChangeRotationCoroutine = StartCoroutine(ChangeRotation(GameManager.level));
	}
}
