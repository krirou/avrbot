/*Copyright (c) 2014 krirou jilali

tous droits reserves */


/* moteur_pap.h developpé pour l'interactive avrbot pour les atmega 16/32*/


/* $Id: moteur_pap.h,v 1.5.2.1 2014/11/10 10:14:03 krirou jilali Exp $ */

#ifndef MOTEUR_H_
#define MOTEUR_H_ 

#include <avr/io.h>
#include<avr/interrupt.h>
#include <avr/interrupt.h>
#define T_MAX  10000 
#define T_MIN 300
#define T_INIT 900
#define T_DEF 9700
#define T_POSITION 500

int sens;
void config_timer_pap(void);
void rotat_step_pap(int sens);
void step_bac_pap(void);
void step_for_pap(void);
void config_interface_pap(void);
void config_adc_pap(void);
void start_adc();
#ifndef __OPTIMIZE__
# warning "Compiler optimizations disabled; functions from <moteur_pap.h> won't work as designed"
#endif

int T_Vitesse_pap=T_INIT;              //la variable de temp qui controle la vitesse de rotation
char etat_step;
char step=0;
char step_pre=0;


void config_timer_pap(void)
    {
	 TIMSK|=(1<<OCIE1B);          //choix de Timer B avec la valeur de comparaison
	 TCCR1B|=(1<<CS10);           //choix de prescaler a 1 pour obtenire ou freqence 1Mhz
	}
	void config_adc_pap(void)
   {
     ADMUX|=(1u<<REFS0);                   //Vref=Avcc
     ADCSRA|=(1u<<ADEN);                   //set on adc 
     ADCSRA|=(1<<ADPS1)|(1<<ADPS0);        //set prescaler To 8 car (1Mhz/8=125khz)
     ADCSRA|=(1u<<ADIE);                   //set one intruption de ADC
    }

	
	//fonction de demarage de la convertion de l'ADC
void start_adc()                       
    {
	 ADCSRA|=(1u<<ADSC);               //lancée la convertion de ADC
	}
	
void step_1(void)                 //etat 1 du moteur
    {
	 PORTB=0b00000011;
	}
	

void step_2(void)                  //etat 2 du moteur
    {
	 PORTB=0b00000110;
	}
	

void step_3(void)                 //etat 3 du moteur
    {
	 PORTB=0b00001100;
	}
	
	
void step_4(void)                 //etat 4 du moteur
    {
	 PORTB=0b00001001;
	}
	
	
void step_for_pap(void)                 //fonction de rotation au sens direct
    {
	  if(etat_step==1)
	   {
	      step_2();
		  etat_step=2;
		}
	 else if(etat_step==2)
	    { 
		  step_3();
		  etat_step=3;
		}
      else if(etat_step==3)
	    { 
		  step_4();
		  etat_step=4;
		}
	 else if(etat_step==4)
	    { 
		  step_1();
		  etat_step=1;
		}
	}
	
void step_bac_pap(void)                     //fonction de rotation au sens indirect
    {
	  if(etat_step==1)
	   { 
		  step_4();
		  etat_step=4;
		}
	 else if(etat_step==2)
	     { 
		  step_1();
		  etat_step=1;
		}
      else if(etat_step==3)
	     {
	      step_2();
		  etat_step=2;
		}
	 else if(etat_step==4)
	    {
		  step_3();
		  etat_step=3;
		}
	 
	}
	
void rotat_step_pap( sens)                    //fonction qui appel les fonction de sense direct et indirect
    {
	  if(sens==1)
	     step_for_pap();
	 else if(sens==2)
	     step_bac_pap();
	}

	
 
/*ISR(TIMER1_COMPB_vect)                    //intruption du timer
    {
	
		 rotat_step(sens);
	     OCR1B=T_Vitesse_pap; 
	
	
	 TCNT1=0;
	       
	}*/
	



	
	
void config_interface_pap(void)
    {
	 
     DDRB|= 0x00001111;                     //declaration de port c comme sortie  
   
	}



#endif