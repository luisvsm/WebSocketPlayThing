var messageQueue = [];

function IngestMessage(){
    if(messageQueue.length > 0){
        return messageQueue.pop();
    }else{
        return false;
    }
}

function UnityLoaded(){
    Start();
}

function StringToJavascript(str){
    console.log("[Unity] " + str.toString());
}

function PassThroughUnity(eventObj){
    messageQueue.push(eventObj);
}

function ToUnity(event, payload){
    messageQueue.push(
        JSON.stringify(
            {
                e:event,
                p:payload
            }
        )
    );
}
