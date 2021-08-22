using System;
using System.Threading.Tasks;
using AluraFlix.Business.Models;

namespace AluraFlix.Business.Interfaces
{
    public interface IVideoService
    {
        public Task<bool> Adicionar(Video video);
        public Task<bool> Atualizar(Guid id,Video video);
        public Task<bool> Remover(Guid id);
    }
}