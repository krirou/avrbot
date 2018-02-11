/*
 * ExoMars_Rovers.c
 * Created: 12/04/2014 00:21:16
 * This  PROGRAM write  for atmega16/atmega32 
 * for other AVR device MODIFIED this program (change just port and registry) 
 * upload ExoMars_Rovers.hex in your favorite Kits using AVrBoT Software
            by krirou jilali
 */ 

#include<avr/io.h>
#include<avr/interrupt.h>
#include <inttypes.h>


#define TS_rotat_teep 700
#define T_INIT 3000

#define SERVO1 PD2                 //servo1, 2 et 3 pour bras de robot pour ramasser des object
#define SERVO2 PD3
#define SERVO3 PD4                 
#define SERVOMOTRICE1 PD4
#define SERVOMOTRICE2 PD5           //4 roue motrice de robot rovers 
#define SERVOMOTRICE3 PD6
#define SERVOMOTRICE7 PD7
# define InfraRedSnsors1 PA0        //detecte obstacle direct (obstacle1)
# define InfraRedSnsors2 PA1        //detecte obstacle inclinit (obstacle2)
# define DistaceSnsors PA2          //calcul distance 
# define dataCam PA3                //commande camera


// dur�es typiques (en �s)
#define PULSE_MIN_WIDTH    600
#define PULSE_MAX_WIDTH    2400
#define PULSE_MED_WIDTH 1500

// nombre de servos g�r�s
#define SERVO_COUNT 5    

// largeurs des pulses des servos, en fonction de la position demand�e
volatile unsigned int pulse_widths[SERVO_COUNT] ;

// id du servo courant (dont on g�n�re le cr�neau)
volatile unsigned char cur_servo = 0 ;



char etat_step;
char step=0;
char step_pre=0;

char sens;



//This function is used to initialize the USART
//at a given UBRR value
void USARTInit(uint16_t ubrr_value)
{

   //Set Baud rate

   UBRRL = ubrr_value;
   UBRRH = (ubrr_value>>8);

   /*Set Frame Format


   >> Asynchronous mode
   >> No Parity
   >> 1 StopBit

   >> char size 8

   */

   UCSRC=(1<<URSEL)|(3<<UCSZ0);


   //Enable The receiver and transmitter

   UCSRB=(1<<RXEN)|(1<<TXEN);


}


//This function is used to read the available data
//from USART. This function will wait untill data is
//available.
char USARTReadChar()
{
   //Wait untill a data is available

   while(!(UCSRA & (1<<RXC)))
   {
      //Do nothing
   }

   //Now USART has got data from host
   //and is available is buffer

   return UDR;
}


//This fuction writes the given "data" to
//the USART which then transmit it via TX line
void USARTWriteChar(char data)
{
   //Wait untill the transmitter is ready

   while(!(UCSRA & (1<<UDRE)))
   {
      //Do nothing
   }

   //Now write the data to USART buffer

   UDR=data;
}





void USART_newline(void)
{
    USARTWriteChar('\r');
		 USARTWriteChar('\n');

  return;
}

void USARTWrite_S_Char(char *data)
{
   unsigned char c;

   while(*data)
   {
      USARTWriteChar(*data++);
   }
   USART_newline();
   return;
   //Now write the data to USART buffer

 
}



void config_timer(void)
    {
	 // configuration pour le servo
	 TCCR1B = (1 << WGM12)| (1 << CS10);   
     OCR1A = PULSE_MAX_WIDTH + 10 ;
     OCR1B = PULSE_MED_WIDTH ;
     TCNT1 = OCR1B + 10 ;
     TIMSK = (1 << OCIE1A)| (1 << OCIE1B);
		   
     //configuration pour MPAP
	 TIMSK|=(1<<OCIE0);  //choix de Timer 0 avec la valeur de comparaison
	 TCCR0|=(1<<CS02);   //configuration de prescaler a 8
	 OCR0=112;      //pour avoir une interupption chaque 1ms
	  
}
	
void step_1(void)                 //etat 1 du moteur
    {
	 PORTB=0b00000001;
	 etat_step=1;
	}
	

void step_2(void)                  //etat 2 du moteur
    {
	 PORTB=0b00000010;
	 etat_step=2;
	}
	

void step_3(void)                 //etat 3 du moteur
    {
	 PORTB=0b00000100;
	 etat_step=3;
	}
	
	
