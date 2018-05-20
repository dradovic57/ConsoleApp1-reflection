//https://www.codeproject.com/Articles/17269/Reflection-in-C-Tutorial
//
using System;
using System.Reflection;

namespace Reflection
{
    /// <summary>
    /// Summary description for Class1.
    /// 
    /// 
    abstract class BaseClass
    {
        abstract public int AddNumb(int numb1);
    }
    class Class1 : BaseClass                                //INHERITING
    {
        public override int AddNumb(int numb1)              //IMPLEMENTING
        {
            int ans = numb1 + numb1;
            return ans;
        }
        public int AddNumb(int numb1, int numb2)            //OVERLOADING
        {
            int ans = numb1 + numb2;
            return ans;
        }
        //class Program
        //{
        [STAThread]                                         //BECAUSE OF "COM" COMPONENTS POTENTIALLY USED ON SINGLE-THREADED FORMS
        static void Main(string[] args)
        {
            //
            // TODO: Add code to start application here
            //
            Type type1 = Type.GetType("Reflection.Class1"); //1st WAY OF GETTING TYPE, has to be full namespecified:  namespace.class
            //Type type1 = typeof(Class1);                  //2nd WAY OF GETTING TYPE
            //Create an instance of the type
            object obj = Activator.CreateInstance(type1);
            object[] mParam = new object[] { 5, 10 };
            //invoke AddMethod, passing in two parameters
            int res = (int)type1.InvokeMember("AddNumb", BindingFlags.InvokeMethod, null, obj, mParam);
            Console.Write("Result: {0} \n", res);
            object[] mParam2 = new object[] { 5 };
            int res2 = (int)type1.InvokeMember("AddNumb", BindingFlags.InvokeMethod, null, obj, mParam2);
            Console.Write("Result: {0} \n", res2);

            MyHelp(type1);

            MethodInfo[] methods = type1.GetMethods();
            //MethodInfo[] methods = type1.GetMethods(("AddNumb");  //NEED TO RESOLVE FOR OVERLOADED METHODS
            //MethodInfo method = type1.GetMethod("AddNumb");       //THIS WON'T WORK AS THERE ARE OVERLOADED METHODS
            //method.Invoke(type1, mParam);
            //method.Invoke(type1, mParam2);
        }
        public static void MyHelp(Type myTypeObj)
        {
            MethodInfo[] myMethodInfos = myTypeObj.GetMethods();
            Console.WriteLine();
            foreach (MethodInfo m in myMethodInfos)
            {
                Console.WriteLine(m.Name);
            }
        }
        //}
    }

}
