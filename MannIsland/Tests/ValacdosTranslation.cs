using System;
using Xunit;
using MannIsland.Services;
using MannIsland;

namespace Tests
{
    public class ValacdosTranslation
    {
        [Fact]
        public void SplitOneLineOK()
        {
            Validator val = new Validator();
            string firstLine = "010004 016715 MOD11    0    0    0    0    0    0    8    7    6    5    4    3    2    1";
            string[] pieces = val.GetPieces(firstLine);
            Assert.Equal(17, pieces.Length);
            Assert.Equal("010004", pieces[0]);
            Assert.Equal("MOD11", pieces[2]);
            Assert.Equal("1", pieces[16]);
        }
        [Fact]
        public void ParseLineToModulusToApply()
        {
            Validator val = new Validator();
            string firstLine = "010004 016715 MOD11    0    0    0    0    0    0    8    7    6    5    4    3    2    1";
            ModulusToApply ma = val.GetParsedValacLine(firstLine);
            Assert.Equal(ma.Start, (uint)10004);
            Assert.Equal(ma.End, (uint)16715);
            Assert.Equal(0, ma.Weightings[0]);
            Assert.Equal(7, ma.Weightings[7]);

            Assert.Equal(14, ma.Weightings.Length);
        }
        [Fact]
        public void ParseLineToModulusWithException()
        {
            Validator val = new Validator();
            string exLine = "070116 070116 MOD11    0    0    7    6    5    8    9    4    5    6    7    8    9   -1  12";
            ModulusToApply ma = val.GetParsedValacLine(exLine);
            Assert.Equal(-1, ma.Weightings[13]);
            Assert.Equal(12, ma.Ex);

            Validator val1 = new Validator(".");
        }
        [Fact]
        public void CheckFullValacdosParses()
        {
            Validator val = new Validator(".");
            Assert.Equal(1073, val.modulii.Count);
        }
    }
}
