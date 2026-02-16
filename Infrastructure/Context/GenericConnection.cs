using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context {
    public class GenericConnection<T> : IGenericConnection<T> where T : IConnection {
        private readonly T _implementation;
        public GenericConnection(T implementation) {
            _implementation = implementation;
        }

        public IDbConnection GetConnection() {
            return _implementation.GetConnection();
        }
    }
}
