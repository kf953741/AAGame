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
		ChangeRotationCoroutine = StartCoroutine(ChangeRotation());
	}
	
	// Update is called once per frame
	void Update () {
		if (canRotate) {
			RotateTheCircle();
		}
	}
	IEnumerator ChangeRotation()
	{

		while (true) {
			yield return new WaitForSeconds(2f);
			if (Random.Range(0,2)>0) {
				rotationSpeed = -Random.Range(50,300);
			} else {
				rotationSpeed = Random.Range(50,300);
			}
		}
	}

	void RotateTheCircle()
	{
		angle = transform.rotation.eulerAngles.z;
		angle+= rotationSpeed*Time.deltaTime;
		transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
	}
}
