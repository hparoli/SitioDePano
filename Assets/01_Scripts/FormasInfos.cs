using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormasInfos : MonoBehaviour {

	[SerializeField]
	private string forma;

	[SerializeField]
	private int index;

	[SerializeField]
	private Sprite sprite;

	public void SetValues(string p_forma, int p_index){
		forma = p_forma;
		index = p_index;
	}

	public string GetForma(){
		return forma;
	}
	
	public int GetIndex(){
		return index;
	}

	public Sprite GetSprite(){
		return sprite;
	}

}
