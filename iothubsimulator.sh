#! /bin/bash
FREQ=$3
if [ -z "$FREQ" ]
then
  FREQ=1
fi

groupname="iotdevicesimulator"
echo "creating resourcegroup $groupname"
az group create --name $groupname --location westeurope
az container create \
    --resource-group $groupname \
    --name iotdevicesim \
    --image uneidelmsft/iotdevicesimulator:3.0 \
    --restart-policy OnFailure \
    --command-line "dotnet IoTDeviceSimulator.dll -iot $1 -payload $2 -count $FREQ"

az group delete --name $groupname --yes




