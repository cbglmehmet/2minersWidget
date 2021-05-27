using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rigApp
{
    class settings
    {
        public bool screenStatus = false;
        static private string file = "settings.ini";
        static public void changeScreenStatus(bool status)
        {
            File.WriteAllText(file, status.ToString());
        }
        static public bool getScreenStatus()
        {
            bool status = false;
            try
            {
                string[] lines = File.ReadAllLines(file);
                status = Convert.ToBoolean(lines[0]);
            }
            catch 
            {

            }
            
            return status;
        }
    }
}
