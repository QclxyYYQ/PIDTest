/*
		
	1500850226 ������ ��Ȩ����
							
							2015��12��24��
*/
#include <STC12C5A60S2.H>
#include "delay.h"

#include "uart.h"

#include "pid.h"

sbit shu_dat=P0^0;
sbit shu_g=P0^1;
sbit shu_rck=P0^2;
sbit shu_sck=P0^3;

sbit spk=P1^3;

sbit fan=P1^6;

sbit key1=P2^7;
sbit key2=P2^6;
sbit key3=P2^5;
sbit key4=P2^4;

sbit Pex1=P3^3;

code unsigned char shu[]={0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7d, 0x07, 0x7f, 0x6f};

void SendDataShu(unsigned int dat);

void key_scan();
void SPK_Err();
void SPK_Info();

unsigned int speed_t=0;

unsigned char mode=0;

unsigned char PWM_CUR=0,PWM_DES=50;

unsigned char Press=0;

bit scan=0;
bit flag_1s,flag_10ms;
bit speaking=0;
bit start=0;
int PWM,Speed_Measure;

PID_Uint sPID,*sptr= &sPID;
 /*
�����������죬��д��λ����������ǰ�Ļ���C++��MFC��ܸĳ�C#��д��
֧�ֲ���ͼ�ֲ��Ŵ󣬹۲����壬֧�ֵ�����Excel�ļ�������ڷ�����
��λ�����棬����ȵ�������ܹ����淶�˴���ͨѶЭ�飬ͨѶ���ȶ���
*/
void SPK_Info()
{
	spk=1;
}
void SendDataShu(unsigned int dat)
{
	unsigned char i=0,j=0,num[4]={0};

	num[0]=shu[dat/1000];
	num[1]=shu[dat%1000/100];
	num[2]=shu[dat%1000%100/10];
	num[3]=shu[dat%1000%100%10];
	for(i=0;i<3;i++)
	{
		if(num[i]!=shu[0])
			break;
		num[i]=0;
	}
	
//	if(mode==1)
//		num[0]=0x73;
	
	for(j=0;j<4;j++)
	{
		P0=(P0&0x0F)|(0x10<<j);
		for(i=0;i<8;i++)
		{
			shu_dat=num[j]&0x80;
			shu_sck=0;
			shu_sck=1;
			num[j]<<=1;
		}
		shu_rck=0;
		shu_rck=1;
		Delay50us();

		shu_dat=0;
		for(i=0;i<8;i++)
		{
			shu_sck=0;
			shu_sck=1;
		}		
		shu_rck=0;
		shu_rck=1;
	}
	
}

void Timer0Init(void)		//1����@11.0592MHz
{
	AUXR |= 0x80;		//��ʱ��ʱ��1Tģʽ
	TMOD &= 0xF0;		//���ö�ʱ��ģʽ
	TL0 = 0xCD;		//���ö�ʱ��ֵ
	TH0 = 0xD4;		//���ö�ʱ��ֵ
	TF0 = 0;		//���TF0��־
	TR0 = 1;		//��ʱ��0��ʼ��ʱ
}
void Ex0() interrupt 0
{
	speed_t++;
}
void timer0_isr() interrupt 1
{
	static unsigned int counter_1s,counter_10ms;
	if(++counter_1s>=1000)				
	{
		counter_1s=0;
		flag_1s=1;
		
		Speed_Measure=speed_t;   ////�����ٶ�
		speed_t=0;
		
		UartSendSpeed(Speed_Measure);
		UartSendPWM(PWM_DES);
		
	}
	if(++counter_10ms>=10)
	{
		flag_10ms=1;
		counter_10ms=0;
	}
	
	PWM_CUR++;
  if (PWM_CUR < PWM_DES)
	  fan = 1; 
	if(PWM_CUR >=PWM_DES)
		fan = 0;      
	
	if(PWM_CUR>100)
		PWM_CUR=0;

}
/*
void key_scan()
{
	if(!key1)
	{
		Delay1ms();
		if(!key1)
		{
			if(mode==1)
				mode=0;
			else
				mode=1;
			while(!key1);
		}
	}else if(!key2)
	{
		Delay1ms();
		if(!key2)
		{
			if(mode==1)
			{
				if(PWM_DES>=10)
				{
					PWM_DES-=10;
					
				}
			}else if(mode==2)
			{
				if(speed_des>0)
					speed_des-=200;
				
			}
			while(!key2);
		}
	}else if(!key3)
	{
		Delay1ms();
		if(!key3)
		{
			if(mode==1)
			{
				if(PWM_DES<=90)
				{
					PWM_DES+=10;
					
				}
			}else if(mode==2)
			{
				if(speed_des<3000)
					speed_des+=200;
				
			}
			while(!key3);
		}
	}else if(!key4)
	{
		Delay1ms();
		if(!key4)
		{
			
			if(mode==2)
			{				
				lock=0;
				mode=0;
			}
				else
			{
				lock=1;
				mode=2;
			}
			
			while(!key4);
		}
	}
}
*/

void init()
{
	Speed_Measure=0;

	PIDInit(sptr);
	
	P0M0=0xF0;
	P1M0|=0x88;
	shu_g=0;
	Timer0Init();
	UartInit();
	
  spk=0;
	
	fan=0;
	
	IT0=1;//�½��ش���
	EX0=1;//�ⲿ�ж�0��
	
	ET0=1;
	
  ET0=1;EX0=1;
	
	EA=1;
	
	P2=0xFF;
}

int main()
{
	int PWM_PID;
	
  init();
	
	while(1)
	{
//		if(mode==0)
//			SendDataShu(speed);
//		else if(mode==2)
//			SendDataShu(PWM_DES);
		
		if(flag_10ms)
		{
			flag_10ms=0;
			
		}
		
		if(flag_1s)
		{
			flag_1s=0;
			
			spk=0;
			
			//if(start)
			{
				
			}
			
			//UartSendByte(Speed_Measure);
			if(mode==0)
			{
				PWM_PID=PID_Calc(Speed_Measure,sptr);
				if((PWM_DES+0.5*PWM_PID)<100&&(PWM_DES+0.5*PWM_PID)>0) //��ֹ���ڱ������� ���PWMֵ������Χ
				{
					if(mode==0)
						PWM_DES=PWM_DES+0.5*PWM_PID;//0.5���ڱ�֤�ٶȵ�����ȹ���ʱPWM�������
				}
			}else if(mode==1)
			{
				
			}
		}
		SendDataShu(Speed_Measure);
		//key_scan();
	}
	return 0;
}