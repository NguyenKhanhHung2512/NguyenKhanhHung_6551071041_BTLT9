using System.ComponentModel.DataAnnotations.Schema;

namespace Bai1.Models
{
    public partial class ChiTieu
    {
        [NotMapped]
        public int MaCT
        {
            get => MaCt;
            set => MaCt = value;
        }
    }
}
