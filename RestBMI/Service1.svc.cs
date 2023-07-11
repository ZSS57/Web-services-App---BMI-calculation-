using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestBMI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public double myBMI(int height, int weight)
        {
            double myBMI = 0;
            myBMI = (1.0 * weight / ((1.0 * height) * (1.0 * height))) * 703;
            //myBMI = (weight / (height * height)) * 703;
            return myBMI;
        }


        public result myHealthJson(int height, int weight)
        {
            Service1 s = new Service1();
            result r = new result();

            double bmi;
            string risk;
            string more;

            bmi = s.myBMI(height, weight);

            if (bmi < 18)
            {
                risk = "You are underweight";
            }
            else if (bmi >= 18 & bmi < 25)
            {
                risk = "You are normal";
            }

            else if (bmi >= 25 & bmi <= 30)
            {
                risk = "You are pre-obese";
            }
            else //(bmi > 30)
            {
                risk = "You are obses";
            }

            more =
                "https://www.cdc.gov/healthyweight/assessing/bmi/index.html, " + "\r\n" +
                "https://www.nhlbi.nih.gov/health/educational/lose_wt/index.htm, " + "\r\n" +
                "https://www.ucsfhealth.org/education/body_mass_index_tool/";


            r.bmi = bmi;
            r.risk = risk;
            r.more = more;
            return r;



        }

        public result myHealthXml(int height, int weight)
        {
            Service1 s = new Service1();
            result r = new result();

            double bmi;
            string risk;
            string more;

            bmi = s.myBMI(height, weight);

            if (bmi < 18)
            {
                risk = "You are underweight";
            }
            else if (bmi >= 18 & bmi < 25)
            {
                risk = "You are normal.";
            }

            else if (bmi >= 25 & bmi <= 30)
            {
                risk = "You are pre-obese";
            }
            else //(bmi > 30)
            {
                risk = "You are obses";
            }

            more =
                "https://www.cdc.gov/healthyweight/assessing/bmi/index.html, " + "\r\n" +
                "https://www.nhlbi.nih.gov/health/educational/lose_wt/index.htm, " + "\r\n" +
                "https://www.ucsfhealth.org/education/body_mass_index_tool/";


            r.bmi = bmi;
            r.risk = risk;
            r.more = more;
            return r;



        }


    }
}