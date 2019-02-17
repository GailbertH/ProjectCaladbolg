using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGame : MonoBehaviour 
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private UIGameJoyStick gameJoyStick;
	[SerializeField] private Animation loadingScreen;

	bool isDragging = false;
	private static UIGame instance;
	public static UIGame Instance { get { return instance; } }

	void Awake()
	{
		instance = this;
		mainCamera.gameObject.SetActive (false);
	}
		
	public bool OnJoyStickDrag
	{
		set{ isDragging = value; }
		get{ return isDragging; }
	}
}
