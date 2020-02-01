using System.ComponentModel;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandLineParser : MonoBehaviour
{
    private const int MAX_COMMAND_MEMORY_BATCH_SIZE = 20;
    private readonly char[] COMMAND_SEPARATORS = {' ', '.'};
    private ArrayList m_parsedCommands = null;

    private CommandDataBase m_commandDataBase = null;

    private void Awake()
    {
        m_commandDataBase = GetComponent<CommandDataBase>();
        m_parsedCommands = new ArrayList(MAX_COMMAND_MEMORY_BATCH_SIZE);
    }

    public void ParseCommand(string command)
    {
        string[] args = command.Split(COMMAND_SEPARATORS);
        bool is_command_exist = IsAnExistingCommand(args);
        if(!is_command_exist)
        {
            Debug.Log(command + " is invalid");
            return;
        }

        dynamic arg = ParseCommandParameter(args);
        if(arg == null)
        {
            Debug.Log(command + " is invalid");
            return;
        }
    }

    private object ParseCommandParameter(string[] command)
    {
        KeyValuePair<string, System.Type>? pair = m_commandDataBase.GetTweakableValuePair(command[0], command[1]);
        if(pair == null)
        {
            Debug.LogError("Unable to parse the type of the command " + command[1] + " from object " + command[0]);
            return null;
        }

        TypeConverter converter = TypeDescriptor.GetConverter(pair.Value.Value);

        try
        {
            return converter.ConvertFromString(command[2]);
        }
        catch
        {
            return null;
        }

        //return ImageConversion
        //return pair.Value.Value;
    }

    private bool IsAnExistingCommand(string[] command_args)
    {
        return m_commandDataBase.IsAnExistingHackableEntity(command_args[0]) &&
            m_commandDataBase.IsAnExistingTweakableValue(command_args[0], command_args[1]);
    }

}