using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    public Text info_text;



    private void Start()
    {

        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetInfo);
    }

    void GetInfo() => StartCoroutine(GetData_Coroutine());



    IEnumerator GetData_Coroutine()
    {
        info_text.text = "Loading...";

        string uri = "https://dummy.restapiexample.com/api/v1/employees";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                info_text.text = request.error;
            else
                info_text.text = request.downloadHandler.text;
        }

    }

}
