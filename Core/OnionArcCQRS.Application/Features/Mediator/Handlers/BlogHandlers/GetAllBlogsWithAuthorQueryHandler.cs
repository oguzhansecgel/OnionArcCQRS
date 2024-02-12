using MediatR;
using OnionArcCQRS.Application.Features.Mediator.Queries.BlogQueries;
using OnionArcCQRS.Application.Features.Mediator.Results.BlogResults;
using OnionArcCQRS.Application.Interfaces.BlogInterfaces;

namespace OnionArcCQRS.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllblogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllblogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllblogsWithAuthorQueryResult
            {
                AuthorID = x.AuthorID,
                BlogId = x.BlogId,
                CategoryID = x.CategoryID,
                CoverImage = x.CoverImage,
                CreatedTime = x.CreatedTime,
                BlogTitle = x.BlogTitle,
                AuthorName = x.Author.AuthorName,
                Description = x.Description,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl
            }).ToList();
        }
    }
}
