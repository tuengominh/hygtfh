using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    // this holds global experiment state, filled in by UI

    // participant info
    public string first_name;
    public string age;
    public string gender; // m, f, na

    // experiment info
    public int group; // 0, 1, 2 based on what kind of trial this is

    // experiment state
    // 0 : searching
    // 1 : returning

    private int progression;
    private float start_time;

    public GameObject done_ui;

    public int GetProgress()
    {
        return progression;
    }

    public void StartTime()
    {
        start_time = Time.time;
        Cursor.visible = false;
    }

    public float TimeSinceStart()
    {
        return Time.time - start_time;
    }

    public void Progress()
    {
        progression = 1;
        done_ui.SetActive(true);
        done_ui.GetComponent<DoneUI>().ShowText();
    }

    private void Awake()
    {
        progression = 0;
    }
}
