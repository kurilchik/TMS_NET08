using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Lesson12
{
    public class AbcManager
    {
        private readonly DbContext _context;

        public AbcManager(DbContext context)
        {
            _context = context;
        }

        public Guid AddA(A a)
        {
            EntityEntry<A> createdUser = _context.Set<A>().Add(a);
            _context.SaveChanges();

            return createdUser.Entity.Id;
        }
        public Guid AddB(B b)
        {
            EntityEntry<B> createdUser = _context.Set<B>().Add(b);
            _context.SaveChanges();

            return createdUser.Entity.Id;
        }
    }
}
