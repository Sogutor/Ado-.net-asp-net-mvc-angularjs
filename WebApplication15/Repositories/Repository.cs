using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApplication15.Models.Entities.Base;

namespace WebApplication15.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity, new()
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public IEnumerable<TEntity> GetAll()
        {
            using (var con = new SqlConnection(_connString))
            {
                var cmd = new SqlCommand($"GetAll{typeof(TEntity).Name}s", con) 
                    {CommandType = CommandType.StoredProcedure};

                var entities = new List<TEntity>();

                try
                {
                    con.Open();
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var entity = new TEntity();
                        foreach (var property in typeof(TEntity).GetProperties())
                        {
                            var value = rdr.GetValue(rdr.GetOrdinal(property.Name));
                            if (value is DBNull)
                                continue; 
                            property.SetValue(entity, value);
                        }
                        entities.Add(entity);
                    }
                    return entities;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }


            }
        }

        public TEntity Get(int id)
        {
            using (var con = new SqlConnection(_connString))
            {
                var entity = new TEntity();
                var cmd = new SqlCommand($"Get{typeof(TEntity).Name}", con) 
                    {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        foreach (var property in typeof(TEntity).GetProperties())
                        {
                            var value = rdr.GetValue(rdr.GetOrdinal(property.Name));
                            if (value is DBNull)
                                continue;
                            property.SetValue(entity, value);
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

                return entity;

            }

        }

        public bool Delete(int id)
        {
            using (var con = new SqlConnection(_connString))
            {
                var cmd = new SqlCommand($"Delete{typeof(TEntity).Name}", con) 
                    {CommandType = CommandType.StoredProcedure};
                try
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", id);
                    var result = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error while delete \n" + ex.Message);
                }

                return true;
            }
        }

        public bool Insert(TEntity entity)
        {
            using (var con = new SqlConnection(_connString))
            {
                var cmd = new SqlCommand($"Insert{typeof(TEntity).Name}", con) 
                    {CommandType = CommandType.StoredProcedure};

                foreach (var property in typeof(TEntity).GetProperties())
                {
                    cmd.Parameters.AddWithValue(property.Name, property.GetValue(entity));
                }

                try
                {
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception("Error while Insert \n" + e.Message);
                }

            }
        }

        public bool Update(TEntity entity)
        {
            using (var con = new SqlConnection(_connString))
            {
                var cmd = new SqlCommand($"Update{typeof(TEntity).Name}", con) 
                    {CommandType = CommandType.StoredProcedure};
                foreach (var property in typeof(TEntity).GetProperties())
                {
                    cmd.Parameters.AddWithValue(property.Name, property.GetValue(entity));
                }

                try
                {
                    con.Open();
                    var executeNonQuery = cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {

                    throw new Exception("Error while Update \n" + e.Message); ;
                }
            }
        }
    }
}