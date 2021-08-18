using UnityEngine;
using UnityEngine.UI;

public class WordData : MonoBehaviour
{
    [SerializeField] private Text wordText;

    [HideInInspector]
    public char wordValue;

    private Button buttonComponent;
    public GameObject optionBtn;

    

    //public void EaseIn()
    //{
    //    optionBtn.transform.LeanScale(Vector2.zero, 3f).setEaseInBack();
    //}

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        if (buttonComponent)
        {
            buttonComponent.onClick.AddListener(() => WordSelected());
        }
    }

    public void SetWord(char value)
    {
        wordText.text = value + "";
        wordValue = value;
        //EaseIn();
        //wordanimation.animate.EaseIn();
    }

    private void WordSelected()
    {
        QuizManager.instance.SelectedOption(this);
    }
    
}
