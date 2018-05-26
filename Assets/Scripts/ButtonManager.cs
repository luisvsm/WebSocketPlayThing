using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonManager : MonoBehaviour {
	private static ButtonManager instance = null;
	public static ButtonManager Instance {
		get{
			if(instance == null){
				instance = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
				NetworkEventManager.Instance.EventListener += instance.ListenForSwitchEvents;
			}
				
			return instance;
		}
	}

	Dictionary<string, NetworkSwitch> switchMap = new Dictionary<string, NetworkSwitch>();
	public static void RegisterSwitch(string switchID, NetworkSwitch NetworkSwitch){
		Instance.switchMap.Add(switchID, NetworkSwitch);
	}
	public static void DeregisterSwitch(string switchID){
		Instance.switchMap.Remove(switchID);
	}
	public void ListenForSwitchEvents(NetworkEventObject eventObj){
		if(eventObj.e == NetworkEventObject.EventType.SwitchFlicked){
			NetworkSwitchState state = JsonUtility.FromJson<NetworkSwitchState>(eventObj.p);
			if(switchMap.ContainsKey(state.id)){
				switchMap[state.id].SetState(state.value);
			}
		}
	}

}
