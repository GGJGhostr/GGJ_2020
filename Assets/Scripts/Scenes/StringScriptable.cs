using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/String", fileName = "String")]

public class StringScriptable : ScriptableObject
{
    [SerializeField] private string[] _strings = null;

    public string[] strings => _strings;
}
