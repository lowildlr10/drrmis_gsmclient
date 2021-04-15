//***********************************************//
//        GSM/GPRS SEND AND READ SMS             //
//                                               //
//  This sketch is used to test              //
//  e-Gizmo SIM800,800L,900D,900 modules/kits  //
//  Wiring Connection:                           //
//  SIM800/900 modules to UARTPORT/gizDuino MCUs //
//    RXD - TX(D3)           //
//    TXD - RX(D2)           //
//    GND - GND              //
//  by e-Gizmo Mechatronix Central           //
//          http://www.egizmo.com                //
//***********************************************//

//INCLUDED LIBRARIES
#include <GPRS_Shield_Arduino.h>
#include <sim900.h>
#include <SoftwareSerial.h>
#include <Wire.h>
#include <string.h>

//SERIAL PIN ASSIGNMENT, BAUDRATE, PHONE NUMBER, MESSAGE
#define PIN_TX    2
#define PIN_RX    3
#define BAUDRATE  9600

GPRS GSM_MODULE(PIN_TX,PIN_RX,BAUDRATE);//RX,TX,BAUDRATE
SoftwareSerial GSM_DEBUG(PIN_TX,PIN_RX);//TX,RX

void setup() {
  Serial.begin(BAUDRATE);
  while(!GSM_MODULE.init()) {
      delay(1000);
      Serial.println("gsm_init_error");
  }
  sim900_init(&GSM_DEBUG, BAUDRATE);
  Serial.println("gsm_init_success");
  delay(1000);
}

bool sendMessage(String params) {
  String _phone = getValue(params, ':', 0);
  String _message = getValue(params, ':', 1);
  const char* phone = _phone.c_str();
  const char* message = _message.c_str();
  //Serial.println("Sending ...");
  delay(100);
  return GSM_MODULE.sendSMS(const_cast<char*>(phone), const_cast<char*>(message));
}

int getSignalStr() {
  int signalVal = 2;
  bool isSignal = false;
  while (!isSignal) {
    isSignal = GSM_MODULE.getSignalStrength(&signalVal);
    signalVal++;
  }
  return signalVal;
}

void loop() {
  if(Serial.available()){
    while (Serial.available()) {
      String cmd = Serial.readString();
      String cond = getValue(cmd, '|', 0);
      String params = getValue(cmd, '|', 1);      
      if (cond == "send_msg") {
        bool res = sendMessage(params);
        Serial.println("message_stat:" + String(res) + ":" + getValue(params, ':', 0));
      } else if (cond == "get_signal_str") {
        int signalStr = getSignalStr();
        Serial.println("signal_str:" + String(signalStr));
      } else if (cond == "get_gsm_stat") {
        bool isConnectedGSM = GSM_MODULE.init();
        String gsmStatus = isConnectedGSM ? "gsm_init_success" : "gsm_init_error";
        Serial.println(gsmStatus);
      } else {
        Serial.read();
        delay(1000);
      }
    }
  }
}

String getValue(String data, char separator, int index) {
  int found = 0;
  int strIndex[] = {0, -1};
  int maxIndex = data.length()-1;
  for(int i=0; i<=maxIndex && found<=index; i++){
    if(data.charAt(i)==separator || i==maxIndex){
        found++;
        strIndex[0] = strIndex[1]+1;
        strIndex[1] = (i == maxIndex) ? i+1 : i;
    }
  }
  return found>index ? data.substring(strIndex[0], strIndex[1]) : "";
}
