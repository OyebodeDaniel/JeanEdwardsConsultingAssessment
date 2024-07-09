/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
    

namespace TechnicalAssessment
{
    public class ExtentManager
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                htmlReporter = new ExtentHtmlReporter("extentReport.html");
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }

    }
}
*/