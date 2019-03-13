## IoTDevice Simulator

sudo docker build -t  uneidelmsft/iotdevicesimulator:3.0 .

sudo docker push uneidelmsft/iotdevicesimulator:3.0

sudo docker run uneidelmsft/iotdevicesimulator:2.0 -iot "HostName=[iothubname].azure-devices.net;DeviceId=SingleDevice;SharedAccessKey=[xxxKEYxxx]" -payload http://www.json-generator.com/api/json/get/bVvfhEQOoO?indent=2