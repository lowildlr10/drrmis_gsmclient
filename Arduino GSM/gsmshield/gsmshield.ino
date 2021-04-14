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
#include <SoftwareSerial.h>
#include <Wire.h>
#include <string.h>

//SERIAL PIN ASSIGNMENT, BAUDRATE, PHONE NUMBER, MESSAGE
#define PIN_TX    2
#define PIN_RX    3
#define BAUDRATE  9600
#define MESSAGE_LENGTH 1000

char phone[13];
char message[MESSAGE_LENGTH];

GPRS GSM_MODULE(PIN_TX,PIN_RX,BAUDRATE);//RX,TX,BAUDRATE
SoftwareSerial GSM_DEBUG(PIN_TX,PIN_RX);//TX,RX

void setup() {
  Serial.begin(BAUDRATE);
  while(!GSM_MODULE.init()) {
      delay(1000);
      Serial.print("INIT ERROR\r\n");
  }  
  Serial.println("GSM INIT SUCCESS");
  delay(1000);
}

void sendMessage(String params) {
  phone = getValue(params, ':', 0);
  message = getValue(params, ':', 1);
  Serial.println("Sending ...");
  delay(1000);
  GSM_MODULE.sendSMS(phone, message);
}

void sendCommandDebug(String param) {
  if(GSM_DEBUG.available()){
    Serial.write(GSM_DEBUG.read());
  }
  if(Serial.available()){     
    GSM_DEBUG.write(Serial.read()); 
  }
}

void loop() {
  if (Serial.available() > 0) {
    while (Serial.available()) {
      String cmd = Serial.readString();
      String cond = getValue(cmd, '|', 0);
      String params = getValue(cmd, '|', 1);      
      if (cond == "send_msg") {
        sendMessage(params);
      } else if (cond == "debug") {
        sendCommandDebug(params);
      }
      Serial.read();
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
