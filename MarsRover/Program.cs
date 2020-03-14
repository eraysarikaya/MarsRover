using Autofac;
using MarsRover.Business.IServices;
using MarsRover.Business.Services;
using MarsRover.Core.Models;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Program
    {
        private static IRoverService _roverService;
        static void RegisterServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RoverService>().As<IRoverService>().InstancePerLifetimeScope();
            var container = builder.Build();

            using (var newScope = container.BeginLifetimeScope())
            {
                _roverService = newScope.Resolve<IRoverService>();
            }
        }
        static void Main(string[] args)
        {
            RegisterServices();
            UpperRightCoordinatesModel upperRightCoordinates = _roverService.EnterUpperRightCoordinates();
            List<RoversModel> roverList = _roverService.FillRoversData(upperRightCoordinates);
            _roverService.RoversMovementActions(roverList);
            Console.ReadKey();
        }
    }
}
