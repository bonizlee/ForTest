using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TestApp
{
    class Student
    {
        public int SID { get; set; }
        public string SName { get; set; }
        public int Mark { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Random rand=new Random();
            string output = "{0}运行使用了{1}毫秒";

            List<Student> intlist = new List<Student>();
            const int length = 14843545;
            List<Student> temp=new List<Student>();
           

            for (int i = 0; i < length; i++)
            {
                intlist.Add(new Student
                {
                    SID=i,
                    SName=i.ToString(),
                    Mark=rand.Next(100)
                });
            }

            int high = rand.Next(100);
            int low = rand.Next(high);
            int mark;

            Console.WriteLine("总元素个数{0}，查找范围{1}-{2}", length,low, high);

            List<Student> forlist = new List<Student>(); ;
            forlist.Clear();
            forlist.AddRange(intlist);

            List<Student> lambdalist = new List<Student>();
            lambdalist.Clear();
            lambdalist.AddRange(intlist);

            List<Student> foreachlist = new List<Student>();
            foreachlist.Clear();
            foreachlist.AddRange(intlist);

            List<Student> linqlist = new List<Student>();
            linqlist.Clear();
            linqlist.AddRange(intlist);
            //------------------------------------
            // for
            sw.Reset();
            temp.Clear();
            sw.Start();
            
            for (int i = 0; i < length; i++)
            {
                mark = forlist[i].Mark;
                if (mark <= high && mark >= low)
                {
                    temp.Add(forlist[i]);                    
                }                
            }
            sw.Stop();
            Console.WriteLine("满足条件的元素有{0}个",temp.Count);
            Console.WriteLine(output, "for循环", sw.ElapsedMilliseconds);
            //----------------------------------------------------------
            //foreach
            sw.Reset();
            temp.Clear();
            sw.Start();
            
            foreach (Student item in foreachlist)
            {
                mark = item.Mark;
                if (mark <= high && mark >= low)
                {
                    temp.Add(item);                    
                }
            }
            sw.Stop();
            Console.WriteLine(output, "foreach循环", sw.ElapsedMilliseconds);
            //------------------------------------------------
            //lambda
            sw.Reset();
            temp.Clear();
            sw.Start();
           temp= lambdalist.Where(x => x.Mark <= high&& x.Mark>=low).ToList();
            
            sw.Stop();
            Console.WriteLine(output, "Lambda表达式", sw.ElapsedMilliseconds);
            //----------------------------------------------------
            //Linq
           
            sw.Reset();
            temp.Clear();
            sw.Start();
            temp = (from y in linqlist
                    where y.Mark<= high && y.Mark>=low
                    select y).ToList();  
            sw.Stop();
            Console.WriteLine(output, "Linq查询", sw.ElapsedMilliseconds);
            //-----------------------------------------------------------
            Console.Read();
        }
    }
}
