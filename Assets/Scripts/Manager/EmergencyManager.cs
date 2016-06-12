using UnityEngine;
using UnityEngine.UI;
using System;

public class EmergencyManager : MonoBehaviour
{
	#region field

	[SerializeField]
	GameObject Talking;
	[SerializeField]
	GameObject Incoming;

	[SerializeField]
	Text[] Number;
	[SerializeField]
	Text Countdown;
	[SerializeField]
	Text Speech;

	bool isTalking;
	int nextCall;
	DateTime lastCallDate;
	Contact contact;

	#endregion

	#region monobehaviour methods

	void Start()
	{
		lastCallDate = DateTime.Now;
		nextCall = 1;
	}

	void Update()
	{
		if (HaveACall())
		{
			UpdateCallMarker();
		}
	}

	#endregion

	#region public methods

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

	public void Calm()
	{

	}

	public void GetInfo()
	{

	}

	public void HangUp()
	{

	}

	#endregion

	#region aux methods

	bool HaveACall()
	{
		if (lastCallDate.AddMinutes(nextCall) < DateTime.Now)
		{
			contact = new Contact();
			return true;
		}
		return false;
	}

	void UpdateCallMarker()
	{
		StartPhoneCall();
		UpdateTimes();
	}

	void StartPhoneCall()
	{
		AudioManager.Instance.Play(AudioManager.Clips.PhoneCall);
	}
	void UpdateTimes()
	{
		lastCallDate = DateTime.Now;
		nextCall = UnityEngine.Random.Range(3, 6);
	}

	void OnMarkerOpen()
	{
		Incoming.SetActive(true);
	}

	#endregion
}
