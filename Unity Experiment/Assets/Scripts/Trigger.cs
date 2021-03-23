using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{   
    public GameObject[] landmarks;
    public GameObject[] pathways;
    public GameObject reward;
    public GameObject participant;
    public State state;

    private int groupId;

    void Start()
    {
        landmarks = GameObject.FindGameObjectsWithTag("Landmark");
        pathways = GameObject.FindGameObjectsWithTag("Pathway");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){

        groupId = state.group; 

        if(other.tag == "Player"){
            if (groupId == 0) { // allocentric only
                //participant.transform.Rotate(0.0f, Random.Range(90.0f, 270.0f), 0.0f, Space.Self); // randomly disoriented
                participant.GetComponent<ControlFPS>().Disorient();

                foreach (GameObject obj in pathways){
                    Destroy(obj); // destroy walls
                }

            }  else if (groupId == 1) { // egocentric only
                foreach (GameObject obj in landmarks) {
                    Destroy(obj); // destroy landmarks
                }
                foreach (GameObject obj in pathways){
                    Destroy(obj); // destroy walls
                }
            }   

            Destroy(reward); // destroy reward
            state.Progress(); // progress state to 'find starting' phase
        }

        Debug.Log(other.tag);
        Debug.Log("Ok");
    }
}

