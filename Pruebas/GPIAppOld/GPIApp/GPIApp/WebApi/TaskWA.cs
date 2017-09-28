using GPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiConector;

namespace GPIApp.WebApi
{
    internal class RestTaskImplemented<T> : RestClient<T>
    {
        public RestTaskImplemented(string url) : base(url)
        {
        }
    }

    public class TaskWA
    {
        RestTaskImplemented<TaskAPP> client = new RestTaskImplemented<TaskAPP>(ConstantsWA.WebApiServer + "TaskWA/");

        public async Task<List<TaskAPP>> Get()
        {
            try
            {
                return await client.Get();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<TaskAPP> Get(int key)
        {
            try
            {
                return await client.Get("id", key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Post(TaskAPP value)
        {
            try
            {
                await client.Post(value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Put(int key, TaskAPP value)
        {
            try
            {
                await client.Put("key", key, value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Delete(int key)
        {
            try
            {
                await client.Delete("key", key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
