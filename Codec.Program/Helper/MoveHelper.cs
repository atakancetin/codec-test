using Codec.Program.Model;
using Codec.Program.Utilities;

namespace Codec.Program.Helper
{
    public class MoveHelper
    {
        private readonly Robot _robot;
        private readonly MarsPlanetau _terrain;
        #region ctor.
        public MoveHelper(Robot robot, MarsPlanetau terrain)
        {
            _robot = robot;
            _terrain = terrain;
        }
        #endregion
        public void StartMoving(char[] moveCommands)
        {
            foreach (var movecommand in moveCommands)
            {
                switch (movecommand)
                {
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                    case 'F':
                        MoveForward();
                        break;
                    default:
                        Console.WriteLine($"{movecommand} not resolved by MoveHelper");
                        break;
                }       
                
            }
        }         
        private void MoveForward()
        {
            switch (_robot.faceDirection)
            {
                case Enums.Compass.N:
                    if (_robot.yPosition + 1 < _terrain.ySize)
                    {
                        _robot.yPosition++;
                    }                    
                    break;
                case Enums.Compass.E:
                    if (_robot.xPosition + 1 < _terrain.xSize)
                    {
                        _robot.xPosition++;
                    }                    
                    break;
                case Enums.Compass.S:
                    if (_robot.yPosition - 1 >= 0 && _robot.yPosition -1 < _terrain.ySize)
                    {
                        _robot.yPosition--;
                    }                    
                    break;
                case Enums.Compass.W:
                    if (_robot.xPosition - 1 >= 0 && _robot.xPosition - 1 < _terrain.xSize)
                    {
                        _robot.xPosition--;
                    }                   
                    break; 
                default:
                    break;
            }
        }
        private void RotateLeft()
        {
            switch (_robot.faceDirection)
            {
                case Enums.Compass.N:
                    _robot.faceDirection = Enums.Compass.W;
                    break;
                case Enums.Compass.E:
                    _robot.faceDirection = Enums.Compass.N;
                    break;
                case Enums.Compass.S:
                    _robot.faceDirection = Enums.Compass.E;
                    break;
                case Enums.Compass.W:
                    _robot.faceDirection = Enums.Compass.S;
                    break;                
            }
        }
        private void RotateRight()
        {
            switch (_robot.faceDirection)
            {
                case Enums.Compass.N:
                    _robot.faceDirection = Enums.Compass.E;
                    break;
                case Enums.Compass.E:
                    _robot.faceDirection = Enums.Compass.S;
                    break;
                case Enums.Compass.S:
                    _robot.faceDirection = Enums.Compass.W;
                    break;
                case Enums.Compass.W:
                    _robot.faceDirection = Enums.Compass.N;
                    break;
            }
        }
        private string PrintDirection(Enums.Compass val)
        {
            switch (val)
            {
                case Enums.Compass.N:
                    return "North";
                case Enums.Compass.E:
                    return "East";
                case Enums.Compass.S:
                    return "South";
                case Enums.Compass.W:
                    return "West";
                default:
                    return "";
            }
        } 

        public string GetRobotStatus()
        {
            if (_robot.xPosition == 0 && _robot.yPosition == 0)
            {
                return "There is no 0,0 position";
            }
            return $"{_robot.xPosition},{_robot.yPosition},{PrintDirection(_robot.faceDirection)}";
        }
    }
}
