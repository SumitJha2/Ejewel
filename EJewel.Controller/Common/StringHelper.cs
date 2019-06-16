using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Controller.Common
{
    /*
     * Partha Ranjan
     * @ 01-02-13
     * This class helps to manage the string opeation
     * */
    public class StringHelper
    {
        /*
         * Partha Ranjan
         * @ 01-02-13
         * This function helps to create a clean string
         * */
        public static string CleanString(string orginalString, string appendString)
        {
            try
            {
                //convert ot lower
                orginalString = orginalString.ToLower().Trim();
                //creat clear string
                orginalString = orginalString.Replace(" ", appendString);
                return orginalString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
         * Partha Ranjan
         * @ 01-02-13
         * This function helps to create random string
         * */
        public static string UniqueString(int noChar)
        {
            try
            {
                noChar = noChar > 32 ? 32 : noChar;
                return Guid.NewGuid().ToString().Substring(0, noChar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
         * Partha Ranjan
         * @ 01-02-13
         * This function check that the extenstion is present ot not
         * */
        public static bool IsValidExtention(string ext)
        {
            string[] fileExt = { "jpg", "jpeg", "png", "gif","JPG" };
            bool result = false;
            foreach (string extention in fileExt)
            {
                if (ext == extention)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        /*
         * Partha Ranjan
         * @ 01-02-13
         * This function get the extention of the file
         * */
        public static string GetFileExtention(string file_name, bool requredDot)
        {
            string extenstion = file_name.Substring(file_name.LastIndexOf('.'));
            if (!requredDot)
            {
                //remov the dot(.) from the extenstion
                extenstion = extenstion.Substring(1);
            }
            return extenstion;
        }
    }
}
