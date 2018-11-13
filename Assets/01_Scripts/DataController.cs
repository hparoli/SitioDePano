using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataController : MonoBehaviour {

	
	private AllAlimentosData alimentosDatas;

	

	private List<string> save;

	private string gameDataAlimentos = "/StreamingAssets/alimentosSave.json";
	private string gameDataPique = "/StreamingAssets/piqueSave.json";
	// Use this for initialization
	void Start () {
		save = new List<string>();
		DontDestroyOnLoad(gameObject);
		alimentosDatas = new AllAlimentosData();
		LoadAlimentosData();
	}
	
	#region Jogo dos Alimentos	
	// Update is called once per frame
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


	private void SaveMemoriaData(){
		string dataAsJson = JsonUtility.ToJson(alimentosDatas);
		string filePath = Application.dataPath + gameDataAlimentos;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}

	public void SetMemoriaData(AlimentosData alimentosData){
		alimentosDatas.alimentosDatas.Add(alimentosData);
		SaveAlimentosData();
	}

	public List<AlimentosData> GetMemoriaDatas(){
		LoadMemoriaData();
		return alimentosDatas.alimentosDatas;		
	}
	#endregion 
}