using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class JsInterface : MonoBehaviour {
	
	[DllImport("__Internal")]
    private static extern void UnityLoaded();

    [DllImport("__Internal")]
    private static extern void ToJavascript(string str);

    [DllImport("__Internal")]
    private static extern string GetMessages();

    [DllImport("__Internal")]
    private static extern void BindWebGLTexture(int texture);

    void Start() {
        #if !UNITY_EDITOR
        UnityLoaded();
        
        ToJavascript("[jsTest] This is a string.");
        #endif
    }
    
    void FixedUpdate(){
        #if !UNITY_EDITOR
        string message = GetMessages();

        if(message!= ""){
            NetworkEventManager.RecNetworkEvent(message);
            ConsoleLog.Log(message);
        }
        #endif
    }
}
