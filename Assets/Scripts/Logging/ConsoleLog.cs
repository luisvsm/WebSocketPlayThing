using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleLog : MonoBehaviour {
	public Text outputText;
	StringBuilder builder = new StringBuilder(); 
	static ConsoleLog instance;
	bool hasInit = false;
	public static ConsoleLog Instance{
		get{
			if(instance == null){
				instance = GameObject.FindObjectOfType<ConsoleLog>();
				instance.init();
			}

			return instance;
		}
	}
	public void Start(){
		Instance.init();
	}
	public void init(){
		if(hasInit) return;
		hasInit = true;
		NetworkEventManager.Instance.EventListener += ListenForConsoleEvents;
		NetworkEventObject consoleListeningEvent = new NetworkEventObject();
		consoleListeningEvent.e = NetworkEventObject.EventType.Log;
		consoleListeningEvent.p = "Listening for console logs";
        NetworkEventManager.RecNetworkEvent(JsonUtility.ToJson(consoleListeningEvent));
	}

	public void ListenForConsoleEvents(NetworkEventObject eventObj){
		if(eventObj.e == NetworkEventObject.EventType.Log){
			Log(eventObj.p, "js");
		}
	}

	public static void Log(string logText, string heading = "Debug"){
		Instance.builder.Insert(0, "[" + heading + "] " + logText + "\n");
		Instance.outputText.text = Instance.builder.ToString();
	}
}
