
/*Copyright (c) 2014 krirou jilali

tous droits reserves */


/* usart_avrbot.h developpé pour l'interactive avrbot pour les atmega 16/32*/


/* $Id: usart_avrbot.h,v 1.5.2.1 2014/11/10 10:14:03 krirou jilali Exp $ */

#ifndef USART_AVRBT_H_
#define USART_AVRBOT_H_ 

#include<avr/io.h>
#include<avr/interrupt.h>
#include <inttypes.h>

void USARTInit(uint16_t ubrr_value);
char USARTReadChar();
void USARTWriteChar(char data);
void USART_newline(void);
void USARTWrite_S_Char(char *data);
char read_nomber(void);




#ifndef __OPTIMIZE__
# warning "Compiler optimizations disabled; functions from <usart_avrbot.h> won't work as designed"
#endif

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
char read_nomber(void)
    {
	 char data;
	 char data1;
	 char data2;
	 char data3;
	 data1=USARTReadChar()-61; 
	 data2=USARTReadChar()-61;
	 data3=USARTReadChar()-61;
	 data=(data1*100)+(data2*10)+data3;
	 USARTWrite_S_Char("ok");
	 USART_newline();
	 return data;
	}

#endif