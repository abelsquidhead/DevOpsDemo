using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MercuryHealth.Web.Utilities
{
    public class HealthCalculator
    {
        // straight forward method
        public int GetHealthIndex(int lhs, int rhs)
        {
            if (lhs > rhs)
            {
                return lhs - rhs;
            }
            return lhs + rhs;
        }


        // need to mock because method uses outside dependency
        public string GenerateReportName(int userId)
        {
            var userRepo = new UserRepository();
            var user = userRepo.GetUser(userId);

            var reportName = DateTime.Now + ": " + user.FirstName + " " + user.LastName;
            return reportName ;
        }


        // show how intellitest can traverse through code
        public int WeirdHealthIndex(int lhs, int rhs)
        {
            if (lhs > rhs)
            {
                return lhs - rhs;
            }
            else if (lhs == rhs)
            {
                return lhs * rhs;
            }
            else if (rhs == 0)
            {
                throw new DivideByZeroException("Weird add cannot divide by zero");
            }
            return lhs + rhs;
        }

        // outside dependencies
        public int GetNumberOfFilesAndFolders(string path)
        {
            var numFiles = Directory.GetFiles(path).Length;
            var numFolders = Directory.GetDirectories(path).Length;

            return numFiles + numFolders;

        }
    }
}