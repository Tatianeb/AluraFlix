using System;
using System.Threading.Tasks;
using AluraFlix.Business.Interfaces;
using AluraFlix.Business.Models;
using AluraFlix.Business.Models.Validations;

namespace AluraFlix.Business.Services
{
    public class VideoService:BaseService, IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository, INotificador notificador): base(notificador)
        {
            _videoRepository = videoRepository;
        }

        public async Task<bool> Adicionar(Video video)
        {
            if (!ExecutarValidacao(new VideoValidation(), video)) return false;

            await _videoRepository.Adicionar(video);
            return true;
        }

        public async Task<bool> Atualizar(Guid id, Video video)
        {
            if (!ExecutarValidacao(new VideoValidation(), video)) return false;

            await _videoRepository.Atualizar(video);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _videoRepository.Remover(id);
            return true;
        }
    }
}