using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUExamen.Transactions
{
    public class LibroBLL
    {
        public static void Create(Libro l)
        {
            //Empezamos la transaccion
            //Siempre que yo CREAR, ACTUALIZA, ELIMINAR debo utilizar una transaccion
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libroes.Add(l);
                        db.SaveChanges();
                        transaction.Commit();//Comprometer cambios
                    }
                    catch (Exception ex)
                    {
                        //Rollback -> para evitar datos inconsistentes
                        transaction.Rollback();//Todo se elimina
                        throw ex;
                    }
                }
            }
        }

        //Para que el alumno este dentro del mismo contexto se hace lo siguiente: (PARA UPDATE)
        //GET-CONSULTAR
        public static Libro Get(int? id)
        {
            Entities db = new Entities();
            return db.Libroes.Find(id);
        }

        public static void Update(Libro Libro)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libroes.Attach(Libro);
                        db.Entry(Libro).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Libro Libro = db.Libroes.Find(id);
                        db.Entry(Libro).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Libro> List()
        {
            Entities db = new Entities(); //Instancia del contexto

            return db.Libroes.ToList();
        }

        public static List<Libro> ListToNames()
        {
            Entities db = new Entities();
            List<Libro> result = new List<Libro>();
            db.Libroes.ToList().ForEach(x =>
                result.Add(
                    new Libro
                    {
                        titulo = x.titulo + " " + x.autores,
                        id_libros = x.id_libros
                    }));
            return result;
        }
        
    }
}
