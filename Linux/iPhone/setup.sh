#!/bin/bash
sudo apt-get install genisoimage rapid-photo-downloader libimobiledevice-utils gvfs
sudo mkdir /usr/bin/iphone-bob
sudo cp iPhone.sh /usr/bin/iphone-bob
sudo chmod 755 /usr/bin/iphone-bob/iPhone.sh
sudo cp Copiar\ fotos\ do\ iPhone.desktop ~/Área\ de\ Trabalho
exit

