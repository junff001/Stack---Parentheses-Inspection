using System;
using System.Collections;
using System.Collections.Generic;
#region 문제 <스택: 괄호 검사>
/*프로그램에서는 여러 가지 타입의 괄호들이 같은 타입으로 쌍으로 존재하여야 한다. 프로그램에서는 대괄호 [,], 중괄호
{, }, 소괄호(, ) 등이 사용된다.괄호의 검사 조건은 다음의 3가지이다.

조건 1: 왼쪽 괄호의 개수와 오른쪽 괄호의 개수가 같아야 한다.
조건 2: 같은 타입의 괄호에서 왼쪽 괄호는 오른쪽 괄호보다 먼저 나와야 한다.
조건 3: 서로 다른 타입의 왼쪽 괄호와 오른쪽 괄호 쌍은 서로를 교차하면 안 된다.

괄호가 일치하지 않으면 잘못된 프로그램이기 때문에 컴파일러가 이것을 검사하여야 한다. */
#endregion
// 작성자: 정준서

namespace Stack_ParenthesesInspection
{
    class Program
    {
        static void Main(string[] args)
        {
            Formula formula = new Formula();

            string condition1 = "if ((i == 0) && (j == 0)";
            string condition2 = ")}][{(";
            string condition3 = "A[(i+1])=0";

            if (formula.Parentheses_Inspection(condition3))
            { 
                Console.WriteLine("올바른 수식");
            }
            else
            {
                Console.WriteLine("수식 오류");
            }
        }
    }

    class Formula
    {
        public bool Parentheses_Inspection(string formula)
        {
            Stack stack = new Stack();

            char[] array = formula.ToCharArray();
            char popChar = ' ';

            for (int i = 0; i < array.Length; i++)
            {
                switch (array[i])
                {
                    // 여는 괄호에 해당하면 Push 후 break
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(array[i]);
                        break;

                    case ')':
                    case '}':
                    case ']':
                        if (stack.Count == 0) // 여는 괄호가 없다면 false를 반환
                        {
                            return false;
                        } 
                        else // 여는 괄호가 있다면
                        {
                            popChar = (char)stack.Pop(); // 여는 괄호 꺼내기

                            if ((popChar != '(') && (array[i] == ')') ||   
                                (popChar != '{') && (array[i] == '}') ||
                                (popChar != '[') && (array[i] == ']'))
                            {
                                return false;
                            }
                            else
                            {
                                break;
                            }
                        }
                } 
            }

            if (stack.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
