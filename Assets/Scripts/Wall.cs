using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Wall : MonoBehaviour, IHackable
{

    private TilemapRenderer m_renderer = null;
    private Wall_Data wData = null;

    private void Awake()
    {
        m_renderer = GetComponent<TilemapRenderer>();

        wData = GameDataManager.Instance.WallData;
        m_renderer.enabled = wData.uVisible;
    }

    public void ComputeHackFromString(string data, dynamic value)
    {
        switch(data)
        {
            case "visible":
                if (value == null)
                    SwitchVisibility(!m_renderer.enabled);
                else
                    SwitchVisibility(value);
                break;

            default:
                break;
        }
    }

    private void SwitchVisibility(bool state)
    {
        m_renderer.enabled = state;
        wData.uVisible = state;
    }

}
