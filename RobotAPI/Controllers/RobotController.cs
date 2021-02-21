using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RobotBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotAPI.Controllers
{
    public class Delta
    {
        public int DeltaX;
        public int DeltaY;

        public override string ToString()
        {
            return $"{this.DeltaX},{this.DeltaY}";
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class RobotController : ControllerBase
    {
        private static Robot _robot;

        private readonly ILogger<RobotController> _logger;

        public RobotController(ILogger<RobotController> logger)
        {
            _logger = logger;

            if (_robot == null)
            {
                _robot = new Robot()
                {
                    Name = "XR-" + (new Random()).Next(100, 999).ToString(),
                    SizeX = (new Random()).Next(1, 9) * 10,
                    SizeY = (new Random()).Next(1, 9) * 10
                };
            }
        }

        // https://localhost:44383/robot?deltax=15&deltay=-10
        [HttpGet]
        public Robot Get(int? deltaX, int? deltaY)
        {
            if (deltaX.HasValue || deltaY.HasValue)
            {
                _robot.Move(deltaX.GetValueOrDefault(0), deltaY.GetValueOrDefault(0));
            }
            return _robot;
        }
    }
}
