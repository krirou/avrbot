/*Copyright (c) 2014 krirou jilali

tous droits reserves */

/* servo.h developpé pour l'interactive avrbot pour les atmega 16/32*/

/* $Id: servo.h,v 1.5.2.1 2014/11/10 10:14:03 krirou jilali Exp $ */

#ifndef SERVO_H_
#define SERVO_H_  

#include<avr/io.h>
#include<avr/interrupt.h>
#include <inttypes.h>
#define SERVO1 PD2
#define SERVO2 PD3
#define SERVO3 PD4

// durées typiques (en µs)
#define PULSE_MIN_WIDTH    600
#define PULSE_MAX_WIDTH    2400
#define PULSE_MED_WIDTH 1500

// nombre de servos gérés
#define SERVO_COUNT    9 

// largeurs des pulses des servos, en fonction de la position demandée
volatile unsigned int pulse_widths[SERVO_COUNT] ;

// id du servo courant (dont on génère le créneau)
volatile unsigned char cur_servo = 0 ;

void config_timer_servo(void);
void config_interface_servo(void);

#ifndef __OPTIMIZE__
# warning "Compiler optimizations disabled; functions from <servo.h> won't work as designed"
#endif


void config_timer_servo(void)
    {
	 // configuration pour le servo
	 TCCR1B = (1 << WGM12)| (1 << CS10);   
     OCR1A = PULSE_MAX_WIDTH + 10 ;
     OCR1B = PULSE_MED_WIDTH ;
     TCNT1 = OCR1B + 10 ;
     TIMSK = (1 << OCIE1A)| (1 << OCIE1B);
	}
	void config_interface_servo(void)
    {
      
     DDRD|=(1<<SERVO1)|(1<<SERVO2)|(1<<SERVO3);  //declaration de port d comme sortie des servo 
     	 
	}
	


#endif