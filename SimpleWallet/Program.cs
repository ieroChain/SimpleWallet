﻿using System;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWallet
{
    static class Program
    {
        static void SetDefaultCulture(CultureInfo culture)
        {
            Type type = typeof(CultureInfo);

            try
            {
                type.InvokeMember("s_userDefaultCulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });

                type.InvokeMember("s_userDefaultUICulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });
            }
            catch { }

            try
            {
                type.InvokeMember("m_userDefaultCulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });

                type.InvokeMember("m_userDefaultUICulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });
            }
            catch { }
        }


        private const string AppMutexName = "37A1DGRT-G58J-6t45-915E-DB85D5929426-ZERO";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetDefaultCulture( new CultureInfo("en-US"));
            bool mutexCreated = false;
            System.Threading.Mutex appMutex = new System.Threading.Mutex(false, AppMutexName, out mutexCreated);
            //You could abort here if the mutex existed already, or you could abort
            //when failing to acquire the mutex. I prefer the latter.
            if (!appMutex.WaitOne(0))
            {
                //MessageBox.Show("Only one application at a time, please!");
                return;
            }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SplashScreen());
                GC.KeepAlive(appMutex);
            }
            finally
            {
                appMutex.ReleaseMutex();
            }
        }
    }
}
