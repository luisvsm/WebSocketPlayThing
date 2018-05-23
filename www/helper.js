var EventType = {
    Log:1,
    PlayerJoined: 2,
    PlayerLeft: 3,
    SwitchFlicked: 4,
    PlayerTimer: 5,
}

function LogToUnity(str){
    ToUnity(EventType.Log, str);
}