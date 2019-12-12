using System;
using Xunit;
using SampleBlog.MVC.Controllers;
using SampleBlog.MVC.Repository;
using SampleBlog.MVC.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace SampleBlog.Test
{
    public class PostControllerTest
    {
        private IPostRepository _repository;  
        
        public PostControllerTest(){
            _repository = new PostRepository();
        }

        [Fact]
        public void Test_Index_View_Result()
        {
            //Arrange
            var controller = new HomeController(this._repository);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Test_Index_Return_Result()
        {
            //Arrange
            var controller = new HomeController(this._repository);
            //Act
            var result = controller.Index();
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Index_GetPosts_MatchData()
        {
            //Arrange
            var controller = new HomeController(this._repository);
            //Act
            var result = controller.Index();
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model =
            Assert.IsAssignableFrom<List<PostViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count);
            Assert.Equal(101, model[0].PostId);
            Assert.Equal("DevOps Demo Title 1", model[0].Title);
        }
    }
}
