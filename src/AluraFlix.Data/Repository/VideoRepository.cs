using AluraFlix.Business.Interfaces;
using AluraFlix.Business.Models;
using AluraFlix.Data.Context;

namespace AluraFlix.Data.Repository
{
    public class VideoRepository:Repository<Video>,IVideoRepository
    {
        public VideoRepository(MeuDbContext contexto) :base(contexto)
        {
        }
    }
}