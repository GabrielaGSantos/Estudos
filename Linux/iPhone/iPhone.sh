#!/bin/bash
clear
rm -rf ~/.iphonetemp
echo "Insira o iPhone, desbloqueie a tela e pressione Enter"
read 
idVendor=$(lsusb -v 2>/dev/null | awk '/idVendor.*Apple/{print $2; exit}')
iSerial=$(lsusb -v -d $idVendor: 2>/dev/null | awk '/iSerial/{print $3; exit}')
gvfs-mount afc://$iSerial/
mkdir ~/.iphonetemp
clear
echo "Aguarde as fotos serem copiadas"
echo "O início pode levar até 2 minutos"
genisoimage -o ~/.iphonetemp/temp.iso /run/user/1000/gvfs/afc:host=*/DCIM
mkdir ~/.iphonetemp/mnt
echo "Insira a senha: "
sudo mount ~/.iphonetemp/temp.iso ~/.iphonetemp/mnt 
clear
echo "Remova o iPhone e aperte enter"
read
clear
echo "Um programa será aberto"
echo "Verifique se as fotos aparecem"
echo ""
echo "Caso não aparecerem berifique se a mídia selecionada é \"CDROM\""
echo ""
echo "Pressione enter APENAS QUANDO A CÓPIA TIVER TERMINADO"
read
rapid-photo-downloader -l /media/$USER/CDROM
rm -rf ~/.iphonetemp
exit


