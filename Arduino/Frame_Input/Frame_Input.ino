
//include peripheral libraries 
#include <Mouse.h>
#include <Keyboard.h>

//locate digital inputs
const int encoderPinA = 1;
const int encoderPinB = 0;
static int upBtnPin = 3;
static int leftBtnPin = 2;
static int rightBtnPin = 4;

//encoder varibles
volatile int lastEncoded = 0;
volatile long encoderValue = 0;
volatile bool turned = false;
volatile int direction = 0;

unsigned long lastTurnTime = 0;
const unsigned long debounceDelay = 50; // ms

void setup() {
  //set pinMode for inputs
  pinMode(upBtnPin, INPUT_PULLUP);
  pinMode(leftBtnPin, INPUT_PULLUP);
  pinMode(rightBtnPin, INPUT_PULLUP);
  pinMode(encoderPinA, INPUT_PULLUP);
  pinMode(encoderPinB, INPUT_PULLUP);

  attachInterrupt(digitalPinToInterrupt(encoderPinA), updateEncoder, CHANGE);
  attachInterrupt(digitalPinToInterrupt(encoderPinB), updateEncoder, CHANGE);
  //start keyboard service
  Keyboard.begin();
}

void loop() {
  // emulate keyboard and mouse

  //scroll
  unsigned long now = millis();
  if (turned && (now - lastTurnTime > debounceDelay)) {
    turned = false;
    lastTurnTime = now;
  Mouse.move(0,0, direction);
  }

  //up arrow
  if(digitalRead(upBtnPin) == LOW) 
  {
    //press up on keyboard
    Keyboard.press(KEY_UP_ARROW);
  } else {
    //release up on keyboard
    Keyboard.release(KEY_UP_ARROW);
  }

  //left arrow
  if(digitalRead(leftBtnPin) == LOW) 
  {
    //press left on keyboard
    Keyboard.press(KEY_LEFT_ARROW);
  } else {
    //release left on keyboard
    Keyboard.release(KEY_LEFT_ARROW);
  }

  //right arrow
    if(digitalRead(rightBtnPin) == LOW) 
  {
    //press right on keyboard
    Keyboard.press(KEY_RIGHT_ARROW);
  } else {
    Keyboard.release(KEY_RIGHT_ARROW);
  }
}

void updateEncoder() {
  int MSB = digitalRead(encoderPinA);
  int LSB = digitalRead(encoderPinB);

  int encoded = (MSB << 1) | LSB;
  int sum = (lastEncoded << 2) | encoded;

  if (sum == 0b1101 || sum == 0b0100 || sum == 0b0010 || sum == 0b1011) {
    encoderValue++;
    direction = 1;
    turned = true;
  } else if (sum == 0b1110 || sum == 0b0111 || sum == 0b0001 || sum == 0b1000) {
    encoderValue--;
    direction = -1;
    turned = true;
  }

  lastEncoded = encoded;
}

