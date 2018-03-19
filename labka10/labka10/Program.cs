using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace labka10
{
    public delegate void MyDelegate(int a,int b);
    class Program
    {
        static void Main(string[] args)
        {
            dlg deleg = new dlg();
            deleg.process();
            
        }

       
    }
    public class dlg
    {
        public void process()
        {
            int a, b;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            Find fd = new Find(a, b);
            MyDelegate md = fd.DoIt;
            Thread.Sleep(3000);
            md.Invoke(a, b);
        }
    }

    class Find
    {
        int a,b;
        public Find(int a,int b)
        {
            this.a = a;
            this.b = b;
        }
        public void DoIt(int a,int b)
        {
            Console.WriteLine(a + b);
        }
    }

}
