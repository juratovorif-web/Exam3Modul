using Exam3Modul.Dtos;
using Exam3Modul.Entities;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace Exam3Modul.Services;

public class QuestionService : IQuestionService
{
    private readonly string FilePath;
    private List<Question> Questions;  

    public QuestionService()
    {
        FilePath = "E:\\code\\DotNet\\Exam\\Exam3Modul\\ExamSolution\\src\\Exam3Modul\\Exam3Modul.csproj";
        Questions = new();
    }
    Question questions = new Question();

    public Guid Create(QuestionCreateDto questionCreateDto)
    {
        ReadQuestionFromFile();
        var question = new Question()
        {
            QuestionId = Guid.NewGuid(),
            Text = questionCreateDto.Text,
            Title = questionCreateDto.Title,
            Description = questionCreateDto.Description,
            QuestionName = questionCreateDto.QuestionName,
            Answer = questionCreateDto.Answer,
        };

        Questions.Add(question);
        SaveQuestionsToFile();
        return question.QuestionId;
    }

    public bool Delete(Guid questionId)
    {
        ReadQuestionFromFile();
        var question = Questions.FirstOrDefault(q => q.QuestionId == questionId);
        if(question != null)
        {
            Questions.Remove(question);
            SaveQuestionsToFile();
            return true;
        }

        return false;
    }

    public List<QuestionGetDto> GetAll()
    {
        ReadQuestionFromFile();
        return Questions.Select(q => new QuestionGetDto
        {
            QuestionId = q.QuestionId,
            QuestionName = q.QuestionName,
            Description = q.Description,
            Title = q.Title,
        })
        .ToList(); 
    }

    public QuestionGetDto? GetById(Guid questionId)
    {
        ReadQuestionFromFile();
        return Questions.Select(q => new QuestionGetDto
        {
            QuestionId = q.QuestionId,
            QuestionName = q.QuestionName,
            Description = q.Description,
            Title = q.Title,
        })
        .FirstOrDefault(q => q.QuestionId == questionId);
    }

    public bool Update(QuestionUpdateDto questionUpdateDto)
    {
        ReadQuestionFromFile();
        var question = Questions.FirstOrDefault(q => q.QuestionId == questionUpdateDto.QuestionId);
        if(question != null)
        {
            question.QuestionName = questionUpdateDto.QuestionName;
            question.Answer = questionUpdateDto.Answer;
            question.Text = questionUpdateDto.Text;
            question.Title = questionUpdateDto.Title;   
            question.Description = questionUpdateDto.Description;
            return true;
        }

        return false;
    }

    private void SaveQuestionsToFile()
    {
        var json = JsonSerializer.Serialize(Questions);
        File.WriteAllText(FilePath, json);
    }

    private void ReadQuestionFromFile()
    {
        var json = File.ReadAllText(FilePath);

        if (string.IsNullOrEmpty(json))
        {
            Questions = new List<Question>();
            return;
        }

        Questions = JsonSerializer.Deserialize<List<Question>>(json) ?? new List<Question>();
    }
}
