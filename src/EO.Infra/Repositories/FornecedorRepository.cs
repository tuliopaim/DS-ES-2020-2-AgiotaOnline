﻿using EO.Application.Interfaces;
using EO.Domain.Entities;
using EO.Infra.Repositories.Base;

namespace EO.Infra.Repositories
{
    public class TomadorRepository : GenericRepository<Tomador>, ITomadorRepository
    {
        private readonly ApplicationContext _context;

        public TomadorRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}