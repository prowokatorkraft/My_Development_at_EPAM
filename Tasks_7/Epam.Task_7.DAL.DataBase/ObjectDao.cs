using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Epam.Task_7.Common.Entities;
using Epam.Task_7.DAL.Interfaces;

namespace Epam.Task_7.DAL.DataBase
{
    public class ObjectDao : IDao
    {
        public IUsersDao Users { get; }

        public IAwardsDao Awards { get; }

        private string _connectionString;

        public ObjectDao(string connectionString = @"Data Source=DESKTOP-LIS1BGO;Initial Catalog=Task_7;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            _connectionString = connectionString;

            Users = new UsersDao(_connectionString, this);
            Awards = new AwardsDao(_connectionString, this);
        }

        public void AddDependUserAndAwards(Guid userId, Guid awardId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AccountAndAward_AddDependUserAndAwards", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@AwardId", awardId);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Guid> GetAllAwardedUserGuids(Guid awardId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AccountAndAward_GetAllAwardedUserGuids", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", awardId);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return (Guid)reader["AccountID"];
                }
            }
        }

        public IEnumerable<Guid> GetAllСustomAwardGuids(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AccountAndAward_GetAllСustomAwardGuids", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", userId);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return (Guid)reader["AwardID"];
                }
            }
        }

        public void RemoveDependUserAndAwards(Guid userId, Guid awardId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AccountAndAward_RemoveDependUserAndAwards", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@AwardId", awardId);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
