#include "pid.h"

void PIDInit(PID_Uint *sptr)
{
	sptr->LastError = 0; //Error[-1]
	sptr->PrevError = 0; //Error[-2]
	sptr->Kp = 2.30f; //比例系数
	sptr->Ki = 1.20f;   //积分系数
	sptr->Kd = 0.10f; //微分系数
	sptr->SetValue = 0;//目标值
}
/*****************************************************************************************
*函数名：int PID_Calc（int MeasureValue）
*函数功能：PID算法 调节PWM增量
*函数参数：MeasureValue  测得的速度值 PID_Adjust 返回值 PWM误差修正值
*****************************************************************************************/
int PID_Calc(int MeasureValue,PID_Uint *sptr)
{
	register int iError, PID_Adjust; 
	iError = sptr->SetValue - MeasureValue; 		//计算增加量
	PID_Adjust = (int)(
		sptr->Kp * iError 			//E[k]项
	- sptr->Ki * sptr->LastError 				//E[k－1]项
	+ sptr->Kd * sptr->PrevError); 			//E[k－2]项
	
	//存储当前误差以便后面计算
	sptr->PrevError = sptr->LastError;
	sptr->LastError = iError;
	//返回增量值
	return (PID_Adjust);
	//此值建议再乘一个数值进行缩小然后再应用到PWM上，因为PWM的范围是有限的，不然很容易超界
}