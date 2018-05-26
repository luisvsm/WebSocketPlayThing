using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class JsInterface : MonoBehaviour {
	
    #if UNITY_EDITOR
    private static void UnityLoaded(){}
    public static void ToJavascript(string str){}
    public static void SwitchStateToJavascript(string str){}
    private static string GetMessages(){return"";}
    private static void BindWebGLTexture(int texture){}
    #else
	[DllImport("__Internal")]
    private static extern void UnityLoaded();

    [DllImport("__Internal")]
    public static extern void ToJavascript(string str);
    [DllImport("__Internal")]
    public static extern void SwitchStateToJavascript(string str);

    [DllImport("__Internal")]
    private static extern string GetMessages();

    [DllImport("__Internal")]
    private static extern void BindWebGLTexture(int texture);
    #endif

    void Start() {
        UnityLoaded();
        
        ToJavascript("[jsTest] This is a string.");
        Application.runInBackground = true;
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
