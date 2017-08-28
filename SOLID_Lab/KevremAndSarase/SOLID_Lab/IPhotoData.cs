using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Lab
{
    interface IPhotoData
    {
        void SavePhotoData(string firstName, string lastName);
        void RetrievePhotoData(string photoId);

    }
}
