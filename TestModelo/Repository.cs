using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelo
{
    public class Repository: EFRepository.Repository, IDisposable, IRepository
    {
        public Repository( 
            bool autoDetectChangesEnabled = false,
            bool proxyCreationEnabled = false): base(new soapros_desaEntities(), autoDetectChangesEnabled, proxyCreationEnabled)
        {

        }
    }
}
