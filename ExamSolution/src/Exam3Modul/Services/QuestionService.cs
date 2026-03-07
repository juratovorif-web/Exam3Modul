using Exam3Modul.Dtos;
using Exam3Modul.Entities;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace Exam3Modul.Services;

public class QuestionService : IQuestionService
{
    public Guid Create(QuestionCreateDto questionCreateDto)
    {
        throw new NotImplementedException();
    }

    public QuestionService Delete(Guid questionId)
    {
        throw new NotImplementedException();
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
            Posts = new List<Post>();
            return;
        }

        Posts = JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
    }
