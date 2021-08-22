using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AluraFlix.Business.Models;
using AluraFlix.Business.Interfaces;
using AluraFlix.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AluraFlix.Data.Repository
{
    public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity:Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id) => await DbSet.FindAsync(id);

        public virtual async Task<List<TEntity>> ObterTodos() => await DbSet.ToListAsync();
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await Salvar();
        }
        public virtual async Task Remover(Guid id)
        {
            var entity = new TEntity {Id = id};
            DbSet.Attach(entity);
            DbSet.Remove(entity);

            await Salvar();
        }
        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await Salvar();
        }
        public async Task<int> Salvar() => await Db.SaveChangesAsync();

    }

}
