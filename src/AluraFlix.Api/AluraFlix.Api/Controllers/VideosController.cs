using AluraFlix.Api.ViewModels;
using AluraFlix.Business.Interfaces;
using AluraFlix.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraFlix.Api.Controllers
{
    [Route("videos")]
    public class VideosController:MainController
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;


        public VideosController(IVideoRepository videoRepository, IMapper mapper, IVideoService videoService)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
            _videoService = videoService;
        }

        [HttpGet]
        public async Task<IEnumerable<VideoViewModel>> ObterTodos()
        {
            var video = _mapper.Map<IEnumerable<VideoViewModel>>(await _videoRepository.ObterTodos());
            return video;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VideoViewModel>> ObterPorId(Guid id)
        {
            var video = await ObterVideoPorId(id);
            if (video == null)
                return NotFound();

            return video;
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<VideoViewModel>> Atualizar(Guid id, VideoViewModel videoViewModel)
        {
            if (id != videoViewModel.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            var video = _mapper.Map<Video>(videoViewModel);
            var result = _videoService.Atualizar(id, video);
            if (!await result) return BadRequest();

            return Ok(video);
        }

        [HttpPost]
        public async Task<ActionResult<VideoViewModel>> Adicionar(VideoViewModel videoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var video = _mapper.Map<Video>(videoViewModel);
            var result =  _videoService.Adicionar(video);

            if (!await result) return BadRequest();

            return Ok(video);
        }

        public async Task<VideoViewModel> ObterVideoPorId(Guid id)
        {
            var video = _mapper.Map<VideoViewModel>(await _videoRepository.ObterPorId(id));
            return video;
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VideoViewModel>> Excluir(Guid id)
        {
            var video = await _videoRepository.ObterPorId(id);
            if (video == null) return NotFound();

            var result = _videoService.Remover(id);

            if (!await result) return BadRequest();

            return Ok(video);
        }
    }
}
