using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoGreen
{
    public enum CarTypeEnum
    {
        electric = 1,
        hybrid,
        gas,
    }
    public class KomodoGreen
    {
        public int ModelId { get; set; }
        public CarTypeEnum CarType { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public KomodoGreen()
        {

        }
        public KomodoGreen(CarTypeEnum carType, string name, string details)
        {
            CarType = carType;
            Name = name;
            Details = details;
        }
    }
}
