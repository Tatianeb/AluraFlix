using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AluraFlix.Business.Models;

namespace AluraFlix.Business.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity, new()
    {
        public Task<TEntity> ObterPorId(Guid id);
        public Task<List<TEntity>> ObterTodos();
        public Task Adicionar(TEntity entity);
        public Task Remover(Guid id);
        public Task Atualizar(TEntity entity);
        public Task<int> Salvar();
    }
}
