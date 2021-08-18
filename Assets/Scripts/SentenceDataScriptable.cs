using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SentenceData", menuName = "SentenceData", order = 1)]
public class SentenceDataScriptable : ScriptableObject
{
    public List<string> sentences;
}
