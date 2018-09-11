using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour {
	
	[SerializeField]
	string gameEffectID;
	[SerializeField]
	GameObject[] touchEffect; 

    
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
			if (gameEffectID == "Menu")
			{
				GameObject copy =  Instantiate(touchEffect[0], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}
			if (gameEffectID == "Pastoreia")
			{
				GameObject copy =  Instantiate(touchEffect[0], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}
			if (gameEffectID == "Coletando Ovos")
			{
				GameObject copy =  Instantiate(touchEffect[2], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}if (gameEffectID == "Contando Bichos")
			{
				GameObject copy =  Instantiate(touchEffect[0], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}if (gameEffectID == "Olho nos Lobos")
			{
				GameObject copy =  Instantiate(touchEffect[4], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}if (gameEffectID == "Ditados")
			{
				GameObject copy =  Instantiate(touchEffect[0], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}if (gameEffectID == "Memoria")
			{
				GameObject copy =  Instantiate(touchEffect[0], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}if (gameEffectID == "Pique Esconde")
			{
				GameObject copy =  Instantiate(touchEffect[1], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}if (gameEffectID == "Sequencia Sonora")
			{
				GameObject copy =  Instantiate(touchEffect[3], mousPos, transform.rotation) as GameObject;
				
			}if (gameEffectID == "Acerta Sequencia")
			{
				GameObject copy =  Instantiate(touchEffect[0], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}if (gameEffectID == "Hide")
			{
				GameObject copy =  Instantiate(touchEffect[0], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}if (gameEffectID == "Hide")
			{
				GameObject copy =  Instantiate(touchEffect[0], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}if (gameEffectID == "Hide")
			{
				GameObject copy =  Instantiate(touchEffect[0], mousPos, transform.rotation) as GameObject;
				Destroy(copy, 5f);
			}

		}
	}
}
