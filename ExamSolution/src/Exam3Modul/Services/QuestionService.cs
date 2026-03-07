using Exam3Modul.Dtos;
using Exam3Modul.Entities;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace Exam3Modul.Services;

public class QuestionService : IQuestionService
{
    private readonly string FilePath;
    public QuestionService()
    {
        FilePath = "E:\\code\\DotNet\\Exam\\Exam3Modul\\ExamSolution\\src\\Exam3Modul\\Exam3Modul.csproj";
    }
    Question questions = new Question();

    public Guid Create(QuestionCreateDto questionCreateDto)
    {
        questionCreateDto
    }

    public QuestionService Delete(Guid questionId)
    {
        
    }

    public List<QuestionGetDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public QuestionGetDto? GetById(Guid questionId)
    {
        throw new NotImplementedException();
    }

    public QuestionUpdateDto Update(QuestionUpdateDto questionUpdateDto)
    {
        throw new NotImplementedException();
    }

    private void SavePostsToFile()
    {
        var json = JsonSerializer.Serialize(Question);
        File.WriteAllText(FilePath, json);
    }

    private void ReadPostsFromFile()
    {
        var json = File.ReadAllText(FilePath);

        if (string.IsNullOrEmpty(json))
        {
            Question = new List<Question>();
            return;
        }

        Question = JsonSerializer.Deserialize<List<Question>>(json) ?? new List<Question>();
    }
}
