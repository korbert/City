using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EmergencyManager : MonoBehaviour {

    bool isTalking;
    DateTime lastCallDate;

    [SerializeField]
    GameObject Incoming;
    [SerializeField]
    GameObject Talking;

    [SerializeField]
    Text[] Number;
    [SerializeField]
    Text Countdown;
    [SerializeField]
    Text Speech;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (HaveACall())
        {
            UpdateCallMarker();
        }
	}

    bool HaveACall()
    {
        if (lastCallDate.AddMinutes(3) < DateTime.Now)
            return true;
        return false;
    }

    void UpdateCallMarker()
    {
        
    }

    void OnMarkerOpen()
    {
        Incoming.SetActive(true);
    }

    public void OnAcceptClick()
    {
        // start calling

        // change prefabs
        Incoming.SetActive(false);
        Talking.SetActive(true);
    }

    public void OnDeclineClick()
    {
        // close call UI
        Incoming.SetActive(false);

        // close call logic
    }
}
