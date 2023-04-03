// See https://aka.ms/new-console-template for more information
#region inputs.
using Codec.Program.Helper;
using Codec.Program.Model;

List<int> marsTerrainLimits = Console.ReadLine().Trim().Split('x').Select(int.Parse).ToList<int>();
char[] moveCommandSet = Console.ReadLine().ToUpper().ToArray();
#endregion
#region model-init.
Robot robot = new Robot();
MarsPlanetau terrain = new MarsPlanetau(marsTerrainLimits[0], marsTerrainLimits[1]);
MoveHelper moveHelper = new MoveHelper(robot, terrain);
#endregion
#region action.
moveHelper.StartMoving(moveCommandSet);
Console.WriteLine(moveHelper.GetRobotStatus());
#endregion
Console.ReadKey();
