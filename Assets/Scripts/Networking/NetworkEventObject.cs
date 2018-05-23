using System;

[Serializable]
public class NetworkEventObject {
	public enum EventType
	{
		Log = 1,
		PlayerJoined = 2,
		PlayerLeft = 3,
		SwitchFlicked = 4,
		PlayerTimer = 5,
	}

	public EventType e; // event
	public string p; // payload
}
