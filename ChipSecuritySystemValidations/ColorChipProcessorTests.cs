using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChipSecuritySystem;
using System.Collections.Generic;

namespace ChipSecuritySystemValidations
{
    [TestClass]
    public class ColorChipProcessorTests
    {
        [TestMethod]
        public void EmptySetFail()
        {
            var chips = new List<ColorChip>();

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(0, result.ChipsUsed);
        }

        [TestMethod]
        public void OneChipPassTest()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Green)
            };

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(1, result.ChipsUsed);
        }

        [TestMethod]
        public void SimpleMultiChipPass()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Red),
                new ColorChip(Color.Red, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Green)
            };

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(3, result.ChipsUsed);
            Assert.AreEqual(3, result.ChipSequence.Count);
        }

        [TestMethod]
        public void SimpleMultiChipFail()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Red),
                new ColorChip(Color.Red, Color.Yellow),
                new ColorChip(Color.Purple, Color.Green)
            };

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void NoBlueFail()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Red, Color.Yellow),
                new ColorChip(Color.Purple, Color.Green)
            };

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void NoGreenFail()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Red),
                new ColorChip(Color.Red, Color.Yellow)
            };

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void MultiPathExtraGreenPass()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Red),
                new ColorChip(Color.Red, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Green),
                new ColorChip(Color.Green, Color.Purple),
                new ColorChip(Color.Purple, Color.Green)
            };

            var result = Evaluator.CheckColorChips(chips);

            /* should use all 5, not the shorter 3-chip path */
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(5, result.ChipsUsed);
            Assert.AreEqual(5, result.ChipSequence.Count);
        }

        [TestMethod]
        public void MultiPathExtraBluePass()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Red),
                new ColorChip(Color.Red, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Blue),
                new ColorChip(Color.Blue, Color.Purple),
                new ColorChip(Color.Purple, Color.Green)
            };

            var result = Evaluator.CheckColorChips(chips);

            /* should use all 5, not the shorter 3-chip path */
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(5, result.ChipsUsed);
            Assert.AreEqual(5, result.ChipSequence.Count);
        }

        [TestMethod]
        public void MultiChipReverseColorsPass()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Red, Color.Blue),
                new ColorChip(Color.Red, Color.Yellow),
                new ColorChip(Color.Green, Color.Yellow)
            };

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(3, result.ChipsUsed);
            Assert.AreEqual(3, result.ChipSequence.Count);
        }

        /*
        [TestMethod]
        public void Test()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Green)
            };

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Green)
            };

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Green)
            };

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test()
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Green)
            };

            var result = Evaluator.CheckColorChips(chips);

            Assert.IsNotNull(result);
        }
        */
    }
}
