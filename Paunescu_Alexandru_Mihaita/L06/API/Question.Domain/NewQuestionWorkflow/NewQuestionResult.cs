using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CSharp.Choices;
using System.Linq;

namespace Question.Domain.NewQuestionWorkflow
{
    [AsChoice]
    public static partial class NewQuestionResult
    {
        public interface PostNewQuestionResult { }
        public class QuestionPosted : PostNewQuestionResult    //intrebare validata si postata
        {
            public Guid Id { get; private set; }
            public string Title { get; private set; }
            public string Body { get; private set; }
            public string Tags { get; private set; }
            public QuestionPosted(Guid id, string title, string body, string tags)
            {
                Id = id;
                Title = title;
                Body = body;
                Tags = tags;
            }
        }
        public class QuestionNotPosted : PostNewQuestionResult             //intrebare nevalidata si nepostata
        {
            public string Reason { get; set; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }
        public class QuestionValidationFailed : PostNewQuestionResult        //intrebare nevalidata
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
