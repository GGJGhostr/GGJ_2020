using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenCommandMenu : MonoBehaviour
{

    public GameObject cmdZone;
    public GameObject CommandLister = null;

    // Update is called once per frame
    void Update()
    {
        CheckForInputs();
    }

    void CheckForInputs()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (cmdZone.activeSelf || CommandLister.activeSelf)
                return;

            cmdZone.SetActive(true);
            CommandLister.SetActive(true);

            EventSystem.current.SetSelectedGameObject(cmdZone);
            CommandLister.GetComponent<CommandListerPannel>().UpdateCommandListing("");
        }

    }

    public void EndEdit()
    {
        cmdZone.GetComponent<InputField>().text = string.Empty;
        cmdZone.SetActive(false);
        CommandLister.SetActive(false);
    }
}
