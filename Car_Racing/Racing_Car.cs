using System;
using System.Threading;
using Car_Racing;

namespace Car_Racing
{
    public class Racing_Car : CarInfo
    {
        public Racing_Car(string carName, string driveName) : base(carName, driveName) { }

        public override void Information(object sender, RaceResultsArgs r)
        {
            if (r.Vacation == "Start")
            {
                if (DistanceTraveled < 100)
                {
                    Console.WriteLine($"The car with {ID} went as far as {DistanceTraveled} km of the road.");
                }
                else
                {
                    Console.WriteLine($"Finished car half with {ID}");
                }
            }
        }

        public override void Message()
        {
            Console.WriteLine($"The car named {_carName} is ready for the race.");
        }
        public override void RaceWinners(object sender, RaceResultsArgs r)
        {
            if (r.Vacation == "Winner")
            {
                if (RowNumber == 1)
                {
                    Console.WriteLine($"{_driveName} congratulations you were first in the race.");
                }
                else if (RowNumber == 2)
                {
                    Console.WriteLine($"{_driveName} congratulations you are second in the race.");
                }
                else if (RowNumber == 3)
                {
                    Console.WriteLine($"{_driveName} congratulations you are third in the race.");
                }
                else
                {
                    Console.WriteLine($"{_driveName} Unfortunately, you didn't win half.");
                }
            }
        }

        public override void Racing()
        {
            Random ran = new Random();
            DistanceTraveled += ran.Next(0, 10);
        }
    }
}
