using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcCQRS.Application.Features.RepositoryPattern;
using OnionArcCQRS.Domain.Entities;
using OnionArcCQRS.Persistence.Repositories.CommentRepositories;

namespace OnionArcCQRS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentsController(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult CommentList() 
        { 
            var values = _repository.GetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _repository.GetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _repository.Create(comment);
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);
            return Ok("Yorum başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("Yorum başarıyla silindi");
        }

       


        //[HttpGet("CommentListByBlog")]
        //public IActionResult CommentListByBlog(int id)
        //{
        //    var value = _commentsRepository.GetCommentsByBlogId(id);
        //    return Ok(value);
        //}

        //[HttpGet("CommentCountByBlog")]
        //public IActionResult CommentCountByBlog(int id)
        //{
        //    var value = _commentsRepository.GetCountCommentByBlog(id);
        //    return Ok(value);
        //}

        //[HttpPost("CreateCommentWithMediator")]
        //public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
        //{
        //    await _mediator.Send(command);
        //    return Ok("Yorum başarıyla eklendi");
        //}
    }
}
