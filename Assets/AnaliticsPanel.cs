using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnaliticsPanel : MonoBehaviour
 {
	 [SerializeField]
	 Text timeOutput;
	 
	// Use this for initialization
	void Start () 
	{
		int seconds = (int)AnaliticsControl.playTime;
		int minutes = seconds / 60;
		seconds = seconds % 60;

		timeOutput.text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
