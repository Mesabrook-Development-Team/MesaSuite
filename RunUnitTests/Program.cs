using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RunUnitTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = args.Length > 0 ? args[0] : Environment.CurrentDirectory;

            Console.WriteLine("Loading all assemblies found in " + directory + "...");
            ConsoleColor originalForeground = Console.ForegroundColor;
            foreach (string file in Directory.EnumerateFiles(directory, "*.dll"))
            {
                try
                {
                    Assembly.LoadFrom(file);
                }
                catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("An error occurred loading " + file);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Console.ForegroundColor = originalForeground;
                }
            }

            Console.WriteLine("Discovering tests...");
            Dictionary<Type, List<MethodInfo>> testMethodsByType = new Dictionary<Type, List<MethodInfo>>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.GetCustomAttribute<TestClassAttribute>() != null)
                        {
                            testMethodsByType.Add(type, new List<MethodInfo>());

                            foreach (MethodInfo method in type.GetMethods().Where(mi => mi.GetCustomAttribute<TestMethodAttribute>() != null))
                            {
                                testMethodsByType[type].Add(method);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("An error occurred iterating through types of the assembly " + assembly.FullName);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Console.ForegroundColor = originalForeground;
                }
            }


            StringBuilder failedTests = new StringBuilder();
            foreach(KeyValuePair<Type, List<MethodInfo>> testMethodsByClass in testMethodsByType)
            {
                Console.WriteLine();
                Console.WriteLine("=== Running " + testMethodsByClass.Key.Name + " ===");
                object instance = Activator.CreateInstance(testMethodsByClass.Key);

                foreach(MethodInfo methodInfo in testMethodsByClass.Value)
                {
                    Console.WriteLine("Running " + methodInfo.Name);
                    try
                    {
                        methodInfo.Invoke(instance, new object[0]);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Success!");
                        Console.ForegroundColor = originalForeground;
                    }
                    catch(Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Failed!");

                        Console.ForegroundColor = originalForeground;
                        failedTests.AppendLine(methodInfo.Name + ": " + ex.InnerException.Message);
                    }
                }
            }

            if (failedTests.Length > 0)
            {
                Environment.ExitCode = 1;

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("=== SOME TESTS FAILED ===");
                Console.WriteLine(failedTests.ToString());

                Console.ForegroundColor = originalForeground;
            }
        }
    }
}
