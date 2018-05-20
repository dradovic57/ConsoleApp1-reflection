//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System;
using System.Reflection;

namespace ConsoleApp1
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        MyClass myclass = new MyClass();
    //        int res = myclass.AddNumb(2, 3);
    //        Console.WriteLine(res);
    //        Console.WriteLine("hello dragan");
    //    }
    //}
    public class MyClass
    {
        public virtual int AddNumb(int numb1, int numb2)
        {
            int result = numb1 + numb2;
            return result;
        }

    }
    public class MyClass2
    {
        int answer;
        public MyClass2()
        {
            answer = 0;
        }

        public int AddNumb(int numb1, int numb2)
        {
            answer = numb1 + numb2;
            return answer;
        }
    }
    class MyMainClass
    {
        //public static int Main()
        //{
        //    Console.WriteLine("\nReflection.MethodInfo");
        //    // Create MyClass object
        //    MyClass myClassObj = new MyClass();
        //    // Get the Type information.
        //    Type myTypeObj = myClassObj.GetType();

        //    //displaying all of the methods
        //    MyHelp(myTypeObj);

        //    // Get Method Information.
        //    MethodInfo myMethodInfo = myTypeObj.GetMethod("AddNumb");
        //    object[] mParam = new object[] { 5, 10 };
        //    // Get and display the Invoke method.
        //    Console.Write("\nFirst method - " + myTypeObj.FullName + " returns " +
        //                         myMethodInfo.Invoke(myClassObj, mParam) + "\n");
        //    return 0;
        //}
        public static void MyHelp(Type myTypeObj)
        {
            MethodInfo[] myMethodInfos = myTypeObj.GetMethods();
            Console.WriteLine();
            foreach (MethodInfo m in myMethodInfos)
            {
                Console.WriteLine(m.Name);
            }
        }
        [STAThread]
        static void Main(string[] args)
        {
            Type type1 = typeof(MyClass2);
            //Create an instance of the type
            object obj = Activator.CreateInstance(type1);
            //displaying all of the methods
            MyHelp(type1);
            Console.Write("\n");
            object[] mParam = new object[] { 5, 10 };
            //invoke AddMethod, passing in two parameters
            int res = (int)type1.InvokeMember("AddNumb", BindingFlags.InvokeMethod,
                                               null, obj, mParam);
            Console.Write("Result: {0} \n", res);
        }
        public class Addition
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
            public int Add(float a, int b)
            {
                return (int)(a + b);
            }
        }
    }

    //Reflection.MethodInfo
    //First method - ConsoleApp1.MyClass returns 15
}
