using e_Clinic.DataAccess;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Repository.IRepository;
using e_Clinic.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;


namespace e_Clinic.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            if (tracked)
            {
                IQueryable<T> query = dbSet;

                query = query.Where(filter);
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault()!;
            } else
            {
                IQueryable<T> query = dbSet.AsNoTracking();

                query = query.Where(filter);
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault()!;
            }
        }

        public async Task<IEnumerable<T>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50, Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        
        public async Task<int> GetPageCount(int pageSize)
        {
            var count = await dbSet.CountAsync();
            return (int) Math.Ceiling(count / (double)pageSize);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public async Task<bool> CreateUserWithIdentityAsync<U>(U user, string password) where U : BaseUser
        {
            var newUser = new ApplicationUser
            {
                Email = user.Email,
                UserName = user.Email,
            };

            string role = ""; 

            if (user is Patient patientUser)
            {
                newUser.Patient = patientUser;
                role = ClinicConstants.ROLE_PATIENT;
            }

            if (user is Doctor doctor)
            {
                newUser.Doctor = doctor;
                role = ClinicConstants.ROLE_DOCTOR;
            }

            if (user is StaffMember staffMember)
            {
                newUser.StaffMember = staffMember;
                role = ClinicConstants.ROLE_STAFF;
            }

            if (password is not null)
            {
                try
                {
                    var result = await _userManager.CreateAsync(newUser, password);
                    var userForRole = _db.ApplicationUsers.FirstOrDefault(u => u.Email == newUser.Email)!;
                    if (user != null)
                    {
                        _userManager.AddToRoleAsync(userForRole!, role).GetAwaiter().GetResult();
                    }
                    _db.SaveChanges();
                    return result.Succeeded;

                } catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
            return false;
        }

        public async Task<bool> RemoveUserWithIdentityAsync<U>(U user) where U : BaseUser
        {
            var identityUserFromDb = await _userManager.FindByIdAsync(user.ApplicationUserId);
            var result = await _userManager.DeleteAsync(identityUserFromDb);
            return result.Succeeded;
        }
    }
}
 