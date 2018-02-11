
/*Copyright (c) 2014 krirou jilali

tous droits reserves */

/* avrbot.h developpé pour l'interactive avrbot pour les atmega 16/32*/

/* $Id: avrbot.h,v 1.5.2.1 2014/11/10 10:14:03 krirou jilali Exp $ */

#ifndef AVRBOT_H_
#define AVRBOT_H_ 

#include<avr/io.h>


#ifndef __OPTIMIZE__
# warning "Compiler optimizations disabled; functions from <avrbot.h> won't work as designed"
#endif



void config_port_sortie( int x);
void config_port_entree( int x);
void port_sortie(int port, int valeur);


//configuration de port en sortie
void config_port_sortie( int x)

{
	if(x==1)
	{
		PORTA=0xff;
	}
	else if(x==2)
	{
		PORTB=0xff;
	}
	else if(x==3)
	{
		PORTC=0xff;
	}
	else if(x==4)
	{
		PORTD=0xff;
	}
}
//configuration de port en entree
void config_port_entree( int x)

{
	if(x==1)
	{
		PORTA=0x00;
	}
	else if(x==2)
	{
		PORTB=0x00;
	}
	else if(x==3)
	{
		PORTC=0x00;
	}
	else if(x==4)
	{
		PORTD=0x00;
	}
}
//les valeurs de port lorsqu 'il connecter 
void port_sortie(int port, int valeur)
{
	
		if (port==1)
		{
			PORTA=valeur;
		}
		else if(port==2)
		{
			PORTB=valeur;
		}
		else if(port==3)
		{
			PORTC=valeur;
		}
		else if(port==4)
		{
			PORTD=valeur;
		}
	
}


#endif