﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class CaminhosData  
{
	public List<float> tempoResposta = new List<float>();
	public float tempoJogo;

	public int acertos;
	public int  erros;
	public int tentativas;
	public int nota;

	public string level;
	
}
