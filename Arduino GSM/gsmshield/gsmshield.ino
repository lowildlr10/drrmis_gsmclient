//INCLUDED LIBRARIES
#include <sim900.h>
#include <GPRS_Shield_Arduino.h>
#include <SoftwareSerial.h>
#include <Wire.h>
#include <string.h>

//SERIAL PIN ASSIGNMENT, BAUDRATE
#define PIN_TX    2
#define PIN_RX    3
#define BAUDRATE  9600

GPRS GSM_MODULE(PIN_TX,PIN_RX,BAUDRATE);//TX,RX,BAUDRATE

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
  Serial.println("gsm_init_success");
}

bool sendMsgTxt(String params) {
  String _phone = getSepartedValues(params, ':', 0);
  String _message = getSepartedValues(params, ':', 1);
  _message.trim();
  const char* phone = _phone.c_str();
  const char* message = _message.c_str();
  sim900_flush_serial();
  if(GSM_MODULE.sendSMS(const_cast<char*>(phone), const_cast<char*>(message))){
    return true;
  }else{
    return false;
  }
}

void sendMsgPDU(String msgStringPDU) {
  // To be developed soon.
}

int getSignalStr() {
  int signalVal = 2;
  bool isSignal = false;
  while(!isSignal) {
    isSignal = GSM_MODULE.getSignalStrength(&signalVal);
    signalVal++;
  }
  return signalVal;
}

String getNetworkProvider() {
  String srvcProv;
  char gprsBuffer[15];
  char* p, *s;
  int i = 0;
  sim900_send_cmd("AT+CSPN?\n");
  sim900_clean_buffer(gprsBuffer, 15);
  srvcProv = sim900_read_string_until(gprsBuffer, 15, "TNT");
  if(srvcProv.length()>0){
    return srvcProv;
  }
  srvcProv = sim900_read_string_until(gprsBuffer, 15, "Smart");
  if(srvcProv.length()>0){
    return srvcProv;
  }
  srvcProv = sim900_read_string_until(gprsBuffer, 15, "TM");
  if(srvcProv.length()>0){
    return srvcProv;
  }
  srvcProv = sim900_read_string_until(gprsBuffer, 15, "Globe");
  if(srvcProv.length()>0){
    return srvcProv;
  }
  return "N/A";
}

void gsmDebug(String writeString) {
  /* byte writeByte[255];
  writeString.getBytes(writeByte, sizeof(writeByte));
  sim900_flush_serial();
  sim900_send_cmd((char*)writeByte);
  sim900_send_End_Mark();*/
}

void loop() {
  //GSM_MODULE.AT_Bypass();
  if(Serial.available()){
    while(Serial.available()) {
      String cmd = Serial.readString();
      String cond = getSepartedValues(cmd, '|', 0);
      String params = getSepartedValues(cmd, '|', 1);      
      if (cond == "send_txt_msg"){
        bool res = sendMsgTxt(params);
        String responseMsg = res ? "success" : "failed"; 
        Serial.println("message_stat:" + responseMsg + ":" + getSepartedValues(params, ':', 0));
      }else if (cond == "send_pdu_msg") {
        String msgStringPDU = getSepartedValues(params, ':', 0);
        sendMsgPDU(msgStringPDU);
      }else if (cond == "get_signal_str") {
        int signalStr = getSignalStr();
        Serial.println("signal_str:" + String(signalStr));
      }else if (cond == "get_gsm_stat"){
        bool isConnectedGSM = GSM_MODULE.init();
        String gsmStatus = isConnectedGSM ? "gsm_init_success" : "gsm_init_error";
        Serial.println(gsmStatus);
      }else if (cond == "get_network"){
        String networkProvider = getNetworkProvider();
        Serial.println(networkProvider);
      }else{
        sim900_flush_serial();
      }
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
