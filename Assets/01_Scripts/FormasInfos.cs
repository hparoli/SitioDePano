using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormasInfos : MonoBehaviour {

	[SerializeField]
	private string forma;

	[SerializeField]
	private int index;

	public void SetValues(string p_forma, int p_index){
		forma = p_forma;
		index = p_index;
	}
}