void step_4(void)                 //etat 4 du moteur
    {
	 PORTB=0b00001000;
	 etat_step=4;
	}
	
	
	//fonction de rotation au sens direct
void step_for(void)
    {
	  if(etat_step==1)
	   {
	      step_2();
		}
	 else if(etat_step==2)
	    { 
		  step_3();
		}
      else if(etat_step==3)
	    { 
		  step_4();
		}
	 else if(etat_step==4)
	    { 
		  step_1();
		}
	}
	
	
	//fonction de rotation au sens indirect, 
void step_bac(void)                     
    {
	  if(etat_step==1)
	   { 
		  step_4();
		}
	 else if(etat_step==2)
	    { 
		  step_1();
		}
      else if(etat_step==3)
	    {
	      step_2();
		}
	 else if(etat_step==4)
	    {
		  step_3();
		}
	 
	}
	
	

 void rotat_step(void)
 {
 if(sens==1)
     step_for();
	 else
     step_bac(); 

   }
ISR(TIMER1_COMPA_vect) 
    {
     PORTD |= (1 << cur_servo+2) ;
     // On d�finit le comparateur B en fonction de la dur�e de l'impulsion � g�n�rer
     OCR1B = pulse_widths[cur_servo];
    }


/*
    Interrupt handler pour l'Ouput Compare B du timer 1

    Le passage � cette valeur correspond � la fin du cr�neau pour
    le servo en cours.
*/
ISR(TIMER1_COMPB_vect) 
    {
     PORTD &= ~(1 << cur_servo+2) ;
     // on passe au servo suivant, en rebouclant en fin de s�rie
     if (++cur_servo == SERVO_COUNT) 
	     cur_servo = 0 ;
}

	
	
ISR(TIMER0_COMP_vect)                    //intruption du timer
    {
	 if(step)
	    {
	     rotat_step();
    	 step--;
	    }	 
	 TCNT0=0;
	 
	}




	
void config_interface(void)
    {
     DDRB=0b00001111;                           //declaration de port c comme sortie de MPAP 
     DDRD|=(1<<SERVO1)|(1<<SERVO2)|(1<<SERVO3);  //declaration de port c comme sortie des servo 
     	 
	}
	



	

char read_nomber(void)
    {
	 char data;
	 char data1;
	 char data2;
	 char data3;
	 
	 data1=USARTReadChar(); 
	 USARTWriteChar(data1);
	 data1=data1-61;
	 
	 data2=USARTReadChar(); 
	 USARTWriteChar(data2);
	 data2=data2-61;
	 
	 data3=USARTReadChar(); 
	 USARTWriteChar(data3);
	 data3=data3-61;
	 
	 
	 data=(data1*100)+(data2*10)+data3;
	 
	
	 return data;
	}

	
int main(void)
    {  
	 char angle;  
	 char data;
	 char angle_s;
	 char servo_id;
	 
     USARTInit(25);    
     config_interface();            //configuration des entr�e et des sortie de ATMEGA16
     config_timer();
	 sei();
	 
	 //INIT mpap
     step_1();
	  // initialisation de tous les servos � mi-course
     for (int i = 0 ; i < SERVO_COUNT ; i++) 
	    {
          pulse_widths[i] = 2000 ;
        }

	 USARTWrite_S_Char("controle de robot rovers");
	 USART_newline();
	
		 while(1)
		    {
		     data=USARTReadChar();
		     
             if(data=='m')
			    {
				 USARTWrite_S_Char(data);
     			 USARTWrite_S_Char("S V P entrer LE SENS ET la position de MPA");
				 sens=USARTReadChar()-0x30;
				 angle=read_nomber()/1.8;
				 step=angle;
				 USART_newline();
				 USARTWrite_S_Char("operating.........");
				 break;
				}
				
		     else if(data=='s')
		        {
				 USARTWrite_S_Char(data);
				 USART_newline();
				 USARTWrite_S_Char(" specifier le servo: ");
				 servo_id=USARTReadChar()-0x30;
				 USART_newline();
		         USARTWrite_S_Char("  donner l\'angle  0.....180 ");
	             USART_newline();
				 angle_s=read_nomber();
				 pulse_widths[servo_id]=angle_s*10;
                 break;
				}
			
        }
    }
