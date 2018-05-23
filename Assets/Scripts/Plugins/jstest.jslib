mergeInto(LibraryManager.library, {

  UnityLoaded: function () {
    UnityLoaded();
  },

  ToJavascript: function (str) {
    ToJavascript(str);
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