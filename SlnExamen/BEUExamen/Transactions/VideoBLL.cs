using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUExamen.Transactions
{
    public class VideoBLL
    {
        public static void Create(Video v)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Videos.Add(v);
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

        public static Video Get(int? id)
        {
            Entities db = new Entities();
            return db.Videos.Find(id);
        }

        public static void Update(Video Video)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Videos.Attach(Video);
                        db.Entry(Video).State = System.Data.Entity.EntityState.Modified;
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
                        Video Video = db.Videos.Find(id);
                        db.Entry(Video).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Video> List()
        {
            Entities db = new Entities();
            return db.Videos.ToList();
        }

        public static List<Video> ListToNames()
        {
            Entities db = new Entities();
            List<Video> result = new List<Video>();
            db.Videos.ToList().ForEach(x =>
                result.Add(
                    new Video
                    {
                        titulo_video = x.titulo_video + "-" + x.titulo_video,
                        id_video = x.id_video
                    }));
            return result;
        }

    }
}

