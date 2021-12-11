
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utils.Cache;

namespace Account.Application.CacheSession
{
    public class ACacheSession : ICacheSession
    {
        private readonly static MemoryCache myCache = new MemoryCache(new MemoryCacheOptions());
        private ICacheBase _cache => new CacheMemoryHelper(myCache);

        private readonly string KEY_SESION;

        public ACacheSession()
        {
            KEY_SESION = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build().GetValue<string>("key_cached:session");
        }

        public List<SessionCustom> GetAllSession()
        {
            var session_custom = _cache.Get<string>(KEY_SESION);
            if (session_custom == null)
            {
                return null;
            }

            var sessions = JsonConvert.DeserializeObject<List<SessionCustom>>(session_custom);
            foreach (var item in sessions)
            {
                if (item.ExpiryDate < DateTime.Now)
                {
                    sessions.Remove(item);
                }
            }

            SetAllSession(sessions);

            return sessions;
        }

        public SessionCustom GetUniqueSession(string account_user)
        {
            var sesions = GetAllSession();
            if (sesions == null) return null;
            return sesions.FirstOrDefault(m => m.Account_User == account_user);
        }

        public void RemoveAllSession()
        {
            _cache.Remove(KEY_SESION);
        }

        public void RemoveUniqueSesion(string id_session)
        {
            var sessions = GetAllSession();
            var item = sessions.SingleOrDefault(m => m.Id_Session == id_session);
            if (item != null)
            {
                sessions.Remove(item);
                SetAllSession(sessions);
            }
        }

        public List<string> ResertAllSession()
        {
            List<string> id_sesions = new List<string>();
            var sessions = GetAllSession();

            foreach (var item in sessions)
            {
                item.Id_Session = Guid.NewGuid().ToString();
                item.ExpiryDate = DateTime.Now.AddHours(5);
                id_sesions.Add(item.Id_Session);
            }
            SetAllSession(sessions);
            return id_sesions;
        }

        public string ResertUniqueSession(string id_session)
        {
            var sessions = GetAllSession();
            var item = sessions.SingleOrDefault(m => m.Id_Session == id_session);
            if (item != null)
            {
                sessions.Remove(item);
                item.Id_Session = Guid.NewGuid().ToString();
                item.ExpiryDate = DateTime.Now.AddHours(5);
                sessions.Add(item);
                SetAllSession(sessions);
            }
            return item.Id_Session;
        }

        public void SetAllSession(List<SessionCustom> sessions)
        {
            if (sessions.Count() != 0)
            {
                _cache.Add(JsonConvert.SerializeObject(sessions), KEY_SESION);
            }
        }

        public void SetUniqueSession(SessionCustom session)
        {
            var sessions = GetAllSession();
            if(sessions!= null && sessions.Any(m=>m.Id_User==session.Id_User))
            {
                sessions.Remove(sessions.Single(m => m.Id_User == session.Id_User));
            }

            if(sessions==null)
            {
                sessions = new List<SessionCustom>();
            }

            sessions.Add(session);
            SetAllSession(sessions);
        }
    }
}
