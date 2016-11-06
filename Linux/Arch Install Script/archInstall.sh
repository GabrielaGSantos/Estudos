#!/bin/bash

clear

KEYBOARD=null
isInternet=null
isUEFI=null
tipoConexao=null
DISK=null
BOOT=null
ROOT=null
START=null
ENDO=null
FORMAT=null

echo "******************************************"
echo "Script de Instalacao do Arch - por vBob"
echo "******************************************"

printf "\nParte 1 - Configuracao basica\n\n"

printf "Procurando pasta EFI... OK\n"
if [ -d "/sys/firmware/efi/efivars" ]
then
    isUEFI=true
else
    isUEFI=false
fi
printf "[UEFI] $isUEFI\n\n" 

printf "Ping http://8.8.8.8... "
isInternet=true
until ping -q -c 1 -W 1 8.8.8.8 >/dev/null
do
    isInternet=false
    tipoConexao=-1
    until [ $tipoConexao -eq 1 -o  $tipoConexao -eq 2 ]
    do
    printf "\nPara continuar a instalacao e necessario possuir uma conexao a internet"
    printf "\n 1) Wireless"
    printf "\n 2) Cabeada\n\n"
    echo -n "Qual seu tipo de conexao? (default: 1) "
    read tipoConexao
    tipoConexao=${tipoConexao:-"1"}
    done

    if [ $tipoConexao -eq 1 ]
    then 
        echo "Abrindo wifi-menu"
        sudo wifi-menu
        printf "\nAguardando conexao..."
        sleep 10s
    fi

    if [ $tipoConexao -eq 2 ]
    then
        printf "\nSera impressa uma lista com o nome dos seus adaptadores de rede\n"
        ls /sys/class/net
        printf "\nDigite o nome do qual o cabo esta conectado: (default: enp3s0) "
        read nomeAdaptadorRede
        nomeAdaptadorRede=${nomeAdaptadorRede:-"enp3s0"}
        echo $nomeAdaptadorRede
        ip link set $nomeAdaptadorRede down
        ip link set $nomeAdaptadorRede up
        systemctl restart dhcpcd@$nomeAdaptadorRede
        printf "\nAguardando conexao..."
        sleep 10s
    fi
    isInternet=true
    printf "\n\nPing http://8.8.8.8... "
done 

printf "OK\n"
echo "[isInternet]=$isInternet" 

echo "set-ntp... OK"

printf "\nb) Teclado\n"

echo -n "Digite o seu formato de teclado (default: us-acentos): "

read KEYBOARD
KEYBOARD=${KEYBOARD:-"us-acentos"}

until grep -Fxq "$KEYBOARD" keyboardMaps.txt 
do
    printf "\nFormato de teclado nao encontrado\n"
    echo -n "Digite novamente o seu formato de teclado (default: us-acentos): "

    read KEYBOARD
    KEYBOARD=${KEYBOARD:-"us-acentos"}
done 

printf "[KEYBOARD]=$KEYBOARD"

loadkeys $KEYBOARD
echo "loadkeys... OK"

OK=false

