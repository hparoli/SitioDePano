using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour {
	
	[SerializeField]
	string gameEffectID;
	
	[SerializeField]
	ParticleControl[] touchEffects;

    
	// Use this for initialization
	void Awake () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		AddEffect();
	}
	private void AddEffect ()
	{
	
		Vector3 mousPos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetButtonDown("Fire1"))
		{
			for (int i = 0; i < touchEffects.Length; i++)
			{
				if (touchEffects[i].particleName == gameEffectID)
				{
					GameObject copy =  Instantiate(touchEffects[i].particleObj, mousPos, transform.rotation) as GameObject;
					Destroy(copy, 5f);
				}

			}

		}
	}
}
