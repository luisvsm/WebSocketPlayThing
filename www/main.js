var socket;

function Start(){
    socket = io();
    LogToUnity("Connecting.");
    socket = io.connect('http://45.63.28.29/:3001');
    socket.on('switch', function (data) {
        PassThroughUnity(data);
    });
}

function sendSwitchState(switchState){
    socket.emit('switch', switchState);
}