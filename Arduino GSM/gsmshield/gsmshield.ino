//INCLUDED LIBRARIES
#include <GPRS_Shield_Arduino.h>
#include <SoftwareSerial.h>
#include <Wire.h>
#include <string.h>

//SERIAL PIN ASSIGNMENT, BAUDRATE
#define PIN_TX    2
#define PIN_RX    3
#define BAUDRATE  9600

SoftwareSerial GSM_SERIAL(PIN_TX,PIN_RX);//RX,TX
GPRS GSM_MODULE(PIN_TX,PIN_RX,BAUDRATE);//RX,TX,BAUDRATE

void setup() {
  GSM_MODULE.checkPowerUp();
  Serial.begin(BAUDRATE);
  while(!GSM_MODULE.init()){
    delay(1000);
    Serial.println("gsm_init_error");
  }
  while(!GSM_MODULE.isNetworkRegistered()){
    delay(1000);
    Serial.println("gsm_init_error");
  }
  GSM_SERIAL.begin(BAUDRATE);
  Serial.println("gsm_init_success");
}

bool sendMsgTxt(String params) {
  String _phone = getSepartedValues(params, ':', 0);
  String _message = getSepartedValues(params, ':', 1);
  _message.trim();
  const char* phone = _phone.c_str();
  const char* message = _message.c_str();
  if(GSM_MODULE.sendSMS(const_cast<char*>(phone), const_cast<char*>(message))){
    return true;
  }else{
    return false;
  }
}

void sendMsgPDU(String msgStringPDU) {
  /*byte writeByteInitPDU[12] = "AT+CMGF=0\r\n";
  byte writeByteMsgCount[10] = "AT+CMGS=42\r\n";
  byte writeByteMsg[200];
  flushSerial();
  GSM_SERIAL.write((char*)writeByteInitPDU);
  delay(1000);
  GSM_SERIAL.write((char*)writeByteMsgCount);
  delay(2000);
  msgStringPDU.getBytes(writeByteMsg, sizeof(writeByteMsg));
  GSM_SERIAL.write((char*)writeByteMsg);
  delay(300);*/
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

String getNetworkProvider() {
  byte writeByte[64] = "AT+CSPN?\n";
  flushSerial();
  GSM_SERIAL.write((char*)writeByte);
}

void gsmDebug(String writeString) {
  byte writeByte[255];
  writeString.getBytes(writeByte, sizeof(writeByte));
  flushSerial();
  GSM_SERIAL.write((char*)writeByte);
}

void loop() {
  if(Serial.available()){
    while (Serial.available()) {
      String cmd = Serial.readString();
      String cond = getSepartedValues(cmd, '|', 0);
      String params = getSepartedValues(cmd, '|', 1);      
      if (cond == "send_txt_msg"){
        bool res = sendMsgTxt(params);
        String responseMsg = res ? "success" : "failed"; 
        Serial.println("message_stat:" + responseMsg + ":" + getSepartedValues(params, ':', 0));
      }else if (cond == "send_pdu_msg") {
        String msgStringPDU = getSepartedValues(params, ':', 0);
        sendMsgPDU("079136190800101011000A9119922547570000FF21C8329BFD06DDDF72363904A296E7F4B4FB0C8212ABA076793E0F9FCB2E\n\r");
      }else if (cond == "get_signal_str") {
        int signalStr = getSignalStr();
        Serial.println("signal_str:" + String(signalStr));
      }else if (cond == "get_gsm_stat"){
        bool isConnectedGSM = GSM_MODULE.init();
        String gsmStatus = isConnectedGSM ? "gsm_init_success" : "gsm_init_error";
        Serial.println(gsmStatus);
      }else if (cond == "get_network"){
        getNetworkProvider();
      }else if (cond == "gsm_debug"){
        String writeString = getSepartedValues(params, ':', 0);
        gsmDebug(writeString);
      }else{
        flushSerial();
      }
    }
  }
  if(GSM_SERIAL.available()){
    while(GSM_SERIAL.available()){
      Serial.write(GSM_SERIAL.read());
    }
  }
}

String getSepartedValues(String data, char separator, int index) {
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

void flushSerial() {
    Serial.read();
    GSM_SERIAL.read();
}
