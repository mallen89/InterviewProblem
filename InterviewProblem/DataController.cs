using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProblem
{
    public static class DataController
    {
        //Parses data from Json file into objects.
        public static TripVm GetJsonDataObjectFromJsonFile()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(@"tripdata.json"))
                {
                    string jsonString = streamReader.ReadToEnd();

                    return JsonConvert.DeserializeObject<TripVm>(jsonString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Verify that the file is named \"tripdata.json\"! ");
            }

            return null;
        }
    }
}
