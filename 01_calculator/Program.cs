/*
 1. 
Використати стандартний делегат  Func<> для класу Калькулятор.
   У класі Calculator визначити 

	- обєкт func  стандартного делегату Func<>, якому буде призначатися метод(чи лямбда) додавання, віднімання, 
	і т.і. в залежності від параметра методу SetOperation( string operation)( можна operation оголосити як char або enum )
	
	- метод double Calculate(double, double) повинен повертати результат обчислення, викликаючи функцію(чи лямбда) по 	делегату func  
 */

using System;

namespace _01_calculator
{
    class Program
    {
        class Calculator
        {
            Func<double, double, double> calc;

            double Add(double a, double b)
            {
                return a + b;
            }

            double Sub(double a, double b)
            {
                return a - b;
            }

            double Mult(double a, double b)
            {
                return a * b;
            }

            double Div(double a, double b)
            {
                return a / b;
            }

            public void SetOperation(char operation)
            {
                try
                {
                    switch (operation)
                    {
                        case '+':
                            calc = Add;
                            break;
                        case '-':
                            calc = Sub;
                            break;
                        case '*':
                            calc = Mult;
                            break;
                        case '/':
                            calc = Div;
                            break;
                        default: //перехопить як помилку і при невірно вказаних операціях додаватиме
                            throw new Exception();
                            
                    }
                }

                catch (Exception)
                {
                    Console.WriteLine("\nError! Incorrect operation '{0}', we use '+' by default", operation);
                    calc = Add;
                }
            }

            public double Calculate(double a, double b)
            {
                return calc(a, b);
            }
        }
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            double a = 2, b = 3;
            c.SetOperation('+');
            Console.WriteLine("{0} + {1} = {2}", a, b, c.Calculate(a, b));
            c.SetOperation('-');
            Console.WriteLine("{0} - {1} = {2}", a, b, c.Calculate(a, b));
            c.SetOperation('*');
            Console.WriteLine("{0} x {1} = {2}", a, b, c.Calculate(a, b));
            c.SetOperation('/');
            Console.WriteLine("{0} / {1} = {2}", a, b, c.Calculate(a, b));
             
            Console.ReadKey();
        }
    }
}
