using System;
using Car_Racing;

namespace Car_Racing
{
    public abstract class CarInfo
    {
        public int ID { get; private set; }
        public int DistanceTraveled { get; set; }
        public int RowNumber { get; set; }
        public string _driveName { get; private set; }
        public string _carName { get; private set; }


        protected CarInfo(string carName, string driveName)
        {
            Random random = new Random();
            ID = random.Next(25451, 68108);
            _carName = carName;
            _driveName = driveName;
        }

        public abstract void Message();

        public abstract void Racing();
        public abstract void Information(object sender, RaceResultsArgs r);

        public abstract void RaceWinners(object sender, RaceResultsArgs r);
    }
}
