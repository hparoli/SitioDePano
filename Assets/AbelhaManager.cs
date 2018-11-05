using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AbelhaManager : MonoBehaviour {

	[SerializeField]
	private int numColunas,numLinhas,level,resp,waypoint,btn;

	[SerializeField]
	private GameObject seta,abelha,ab;

	[SerializeField]
	public List<GameObject> setas,botoes;

	[SerializeField]
	private Transform pos;

	[SerializeField]
	private Sprite img;

	[SerializeField]
	private float marg;

	[SerializeField]
	private Vector3 tam;

	[SerializeField]
	private Text texto;

	public AudioClip[] sons;
	private AudioSource fonteAudio;

	[SerializeField]
	private Color standard;

	public bool respondeu,fimCaminho;

	public float moveSpeed;

	void Start(){
		level = 1;
		respondeu = false;
		waypoint = 0;
		InicializaLevel(level);
		fonteAudio = GetComponent<AudioSource> ();
	}

	void Update(){
		
	}

	private void InicializaLevel(int lvl){
		if (lvl == 1){
			numColunas = 4;
			numLinhas = 2;
			marg = 1.5f;
		}
		else if (lvl == 2){
			numColunas = 4;
			numLinhas = 3;
			marg = 1.5f;
		}
		else if (lvl == 3){
			numColunas = 5;
			numLinhas = 3;
			marg = 1.5f;
		}
	

		int index = 0;
		for (int i = 0; i < numColunas; i++)
		{
			for (int j = 0; j < numLinhas; j++)
			{
				setas.Add(GameObject.Instantiate(seta, new Vector3(pos.position.x - (i*marg), pos.position.y - (j*marg), pos.position.z) ,pos.rotation));
				setas[index].GetComponent<SetaBehavior>().x = j;
				setas[index].GetComponent<SetaBehavior>().y = i;
				setas[index].GetComponent<SetaBehavior>().dir = 0;
				setas[index].GetComponent<SetaBehavior>().cor = Color.white;
				setas[index].GetComponent<SetaBehavior>().tipoSeta = "normal";
				index++;
			}
		}
		OrganizaSetas(lvl);
		Debug.Log(index);
	}

	private void OrganizaSetas(int lvl){
		if (lvl == 1){
			setas[0].transform.eulerAngles = new Vector3(0,0,180);
			setas[1].transform.eulerAngles = new Vector3(0,0,180);
			setas[2].transform.eulerAngles = new Vector3(0,0,270);
			setas[3].transform.eulerAngles = new Vector3(0,0,0);
			setas[4].transform.eulerAngles = new Vector3(0,0,270);
			setas[5].transform.eulerAngles = new Vector3(0,0,270);
			setas[6].transform.eulerAngles = new Vector3(0,0,0);
			setas[7].transform.eulerAngles = new Vector3(0,0,180);
		}
		else if (lvl == 2){
			setas[0].transform.eulerAngles = new Vector3(0,0,180);
			setas[1].transform.eulerAngles = new Vector3(0,0,270);
			setas[2].transform.eulerAngles = new Vector3(0,0,0);
			setas[3].transform.eulerAngles = new Vector3(0,0,90);
			setas[4].transform.eulerAngles = new Vector3(0,0,270);
			setas[5].transform.eulerAngles = new Vector3(0,0,0);
			setas[6].transform.eulerAngles = new Vector3(0,0,270);
			setas[7].transform.eulerAngles = new Vector3(0,0,180);
			setas[8].transform.eulerAngles = new Vector3(0,0,0);
			setas[9].transform.eulerAngles = new Vector3(0,0,90);
			setas[10].transform.eulerAngles = new Vector3(0,0,180);
			setas[11].transform.eulerAngles = new Vector3(0,0,180);
		}
		else if (lvl == 3){
			setas[0].transform.eulerAngles = new Vector3(0,0,90);
			setas[1].transform.eulerAngles = new Vector3(0,0,0);
			setas[2].transform.eulerAngles = new Vector3(0,0,90);
			setas[3].transform.eulerAngles = new Vector3(0,0,0);
			setas[4].transform.eulerAngles = new Vector3(0,0,0);
			setas[5].transform.eulerAngles = new Vector3(0,0,180);
			setas[6].transform.eulerAngles = new Vector3(0,0,90);
			setas[7].transform.eulerAngles = new Vector3(0,0,90);
			setas[8].transform.eulerAngles = new Vector3(0,0,0);
			setas[9].transform.eulerAngles = new Vector3(0,0,90);
			setas[10].transform.eulerAngles = new Vector3(0,0,270);
			setas[11].transform.eulerAngles = new Vector3(0,0,0);
			setas[12].transform.eulerAngles = new Vector3(0,0,180);
			setas[13].transform.eulerAngles = new Vector3(0,0,270);
			setas[14].transform.eulerAngles = new Vector3(0,0,90);			
		}
		
	}

	public void Responde(int resposta){
		btn = resposta;
		if(resp == resposta){
			texto.text = "Parabéns! Você acertou!";
			fonteAudio.PlayOneShot(sons[0]);
		} 
		else{
			texto.text = "Que pena, você errou!";
			fonteAudio.PlayOneShot(sons[1]);
		}
		//som de click do botão
		respondeu = true;
		ab = GameObject.Instantiate(abelha);
		
	}


	void Move(){
	}

	public IEnumerator FeedBack(){

		yield return new WaitForSeconds(0.5f);
		for (float f = 0f; f <= standard.a; f += 0.01f)
		{
			Color c = texto.color;
			c.a = f;
			texto.color = c;
			new WaitForSeconds(.2f);
			yield return null;
		}
		yield return new WaitForSeconds(.5f);
		for (float f = 1f; f >= 0; f -= 0.01f)
		{
			Color c = texto.color;
			c.a = f;
			texto.color = c;
			new WaitForSeconds(.2f);
			yield return null;
		}
		if(/*level == 1 || level == 3 || level == 5 || level == 7*/level < 6){
			level++;
			Clear();
			InicializaLevel(level);
		} 
		else{
			new WaitForSeconds(.2f);
			GameOver();
		} 
	}

	public void Clear(){
		for (int i = 0; i < setas.Count; i++)
		{
			Destroy(setas[i]);
		}
		setas.Clear();
		resp = -1;
		Destroy(ab);

	}

	public void GameOver(){
		SceneManager.LoadScene("Score");
	}
}
