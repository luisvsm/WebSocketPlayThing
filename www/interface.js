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

function ToJavascript(str){
    console.log("[Unity] " + str);
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
