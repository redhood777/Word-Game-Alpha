using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordanimation : MonoBehaviour
{
    public static wordanimation animate;
    public Button wordButton;

    public void EaseIn()
    {
        wordButton.transform.LeanScale(Vector2.zero, 0.1f).setEaseInBack();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        wordButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
