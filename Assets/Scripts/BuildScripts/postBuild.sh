#!/bin/bash

echo Starting post build: `pwd`
echo Build target is ${1}

SocketIOInclude="<script src=\"socket.io.js\"></script>\
<script src=\"helper.js\"></script>\
<script src=\"interface.js\"></script>\
<script src=\"main.js\"></script>\
"

filePath="../builds/WebGL/index.html"

escapedScriptInclude=$(sed 's/[&/\]/\\&/g' <<<"$SocketIOInclude") # escape it

if [ "$1" = "WebGL" ]
then
    echo "Copying WebGL files to html directory"
    rm -r ../../HostAThing/html/playsockets/*
    cp -a ../builds/${1}/. ../../HostAThing/html/playsockets

    echo "Copying www files to html directory"
    cp -a ../www/. ../../HostAThing/html/playsockets

    echo "Including custom JS"
    sed -i '' "s/<\/head>/$escapedScriptInclude<\/head>/" ../../HostAThing/html/playsockets/index.html
fi
