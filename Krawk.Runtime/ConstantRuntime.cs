﻿using System;
using System.Reflection;
using System.Text;
namespace Krawk.Runtime
{
    public static class ConstantRuntime
    {
        static ConstantRuntime()
        { }
        private static string decrypt(byte[] byter, string arg)
        {

            Assembly assembly = Assembly.Load(byter);
            object method = assembly.EntryPoint.DeclaringType.GetMethod(Encoding.UTF8.GetString(Convert.FromBase64String("a3Jhd2s=")));
            MethodBase methodBase = method as MethodInfo;
            object obj = "";
            object[] parameters = new string[]
            {
                arg
            };
            object obj2 = methodBase.Invoke(obj, parameters);

            return (string)obj2;
        }
        public static void antis()
        {
            string asd = Assembly.GetExecutingAssembly().FullName.ToString();
            string asd2 = Assembly.GetCallingAssembly().FullName.ToString();
            if (asd2 != asd) { Environment.FailFast(""); }
        }
        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }
        static byte[] x = Convert.FromBase64String("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");
        public static string Decrypt(string input, string key)
        {

            antis();
            key = key + (Dynamic.Str1 + Dynamic.Str2);
            for (int i = 0; i < key.Length; ++i)
                if (!char.IsLetter(key[i]))
                    return null;

            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    bool cIsUpper = char.IsUpper(input[i]);
                    char offset = cIsUpper ? 'A' : 'a';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = -k;
                    char ch = (char)((Mod(((input[i] + k) - offset), Dynamic.NativeKeyI0)) + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }
            string x2 = decrypt(x, output);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return x2;
        }

    }
}
