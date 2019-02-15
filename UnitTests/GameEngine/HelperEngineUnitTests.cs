using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.GameEngine
{
    [TestFixture]
    public class HelperEngineUnitTests
    {
        [Test]
        public void RollDice_Roll_1_Dice_10_Should_Pass()
        {
            // Arrange
            var Roll = 1;
            var Dice = 10;

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.NotZero(Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void RollDice_Roll_2_Dice_10_Should_Pass()
        {
            // Arrange
            var Roll = 2;
            var Dice = 10;

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.NotZero(Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void RollDice_Roll_0_Dice_10_Should_Fail()
        {
            // Arrange
            var Roll = 0;
            var Dice = 10;
            var Expected = 0;   // Fail

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.AreEqual(Expected,Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void RollDice_Roll_Neg1_Dice_10_Should_Fail()
        {
            // Arrange
            var Roll = -1;
            var Dice = 10;
            var Expected = 0;   // Fail

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void RollDice_Roll_1_Dice_Neg1_Should_Fail()
        {
            // Arrange
            var Roll = 1;
            var Dice = -1;
            var Expected = 0;   // Fail

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void RollDice_Roll_1_Dice_Zero_Should_Fail()
        {
            // Arrange
            var Roll = 1;
            var Dice = 0;
            var Expected = 0;   // Fail

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void RollDice_Roll_1_Dice_10_Fixed_5_Should_Return_5()
        {
            // Arrange
            var Roll = 1;
            var Dice = 10;
            var Expected = 5;   // Fail

            // Force RollDice to return a 5
            Crawl.Models.GameGlobals.SetForcedRandomNumbersValue(5);

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Reset
            Crawl.Models.GameGlobals.DisableRandomValues();

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void RollDice_Roll_3_Dice_10_Fixed_5_Should_Return_5()
        {
            // Arrange
            var Roll = 3;
            var Dice = 10;
            var Expected = 15;

            // Force RollDice to return a 5
            Crawl.Models.GameGlobals.SetForcedRandomNumbersValue(5);

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Reset
            Crawl.Models.GameGlobals.DisableRandomValues();

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ScaleLevel_Current_1_End_100_Should_Fail()
        {
            // Arrange
            var CurrentLevel = 1;
            var EndLevel = 100;
            var Expected = false;

            // Create Character
            Crawl.Models.Character c;
            c = new Crawl.Models.Character { Id = Guid.NewGuid().ToString(), Name = "c", Description = "d", Level = CurrentLevel };

            // Act
            var Actual = c.ScaleLevel(EndLevel);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ScaleLevel_Current_1_End_0_Should_Fail()
        {
            // Arrange
            var CurrentLevel = 1;
            var EndLevel = 0;
            var Expected = false;

            // Create Character
            Crawl.Models.Character c;
            c = new Crawl.Models.Character { Id = Guid.NewGuid().ToString(), Name = "c", Description = "d", Level = CurrentLevel };

            // Act
            var Actual = c.ScaleLevel(EndLevel);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ScaleLevel_Current_20_End_21_Should_Fail()
        {
            // Arrange
            var CurrentLevel = 20;
            var EndLevel = 21;
            var Expected = false;

            // Create Character
            Crawl.Models.Character c;
            c = new Crawl.Models.Character { Id = Guid.NewGuid().ToString(), Name = "c", Description = "d", Level = CurrentLevel };

            // Act
            var Actual = c.ScaleLevel(EndLevel);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ScaleLevel_Current_1_End_1_Fixed_5_Should_set_HP_5()
        {
            // Arrange
            var CurrentLevel = 1;
            var EndLevel = 1;
            var Expected = 5;

            // Force RollDice to return a 5
            Crawl.Models.GameGlobals.SetForcedRandomNumbersValue(5);

            // Create Character
            Crawl.Models.Character c;
            c = new Crawl.Models.Character { Id = Guid.NewGuid().ToString(), Name = "c", Description = "d", Level = CurrentLevel };

            // Act
            c.ScaleLevel(1);
            var Actual = c.GetHealthMax();

            // Reset
            Crawl.Models.GameGlobals.DisableRandomValues();

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }


    }
}
