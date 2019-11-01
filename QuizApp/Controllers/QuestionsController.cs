using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {

        private readonly IQuestionService _questionService;

        // TODO: create a constructor and inject the question service
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        // TODO: anonymous users can still call this action
        [HttpGet()]
        public IActionResult GetAll()
        {
            // TODO: replace the following code with a complete implementation
            // that will return all questions
            // ModelState.AddModelError("GetQuestions", "Not Implemented!");
            // return BadRequest(ModelState);
            try
            {
                return Ok(_questionService.GetAll());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetQuestions", ex.Message);
                return BadRequest(ModelState);
            }


        }

        // TODO: anonymous users can still call this action
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // TODO: replace the following code with a complete implementation
            // that will return a single question based on id
            // ModelState.AddModelError("GetQuestion", "Not Implemented!");
            // return BadRequest(ModelState);
            try
            {
                var question = _questionService.Get(id);
                if (question == null) return NotFound();
                return Ok(question);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Get Question", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // TODO: only authenticated users can call this action
        [HttpPost]
        public IActionResult Add([FromBody] QuestionModel question)
        {
            // TODO: replace the following code with a complete implementation
            // that will add a new question 
            try
            {
                return Ok(_questionService.Add(question.ToDomainModel()));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("AddQuestion", ex.Message);
                return NotFound(ModelState);
            }
        }

        // TODO: only authenticated users can call this action
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] QuestionModel questionModel)
        {
            // TODO: replace the following code with a complete implementation
            // that will update a question
            ModelState.AddModelError("UpdateQuestion", "Not Implemented!");
            return BadRequest(ModelState);
        }

        // TODO: only authenticated users can call this action
        [HttpDelete]
        public IActionResult Remove()
        {
            // TODO: replace the following code with a complete implementation
            // that will delete a question
            ModelState.AddModelError("RemoveQuestion", "Not Implemented!");
            return BadRequest(ModelState);
        }
    }
}
