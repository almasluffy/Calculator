using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc

{
    public delegate void MyDelegate(string msg);
    public enum CurrentState
    {
        Zero,
        AccumulateDigits,
        AccumulateDigitsWithSeparator,
        Compute,
        ComputePending,

    }

    public class Brain
    {
        
        public MyDelegate invoker;

        public string firstnumber = "0";
        public string result = "0";
        public string op = "";
        public string savednumber= "0";

        public string[] operations = { "+", "-", "÷", "x", };
        public string[] digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public string[] nozerodigits = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public string[] savingop = { "MC", "MR", "M+", "M-", "MS" };
        public string[] specialoperations = { "%", "√", "x²", "1/x","±", };
        public string[] zero = { "0" };
        public string[] separators = { "," };
        public string[] clear = { "C", "CE", "⌫" };
        public string[] equals = { "=" };
        public int k = 0;
        public bool flag = false;

        CurrentState curentstate = CurrentState.Zero;
       

        public void Process(string item)
        {
            switch (curentstate)
            {
                case CurrentState.Zero:
                    Zero(item, false);
                    break;
                case CurrentState.AccumulateDigits:
                    AccumulateDigits(item, false);
                    break;
                case CurrentState.AccumulateDigitsWithSeparator:
                    AccumulateDigitsWithSeparator(item, false);
                    break;
                case CurrentState.ComputePending:
                    ComputePending(item, false);
                    break;
                case CurrentState.Compute:
                    Compute(item, false);
                    break;
            }
        }

        public void Zero(string item, bool isInput)
        {
            if (isInput)
            {
                result = "";
                curentstate = CurrentState.Zero;
                invoker.Invoke(result);
            }
            else
            {
                if (operations.Contains(item))
                {
                    AccumulateDigits(item, true);
                }
                else if (nozerodigits.Contains(item))
                {
                    AccumulateDigits(item, true);
                }
            }
        }
        public void AccumulateDigits(string item, bool isInput)
        {
            if (isInput)
            {
                k++;





                if (result == "0" && k > 0 || result == "Ошибка")
                {
                    result = "";
                    result += item;
                }
                else
                {
                    result += item;
                }


                curentstate = CurrentState.AccumulateDigits;
                invoker.Invoke(result);
            }


            else
            {
                if (digits.Contains(item))
                {
                    AccumulateDigits(item, true);
                }
                else if (separators.Contains(item))
                {
                    AccumulateDigitsWithSeparator(item, true);
                }
                else if (operations.Contains(item))
                {
                    ComputePending(item, true);
                    k = 0;
                }
                else if (equals.Contains(item))
                {
                    Compute(item, true);
                    k = 0;
                }
                else if (clear.Contains(item))
                {
                    if (item == "C")
                    {
                        result = "0";
                        firstnumber = "0";
                        invoker.Invoke(result);
                        k = 0;


                    }
                    else if (item == "CE")
                    {

                        result = "0";
                        invoker.Invoke("0");
                        k = 0;

                    }
                    else if (item == "⌫")
                    {
                        if(result == "Ошибка")
                        {
                            result = "0";
                        }
                        else
                        {
                            result = result.Remove(result.Length - 1, 1);
                            if (result.Length == 0)
                            {
                                result = "0";
                            }
                        }
                               

                        invoker.Invoke(result);

                    }

                }


                else if (specialoperations.Contains(item))
                {
                    if (item == "%")
                    {
                        double b = double.Parse(result) / 100;

                        result = b.ToString();
                        invoker.Invoke(result);

                    }
                    else if (item == "1/x")
                    {
                        double b = 1 / double.Parse(result);

                        result = b.ToString();
                        invoker.Invoke(result);
                    }
                    else if (item == "x²")
                    {
                        double b = Math.Pow(double.Parse(result), 2);

                        result = b.ToString();
                        invoker.Invoke(result);
                    }
                    else if (item == "√")
                    {
                        double b = Math.Sqrt(double.Parse(result));

                        result = b.ToString();
                        invoker.Invoke(result);
                    }
                    else if (item == "±")
                    {
                        double b = (-1) * double.Parse(result);

                        result = b.ToString();
                        invoker.Invoke(result);
                    }
                }
                else if (savingop.Contains(item))
                {
                    if (item == "MC")
                    {
                        savednumber = "0";
                        flag = false;
                    }
                    if (item == "M+")
                    {
                        if (flag == true)
                        {
                            savednumber = (double.Parse(savednumber) + double.Parse(result)).ToString();
                            
                        }
                    }
                    if (item == "M-")
                    {
                        if (flag == true)
                        {
                            savednumber = (double.Parse(savednumber) - double.Parse(result)).ToString();
                        }
                    }
                    if (item == "MR")
                    {
                        if (flag == true)
                        {
                            invoker.Invoke(savednumber);
                        }
                    }
                    if (item == "MS")
                    {
                        savednumber = result;
                        flag = true;
                    }

                }
                else if (operations.Contains(item))
                {
                    if(item == "+")
                    {
                        ComputePending(item, true);
                    }
                }
            
            }
            }

            public void AccumulateDigitsWithSeparator(string item, bool isInput)
        {
            if (isInput)
            {
              
                if (item == "," && !result.Contains(",") ) result += ",";
                
                curentstate = CurrentState.AccumulateDigits;
                invoker.Invoke(result);
            }
            else
            {
                if (digits.Contains(item))
                {
                    AccumulateDigitsWithSeparator(item, true);
                }
                else if (operations.Contains(item))
                {
                    ComputePending(item, true);
                }
            }
        }
       
        public void ComputePending(string item, bool isInput)
        {
            if (isInput)
            {
                op = item;
                firstnumber = result;
                result = "0";
                curentstate = CurrentState.ComputePending;
                invoker.Invoke(result);
            }
            else
            {
                if (digits.Contains(item))
                {
                    AccumulateDigits(item, true);
                }
                else if (separators.Contains(item))
                {
                    AccumulateDigitsWithSeparator(item, true);
                }
              
            }
        }
        public void Compute(string item, bool isInput)
        {
            if (isInput)
            {
                double a1 = double.Parse(firstnumber);
                double a2 = double.Parse(result);
                double r = 0;

                if (op == "+")
                {
                    r = a1 + a2;
                }
                else if (op == "-")
                {
                    r = a1 - a2;
                }
                else if (op == "÷")
                {
                    r = a1 / a2;
                }
                else if (op == "x")
                {
                    r = a1 * a2;
                }
                
                result = r.ToString();
                if(result == "∞")
                {
                    result = "Ошибка";
                }
                curentstate = CurrentState.Compute;
                invoker.Invoke(result);
            }
            else
            {
                
                if (digits.Contains(item))
                {
                    
                    AccumulateDigits(item, true);
                }
                else if (operations.Contains(item))
                {
                    ComputePending(item,true);
                }
                else if (separators.Contains(item))
                {
                    AccumulateDigitsWithSeparator(item, true);
                }
                else if (specialoperations.Contains(item) || clear.Contains(item) || savingop.Contains(item))
                {
                    AccumulateDigits(item, false);
                }
                
            }
        }

        }

    }
