using UnityEngine;
using UnityEngine.UI; 

public class TextManager : MonoBehaviour
{
    public Text displayText; 
    
    void Start()
    {
        SetText("Zen Garden"); 
    }

    public void SetText(string text)
    {
        displayText.text = text; 
    }

}

