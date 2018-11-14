using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataController : MonoBehaviour {

	
	private AllAlimentosData alimentosDatas;
	private AllBolosData bolosDatas;
	private AllCaminhosData caminhosDatas;
	private AllColetandoOvosData coletandoOvosDatas;
	private AllContandoBixosData contandoBixosDatas;
	private AllDitadosData ditadosDatas;
	private AllHortaData hortaDatas;
	private AllMemoriaData memoriaDatas;
	private AllOlhoNoLoboData olhoNoLoboDatas;
	private AllPastoreiraData pastoreiraDatas;
	private AllPiqueData piqueDatas;
	private AllSequenciaSonoraData sequenciaSonoraDatas;
	

	private string gameDataAlimentos = "/StreamingAssets/alimentosSave.json";
	private string gameDataPique = "/StreamingAssets/piqueSave.json";
	private string gameDataHorta = "/StreamingAssets/hortaSave.json";
	private string gameDataOlhoNosLobos = "/StreamingAssets/olhoNoLoboSave.json";
	private string gameDataMemoria = "/StreamingAssets/memoriaSave.json";
	private string gameDataBolos = "/StreamingAssets/bolosSave.json";
	private string gameDataPastoreira = "/StreamingAssets/pastoreiraSave.json";
	private string gameDataContandoBixos = "/StreamingAssets/contandoBixosSave.json";
	private string gameDataColetandoOvos = "/StreamingAssets/coletandoOvosSave.json";
	private string gameDataCaminhos = "/StreamingAssets/caminhosSave.json";
	private string gameDataSequenciaSonora = "/StreamingAssets/sequenciaSonoraSave.json";
	private string gameDataDitados = "/StreamingAssets/ditadosSave.json";


	// Use this for initialization
	void Start ()
	 {
		DontDestroyOnLoad(gameObject);
		alimentosDatas = new AllAlimentosData();
		bolosDatas = new AllBolosData();
		caminhosDatas = new AllCaminhosData();
		coletandoOvosDatas = new AllColetandoOvosData();
		contandoBixosDatas = new AllContandoBixosData();
		ditadosDatas = new AllDitadosData();
		hortaDatas = new AllHortaData();
		memoriaDatas = new AllMemoriaData();
		olhoNoLoboDatas = new AllOlhoNoLoboData();
		pastoreiraDatas = new AllPastoreiraData();
		piqueDatas = new AllPiqueData();
		sequenciaSonoraDatas = new AllSequenciaSonoraData();


		LoadAlimentosData();
	}
	
	#region Jogo dos Alimentos	
	private void LoadAlimentosData(){
		string filePath = Application.dataPath + gameDataAlimentos;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllAlimentosData loadedData = (JsonUtility.FromJson<AllAlimentosData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) alimentosDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save dos alimentos");
		}
	}


	private void SaveAlimentosData(){
		string dataAsJson = JsonUtility.ToJson(alimentosDatas);
		string filePath = Application.dataPath + gameDataAlimentos;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}

	public void SetAlimentosData(AlimentosData alimentosData){
		alimentosDatas.alimentosDatas.Add(alimentosData);
		SaveAlimentosData();
	}

	public List<AlimentosData> GetAlimentosDatas(){
		LoadAlimentosData();
		return alimentosDatas.alimentosDatas;		
	}
	#endregion

	#region Jogo da Memória	
	// Update is called once per frame
	private void LoadMemoriaData(){
		string filePath = Application.dataPath + gameDataMemoria;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllMemoriaData loadedData = (JsonUtility.FromJson<AllMemoriaData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) memoriaDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}


	private void SaveMemoriaData(){
		string dataAsJson = JsonUtility.ToJson(memoriaDatas);
		string filePath = Application.dataPath + gameDataMemoria;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}

	public void SetMemoriaData(MemoriaData memoriaData){
		memoriaDatas.memoriaDatas.Add(memoriaData);
		SaveAlimentosData();
	}

	public List<MemoriaData> GetMemoriaDatas(){
		LoadMemoriaData();
		return memoriaDatas.memoriaDatas;		
	}
	#endregion 
}