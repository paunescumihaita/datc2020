using System;
using System.Collections.Generic;
using System.Text;
using Question.Domain.NewQuestionWorkflow;
using System.Net;
using static Question.Domain.NewQuestionWorkflow.NewQuestionResult;

namespace Test.App
{
    class Program_question
    {
        static void Main(string[] args)
        {
            var cmd = new NewQuestionCmd("How can I remove a specific item from an array?", "I have an array of numbers and I'm using the .push() method to add elements to it.Is there a simple way to remove a specific element from an array?I'm looking for the equivalent of something like: array.remove(number); I have to use core JavaScript. Frameworks are not allowed.", "javascript, arrays");
           //exemplu verificare titlu null
            //var cmd = new NewQuestionCmd("", "I have an array of numbers and I'm using the .push() method to add elements to it.Is there a simple way to remove a specific element from an array?I'm looking for the equivalent of something like: array.remove(number); I have to use core JavaScript. Frameworks are not allowed.", "javascript, arrays");

            var result = PostNewQuestion(cmd);

            result.Match(
                    ProcessQuestionPosted,
                    ProcessQuestionNotPosted,
                    ProcessInvalidQuestion
                );

            Console.ReadLine();
        }

        private static PostNewQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static PostNewQuestionResult ProcessQuestionNotPosted(QuestionNotPosted questionNotCreatedResult)
        {
            Console.WriteLine($"The question was not posted: {questionNotCreatedResult.Reason}");
            return questionNotCreatedResult;
        }

        private static PostNewQuestionResult ProcessQuestionPosted(QuestionPosted questionPosted)
        {
            Console.WriteLine($"Question was posted!");
           //Console.WriteLine($"    -Question id:  {questionPosted.Id}");
            Console.WriteLine($"    -Question title:  {questionPosted.Title}");
            Console.WriteLine($"    -Question body:  {questionPosted.Body}");
            Console.WriteLine($"    -Question tags:  {questionPosted.Tags}");
            return questionPosted;
        }

        public static PostNewQuestionResult PostNewQuestion(NewQuestionCmd newQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(newQuestionCommand.Title))
            {
                //var errors = new List<string>() { "Title can not pe NULL!" };
                return new QuestionNotPosted("Title can not pe NULL!");
            }
            if (string.IsNullOrWhiteSpace(newQuestionCommand.Body))
            {
                var errors = new List<string>() { "Invalid Body! Body can not be NULL!" };
                return new QuestionValidationFailed(errors);
            }


            var questId = Guid.NewGuid();
            var result = new QuestionPosted(questId, newQuestionCommand.Title, newQuestionCommand.Body, newQuestionCommand.Tags);


            //execute logic
            return result;
        }
    }
}
