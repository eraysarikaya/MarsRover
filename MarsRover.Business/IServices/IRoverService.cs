using MarsRover.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.IServices
{
    public interface IRoverService
    {
        List<RoversModel> FillRoversData(UpperRightCoordinatesModel upperRightCoordinateModel);
        void RoversMovementActions(List<RoversModel> roverList);
        UpperRightCoordinatesModel EnterUpperRightCoordinates();
    }
}
