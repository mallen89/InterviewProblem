using System;
using System.Collections.Generic;

namespace InterviewProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TripVm tripVm = DataController.GetJsonDataObjectFromJsonFile();

            TripVmController controller = new TripVmController(tripVm);

            controller.ShowEventDurationData();

            controller.ShowDataWrappedDurationData();

            Console.ReadKey();
        }

        
    }
}
