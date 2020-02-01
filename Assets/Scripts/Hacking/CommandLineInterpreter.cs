using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandLineInterpreter : MonoBehaviour
{

    private CommandDataBase m_commandDataBase = null;

    private void Awake()
    {
        m_commandDataBase = GetComponent<CommandDataBase>();
    }

    public void InterpretCommand(string[] cmds, KeyValuePair<string, System.Type> arg)
    {
        if(cmds.Length <= 2 && arg.Value != typeof(bool))
        {
            Debug.Log(cmds[0] + " " + cmds[1] + " need a value");
            return;
        }

        dynamic obj;

        if (arg.Value == typeof(bool) && cmds.Length <= 2)
            obj = null;
        else
            obj = ComputeTypeConvertion(cmds[2], arg.Value);
        if (obj == null && arg.Value != typeof(bool))
        {
            Debug.Log("Bad parameter: " + cmds[2]);
            return;
        }
        ExecuteCommand(cmds, obj);
    }

    private void ExecuteCommand(string[] cmds, dynamic param)
    {
        GameObject[] gaos = GameObject.FindGameObjectsWithTag(cmds[0]);
        //System.Type T = m_commandDataBase.ConvertHackableNameToType(cmds[0]);
        foreach(GameObject gao in gaos)
        {
            gao.GetComponent<IHackable>().ComputeHackFromString(cmds[1], param);
        }

    }

    private object ComputeTypeConvertion<T>(string param, T type) where T : System.Type
    {
        TypeConverter converter = TypeDescriptor.GetConverter(type);

        try
        {
            return converter.ConvertFromString(param);
        }
        catch
        {
            return null;
        }
    }
}