﻿using System.Linq;
using System.Threading.Tasks;
using EO.Domain.Entities;
using EO.Domain.Interfaces;
using EO.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EO.Infra.Repositories
{
    public class TomadorRepository : GenericRepository<Tomador>, ITomadorRepository
    {
        private readonly ApplicationContext _context;

        public TomadorRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tomador> ObterPorUsuarioIdComEndereco(int id, bool track = false)
        {
            return await BuildQuery(x => x.UsuarioId == id, track: track)
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync();
        }

        public async Task<Tomador> ObterPorIdCompleto(int id, bool track = false)
        {
            return await BuildQuery(x => x.Id == id, track: track)
                .Include(x => x.Endereco)
                .Include(x => x.Solicitacoes)
                .FirstOrDefaultAsync();
        }

        public async Task<Tomador> ObterPorIdComEndereco(int id, bool track = false)
        {
            return await BuildQuery(x => x.Id == id, track: track)
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync();
        }

        public async Task<int> ObterIdPorUsuarioId(int usuarioId)
        {
            return await _context.Tomadores
                .AsNoTracking()
                .Where(x => x.UsuarioId == usuarioId)
                .Select(x => x.Id).FirstOrDefaultAsync();
        }
    }
}