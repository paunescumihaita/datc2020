using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Question.Domain.NewQuestionWorkflow
{
    public struct NewQuestionCmd
    {
        [Required]                                      //denumirile sunt aceleasi cu cele de pe site si in aceeasi ordine: title, body, tags
        public string Title { get; private set; }           //titlul intrebarii care se vrea a fi pusa
        [Required]
        public string Body { get; private set; }            //descrierea succinta dar clara a intrebarii, portiuni de cod, erori, metode incercate
        public string Tags { get; set; }                     //tag urile (minimum 1, maximum 5 tag- uri per intrebare)
        public NewQuestionCmd(string title, string body, string tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }
    }
}
