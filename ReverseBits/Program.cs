using System;

namespace ReverseBits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            uint res = Reverse(234);
        }

        static uint Reverse(uint input)
        {
            uint mask = 1;
            uint mask2 = mask << 31;
            uint result = 0;
            for (int i = 0; i < 32; i++)
            {
                uint lessBit = input & mask;
                if(lessBit != 0)
                {
                    result |= mask2;
                }
                mask <<= 1;
                mask2 >>= 1;
            }

            return result;
        }
    }
}
