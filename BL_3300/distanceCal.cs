//using System;
//using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Xml;
using BE;
using DAL;
using System;

namespace BL
{
    public class distanceCalculator
    {

        public static double _distanceCalculator(string t, string Address)
        {

            string origin = t; //or "תקווה פתח 100 העם אחד "etc.
            string destination = Address;//or "גן רמת 10 בוטינסקי'ז "etc.
            string KEY = @"<R6TPVxwAwHoYmJnQ6RtYicQFJZz4iAF9>";
            string url = @"https://www.mapquestapi.com/directions/v2/route" +
             @"?key=" + KEY +
             @"&from=" + origin +
             @"&to=" + destination +
             @"&outFormat=xml" +
             @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
             @"&enhancedNarrative=false&avoidTimedConditions=false";
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {

                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                double Distance = distInMiles * 1.609344;
                //Console.WriteLine("Distance In KM: " + distInMiles * 1.609344);
                //display the returned driving time
                XmlNodeList formattedTime = xmldoc.GetElementsByTagName("formattedTime");
                string fTime = formattedTime[0].ChildNodes[0].InnerText;
                Console.WriteLine("Driving Time: " + fTime);
                return Distance;
            }

            else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            //we have an answer that an error occurred, one of the addresses is not found
            {
                Console.WriteLine("an error occurred, one of the addresses is not found. try again.");
                Console.WriteLine("Enter the addresses again");                
                string q = Console.ReadLine();
                string address = Console.ReadLine();
                return _distanceCalculator(q, address);
            }
            else //busy network or other error...
            {
                Console.WriteLine("We have'nt got an answer, maybe the net is busy...");
                System.Threading.Thread.Sleep(2000);
            }

            return _distanceCalculator(t, Address);

        }
    }
}
