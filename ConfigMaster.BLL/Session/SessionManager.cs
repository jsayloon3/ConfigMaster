using System.Collections.Concurrent;

namespace ConfigMaster.BLL.Session
{
    public class SessionManager
    {
        private readonly ConcurrentDictionary<string, IUserSession> _sessions;
        private string _currentUser = string.Empty;

        public SessionManager()
        {
            _sessions = new ConcurrentDictionary<string, IUserSession>();
        }

        public IUserSession CreateSession(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(userName));
            }

            var userSession = new UserSession(userName);
            _sessions[userName] = userSession;
            _currentUser = userName;
            return userSession;
        }

        public IUserSession GetSession()
        {
            if (string.IsNullOrEmpty(_currentUser) || !_sessions.ContainsKey(_currentUser))
            {
                throw new InvalidOperationException("No active session found.");
            }

            return _sessions[_currentUser];
        }

        public void RemoveSession(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(userName));
            }

            _sessions.TryRemove(userName, out _);
            if (_currentUser == userName)
            {
                _currentUser = string.Empty;
            }
        }

        public bool SessionExists(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(userName));
            }

            return _sessions.ContainsKey(userName);
        }
    }
}
