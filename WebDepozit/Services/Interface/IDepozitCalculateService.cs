using WebDepozit.Models;

namespace WebDepozit.Services.Interface
{
    public interface IDepozitCalculateService
    {
        public MounthlyDepozitReport[] CalculateDifficultProcent(double startDepozit, double mounthPlus, double yearProcent, int terminInMounth);
    }
}
