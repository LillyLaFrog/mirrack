void setup() {
  // put your setup code here, to run once:
  pinMode(2, INPUT);
  pinMode(3, INPUT);
  pinMode(4, INPUT);
  pinMode(13, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(digitalRead(2) == HIGH) 
  {
    //press up on keyboard
    digitalWrite(13, HIGH);
    delay(1000);
    digitalWrite(13, LOW);
  }
    if(digitalRead(3) == HIGH) 
  {
    //press left on keyboard
    digitalWrite(13, HIGH);
    delay(2000);
    digitalWrite(13, LOW);
  }
      if(digitalRead(4) == HIGH) 
  {
    //press right on keyboard
    digitalWrite(13, HIGH);
    delay(3000);
    digitalWrite(13, LOW);
  }
  //todo: set up potentiometer :)
}
