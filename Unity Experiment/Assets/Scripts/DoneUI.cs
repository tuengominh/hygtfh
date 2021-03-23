using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoneUI : MonoBehaviour
{
    public State state;

    public Button done_button;
    public Text task_text;

    void Start()
    {
        done_button.onClick.AddListener(EndTrialOnClick);
        gameObject.SetActive(false);
    }

    public void ShowText(){
        Destroy(task_text, 5.0f);
    }

    void EndTrialOnClick()
    {
        Debug.Break();
        Application.Quit();
    }
}
