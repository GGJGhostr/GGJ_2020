using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDataBase : MonoBehaviour
{

    Dictionary<string, List<KeyValuePair<string, System.Type>>> m_hackableEntityMap = null;

    private void Awake()
    {
        m_hackableEntityMap = new Dictionary<string, List<KeyValuePair<string, System.Type>>>();

        AddTweakableValueInEntity("player", "visible", typeof(bool), true);
        AddTweakableValueInEntity("player", "speed", typeof(int), true);

        AddTweakableValueInEntity("wall", "visible", typeof(bool), true);

        AddTweakableValueInEntity("bullet", "visible", typeof(bool), true);
        AddTweakableValueInEntity("bullet", "speed", typeof(float), true);
        AddTweakableValueInEntity("bullet", "traverse", typeof(float), true);

        //AddTweakableValueInEntity("gravity", "reverse", typeof(bool), true);
        PrintCommandMap();
    }

    public List<string> GetAllHackableEntityFromDB()
    {
        var map_enumerator = m_hackableEntityMap.GetEnumerator();
        List<string> entities = new List<string>();

        while(map_enumerator.MoveNext())
        {
            var current = map_enumerator.Current;
            entities.Add(current.Key);
        }

        return entities;
    }

    public List<string> GetAllTweakableNameOfEntityFromDB(string entity_name)
    {
        List<KeyValuePair<string, System.Type>> pairs;// = new List<string>();
        m_hackableEntityMap.TryGetValue(entity_name, out pairs);

        List<string> names = new List<string>();

        foreach (KeyValuePair<string, System.Type> pair in pairs)
        {
            names.Add(pair.Key);
        }

        return names;
    }

    public KeyValuePair<string, System.Type>? GetTweakableValuePair(string entity_name, string tweakable_value)
    {
        List<KeyValuePair<string, System.Type>> pair_list;
        m_hackableEntityMap.TryGetValue(entity_name, out pair_list);

        foreach (KeyValuePair<string, System.Type> pair in pair_list)
        {
            if (pair.Key == tweakable_value)
                return pair;
        }

        return null;
    }

    public bool IsAnExistingHackableEntity(string entity_name)
    {
        if (m_hackableEntityMap.ContainsKey(entity_name))
            return true;

        return false;
    }

    public bool IsAnExistingTweakableValue(string entity_name, string tweakable_name)
    {
        List<KeyValuePair<string, System.Type>> pair_list;
        m_hackableEntityMap.TryGetValue(entity_name, out pair_list);

        foreach(KeyValuePair<string, System.Type> pair in pair_list)
        {
            if (pair.Key == tweakable_name)
                return true;
        }

        return false;
    }

    private void AddHackableEntity(string hackable_entity_name, List<KeyValuePair<string, System.Type>> tweakable_values_map = null)
    {
        if (IsAnExistingHackableEntity(hackable_entity_name))
        {
            Debug.LogWarning(hackable_entity_name + " is already registered in the Map");
            return;
        }

        tweakable_values_map =  tweakable_values_map == null ? new List<KeyValuePair<string, System.Type>>() : tweakable_values_map;

        m_hackableEntityMap.Add(hackable_entity_name, tweakable_values_map);
    }

    private void AddTweakableValueInEntity(string hackable_name, string tweakable_value_name, System.Type param_type, bool auto_create_entity = false)
    {
        bool is_existing = IsAnExistingHackableEntity(hackable_name);
        if (!is_existing && !auto_create_entity)
        {
            Debug.LogWarning("Cannot add tweakable value inside " + hackable_name + ", this hackable entity don't exist in the Map");
            return;
        }

        KeyValuePair<string, System.Type>  value_args_pair = new KeyValuePair<string, System.Type>(tweakable_value_name, param_type);

        if(!is_existing)
        {
            List<KeyValuePair<string, System.Type>>  tweakable_list = new List<KeyValuePair<string, System.Type>>();
            tweakable_list.Add(value_args_pair);
            AddHackableEntity(hackable_name, tweakable_list);
        }
        else
        {
            List<KeyValuePair<string, System.Type>> tweakable_list;
            m_hackableEntityMap.TryGetValue(hackable_name, out tweakable_list);
            tweakable_list.Add(value_args_pair);
        }

    }

    public void PrintCommandMap()
    {
        Debug.Log("Start printing Command Map ...");
        var enumerator = m_hackableEntityMap.GetEnumerator();
        while(enumerator.MoveNext())
        {
            Debug.Log("\tEntity "+enumerator.Current.Key);
            foreach(KeyValuePair<string, System.Type> pair in enumerator.Current.Value)
            {
                Debug.Log("\t\t"+pair.Key+"("+pair.Value.ToString()+")");
            }
        }
        Debug.Log("End of printing Command Map ...");
    }

    public System.Type ConvertHackableNameToType(string name)
    {
        System.Type to_return = null;
        switch (name)
        {
            case "bullet":
                to_return = typeof(PLACEHOLDER.Bullets);
                break;

            default:
                break;
        }

        return to_return;
    }
}
