using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Epam.Task_7.Common.Entities;
using Epam.Task_7.DAL.Interfaces;

namespace Epam.Task_7.DAL.DataBase
{
    public class AwardsDao : IAwardsDao
    {
        private readonly IDao _objectDao;

        private string _connectionString;

        public AwardsDao(string connectionString, IDao dao)
        {
            _connectionString = connectionString;
            _objectDao = dao;
        }

        public Guid AddAward(Award award)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Award_AddAward", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", award.Id);
                command.Parameters.AddWithValue("@Title", award.Title);

                connection.Open();

                command.ExecuteNonQuery();

                return award.Id;
            }
        }

        public bool ChangeAward(Award newAward)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Awards_ChangeAward", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", newAward.Id);
                command.Parameters.AddWithValue("@Title", newAward.Title);

                connection.Open();

                command.ExecuteNonQuery();

                //foreach (var item in newAward.OwnerList)
                //{
                //    _objectDao.AddDependUserAndAwards(newAward.Id, item);
                //}

                return true;
            }
        }

        public IEnumerable<Award> GetAllAward()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("Award_GetAllAwards", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                connection.Open();

                var reader = command.ExecuteReader();

                Award award;

                while (reader.Read())
                {
                    award = new Award((Guid)reader["Id"], reader["Title"] as string);

                    foreach (var item in _objectDao.GetAllAwardedUserGuids(award.Id))
                    {
                        award.OwnerList.Add(item);
                    }

                    yield return award;
                }
            }
        }

        public Award GetAward(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("Award_GetAward", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                var reader = command.ExecuteReader();

                reader.Read();

                return new Award((Guid)reader["Id"], reader["Title"] as string);
            }
        }

        public bool IsAward(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("Award_GetAward", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }

                return false;
            }
        }

        public bool RemoveAward(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Award_RemoveAward", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
        }
    }
}
