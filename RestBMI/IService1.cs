using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestBMI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/myBMI?height={height}&weight={weight}")]
        double myBMI(int height, int weight);


        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json, UriTemplate = "/myHealthJson?height={height}&weight={weight}")]

        result myHealthJson(int height, int weight);


        [OperationContract]
        [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/myHealthXml?height={height}&weight={weight}")]

        result myHealthXml(int height, int weight);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]

    public class result
    {


        [DataMember(Order = 1)]
        public double bmi { get; set; }
        [DataMember(Order = 2)]
        public string risk { get; set; }

        [DataMember(Order = 3)]
        public string more { get; set; }
    }

}