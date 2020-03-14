using MarsRover.Enumeration;
using MarsRover.Helpers;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Program
    {
        static UpperRightCoordinatesModel upperRightCoordinateModel;
        static void Main(string[] args)
        {
            List<RoversModel> roverList = FillRoversData();
            RoversMovementActions(roverList);
            Console.ReadKey();
        }

        public static List<RoversModel> FillRoversData()
        {
            List<RoversModel> rovers = new List<RoversModel>();
            EnterUpperRightCoordinates();

            do
            {
                string[] roverData = EnterRoverData();
                char[] movementCommandsData = EnterRoverMovementCommandsData(roverData);

                rovers.Add(new RoversModel
                {
                    XCoordinate = Convert.ToInt32(roverData[0]),
                    YCoordinate = Convert.ToInt32(roverData[1]),
                    Direction = (int)EnumHelper.GetEnumByName<DirectionEnum>(roverData[2]),
                    RoverMovementCommands = movementCommandsData.ToList()
                });
                Console.WriteLine("Rover ekleme işleminden çıkmak için ESC tuşuna basınız. İşleme devam etmek için herhangi bir tuşa basınız...");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine();
            return rovers;
        }

        public static void RoversMovementActions(List<RoversModel> roverList)
        {
            foreach (RoversModel rover in roverList)
            {
                foreach (char movementCommand in rover.RoverMovementCommands)
                {
                    switch (movementCommand)
                    {
                        case 'L': rover.TurnLeft(); break;
                        case 'R': rover.TurnRight(); break;
                        default: rover.Move(); break;
                    }
                }
                Console.WriteLine(String.Format("{0} {1} {2}", rover.XCoordinate, rover.YCoordinate, (DirectionEnum)rover.Direction));
            }
        }

        #region EnterData
        public static void EnterUpperRightCoordinates()
        {
            bool succcess = false;
            string upperRightCoordinates = string.Empty;

            while (!succcess)
            {
                Console.WriteLine("Bölge sağ üst kordinat bilgilerini giriniz...");
                upperRightCoordinates = Console.ReadLine();
                succcess = UpperRightCoordinatesControl(upperRightCoordinates);
            }
            string[] upperRightCoordinatesSplit = upperRightCoordinates.CustomSplit(' ');

            upperRightCoordinateModel = new UpperRightCoordinatesModel
            {
                XCoordinate = Convert.ToInt32(upperRightCoordinatesSplit[0]),
                YCoordinate = Convert.ToInt32(upperRightCoordinatesSplit[1])
            };
        }

        public static string[] EnterRoverData()
        {
            bool succcess = false;
            string roverData = string.Empty;

            while (!succcess)
            {
                Console.WriteLine("Rover bilgilerini giriniz...");
                roverData = Console.ReadLine();
                succcess = RoverDataControl(roverData);
            }
            string[] roverDataSplit = roverData.CustomSplit(' ');
            return roverDataSplit;
        }

        public static char[] EnterRoverMovementCommandsData(string[] roverData)
        {
            bool succcess = false;
            string movementCommandsData = string.Empty;

            while (!succcess)
            {
                Console.WriteLine("Rover hareket komutlarını giriniz...");
                movementCommandsData = Console.ReadLine();
                succcess = RoverMovementCommandsDataControl(roverData, movementCommandsData);
            }
            char[] movementCommandsDataSplit = movementCommandsData.ToUpper().ToCharArray();
            return movementCommandsDataSplit;
        }
        #endregion
        #region DataControl
        public static bool UpperRightCoordinatesControl(string upperRightCoordinates)
        {
            try
            {
                string[] upperRightCoordinatesSplit = upperRightCoordinates.Split(' ');

                if (upperRightCoordinatesSplit.Count() < 2 || !int.TryParse(upperRightCoordinatesSplit[0], out int x) || x <= 0 || !int.TryParse(upperRightCoordinatesSplit[1], out int y) || y <= 0)
                {
                    Console.WriteLine("Lütfen geçerli kordinat bilgisi giriniz!");
                    return false;
                }

                return true;
            }
            catch
            {
                Console.WriteLine("Lütfen geçerli kordinat bilgisi giriniz!");
                return false;
            }
        }

        public static bool RoverDataControl(string roverData)
        {
            try
            {
                string[] roverDataSplit = roverData.CustomSplit(' ');
                if (roverDataSplit.Count() < 3)
                {
                    Console.WriteLine("Lütfen geçerli rover bilgisi giriniz!");
                    return false;
                }
                if (!int.TryParse(roverDataSplit[0], out int x) || x < 0 || x > upperRightCoordinateModel.XCoordinate || !int.TryParse(roverDataSplit[1], out int y) || y < 0 || y > upperRightCoordinateModel.YCoordinate)
                {
                    Console.WriteLine("Lütfen bölge sınırları içinde geçerli değerler giriniz!");
                    return false;
                }
                if (!EnumHelper.GetItems(typeof(DirectionEnum)).Contains(roverDataSplit[2]))
                {
                    Console.WriteLine("Lütfen geçerli pusula yön bilgisi giriniz!");
                    return false;
                }

                return true;
            }
            catch
            {
                Console.WriteLine("Lütfen geçerli rover bilgisi giriniz!");
                return false;
            }
        }

        public static bool RoverMovementCommandsDataControl(string[] roverData, string movementCommandsData)
        {
            try
            {
                if (string.IsNullOrEmpty(movementCommandsData))
                    return false;
                else
                {
                    char[] movementCommandsDataSplit = movementCommandsData.ToUpper().ToCharArray();
                    List<string> movementCommandsEnumDataList = EnumHelper.GetItems(typeof(MovementCommandsEnum));

                    RoversModel routeTestModel = new RoversModel
                    {
                        XCoordinate = Convert.ToInt32(roverData[0]),
                        YCoordinate = Convert.ToInt32(roverData[1]),
                        Direction = (int)EnumHelper.GetEnumByName<DirectionEnum>(roverData[2]),
                    };

                    foreach (char data in movementCommandsDataSplit)
                    {
                        if (!movementCommandsEnumDataList.Contains(data.ToString()))
                        {
                            Console.WriteLine("Lütfen geçerli hareket komut bilgisi giriniz!");
                            return false;
                        }
                        else
                        {
                            switch (data)
                            {
                                case 'L': routeTestModel.TurnLeft(); break;
                                case 'R': routeTestModel.TurnRight(); break;
                                default: routeTestModel.Move(); break;
                            }

                            if (routeTestModel.XCoordinate > upperRightCoordinateModel.XCoordinate || routeTestModel.YCoordinate > upperRightCoordinateModel.YCoordinate || routeTestModel.XCoordinate < 0 || routeTestModel.YCoordinate < 0)
                            {
                                Console.WriteLine("Lütfen hareket komutlarını rover bölge içinde kalacak şekilde giriniz!");
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
