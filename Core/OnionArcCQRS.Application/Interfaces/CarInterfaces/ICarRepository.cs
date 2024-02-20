using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarListWithBrand();
        List<Car> GetLast5CarsWithBrands();
        int GetCarCount();
    }
}
