using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapBMI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
       
        [OperationContract]
        double myBMI(int height, int weight);

        [OperationContract]
        result myHealth(int height, int weight);
   

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    
    public class result
    {
        //internal string bmi_text;

        [DataMember]
        public double bmi { get; set; }
        [DataMember]
        public string risk { get; set; }

        [DataMember]
        public string more { get; set; }
    }
}
