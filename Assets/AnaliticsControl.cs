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
	
	public static float ditadosTime
	{
		get
		{
			return PlayerPrefs.GetFloat("ditadosTime"); 
		}
		set
		{
			PlayerPrefs.SetFloat("ditadosTime", value);
		}
	}

	public static float memoriaTime
	{
		get
		{
			return PlayerPrefs.GetFloat("memoriaTime"); 
		}
		set
		{
			PlayerPrefs.SetFloat("memoriaTime", value);
		}
	}	
	public static float sequenciaTime
	{
		get
		{
			return PlayerPrefs.GetFloat("sequenciaTime"); 
		}
		set
		{
			PlayerPrefs.SetFloat("sequenciaTime", value);
		}
	}	
	public static float pastoreiraTime
	{
		get
		{
			return PlayerPrefs.GetFloat("pastoreiraTime"); 
		}
		set
		{
			PlayerPrefs.SetFloat("pastoreiraTime", value);
		}
	}	
	public static float ovosTime
	{
		get
		{
			return PlayerPrefs.GetFloat("ovosTime"); 
		}
		set
		{
			PlayerPrefs.SetFloat("ovosTime", value);
		}
	}	
	public static float lobosTime
	{
		get
		{
			return PlayerPrefs.GetFloat("lobosTime"); 
		}
		set
		{
			PlayerPrefs.SetFloat("lobosTime", value);
		}
	}	
	public static float bichosTime
	{
		get
		{
			return PlayerPrefs.GetFloat("bichosTime"); 
		}
		set
		{
			PlayerPrefs.SetFloat("bichosTime", value);
		}
	}		




}
