﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using GameObjects;

public class ExtensionInterface
{
    private static Dictionary<String, String> extensionFiles = null;
    private static List<Type> compiledTypes = null;

    private static void loadAllExtensionFiles()
    {
        if (extensionFiles == null)
        {
            string[] filePaths;
            extensionFiles = new Dictionary<String, String>();
            try
            {
                filePaths = Directory.GetFiles("Resources/Extensions/", "*.cs");
            }
            catch (DirectoryNotFoundException)
            {
                return;
            } 
            foreach (String fileName in filePaths)
            {
                TextReader tr = new StreamReader(fileName);
                String result = "";
                while (tr.Peek() >= 0)
                {
                    result += tr.ReadLine() + "\n";
                }
                extensionFiles.Add(fileName, result);
                tr.Close();
            }
        }
    }

    private static void loadCompiledTypes()
    {
        if (compiledTypes == null)
        {
            compiledTypes = new List<Type>();
            loadAllExtensionFiles();
            TextWriter tw = new StreamWriter("Resources/Extensions/Errors.txt");
            foreach (KeyValuePair<String, String> file in extensionFiles)
            {
                var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
                var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll", "GameObjects.dll", "GameGlobal.dll" });
                parameters.GenerateExecutable = false;
                CompilerResults results = csc.CompileAssemblyFromSource(parameters, file.Value);
                if (results.Errors.Count <= 0)
                {
                    Type t = results.CompiledAssembly.GetModules()[0].GetTypes()[0];
                    compiledTypes.Add(t);
                }
                else
                {
                    tw.WriteLine(">>> Cannot compile file " + file.Key);
                    foreach (CompilerError error in results.Errors)
                    {
                        tw.WriteLine(error.ErrorText);
                    }
                }
            }
            tw.Close();
        }
    }

    public static void call(String methodName, Object[] param)
    {
        loadCompiledTypes();
        foreach (Type t in compiledTypes)
        {
            try
            {
                MethodInfo m = t.GetMethod(methodName);
                m.Invoke(Activator.CreateInstance(t), param);
            }
            catch
            {
                //ignore
            }
        }
    }

}