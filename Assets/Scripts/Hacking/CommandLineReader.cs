using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CommandLineReader : MonoBehaviour
{

    private CommandLineParser m_commandParser = null;

    private void Awake()
    {
        m_commandParser = GetComponent<CommandLineParser>();
    }

    public void OnSubmitCommand(string command)
    {
        m_commandParser.ParseCommand(command.ToLower());
    }

}