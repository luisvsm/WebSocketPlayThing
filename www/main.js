var socket;

function Start(){
    socket = io();
    LogToUnity("Connecting.");
}