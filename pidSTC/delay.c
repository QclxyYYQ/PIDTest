#include <delay.h>
#include <intrins.h>
void Delay50us()		//@11.0592MHz
{
	unsigned char i, j;

	_nop_();
	_nop_();
	_nop_();
	i = 1;
	j = 133;
	do
	{
		while (--j);
	} while (--i);
}

