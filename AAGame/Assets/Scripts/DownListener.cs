using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DownListener : MonoBehaviour,IPointerDownHandler{

	public delegate void VoidDelegate();
	public VoidDelegate onDown;

	static public DownListener Get(GameObject go)
	{
		DownListener listener = go.GetComponent<DownListener>();
		if (listener == null)
			listener = go.AddComponent<DownListener>();
		return listener;
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		if (onDown != null) onDown();
	}
}
