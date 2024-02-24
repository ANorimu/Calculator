using Model.App.Calculator.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.App.Calculator
{
    public class CalculateService : ICalculateService
    {
        public CalculateHistory Calculate()
        {
            // TODO 計算処理
            return new CalculateHistory
            {
                ID = 0,
                At = DateTime.Now,
                LeftNumber = 1,
                RightNumber = 2,
                Result = 3,
                Sign = "+",
                Formula = "1 + 2 ="
            };

            // TODO DB保存処理
        }
    }
}
