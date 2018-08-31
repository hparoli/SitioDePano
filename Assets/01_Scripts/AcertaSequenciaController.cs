using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcertaSequenciaController : MonoBehaviour {

	[SerializeField]
	private Formas[] formas;

	[SerializeField]
	private GameObject[] formasPergunta,formasResposta;

	[SerializeField]
	private GameObject forma; 

	[SerializeField]
	private Transform pos, posR;

	[SerializeField]
	private int level,ind;

	[SerializeField]
	private Color standard;

	[SerializeField]
	private Text Txt;

	[SerializeField]
	private Image[] cortinas;

	void Start () {
		level = 3;
		formasPergunta = new GameObject[level];
		StartGame();
	}
	
	void Update () {
		
	}

	public void StartGame(){
		StartCoroutine("MostraSequencia");
	}

	private IEnumerator MostraSequencia(){
		Txt.text = "Memorize a Sequência";
        yield return new WaitForSeconds(0.2f);
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = Txt.color;
			c.a = f;
			Txt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = Txt.color;
			c.a = f;
			Txt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
		yield return new WaitForSeconds(1f);
		int index = -1;
		for(int i = 0; i < level; i++){
			formasPergunta[i] = GameObject.Instantiate(forma, new Vector3(pos.position.x + (i*2),pos.position.y,pos.position.z) ,pos.rotation);
			//primeiro level
			if(level == 3) {
				Debug.Log(index);
				if(index < 0) index = Random.Range(0,4);
				formasPergunta[i].GetComponent<SpriteRenderer>().sprite = formas[index].imagem;
				if(index < 3) index++;
				else index = 0;
			}
		}
		Embaralha("P");

		//abre cortina
		for (float f = 1f; f >= 0; f -= 0.01f)
        {
            cortinas[0].fillAmount = f;
            cortinas[1].fillAmount = f;
			new WaitForSeconds(.1f);
            yield return null;
        }
		yield return new WaitForSeconds(5f);
		for (float f = 0f; f <= 1; f += 0.01f)
        {
            cortinas[0].fillAmount = f;
            cortinas[1].fillAmount = f;
			new WaitForSeconds(.1f);
            yield return null;
        }
		StartCoroutine("Responde");
	}

	private void Embaralha(string param)
	{
		var formaList = new List<Sprite> ();

		if(param == "P"){
			Sprite form = formasPergunta [Random.Range (0, formasPergunta.Length)].GetComponent<SpriteRenderer>().sprite;
			
			for (int i = 0; i < formasPergunta.Length; i++) 
			{
				while (formaList.Contains (form)) 
				{
					form = formasPergunta [Random.Range (0, formasPergunta.Length)].GetComponent<SpriteRenderer>().sprite;
				}
				formaList.Add (form);
			}
			for(int i = 0; i < formaList.Count; i++){
			formasPergunta [i].GetComponent<SpriteRenderer>().sprite = formaList[i];
			formasPergunta [i].GetComponent<FormasInfos>().SetValues(formaList[i].name, i);
			}
		}

		if(param == "R"){
			Sprite form = formasResposta [Random.Range (0, formasResposta.Length)].GetComponent<SpriteRenderer>().sprite;
			
			for (int i = 0; i < formasResposta.Length; i++) 
			{
				while (formaList.Contains (form)) 
				{
					form = formasResposta [Random.Range (0, formasResposta.Length)].GetComponent<SpriteRenderer>().sprite;
				}
				formaList.Add (form);
			}
			for(int i = 0; i < formaList.Count; i++){
			formasResposta [i].GetComponent<SpriteRenderer>().sprite = formaList[i];
			formasResposta [i].GetComponent<FormasInfos>().SetValues(formaList[i].name, i);
			}
		}
	}

	private IEnumerator Responde(){
		StopCoroutine("GameStart");	
		Txt.text = "Agora coloque as peças na sequência correta";
        yield return new WaitForSeconds(0.2f);
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = Txt.color;
			c.a = f;
			Txt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = Txt.color;
			c.a = f;
			Txt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }	
		yield return new WaitForSeconds(1f);

		if(level == 3){
			formasResposta = new GameObject[formasPergunta.Length];
			for(int i = 0; i < formasResposta.Length; i++){
				formasResposta[i] = GameObject.Instantiate(forma, new Vector3(posR.position.x + (i*2), posR.position.y, posR.position.z) ,posR.rotation);
				formasResposta[i].GetComponent<SpriteRenderer>().sprite = formasPergunta[i].GetComponent<SpriteRenderer>().sprite;
			}
		}
		Embaralha("R");
	}
}
