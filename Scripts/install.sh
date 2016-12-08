#! /bin/sh

echo 'Downloading from http://netstorage.unity3d.com/unity/38b4efef76f0/MacStandardAssetsInstaller/StandardAssets-5.5.0f3.pkg?_ga=1.208002134.519676670.1481228784'
curl -o http://netstorage.unity3d.com/unity/38b4efef76f0/MacStandardAssetsInstaller/StandardAssets-5.5.0f3.pkg?_ga=1.208002134.519676670.1481228784
echo 'Installing Unity.pkg'
sudo installer -dumplog -package Unity.pkg -target /
