using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NetworkSwitchState{
	public string id;
	public int value;
}

public class NetworkSwitch : MonoBehaviour {
	public List<Sprite> buttonStates;
	public Image renderer;
	public NetworkSwitchState state;

	// Use this for initialization
	void Start() {
		ButtonManager.RegisterSwitch(state.id, this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetState(int newState){
		state.value = newState % buttonStates.Count;
		renderer.sprite = buttonStates[state.value];
	}

	public void ToggleState(){
		state.value = (state.value + 1) % buttonStates.Count;
		SetState(state.value);
		NetworkEventManager.SendSwitchState(state);
	}
}
