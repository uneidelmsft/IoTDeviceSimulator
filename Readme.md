## IoTDevice Simulator

Please use the following command to simulate Azure IoT Device Telemetry Send: 

1)Create your custom Payload:
  Go To https://www.json-generator.com/ and build your Payload  (Please choose a High Repeat number)
  Press Generate and Upload JSON to Server
  COPY JSON to URL File
2)Get your Device Connection String

curl -L https://aka.ms/iothubsimulator.sh | bash -s  "HostName=[YOURHUB].azure-devices.net;DeviceId=SingleDevice;SharedAccessKey=[YOURKEY]" "http://www.json-generator.com/api/json/get/bVvfhEQOoO?indent=2" 1


The Telemetry Data is used from http://json-generator.com Thanks for that useful tool.







Copyright (c) uneidelmsft 2019
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
