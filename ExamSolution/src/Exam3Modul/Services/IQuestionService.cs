using Exam3Modul.Dtos;

namespace Exam3Modul.Services;

public interface IQuestionService
{
    Guid Create(QuestionCreateDto questionCreateDto);
    List<QuestionGetDto> GetAll();
    QuestionGetDto? GetById(Guid questionId);
    bool Delete(Guid questionId);
    bool Update(QuestionUpdateDto questionUpdateDto);

}