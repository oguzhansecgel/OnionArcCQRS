using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Dto.CarPricingDtos
{
    public class ResultCarPricingListWithModelDto
    {
        public string model { get; set; }
        public int dailyAmount { get; set; }
        public int weeklyAmount { get; set; }
        public int monthlyAmount { get; set; }
    }
}

 
 