while ! $OK
    do
    clear
    echo "******************************************"
    echo "Script de Instalacao do Arch - por vBob"
    echo "******************************************"
    printf "\n"
    echo "************************************************************"
    echo "*                                                          *"
    echo "*  AVISO: DADOS PODEM SER PERDIDOS                         *"
    echo "*  O criador deste script nao se responsabiliza por danos  *"
    echo "*  Os comandos antes de executados serao escritos          *"
    echo "*  So prossiga se tiver certeza do que esta fazendo        *"
    echo "*                                                          *"
    echo "************************************************************"

    printf "\nParte 2 - Particionamento\n"

    printf "\nAbaixo estao os discos existentes: \n"
    lsblk --nodeps -p -n -o NAME,SIZE,FSTYPE,MOUNTPOINT

    printf "\nDigite o caminho do disco a ser utilizado (default: sda): /dev/"
    read DISK
    DISK=${DISK:-"sda"}

    clear
    echo "******************************************"
    echo "Script de Instalacao do Arch - por vBob"
    echo "******************************************"
    printf "\n"
    echo "************************************************************"
    echo "*                                                          *"
    echo "*  AVISO: DADOS PODEM SER PERDIDOS                         *"
    echo "*  O criador deste script nao se responsabiliza por danos  *"
    echo "*  Os comandos antes de executados serao escritos          *"
    echo "*  So prossiga se tiver certeza do que esta fazendo        *"
    echo "*                                                          *"
    echo "************************************************************"

    printf "\nParte 2 - Particionamento\n\n"

    while true; do
        printf "Dual Boot com Windows? [Y/n] (default: n) " 
        read WINDOWS
        WINDOWS=${WINDOWS:-"n"}
        case $WINDOWS in
            [Yy]* ) WINDOWS=true; break;;
            [Nn]* ) WINDOWS=false; break;;
            * ) printf "\nDigite Y ou N\n";;
        esac
    done

    clear
    echo "******************************************"
    echo "Script de Instalacao do Arch - por vBob"
    echo "******************************************"
    printf "\n"
    echo "************************************************************"
    echo "*                                                          *"
    echo "*  AVISO: DADOS PODEM SER PERDIDOS                         *"
    echo "*  O criador deste script nao se responsabiliza por danos  *"
    echo "*  Os comandos antes de executados serao escritos          *"
    echo "*  So prossiga se tiver certeza do que esta fazendo        *"
    echo "*                                                          *"
    echo "************************************************************"

    printf "\nParte 2 - Particionamento\n\n"

    while true; do
       
        printf "Particoes ja criadas? [Y/n] (default: n) " 
        read PARTITIONS
        PARTITIONS=${PARTITIONS:-"n"}
        case $PARTITIONS in
            [Yy]* ) PARTITIONS=true; break;;
            [Nn]* ) PARTITIONS=false; FORMAT=true; break;;
            * ) printf "\nDigite Y ou N\n";;
        esac
    done

    if ($PARTITIONS || ($isUEFI && $WINDOWS))
    then
        printf "\nAbaixo estao as particoes existentes no disco selecionados: \n"
        lsblk /dev/$DISK -p -n -o NAME,SIZE,FSTYPE,MOUNTPOINT

        printf "\nDigite o caminho da particao /boot (default: ${DISK}1): /dev/"

        read BOOT
        BOOT=${BOOT:-${DISK}1}

        if $PARTITIONS
        then   
            printf "\nDigite o caminho da particao / (default: ${DISK}2): /dev/"
            read ROOT
            ROOT=${ROOT:-${DISK}2} 
        fi
    fi

    printf "\n\n Instalar bc... "
    pacman -Syyu --noconfirm -q bc
    printf "\n\n Instalar bc... OK"

    clear
    echo "******************************************"
    echo "Script de Instalacao do Arch - por vBob"
    echo "******************************************"
    printf "\n"
    echo "************************************************************"
    echo "*                                                          *"
    echo "*  AVISO: DADOS PODEM SER PERDIDOS                         *"
    echo "*  O criador deste script nao se responsabiliza por danos  *"
    echo "*  Os comandos antes de executados serao escritos          *"
    echo "*  So prossiga se tiver certeza do que esta fazendo        *"
    echo "*                                                          *"
    echo "************************************************************"

    printf "\nParte 2 - Particionamento\n"
    printf "\nPegar posicao da particao..."
    POSITION=`sudo parted -m /dev/$DISK unit MiB print free | grep "free;" | tail -n 1 | awk -F':' '{print $1}'`
    printf "OK\nPegar posicao de inicio... "
    START=`sudo parted -m /dev/$DISK unit MiB print free | grep "free;" | tail -n 1 | awk -F':' '{print $2}'`
    printf "OK\nPegar posicao de fim... "
    END=`sudo parted -m /dev/$DISK unit MiB print free | grep "free;" | tail -n 1 | awk -F':' '{print $3}'`
    printf "OK\n\n" 

    FREESIZE=`echo ${END%MiB} - ${START%MiB} | bc`
    if [[ ${FREESIZE%.*} -lt "2048" ]]
    then   
        echo "Espaco insuficiente neste disco"

        while true; do
            printf "Deseja formatar o disco por completo [Y/n] (default: n) " 
            read FORMAT
            FORMAT=${FORMAT:-"n"}
            case $FORMAT in
                [Yy]* ) FORMAT=true; break;;
                [Nn]* ) FORMAT=false; break;;
                * ) printf "\nDigite Y ou N\n";;
            esac
        done
    fi

    if ($FORMAT)
    then   
        if ($isUEFI)
        then
            LABEL="gpt"
        else   
            LABEL="msdos"
        fi

        clear
        printf "EXECUTAR PODE SER PERIGOSO\n\n"
        printf "TODOS OS DADOS NO DISCO \dev\\${DISK} SERAO PERDIDOS\n\n"
        printf "$ parted /dev/${DISK} mklabel $LABEL \n"
        printf "Isto criara um novo sistema de particoes no formato $LABEL\n\n"
        printf "Deseja executar este comando? [Y/n] (default: n) " 
            read FORMAT
            FORMAT=${FORMAT:-"n"}
            case $FORMAT in
                [Yy]* ) printf "\nCriar um novo sistema de particoes...RUN parted /dev/${DISK} mklabel $LABEL \nOK"; read as; break;;
                [Nn]* ) FORMAT=false; break;;
                * ) printf "\nDigite Y ou N\n";;
            esac

    fi

    if ! ($PARTITIONS || ($isUEFI && $WINDOWS) && OK)
    then

        printf "\n\nAVISO: DADOS PODEM SER PERDIDOS\n"
        printf "EXECUTAR PODE SER PERIGOSO\n\n"
        ENDBOOT=`echo ${START%MiB}+512 | bc`
        echo "/boot ->   $ parted /dev/$DISK mkpart ESP fat32 $START ${ENDBOOT}MiB"
        echo "/boot ->   $ set 1 boot on"
        echo "/boot ->   $ mkfs /dev/${DISK}1"
        printf "Isto criara uma nova particao e definira como bootavel\n\n"
        printf "Deseja executar este comando? [Y/n] (default: n) " 
            read FORMAT
            FORMAT=${FORMAT:-"n"}
            case $FORMAT in
                [Yy]* ) printf "\nCriar \boot...RUN parted /dev/$DISK mkpart ESP fat32 $START ${ENDBOOT}MiB \nOK"; read as; break;;
                [Nn]* ) FORMAT=false; break;;
                * ) printf "\nDigite Y ou N\n";;
            esac
    else 
       ENDBOOT=`echo ${START%MiB}+512 | bc`
       if (! $WINDOWS)
       then
            echo "/boot ->   $ parted /dev/$DISK mkpart ESP fat32 $START ${ENDBOOT}MiB"
            echo "/boot ->   $ set 1 boot on"
       fi
       echo "/ ->       $ parted /dev/$DISK mkpart primary ${ENDBOOT}MiB $END"
    fi

done
