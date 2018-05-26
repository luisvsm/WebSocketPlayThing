mergeInto(LibraryManager.library, {

  UnityLoaded: function () {
    UnityLoaded();
  },

  ToJavascript: function (str) {
    StringToJavascript(Pointer_stringify(str));
  },

  SwitchStateToJavascript: function (str) {
    sendSwitchState(Pointer_stringify(str));
  },

  GetMessages: function () {
    var returnStr = IngestMessage();
    if(returnStr == false) returnStr = ""; 

    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  }

});