using Exam3Modul.Dtos;
using Exam3Modul.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exam3Modul.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService QuestionService;
        public QuestionController()
        {
            QuestionService = new QuestionService();
        }

        [HttpPost("create")]
        public Guid Create(QuestionCreateDto questionCreateDto)
        {
            var questionId = QuestionService.(QuestionCreateDto);
            return questionId;
        }

        [HttpGet("get-all")]
        public List<QuestionGetDto> GetAll()
        {
            return QuestionService.GetAllQuestion();
        }

        [HttpGet("get-by-id")]
        public QuestionGetDto? GetById(Guid questionId)
        {
            return QuestionService.GetQuestionById(questionId);
        }

        [HttpDelete("delete")]
        public bool Delete(Guid questionId)
        {
            return QuestionService.DeleteQuestion(questionId);
        }

        [HttpPut]
        public bool Update(Guid questionId, QuestionUpdateDto qiestionUpdateDto)
        {
            return QuestionService.UpdateQuestion(questionId, questionUpdateDto);
        }
    }

}


