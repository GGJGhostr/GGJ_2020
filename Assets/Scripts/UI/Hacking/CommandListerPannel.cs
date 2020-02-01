using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CommandListerPannel : MonoBehaviour
{
    [SerializeField] private GameObject m_commandObject = null;
    [SerializeField] private VerticalLayoutGroup m_verticalLayoutGroup = null;
    [SerializeField] private CommandDataBase m_dataBase = null;

    private readonly char[] COMMAND_SEPARATORS = { ' '/*, '.'*/};

    private List<Text> m_childText = null;

    private void Awake()
    {
        m_childText = new List<Text>();
    }

    private Text CreateModelChildText()
    {
        GameObject obj = Instantiate(m_commandObject, m_verticalLayoutGroup.transform);
        Text txt = obj.GetComponent<Text>();
        m_childText.Add(txt);
        obj.SetActive(false);

        return txt;
    }

    public void UpdateCommandListing(string typedCommand)
    {
        string[] cmds = typedCommand.ToLower().Split(COMMAND_SEPARATORS);

        if (cmds.Length == 1)
            DisplayCommandFor(null);
        else if (cmds.Length == 2)
            DisplayCommandFor(cmds[0]);
        else
        {
            DesactivateAllChild();
            var pair = m_dataBase.GetTweakableValuePair(cmds[0], cmds[1]);
            if (pair == null)
                DisplayCommandFor(cmds[0]);
            else
            {
                DisplayOneCommand(pair.Value.Value.ToString());
            }
        }

    }

    private void DisplayOneCommand(string text)
    {
        m_childText[0].gameObject.SetActive(true);
        m_childText[0].text = text;
    }

    private void DisplayCommandFor(string db_index = null)
    {
        if(db_index == null)
        {
            List<string> datas = m_dataBase.GetAllHackableEntityFromDB();
            UpdateChildsDataInfo(datas);
        }
        else
        {
            List<string> datas = m_dataBase.GetAllTweakableNameOfEntityFromDB(db_index);
            UpdateChildsDataInfo(datas);
        }
        
    }

    private void UpdateChildsDataInfo(List<string> datas)
    {
        DesactivateAllChild();
        UpdateChildWithData(datas);
    }

    private void UpdateChildWithData(List<string> datas)
    {
        while(m_childText.Count < datas.Count)
            CreateModelChildText();

        for(int i = 0; i < datas.Count; i++)
        {
            m_childText[i].gameObject.SetActive(true);
            m_childText[i].text = datas[i];
        }
    }

    private void DesactivateAllChild()
    {
        foreach(Text txt in m_childText)
        {
            txt.gameObject.SetActive(false);
        }
    }
}
