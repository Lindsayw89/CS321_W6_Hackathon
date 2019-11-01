using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    public class QuizzesController : Controller
    {

        private readonly IQuizService _quizService;

        //inject quiz service
        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet()]
        public IActionResult GetQuizzes()
        {
            // that will return quizzes from the database
            try
            {
                return Ok(_quizService.GetAll().ToApiModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetQuiz", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetQuiz(int id)
        {
            // : replace the following code with a complete implementation
            try
            {
                return Ok(_quizService.Get(id).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateBlog", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // OPTIONAL - PUSH YOURSELF FURTHER
        // Implement a controller action that will return
        // a quiz containing five randomly selected questions.
    }
}
