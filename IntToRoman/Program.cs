using System;
using System.Text;
using System.Collections.Generic;
/*Integer to Roman

Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given an integer, convert it to a roman numeral. Input is guaranteed to be within the range from 1 to 3999.

Example 1:

Input: 3
Output: "III"
Example 2:

Input: 4
Output: "IV"
Example 3:

Input: 9
Output: "IX"
Example 4:

Input: 58
Output: "LVIII"
Explanation: L = 50, V = 5, III = 3.
Example 5:

Input: 1994
Output: "MCMXCIV"
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

* */
namespace IntToRoman
{
    public class Program
    {

        public static string IntToRoman(int num)
        {
            StringBuilder sb = new StringBuilder();
            int rem = 0, result = num;
            int capacity = 1;

            while (result > 0)
            {
                rem = result % 10;
                result = (result - rem) / 10;

                if (rem < 4)
                {
                    int ii = rem;
                    string ss = "";
                    while (ii >= 1) //1+1+1
                    {
                        char cc = IsValue(1 * capacity);
                        ss = ss + Convert.ToString(cc);
                        ii--;
                    }
                    sb.Insert(0, ss);
                }
                else if (rem == 4)
                {
                    char cc = IsValue(5 * capacity);
                    char cc_b = FindPair(4 * capacity);
                    sb.Insert(0, (Convert.ToString(cc_b) + Convert.ToString(cc)));

                }
                else if (rem < 9 ) //5+1+1+1
                {
                    char cc = IsValue(5 * capacity);
                    string ss = Convert.ToString(cc);

                    int ii = rem - 5;
                    while (ii >= 1)
                    {
                        cc = IsValue(1 * capacity);
                        ss = ss + Convert.ToString(cc);
                        ii--;
                    }
                    sb.Insert(0, ss);
                }
                else if (rem == 9 )
                {
                    char cc = IsValue(10 * capacity);
                    char cc_b = FindPair(9 * capacity);
                    sb.Insert(0, (Convert.ToString(cc_b) + Convert.ToString(cc)));
                }
               
                capacity = capacity * 10;
            }
            return sb.ToString();
        }

        public static char IsValue(int i)
        {
            char val = (char)0;
            switch (i)
            {
                case 1:
                    val = 'I';
                    break;
                case 5:
                    val = 'V';
                    break;
                case 10:
                    val = 'X';
                    break;
                case 50:
                    val = 'L';
                    break;
                case 100:
                    val = 'C';
                    break;
                case 500:
                    val = 'D';
                    break;
                case 1000:
                    val = 'M';
                    break;
                default:
                    break;
            }
            return val;
        }

        public static char FindPair(int i)
        {
            char pair = (char)0;
            switch (i)
            {
                case 4:
                    pair = 'I';
                    break;
                case 9:
                    pair = 'I';
                    break;
                case 40:
                    pair = 'X';
                    break;
                case 90:
                    pair = 'X';
                    break;
                case 400:
                    pair = 'C';
                    break;
                case 900:
                    pair = 'C';
                    break;
                default:
                    break;
            }
            return pair;
        }


        public static void Main(string[] args)
        {
            int number = 1994;
            string ss = IntToRoman(number);

            Console.WriteLine(ss);
        }
    }
}
