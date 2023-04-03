using Codec.Program.Helper;
using Codec.Program.Model;

namespace Codec.Test
{
    public class MoveCommandTestCases
    {
        public static IEnumerable<object[]> commandResultList => new List<object[]> {
            new object[]{ new int[] { 5, 5 }, "LFLFLFLFF".ToCharArray(),  "1,2,North"},
            new object[]{ new int[] { 5, 5 }, "FFRFLFLF".ToCharArray(), "1,4,West" },
            new object[]{ new int[] { 5, 5 }, "FFRFLFLFFLFFLF".ToCharArray(), "1,2,East" },
            new object[]{ new int[] { 5, 5 }, "FFFFFFF".ToCharArray(),  "1,4,North"},
            new object[]{ new int[] { 5, 5 }, "LLFF".ToCharArray(),  "1,0,South"},
            new object[]{ new int[] { 5, 5 }, "LFLFFF".ToCharArray(), "There is no 0,0 position" },
            new object[]{ new int[] { 5, 5 }, "RFLFRFLFF".ToCharArray(), "3,4,North" },
            new object[]{ new int[] { 8, 5 }, "LLFF".ToCharArray(),  "1,0,South"},
            new object[]{ new int[] { 12, 5 }, "RFLFFF".ToCharArray(), "2,4,North" },
            new object[]{ new int[] { 10, 19 }, "LFLRFLFF".ToCharArray(), "There is no 0,0 position" }
        };
    }
    public class NavigationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(typeof(MoveCommandTestCases), nameof(MoveCommandTestCases.commandResultList))]
        public void RunCommandCase(int[] terrainSizes, char[] commands, string expectedOutput)
        {
            #region Arrange
            Robot robot = new Robot();
            MarsPlanetau terrain = new MarsPlanetau(terrainSizes[0], terrainSizes[1]);
            MoveHelper moveHelper = new MoveHelper(robot, terrain);            
            #endregion
            #region Act
            moveHelper.StartMoving(commands);
            #endregion
            #region Assert         
            Assert.AreEqual(expectedOutput, moveHelper.GetRobotStatus());
            #endregion
        }
        [Test]
        public void OverLimitCase()
        {
            #region Arrange
            Robot robot = new Robot();
            MarsPlanetau terrain = new MarsPlanetau(5, 5);
            MoveHelper moveHelper = new MoveHelper(robot, terrain);
            char[] moveCommands = "LFF".ToCharArray();
            #endregion
            #region Act
            moveHelper.StartMoving(moveCommands);
            #endregion
            #region Assert
            string expectedOutput = "0,1,West";
            Assert.AreEqual(expectedOutput, moveHelper.GetRobotStatus());
            #endregion
        }
        [Test]
        public void ZeroToZeroPositionCase()
        {
            #region Arrange
            Robot robot = new Robot();
            MarsPlanetau terrain = new MarsPlanetau(5, 5);
            MoveHelper moveHelper = new MoveHelper(robot, terrain);
            char[] moveCommands = "LFLF".ToCharArray();
            #endregion
            #region Act
            moveHelper.StartMoving(moveCommands);
            #endregion
            #region Assert
            string expectedOutput = "There is no 0,0 position";
            Assert.AreEqual(expectedOutput, moveHelper.GetRobotStatus());
            #endregion
        }
    }
}