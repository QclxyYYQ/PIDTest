#ifndef __PID_H__
#define __PID_H__

#define PID_Uint struct PID
	
struct PID         				//����PID�ṹ��
{
	int SetValue;   			//�趨ֵ
	float Kp; 			//����ϵ��
	float Ki; 			//����ϵ��
	float Kd; 			//΢��ϵ��
	int LastError;
	int PrevError;
};

void PIDInit(PID_Uint *sptr);
int PID_Calc(int MeasureValue,PID_Uint *sptr);

#endif