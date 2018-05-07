using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "Novo Animal", menuName = "Animal")]
public class Animais : ScriptableObject {
	public string animal;

	public Sprite sprite;
	public AnimatorController animation;

}
