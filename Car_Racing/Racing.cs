using System;
using System.Collections.Generic;
using System.Threading;
using Car_Racing;

namespace Car_Racing
{
    public class RaceResultsArgs : EventArgs
    { 
        public string Vacation { get; set; }
    }

    public class Racing
    {
        private int RaceWinnerRowNumber;
        private List<CarInfo> _cars;
        private List<CarInfo> _bigCars;
        private delegate void Message();
        private delegate void RacingTime();
        public event EventHandler<RaceResultsArgs> Info;


        public Racing(List<CarInfo> cars, List<CarInfo> bigCars)
        {
            _cars = new List<CarInfo>();
            _bigCars = new List<CarInfo>();

            _cars = cars;
            _bigCars = bigCars;            
        }


        public void RacePreparationMessage()
        {
            Message message = new Message(_cars[0].Message);
            for (int i = 1; i < _cars.Count; i++) { message += _cars[i].Message; }
            foreach (CarInfo item in _bigCars.ToArray()) { message += item.Message; }
            foreach (Message item in message.GetInvocationList()) { item(); }

            Thread.Sleep(5000);
            Console.Clear();
        }

        public void StartRacing()
        {
            if (_cars.Count >= 1 && _bigCars.Count >= 0 || _cars.Count >= 0 && _bigCars.Count >= 1)
            {
                RacingTime racingTime = new RacingTime(_cars[0].Racing);
                Info += _cars[0].Information;

                for (int i = 1; i < _cars.Count; i++)
                {
                    racingTime += _cars[i].Racing;
                    Info += _cars[i].Information;
                }

                foreach (var item in _bigCars)
                {
                    racingTime += item.Racing;
                    Info += item.Information;
                }

                List<CarInfo> cars = new List<CarInfo>(_cars);
                List<CarInfo> bigCars = new List<CarInfo>(_bigCars);

                while (true)
                {
                    if (racingTime != null)
                    {
                        foreach (RacingTime item in racingTime.GetInvocationList()) { item(); }

                        for (int i = 0; i < _cars.Count; i++)
                        {
                            if (_cars[i].DistanceTraveled >= 100)
                            {
                                racingTime -= _cars[i].Racing;

                                _cars[i].RowNumber = ++RaceWinnerRowNumber;

                                _cars.Remove(_cars[i]);
                            }
                        }

                        for (int i = 0; i < _bigCars.Count; i++)
                        {
                            if (_bigCars[i].DistanceTraveled >= 100)
                            {
                                racingTime -= _bigCars[i].Racing;

                                _bigCars[i].RowNumber = ++RaceWinnerRowNumber;

                                _bigCars.Remove(_bigCars[i]);
                            }
                        }

                        Info(this, new RaceResultsArgs() { Vacation = "Start" });

                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else { break; }
                }

                for (int i = 0; i < cars.Count; i++) { Info -= cars[i].Information; }
                for (int i = 0; i < bigCars.Count; i++) { Info -= bigCars[i].Information; }

                foreach (var item in cars) { Info += item.RaceWinners; }
                foreach (var item in bigCars) { Info += item.RaceWinners; }

                Info(this, new RaceResultsArgs() { Vacation = "Winner" });
            }
        }
    }
}
