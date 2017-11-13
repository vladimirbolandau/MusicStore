using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    interface ICacheRepository
    {
        bool DoesFileForTodayExists(string path);

        void ClearCacheIn(string directory, string exceptFile);
    }
}
