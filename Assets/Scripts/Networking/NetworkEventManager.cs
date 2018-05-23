using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetworkEventManager : MonoBehaviour {

	public delegate void EventDelegate(NetworkEventObject eventObj);
	public EventDelegate EventListener = (e)=>{};

	private static NetworkEventManager instance;
	public static NetworkEventManager Instance{
		get{
			if(instance == null){
				GameObject tmpGameObject = GameObject.Find("NetworkEventManager");
				instance = tmpGameObject.GetComponent<NetworkEventManager>();
			}
			return instance;
		}
	}

	public static void RecNetworkEvent(string eventMessage){
		Debug.Log(eventMessage);
		NetworkEventObject eventObj = null;
		try{
			eventObj = JsonUtility.FromJson<NetworkEventObject>(eventMessage);
		}catch(Exception e){
			Debug.LogError(e);
		}

		if(eventObj == null){
			Debug.LogError("[NetworkEventManager] RecNetworkEvent failed to parse eventMessage " + eventMessage);
		}else{
			Instance.EventListener(eventObj);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
