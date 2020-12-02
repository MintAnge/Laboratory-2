using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
{
    public class UBI
    {
        public string IndefUBI {get; set;}
        public string NameUBI {get; set;}
        public string Description { get; set;}
        public string SourceOfThreat { get; set; }
        public string Object { get; set; }
        public string BreachConf { get; set; }
        public string IntegrityViolation { get; set; }
        public string AccessibilityViolation { get; set; }
        public UBI(string ind, string name, string des, string sourse, string obj, string bre, string inte, string acc )
        {
            IndefUBI = ind;
            NameUBI = name;
            Description = des;
            SourceOfThreat = sourse;
            Object = obj;
            if (bre == "1")
            BreachConf = "Yes";
            else BreachConf = "No";
            if (inte == "1")
                IntegrityViolation ="Yes";
            else IntegrityViolation = "No";
            if (acc == "1")
                AccessibilityViolation = "Yes";
            else AccessibilityViolation = "No";
        }
    }
}
