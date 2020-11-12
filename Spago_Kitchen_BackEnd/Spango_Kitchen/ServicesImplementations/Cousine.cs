﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spango_Kitchen.Model;
using Spango_Kitchen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spango_Kitchen.ServicesImplementations
{
    public class Cousine :ICousine
    {
        private readonly Spango_Context _context;

        public Cousine(Spango_Context context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Model.Cousine>>> GetCousine()
        {
            return await _context.Cousine.ToListAsync();
        }
        public async Task<ActionResult<Model.Cousine>> GetCousine(int id)
        {
            var cousine = await _context.Cousine.FindAsync(id);

            if (cousine == null)
            {
                return null;
            }

            return cousine;
        }
        public async Task<ActionResult<Model.Cousine>> PostCousine(Model.Cousine cousine)
        {
            _context.Cousine.Add(cousine);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<IActionResult> PutCousine(int id, Model.Cousine cousine)
        {
            if (id != cousine.Id)
            {
                return null;
            }

            _context.Entry(cousine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CousineExists(id))
                {
                    return null;

                }
                else
                {
                    throw;
                }
            }

            return null;
        }

        public async Task<ActionResult<Model.Cousine>> DeleteCousine(int id)
        {
            var cousine = await _context.Cousine.FindAsync(id);
            if (cousine == null)
            {
                return null;
            }

            _context.Cousine.Remove(cousine);
            await _context.SaveChangesAsync();

            return cousine;
        }

        private bool CousineExists(int id)
        {
            return _context.Cousine.Any(e => e.Id == id);
        }
    }
}