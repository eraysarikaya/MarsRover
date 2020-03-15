using Autofac;
using MarsRover.Business.IServices;
using MarsRover.Business.Services;
using MarsRover.Core.Enumeration;
using MarsRover.Core.Helpers;
using MarsRover.Core.Models;
using MarsRover.Test.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Test
{
    [TestClass]
    public class MarsRoverUnitTest
    {
        #region Register Services
        private IRoverService _roverService;

        [TestInitialize]
        public void RegisterServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RoverService>().As<IRoverService>().InstancePerLifetimeScope();
            var container = builder.Build();

            using (var newScope = container.BeginLifetimeScope())
            {
                _roverService = newScope.Resolve<IRoverService>();
            }
        }
        #endregion

        [TestMethod]
        public void RoversMovementActionTest()
        {
            List<RoversModel> roverList = new List<RoversModel>();

            #region Create Rover Test Model
            string upperRightCoordinates = "5 5";
            Assert.IsTrue(_roverService.UpperRightCoordinatesControl(upperRightCoordinates));
            UpperRightCoordinatesModel upperRightCoordinatesModel = new UpperRightCoordinatesModel
            {
                XCoordinate = Convert.ToInt32(upperRightCoordinates.Split(' ')[0]),
                YCoordinate = Convert.ToInt32(upperRightCoordinates.Split(' ')[1])
            };

            List<RoverListTestModel> roverTestList = new List<RoverListTestModel> {
                new RoverListTestModel
                {
                    RoverData = "1 2 N",
                    RoverMovementCommandsData = "LMLMLMLMM"
                },
                new RoverListTestModel
                {
                    RoverData = "3 3 E",
                    RoverMovementCommandsData = "MMRMMRMRRM"
                }
            };
            #endregion

            foreach (RoverListTestModel testModel in roverTestList)
            {
                Assert.IsTrue(_roverService.RoverDataControl(testModel.RoverData, upperRightCoordinatesModel));
                Assert.IsTrue(_roverService.RoverMovementCommandsDataControl(testModel.RoverData.Split(' '), testModel.RoverMovementCommandsData, upperRightCoordinatesModel));

                roverList.Add(new RoversModel
                {
                    XCoordinate = Convert.ToInt32(testModel.RoverData.Split(' ')[0]),
                    YCoordinate = Convert.ToInt32(testModel.RoverData.Split(' ')[1]),
                    Direction = (int)EnumHelper.GetEnumByName<DirectionEnum>(testModel.RoverData.Split(' ')[2]),
                    RoverMovementCommands = testModel.RoverMovementCommandsData.ToCharArray().ToList()
                });
            }

            _roverService.RoversMovementActions(roverList);
        }
    }
}
