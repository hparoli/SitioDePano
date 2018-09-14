using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class AnaliticsControl 
{
	public static float playTime
	{
		get 
		{

			return PlayerPrefs.GetFloat("playTime"); 
		}
		set 
		{
			PlayerPrefs.SetFloat("playTime", value);
		}
	}	
}
