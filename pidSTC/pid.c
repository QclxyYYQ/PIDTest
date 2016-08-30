#include "pid.h"

void PIDInit(PID_Uint *sptr)
{
	sptr->LastError = 0; //Error[-1]
	sptr->PrevError = 0; //Error[-2]
	sptr->Kp = 2.30f; //����ϵ��
	sptr->Ki = 1.20f;   //����ϵ��
	sptr->Kd = 0.10f; //΢��ϵ��
	sptr->SetValue = 0;//Ŀ��ֵ
}
/*****************************************************************************************
*��������int PID_Calc��int MeasureValue��
*�������ܣ�PID�㷨 ����PWM����
*����������MeasureValue  ��õ��ٶ�ֵ PID_Adjust ����ֵ PWM�������ֵ
*****************************************************************************************/
int PID_Calc(int MeasureValue,PID_Uint *sptr)
{
	register int iError, PID_Adjust; 
	iError = sptr->SetValue - MeasureValue; 		//����������
	PID_Adjust = (int)(
		sptr->Kp * iError 			//E[k]��
	- sptr->Ki * sptr->LastError 				//E[k��1]��
	+ sptr->Kd * sptr->PrevError); 			//E[k��2]��
	
	//�洢��ǰ����Ա�������
	sptr->PrevError = sptr->LastError;
	sptr->LastError = iError;
	//��������ֵ
	return (PID_Adjust);
	//��ֵ�����ٳ�һ����ֵ������СȻ����Ӧ�õ�PWM�ϣ���ΪPWM�ķ�Χ�����޵ģ���Ȼ�����׳���
}