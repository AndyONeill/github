using System;
using Xunit;
using RomanNumerals.Helpers;
using System.Collections.Generic;

namespace RomanNumerals.Tests
{
    public class UnitTest1
    {
        private Numerals numerals = new Numerals();
        [Fact]
        public void When_1_Expect_I()
        {
            string result = numerals.Convert(1);
            Assert.Equal("I", result);
        }
        [Fact]
        public void When_2_Expect_II()
        {
            string result = numerals.Convert(2);
            Assert.Equal("II", result);
        }
        [Fact]
        public void When_3_Expect_III()
        {
            string result = numerals.Convert(3);
            Assert.Equal("III", result);
        }
        [Fact]
        public void When_4_Expect_IV()
        {
            string result = numerals.Convert(4);
            Assert.Equal("IV", result);
        }
        [Fact]
        public void When_5_Expect_V()
        {
            string result = numerals.Convert(5);
            Assert.Equal("V", result);
        }
        [Fact]
        public void When_6_Expect_VI()
        {
            string result = numerals.Convert(6);
            Assert.Equal("VI", result);
        }
        [Fact]
        public void When_7_Expect_VII()
        {
            string result = numerals.Convert(7);
            Assert.Equal("VII", result);
        }
        [Fact]
        public void When_8_Expect_VIII()
        {
            string result = numerals.Convert(8);
            Assert.Equal("VIII", result);
        }
        [Fact]
        public void When_9_Expect_IX()
        {
            string result = numerals.Convert(9);
            Assert.Equal("IX", result);
        }
        [Fact]
        public void When_10_Expect_X()
        {
            string result = numerals.Convert(10);
            Assert.Equal("X", result);
        }
        [Fact]
        public void When_11_Expect_XI()
        {
            string result = numerals.Convert(11);
            Assert.Equal("XI", result);
        }
        [Fact]
        public void When_12_Expect_XIi()
        {
            string result = numerals.Convert(12);
            Assert.Equal("XII", result);
        }
        [Fact]
        public void When_13_Expect_XIII()
        {
            string result = numerals.Convert(13);
            Assert.Equal("XIII", result);
        }
        // I got bored doing every single number
        [Fact]
        public void When_23_Expect_XXIII()
        {
            string result = numerals.Convert(23);
            Assert.Equal("XXIII", result);
        }
        [Fact]
        public void When_41_Expect_XLI()
        {
            string result = numerals.Convert(41);
            Assert.Equal("XLI", result);
        }
        [Fact]
        public void When_50_Expect_L()
        {
            string result = numerals.Convert(50);
            Assert.Equal("L", result);
        }
        [Fact]
        public void When_90_Expect_XC()
        {
            string result = numerals.Convert(90);
            Assert.Equal("XC", result);
        }
        private List<string> Roman1Too100 = new List<string>
        {
            "?",
 "I",
"II",
"III",
"IV",
"V",
"VI",
"VII",
"VIII",
"IX",
"X",
"XI",
"XII",
"XIII",
"XIV",
"XV",
"XVI",
"XVII",
"XVIII",
"XIX",
"XX",
"XXI",
"XXII",
"XXIII",
"XXIV",
"XXV",
"XXVI",
"XXVII",
"XXVIII",
"XXIX",
"XXX",
"XXXI",
"XXXII",
"XXXIII",
"XXXIV",
"XXXV",
"XXXVI",
"XXXVII",
"XXXVIII",
"XXXIX",
"XL",
"XLI",
"XLII",
"XLIII",
"XLIV",
"XLV",
"XLVI",
"XLVII",
"XLVIII",
"XLIX",
"L",
"LI",
"LII",
"LIII",
"LIV",
"LV",
"LVI",
"LVII",
"LVIII",
"LIX",
"LX",
"LXI",
"LXII",
"LXIII",
"LXIV",
"LXV",
"LXVI",
"LXVII",
"LXVIII",
"LXIX",
"LXX",
"LXXI",
"LXXII",
"LXXIII",
"LXXIV",
"LXXV",
"LXXVI",
"LXXVII",
"LXXVIII",
"LXXIX",
"LXXX",
"LXXXI",
"LXXXII",
"LXXXIII",
"LXXXIV",
"LXXXV",
"LXXXVI",
"LXXXVII",
"LXXXVIII",
"LXXXIX",
"XC",
"XCI",
"XCII",
"XCIII",
"XCIV",
"XCV",
"XCVI",
"XCVII",
"XCVIII",
"XCIX",
"C",

        };
        [Fact]
        public void When_List1_to_100_Expect_AllToMatch()
        {
            for (int i = 1; i < 100; i++)
            {
                string result = numerals.Convert(i);
                Assert.Equal(Roman1Too100[i], result);
            }
        }
    }
}
