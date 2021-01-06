using Jobs.Domain.Entities;
using Jobs.Domain.Responses;
using Jobs.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Jobs.Infraestructure.Repositorys
{
    // In this class is the communication with an Api or access to Database
    public class JobRepository : IJobRepository
    {
        public ResponseStatus JobAdd(Job job)
        {
            throw new NotImplementedException();
        }

        public ResponseStatus JobDelete(int JobID)
        {
            throw new NotImplementedException();
        }

        public ResponseStatus JobEdit(Job job)
        {
            throw new NotImplementedException();
        }

        public JobResponse JobsList()
        {
            JobResponse response = new JobResponse();
            
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "../../DBJobs.db";
            try
            {
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    var JobsList = connection.CreateCommand();
                    JobsList.CommandText = "SELECT * FROM JOBS";
                    using (var reader = JobsList.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            Job job = new Job();
                            job.JobID = reader.GetInt32(0);
                            job.JobTitle = reader.GetString(1);
                            job.JobDescription = reader.GetString(2);
                            job.CreatedAt = Convert.ToDateTime(reader.GetString(3));
                            job.ExpiresAt = Convert.ToDateTime(reader.GetString(4));
                            response.AllJobs.Add(job);
                        }
                        connection.Close();
                        response.responseStatus = new ResponseStatus { Code = "200", Description = "OK" };
                    }
                }
            }
            catch (Exception ex)
            {
                response.responseStatus = new ResponseStatus { Code = "500", Description = "ServerError" };
            }

            return response;
        }
    }
}
