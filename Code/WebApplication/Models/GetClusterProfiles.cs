using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class GetClusterProfiles
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public string AttributeValueType { get; set; }
        public string ValueTag { get; set; }
        public double Marginal { get; set; }
        public double Value002 { get; set; }
        public double Value001 { get; set; }
        public double Value004 { get; set; }
        public double Value005 { get; set; }
        public double Value006 { get; set; }
        public double Value009 { get; set; }
        public double Value003 { get; set; }
        public double Value007 { get; set; }
        public double Value010 { get; set; }
        public double Value008 { get; set; }
        public double getValues(int id)
        {
            switch (id)
            {
                case 1:
                    return Value001;
                case 2:
                    return Value002;
                case 3:
                    return Value003;
                case 4:
                    return Value004;
                case 5:
                    return Value005;
                case 6:
                    return Value006;
                case 7:
                    return Value007;
                case 8:
                    return Value008;
                case 9:
                    return Value009;
                case 10:
                    return Value010;
            }
            return 0;
        }

        public double maxValue()
        {
            double[] list = { Value001, Value002, Value003, Value004, Value005, Value006, Value007, Value008, Value009, Value010};
            double maxNe = -1;
            int id = 0;
            for (int i = 0; i< list.Length; i++)
            {
                if (list[i] > maxNe)
                {
                    maxNe = list[i];
                    id = i;
                }
            }
            return maxNe;
        }
        public int Idmax()
        {
            double[] list = { Value001, Value002, Value003, Value004, Value005, Value006, Value007, Value008, Value009, Value010 };
            double maxNe = -1;
            int id = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] > maxNe)
                {
                    maxNe = list[i];
                    id = i;
                }
            }
            return id + 1;
        }


        public double maxValue(int id)
        {
            return getValues(id);
        }
    }
}