﻿using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.Post;
using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Aniverse.API.Controllers
{
    [ApiController, Route("api/")]
    public class PostsController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public PostsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        [HttpGet("users/{username}/[controller]")] // api/users/revanzli/posts
        public async Task<IActionResult> GetAllByUser([FromRoute] string username, [FromQuery] PaginationQuery query)
          => Ok(await _unitOfWorkService.PostService.GetAllByUserAsync(username, query));
        [HttpGet("users/login/[controller]")] //api/users/login/posts
        public async Task<IActionResult> GetAllByLoginUser([FromQuery] PaginationQuery query)
            => Ok(await _unitOfWorkService.PostService.GetAllByLoginUserAsync(query));
        [HttpGet("[controller]/{id}/likes")] //api/posts/{postId}/likes
        public async Task<IActionResult> GetAllUserLikesPost([FromRoute] string id, [FromQuery] PaginationQuery query)
            => Ok(await _unitOfWorkService.PostService.GetAllUserLikesPostAsync(id, query));
        [HttpGet("[controller]/{id}/comments")] //api/posts/{postId}/comments
        public async Task<IActionResult> GetAllPostComments([FromRoute] string id, [FromQuery] PaginationQuery query)
            => Ok(await _unitOfWorkService.PostService.GetAllPostCommentsAsync(id, query));
        public async Task<IActionResult> GetAllByAnimal([FromRoute] string animalname, [FromQuery] PaginationQuery query)
            => Ok(await _unitOfWorkService.PostService.GetAllByAnimalAsync(animalname, query));
    }
}
