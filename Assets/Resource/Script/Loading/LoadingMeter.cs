﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingMeter : MonoBehaviour {

	[SerializeField] private Image fillMeter;

	private float meterValue;
	private bool isMeterFull;
	Vector3 scale = Vector3.one;

	// Use this for initialization
	void Start () 
	{
		this.Reset ();
		LoadingManager.Instance.SetSceneToLoad (SceneNames.TITLE_SCENE);
		LoadingManager.Instance.LoadMainMenuScene ();
	}

	public void Reset()
	{
		fillMeter.fillAmount = 0;
		isMeterFull = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (isMeterFull) 
		{
			if (this.OnLoadDoneEvent != null)
				this.OnLoadDoneEvent ();

			this.OnLoadDoneEvent = null;
			this.OnLoadMeterChangeEvent = null;
			return;
		}

		if (OnLoadMeterChangeEvent != null)
			OnLoadMeterChangeEvent (this.meterValue);

		fillMeter.fillAmount = this.meterValue;
		isMeterFull = this.meterValue >= 1;
	}

	public float MeterValue
	{
		set{meterValue = value;}
		get{return meterValue;}
	}


	public void OnLoadMeterChange(ValueChange method)
	{
		this.OnLoadMeterChangeEvent += method;
	}
	public void OnLoadDone(LoadingDone method)
	{
		this.OnLoadDoneEvent += method;
	}

	public delegate void ValueChange(float value);
	private event ValueChange OnLoadMeterChangeEvent;

	public delegate void LoadingDone();
	private event LoadingDone OnLoadDoneEvent;
}
