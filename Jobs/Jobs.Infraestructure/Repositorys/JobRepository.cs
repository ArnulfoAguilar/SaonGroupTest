using Jobs.Domain.Entities;
using Jobs.Domain.Responses;
using Jobs.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Net;

namespace Jobs.Infraestructure.Repositorys
{
    // In this class is the communication with an Api or access to Database
    public class JobRepository : IJobRepository
    {
        public SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();
        public JobRepository()
        {
            connectionStringBuilder.DataSource = "../../DBJobs.db";
        }
        public ResponseStatus JobAdd(Job job)
        {

            try
            {
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        var insert = connection.CreateCommand();
                        insert.CommandText = @"Insert into Jobs(JobTitle,JobDescription,CreatedAt,ExpiresAt) 
                                            VALUES('"+job.JobTitle+"','"+job.JobDescription+"','" +job.CreatedAt+"','"+job.ExpiresAt+"')";
                        insert.ExecuteNonQuery();
                        transaction.Commit();
                        connection.Close();
                    }
                }
                    ResponseStatus response = new ResponseStatus
                    {
                        Code = HttpStatusCode.OK.ToString(),
                        Description = "Job is saved"
                    };
                return response;
            }
            catch (Exception ex)
            {
                ResponseStatus response = new ResponseStatus
                {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Description = "An error has occurred when y tried to save a Job"
                };
                return response;
            }
        }

        public ResponseStatus JobDelete(int JobID)
        {
            try
            {
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        var insert = connection.CreateCommand();
                        insert.CommandText = @"DELETE FROM JOBS WHERE JobID=" + JobID;
                        insert.ExecuteNonQuery();
                        transaction.Commit();
                        connection.Close();
                    }
                }
                ResponseStatus response = new ResponseStatus
                {
                    Code = HttpStatusCode.OK.ToString(),
                    Description = "Job is deleted"
                };
                return response;
            }
            catch (Exception ex)
            {
                ResponseStatus response = new ResponseStatus
                {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Description = "An error has occurred when y tried to delete a Job"
                };
                return response;
            }
        }

        public ResponseStatus JobEdit(Job job)
        {
            try
            {
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        var insert = connection.CreateCommand();
                        insert.CommandText = @"UPDATE JOBS SET JobTitle='" + job.JobTitle + "',JobDescription='" + job.JobDescription +
                            "',CreatedAt='" + job.CreatedAt + "',ExpiresAt='" + job.ExpiresAt + "' WHERE JobID=" + job.JobID;
                        insert.ExecuteNonQuery();
                        transaction.Commit();
                        connection.Close();
                    }
                }
                ResponseStatus response = new ResponseStatus
                {
                    Code = HttpStatusCode.OK.ToString(),
                    Description = "Job is updated"
                };
                return response;
            }
            catch (Exception ex)
            {
                ResponseStatus response = new ResponseStatus
                {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Description = "An error has occurred when y tried to update a Job"
                };
                return response;
            }
        }

        public Job JobEditGet(int job)
        {
            Job JobEdit = new Job();
            try
            {
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    var JobsList = connection.CreateCommand();
                    JobsList.CommandText = "SELECT * FROM JOBS Where JobID ="+job;
                    using (var reader = JobsList.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JobEdit.JobID = reader.GetInt32(0);
                            JobEdit.JobTitle = reader.GetString(1);
                            JobEdit.JobDescription = reader.GetString(2);
                            JobEdit.CreatedAt = reader.GetString(3);
                            JobEdit.ExpiresAt = reader.GetString(4);
                        }
                        connection.Close();
                       
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return JobEdit;
        }

        public JobResponse JobsList()
        {
            JobResponse response = new JobResponse();
            List<Job> JobList = new List<Job>();
            
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
                            job.CreatedAt = reader.GetString(3);
                            job.ExpiresAt = reader.GetString(4);
                            JobList.Add(job);
                        }
                        connection.Close();
                        response.AllJobs = JobList;
                        response.responseStatus = new ResponseStatus { Code = "200", Description = "OK" };
                    }
                    connection.Close();
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
