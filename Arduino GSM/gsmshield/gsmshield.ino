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
  GSM_MODULE.powerReset(PIN_TX);
  GSM_MODULE.powerReset(PIN_RX);
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

bool sendMsgTxt(String _phone, String _message) {
  _message.trim();
  const char* phone = _phone.c_str();
  const char* message = _message.c_str();
  sim900_flush_serial();
  delay(1000);
  if(GSM_MODULE.sendSMS(const_cast<char*>(phone), const_cast<char*>(message))){
    return true;
  }else{
    return false;
  }
}

bool sendMsgPDU(String _tpduLength, String _tpduParam) {
  // Under development
  const char* tpduLength = _tpduLength.c_str();
  const char* tpduParam = _tpduParam.c_str();
  sim900_flush_serial();
  sim900_send_cmd(F("AT+CMGF=0\n"));
  delay(500);
  sim900_send_cmd(F("AT+CMGS=\""));
  sim900_send_cmd(tpduLength);
  delay(3000);
  if (!sim900_check_with_cmd(F("\"\r\n"), ">", CMD)) {
    return false;
  }
  delay(1000);
  sim900_send_cmd(tpduParam);
  delay(3000);
  sim900_send_End_Mark();
  return sim900_wait_for_resp("OK\r\n", CMD, 20U, 5000U);
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
  // To developed
}

void loop() {
  //GSM_MODULE.AT_Bypass();
  if(Serial.available()){
    while(Serial.available()) {
      String cmd = Serial.readString();
      String cond = getSepartedValues(cmd, '|', 0);
      String params = getSepartedValues(cmd, '|', 1);      
      if (cond == "send_txt_msg"){
        String phone = params;
        String message = getSepartedValues(cmd, '|', 2);
        bool res = sendMsgTxt(phone,message);
        String responseMsg = res ? "success" : "failed"; 
        Serial.println("message_txt_stat:" + responseMsg + ":" + phone + ":txt");
      }else if (cond == "send_pdu_msg") {
        String tpduLength = params;
        String tpduParam = getSepartedValues(cmd, '|', 2);
        bool res = sendMsgPDU(tpduLength,tpduParam);
        String responseMsg = res ? "success" : "failed"; 
        Serial.println("message_pdu_stat:" + responseMsg + ":" + tpduParam + ":pdu");
        // Under development.
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
