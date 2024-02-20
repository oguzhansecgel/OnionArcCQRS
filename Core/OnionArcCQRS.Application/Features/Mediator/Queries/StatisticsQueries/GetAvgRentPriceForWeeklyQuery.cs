using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Results.StatisticsResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetAvgRentPriceForWeeklyQuery : IRequest<GetAvgRentPriceForWeeklyQueryResult>
    {
    }
}
