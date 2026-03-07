using Exam3Modul.Dtos;

namespace Exam3Modul.Services;

public interface IQuestionService
{
    Guid Create(QuestionCreateDto questionCreateDto);
    List<QuestionGetDto> GetAll();
    QuestionGetDto? GetById(Guid questionId);
    QuestionService Delete(Guid questionId);
    QuestionUpdateDto Update(QuestionUpdateDto questionUpdateDto);

}