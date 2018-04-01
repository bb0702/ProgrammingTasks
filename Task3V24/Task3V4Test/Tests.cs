using System;
using Task3V24;
using Xunit;
using Xunit.Sdk;

namespace Task3V4Test
{
    public class StepFunctionTest
    {
        private readonly StepFunction _testVar = new StepFunction();

        [Fact]
        public void SetValuesTest()
        {
            Assert.Equal(0, _testVar.A);
            Assert.Equal(0, _testVar.B);
            Assert.Equal(0, _testVar.X);

            _testVar.SetValues(1.1, 2, 3);
            Assert.Equal(1.1, _testVar.A);
            Assert.Equal(2, _testVar.B);
            Assert.Equal(3, _testVar.X);

            Assert.NotEqual(4, _testVar.X);

            Assert.NotNull(_testVar.A);
            Assert.NotNull(_testVar.B);
            Assert.NotNull(_testVar.X);

            _testVar.SetValues(1.1, 2, ' ');
            Assert.Throws<EqualException>(() => Assert.Equal(3, _testVar.X));
        }

        [Fact]
        public void FuncResTest()
        {
            _testVar.SetValues(1.1, 2, 3);
            Assert.Equal(9.9, _testVar.FuncRes());
            Assert.NotEqual(10, _testVar.FuncRes());
            Assert.NotNull(_testVar.FuncRes());
        }

        [Fact]
        public void GetNlookTest()
        {
            _testVar.SetValues(1.1, 2, 3);
            Assert.Equal("2,2*x^(1)", _testVar.GetNlook(1));
            Assert.NotEqual("2,2", _testVar.GetNlook(1));
            Assert.NotEqual("", _testVar.GetNlook(1));
        }

        [Fact]
        public void GetNresultTest()
        {
            _testVar.SetValues(1.1, 2, 3);
            Assert.Equal(2.2, _testVar.GetNresult(2));
            Assert.NotEqual(10, _testVar.GetNresult(2));
            Assert.NotNull(_testVar.GetNresult(2));
        }
    }

    public class MainClassTest
    {
        [Fact]
        public void MainTest()
        {
            var func = new StepFunction(4, 3, 3);
            StepFunction[] array =
            {
                new StepFunction(10, 0, 2),
                new StepFunction(4, 1, 2),
                new StepFunction(3, 2, 2)
            };
            const int n = 4;
            const int m = 2;

            Assert.NotNull(func.A);
            Assert.NotNull(func.B);
            Assert.NotNull(func.X);
            Assert.NotEmpty(array);
            Assert.NotNull(array[0]);
            Assert.NotNull(array[1]);
            Assert.NotNull(array[2]);
            Assert.Throws<IndexOutOfRangeException>(() => Assert.Null(array[3]));

            Assert.Equal(108, func.FuncRes());
            Assert.Equal("0*x^(-1)", func.GetNlook(n));
            Assert.Equal(0, func.GetNresult(n));

            var look = " ";
            double result = 0;
            double derivativeRes = 0;
            foreach (var el in array)
            {
                result += el.FuncRes();
                look += el.GetNlook(m);
                look += "+ ";
                derivativeRes += el.GetNresult(m);
            }

            look = look.Substring(0, look.Length - 2);
            Assert.Equal(30, result);
            Assert.Equal(" 0*x^(-2)+ 0*x^(-1)+ 6*x^(0)", look);
            Assert.Equal(6, derivativeRes);
        }
    }
}