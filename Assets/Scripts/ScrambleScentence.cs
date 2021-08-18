using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrambleScentence : MonoBehaviour
{
    public static ScrambleScentence instance;

    [HideInInspector]
    int score = 0;
    int question = 1;
    string sentence;
    public string answerSentence;
    string[] words;
    string[] jumbledWords;
    List<string> sentences;
    public GameObject optionsPanel;
    public GameObject answerPanel;
    public GameObject buttonPrefab;
   // public GameObject resetButton;
   // public GameObject submitButton;
    
    public Text buttonText;
    public Text scoreText;
    public Text questionNumber;


    [SerializeField]
    private SentenceDataScriptable sentenceDataScriptable;
    public GameObject correctAnswerText;

    public Sprite correctAnswer;
    public Sprite wrongAnswer;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            GameObject.Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
        questionNumber.text = "Q.1";
        sentences = sentenceDataScriptable.sentences;
        sentence = sentences[Random.Range(0, sentences.Count)];
        answerSentence = sentence + " ";
        Debug.Log(answerSentence);
        buttonText = buttonPrefab.GetComponentInChildren<Text>();
        SplitSentence(sentence);
        RandomizeArray(words);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SplitSentence(string sentence)
    {
        string str = sentence;
        words = sentence.Split(' ');
        ////Debug.Log(words.Length);
        //for (int i = 0; i < words.Length; i++)
        //{
        //    Debug.Log(words[i]);
        //}
    }

    public void RandomizeArray(string[] sentenceArray)
    {
        for(int i = sentenceArray.Length - 1; i > 0; i--)
        {
            var r = Random.Range(0, i);
            var temp = sentenceArray[i];
            sentenceArray[i] = sentenceArray[r];
            sentenceArray[r] = temp;
        }

        for (int i = 0; i < sentenceArray.Length; i++)
        {
            GameObject wordButton = Instantiate(buttonPrefab, optionsPanel.transform);
            wordButton.GetComponentInChildren<Text>().text = sentenceArray[i];
        }

        //optionsPanel.GetComponent<VerticalLayoutGroup>().childScaleHeight = false;

    }

    public void OptionSelected(GameObject option)
    {
        GameObject copy;
        copy = Instantiate(option);
        copy.transform.SetParent(answerPanel.transform);
        option.SetActive(false);

    }

    public void ResetOptions()
    {
        foreach(Transform child in answerPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach(Transform child in optionsPanel.transform)
        {
            child.gameObject.SetActive(true);
        }

        correctAnswerText.GetComponent<Text>().text = " ";

    }

    public void SubmitAnswer()
    {
        string answer = string.Empty;
        foreach (Transform child in answerPanel.transform)
        {
            string tmp = child.gameObject.GetComponentInChildren<Text>().text + " ";
            answer = answer + tmp;
            tmp = string.Empty;
        }
        //Debug.Log(answerSentence);
        //Debug.Log(answer);

        if (answer == answerSentence)
        {
            correctAnswerText.GetComponent<Text>().text = "Correct Answer";
            Invoke("NewSentence", 1f);
        }
        else
        {
            correctAnswerText.GetComponent<Text>().text = "Wrong Answer";
        }
    }

    public void NewSentence()
    {
        correctAnswerText.GetComponent<Text>().text = " ";

        string newSentence = sentences[Random.Range(0, sentences.Count)];
        while(newSentence == sentence)
        {
            newSentence = sentences[Random.Range(0, sentences.Count)];
        }

        foreach (Transform child in answerPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in optionsPanel.transform)
        {
            Destroy(child.gameObject);
        }

        answerSentence = newSentence + " ";
        Debug.Log(answerSentence);
        SplitSentence(newSentence);
        RandomizeArray(words);

        score += 10;
        question += 1;

        scoreText.text = score.ToString();
        questionNumber.text = "Q." + question.ToString();

    }
}
