using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Routing;
using System.IO;
using System.Web.Security;
using MercuryHealth.Models;
using System.Web.Optimization;
using System.Data.Entity;
using System.Diagnostics;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.DataContracts;

namespace MecuryHealth
{ 
    public class Helper
    {
        public static string Truncate(string input, int length)
        {

            try
            {
                if (input != null)
                {

                    if (input.Length <= length)
                    {
                        return input;
                    }
                    else
                    {
                        return input.Substring(0, length) + "...";
                    }
                
                }
                else
                {
                    return input;
                }

            }
            catch (Exception)
            {
                
                return input;
            }

        }

        public static string GetAssemblyVersionAndDate()
        {
            string mybuild = " *** ";
            string myversion = " *** ";
            DateTime lastWriteTime = DateTime.Now;

            try
            {

                // Establish a link to the assembly (*.dll)
                string assemblyLocation = System.Web.HttpContext.Current.Server.MapPath(@"\bin\");
                string assemblyFileName = "MercuryHealth.Web.dll";

                // Extract the version and build number from *.dll
                Assembly ai = System.Reflection.Assembly.LoadFrom(assemblyLocation + assemblyFileName);

                mybuild = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                myversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();

                // Extract the last write time of assembly
                lastWriteTime = File.GetLastWriteTime(@assemblyLocation + assemblyFileName);

            }
            catch
            {
            }

            return "Version " + myversion + " | Build " + mybuild + " | Updated on " + lastWriteTime.ToLongDateString() + " at " + lastWriteTime.ToShortTimeString();

        }

        public static string GetAssemblyVersionOnly()
        {
            string mybuild = " *** ";

            try
            {

                // Establish a link to the assembly (*.dll)
                string assemblyLocation = System.Web.HttpContext.Current.Server.MapPath(@"\bin\");
                string assemblyFileName = "MercuryHealth.Web.dll";

                // Extract the version and build number from *.dll
                Assembly ai = System.Reflection.Assembly.LoadFrom(assemblyLocation + assemblyFileName);

                mybuild = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            }
            catch
            {
            }

            return mybuild;

        }

        // Telemetry initializer class for Correlating with build versions
        public class MyTelemetryInitializer : IContextInitializer
        {
            public void Initialize(TelemetryContext context)
            {
                // Set the Application Version from the *.dll assembly
                context.Properties["AppVersion"] = Helper.GetAssemblyVersionOnly();
            }
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
        public class AiHandleErrorAttribute : HandleErrorAttribute
        {
            public override void OnException(ExceptionContext filterContext)
            {
                if (filterContext != null && filterContext.HttpContext != null && filterContext.Exception != null)
                {
                    //If customError is Off, then AI HTTPModule will report the exception
                    if (filterContext.HttpContext.IsCustomErrorEnabled)
                    {   //or reuse instance (recommended!). see note above  
                        var ai = new TelemetryClient();
                        ai.TrackException(filterContext.Exception);
                    }
                }
                base.OnException(filterContext);
            }
        }

        public static string CalcTimeAgo(DateTime tmpDate)
        {
            // Get the current DateTime.
            DateTime now = DateTime.Now;
            string myTimeAgoMsg = "less than a day";
            int YearsAgo = 0;

            TimeSpan ts = now.Subtract(tmpDate);

            // Check if date is greater than 1 day
            if (DateTime.Compare(now, tmpDate) >= 0)
            {

                YearsAgo = ts.Days / 366;
                DateTime workingDate = tmpDate.AddYears(YearsAgo);
                while (workingDate.AddYears(1) <= now)
                {
                    workingDate = workingDate.AddYears(1);
                    YearsAgo++;
                }

                if (YearsAgo > 0)
                {
                    if (YearsAgo > 1)
                    {
                        myTimeAgoMsg = "over " + YearsAgo.ToString("0") + " years, " + string.Format("{0} days", ts.Days - (366 * YearsAgo));
                    }
                    else
                    {
                        myTimeAgoMsg = "over " + YearsAgo.ToString("0") + " year, " + string.Format("{0} days", ts.Days - 366);

                    }
                }
                else
                {
                    if (ts.Days > 1)
                    {
                        //myTimeAgoMsg = "over " + string.Format("{0} days, {1} hours, {2} minutes", ts.Days, ts.Hours, ts.Minutes);
                        myTimeAgoMsg = "over " + string.Format("{0} days", ts.Days);
                    }
                    else
                    {
                        //myTimeAgoMsg = string.Format("{1} hours, {2} minutes", ts.Hours, ts.Minutes);
                        myTimeAgoMsg = "less than a day";
                    }
                }
            }

            return myTimeAgoMsg;
        }

        public static string GetFileContentLength(string myFileURL)
        {
            string myContentSize = "";

            try
            {

                System.Net.WebRequest req = System.Net.HttpWebRequest.Create(myFileURL);
                req.Method = "HEAD";
                using (System.Net.WebResponse resp = req.GetResponse())
                {
                    double ContentLength;
                    if (double.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                        {
                            double tmp = ContentLength;
                            string suffix = " B ";
                            if (tmp > 1024) { tmp = tmp / 1024; suffix = " KB"; }
                            if (tmp > 1024) { tmp = tmp / 1024; suffix = " MB"; }
                            if (tmp > 1024) { tmp = tmp / 1024; suffix = " GB"; }
                            if (tmp > 1024) { tmp = tmp / 1024; suffix = " TB"; }

                            myContentSize = string.Format("{0:0.0#}", Math.Round(tmp, 1)) + suffix;

                        }
                }
            }
            catch (Exception)
            {
                myContentSize = "";
            }

            return myContentSize;

        }

        public static object CheckIfDateIsNull(DateTime? nullable, string checkType)
        {

            if (nullable.HasValue)
            {
                //return nullable;

                DateTime dt = (DateTime)Convert.ChangeType(nullable, typeof(DateTime));

                if (checkType == "Date")
                {
                    return dt.ToString("ddd, MMM dd, yyyy");
                }
                else
                {
                    return dt.ToString("hh:mm tt");
                }
            }
            else
            {
                return string.Empty;
            }


        }
    }

    

}
