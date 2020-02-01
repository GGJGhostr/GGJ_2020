using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenCommandMenu : MonoBehaviour
{

    public GameObject cmdZone;
    public GameObject CommandLister = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInputs();
    }

    void CheckForInputs()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            cmdZone.SetActive(true);
            EventSystem.current.SetSelectedGameObject(cmdZone);

            CommandLister.SetActive(true);
        }

    }

    public void EndEdit()
    {
        cmdZone.GetComponent<InputField>().text = string.Empty;
        cmdZone.SetActive(false);
        CommandLister.SetActive(false);
    }
}
