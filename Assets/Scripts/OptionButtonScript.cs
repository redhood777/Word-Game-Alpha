using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButtonScript : MonoBehaviour
{
    public GameObject option;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        ScrambleScentence.instance.GetComponent<ScrambleScentence>().OptionSelected(option);
    }
}
