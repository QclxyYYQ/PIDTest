#ifndef __UART_H__
#define __UART_H__

#include "pid.h"

void UartInit(void);
void UartSendByte(unsigned char dat);
void UartProc();
void UartSend(unsigned char *dat);
void ByteToFloat(unsigned char *b,float *f);
void ByteToInt(unsigned char *b,int *f);
void UartSendInt(int dat);

void UartSendSpeed(int speed);
void UartSendPWM(unsigned char pwm);
void UartSendPID(PID_Uint *sptr);

#define Flag_First 0xFF
#define Flag_Start 0xF0
#define Flag_Stop 0x8F
#define Flag_SetPWM 0x10
#define Flag_SetTar 0x20
#define Flag_SetPID 0x24
#define Flag_GetSpeed 0x25
#define Flag_GetPWM 0x27
#define Flag_GetPID 0x26

#endif