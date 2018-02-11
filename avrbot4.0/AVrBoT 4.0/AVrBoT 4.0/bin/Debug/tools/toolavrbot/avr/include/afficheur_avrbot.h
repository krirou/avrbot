
/*Copyright (c) 2014 krirou jilali

tous droits reserves */


/* afficheur_avrbot.h developpé pour l'interactive avrbot pour les atmega 16/32*/


/* $Id: afficheur_avrbot.h,v 1.5.2.1 2014/11/10 10:14:03 krirou jilali Exp $ */


#ifndef AFFICHEUR_H_
#define AFFICHEUR_H_ 


char nmb(char a);
void cod(void);


#ifndef __OPTIMIZE__
# warning "Compiler optimizations disabled; functions from <afficheur_avrbot.h> won't work as designed"
#endif
char nmb(char a)
    {
     switch(a)
        {
         case 0: a=0b01011111;
         break;
         case 1: a=0x06;
         break;
         case 2: a=0b00111011;
         break;
         case 3: a=0b00101111;
         break;
         case 4: a=0x66;
         break;
         case 5: a=0X6d;
         break;
         case 6: a=0x7d;
         break;
         case 7: a=0x07;
         break;
         case 8: a=0x7f;
         break;
         case 9: a=0X6f;
         break;
        }
      return a;
    }

void cod(void)
    {
     b=a/10;
     c=a-b*10;
     b=nmb(b);
     c=nmb(c);
     c=c&0b01111111;
     b=b|(1u<<7);

    }

#endif