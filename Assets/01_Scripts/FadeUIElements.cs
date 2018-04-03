using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FadeUIElements : MonoBehaviour {

    Image ImageUI;
    Color standard;

    void Start()
    {
        ImageUI = GetComponent<Image>();
        
    }

	void OnEnable()
    {
        standard = ImageUI.color;
        StartCoroutine("FadeUI");

    }
    IEnumerator FadeUI()
    {
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = ImageUI.color;
            c.a = f;
            ImageUI.color = c;
            new WaitForSeconds(1f);
            yield return null;
        }
    }
}